## SOLID Refactor — Order Screen

The original `Form1.cs` did everything: summed the grid, decided discount rates, opened a
`SqlConnection`, built an e-mail, and popped a message box. Below is what each principle
actually fixed here.

## S — Single Responsibility
Form1 had at least five reasons to change (layout, pricing, discount rates, storage, messaging).
Each one moved into its own class: `OrderTotalCalculator` (money), `SqlOrderRepository` (storage),
`EmailInvoiceSender` (SMTP), `PlainTextInvoiceFormatter` (invoice wording),
`MessageBoxInvoicePresenter` (preview). Changing the invoice wording no longer risks breaking the
Save button, and the total can now be calculated without a form existing at all.

## O — Open/Closed
The discount logic was an `if/else if` chain that had to be edited for every new promo. It is now
`IDiscountStrategy` plus one small class per rule (`StudentDiscount`, `SeniorDiscount`,
`BlackFridayDiscount`). Adding "Christmas 20% off" means adding one file and one line in
`Composition.Default()` `OrderTotalCalculator` and `Form1` are never touched or re-tested.

## L — Liskov Substitution
See the question below. The rule shaped the design: `IDiscountStrategy.Apply` promises "give me a
valid total, get a valid total back", and every implementation honours it. Free shipping does not,
so it lives behind `IShippingAdjustment` (`Domain/Shipping/FreeShipping.cs`) instead.

## I — Interface Segregation
Instead of one fat `IOrderService` with Save + Email + Print, the capabilities are split:
`IOrderWriter`, `IOrderReader`, `IInvoiceSender`, `IInvoicePresenter`. `FakeOrderRepository` only
has to implement what it really supports, and no class is forced to write an empty or throwing
method which is exactly how LSP violations get created in the first place.

## D — Dependency Inversion
`Form1` no longer news up `SqlConnection` or `SmtpClient`. It receives interfaces through its
constructor (`OrderScreenDependencies`) and `Composition` is the single place that names concrete
classes. That is what makes `Composition.Offline(new FakeOrderRepository())` possible: the same
screen, no database, no mail server.

---

## Submission item 3

**Why does `FreeShippingDiscount` break the substitutability promise of `IDiscountStrategy`?**

Because it "is-a" `IDiscountStrategy` only in the compiler's eyes, not in behaviour.
`IDiscountStrategy` promises that `Apply(total)` accepts any valid total and returns a valid total.
`OrderTotalCalculator` is written against that promise and calls `Apply` the same way for every
strategy. `FreeShippingDiscount` strengthens the precondition to "never call me with an order
total" and replaces the return value with a `NotSupportedException`, so code that was correct for
`StudentDiscount` becomes broken the moment this object is substituted in. The crash happens at
runtime, in the calculator, far from the class that caused it.

**What does LSP say about subtypes that can't be swapped in safely?**

That they are not subtypes of that abstraction at all, and the fix belongs in the hierarchy rather
than in the caller. A subtype must be usable anywhere the base type is expected without the caller
knowing which one it got: it may not strengthen preconditions, weaken postconditions, or throw
exceptions the contract does not allow. Needing `if (x is FreeShippingDiscount)` guards around the
calculator is the symptom the real cause is that a shipping rule was forced into an order-total
interface. Free shipping modifies a shipping fee, so it implements `IShippingAdjustment`, where it
can keep its contract for every input.

## Submission item 4

`Persistence/FakeOrderRepository.cs` stores orders in a `List<Order>` and exposes `SavedOrders`.
**Why it's useful for testing:** it satisfies the same `IOrderWriter`/`IOrderReader` contracts
entirely in memory, so saving behaviour can be asserted instantly and repeatably with no SQL Server,
no connection string, and no leftover rows in a real database (and its `FailWith` property lets a
test force a failure to check the error handling).


