using System;
using System.Windows.Forms;
using SistemaReservasSalas.Formularios;

namespace SistemaReservasSalas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration_Initialize();
            Application.Run(new FormLogin());
        }

        // Equivalente manual a ApplicationConfiguration.Initialize() de las plantillas nuevas,
        // escrito explícitamente para no depender de código autogenerado.
        private static void ApplicationConfiguration_Initialize()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
