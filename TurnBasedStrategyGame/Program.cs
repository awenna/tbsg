using System;
using System.Windows.Forms;

namespace TurnBasedStrategyGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configProvider = new ConfigurationProvider();

            var algorithms = new Algorithms();
            var renderer = new Renderer(algorithms);
            var camera = new Camera(algorithms, configProvider);

            var gameWindowForm = new GameWindowForm(renderer, camera);

            Application.Run(gameWindowForm);
        }
    }
}
