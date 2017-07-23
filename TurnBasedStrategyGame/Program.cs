using System;
using System.Windows.Forms;
using TBSG.Data;
using TBSG.Model;
using TBSG.View;

namespace TBSG
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

            var mapGenerator = new MapGenerator();
            var mapSize = new Coordinate(
                configProvider.GetValue<int>("MapSizeXDefault"),
                configProvider.GetValue<int>("MapSizeYDefault"));
            var map = new Map(mapGenerator, mapSize);

            var gameController = new GameController(map, null);
            gameController.SetManualTestingMap();

            var renderer = new Renderer(algorithms, map);
            var camera = new Camera(algorithms, configProvider);

            var gameWindowForm = new GameWindowForm(renderer, camera, configProvider);

            Application.Run(gameWindowForm);
        }
    }
}
