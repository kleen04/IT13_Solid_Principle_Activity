using SolidRefactor.UI;

namespace SolidRefactor;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1(Composition.Default()));
    }
}
