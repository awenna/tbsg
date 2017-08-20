using System;
using System.Windows.Forms;
using TBSG.Data;
using TBSG.Model;
using TBSG.View;
using TBSG.View.Forms;
using TBSG.Control;

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

            var effectApplier = new EffectApplier(map);
            var commandResolver = new CommandResolver(map, effectApplier);

            var gameController = new GameController(map, commandResolver);
            gameController.SetManualTestingMap();

            var renderer = new Renderer(algorithms, map, configProvider);
            var cameraController = new CameraController(algorithms, configProvider);

            var fieldPanelController = new FieldPanelController(algorithms, gameController, map);

            var gameWindowForm = new GameWindowForm(algorithms, renderer, cameraController, fieldPanelController, configProvider);

            Application.Run(gameWindowForm);
        }
    }
}
