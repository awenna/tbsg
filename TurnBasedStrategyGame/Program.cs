using System;
using System.Windows.Forms;
using TBSG.Model;
using TBSG.View;
using TBSG.View.Drawing;
using TBSG.View.Forms;
using TBSG.Control;
using TBSG.Data.Hexmap;
using TBSG.Model.Hexmap;

namespace TBSG
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configProvider = new ConfigurationProvider();

            var algorithms = new Algorithms();

            var mapGenerator = new MapGenerator();
            var mapFunctions = new MapFunctions(algorithms);
            var mapSize = new Coordinate(
                configProvider.GetValue<int>("MapSizeXDefault"),
                configProvider.GetValue<int>("MapSizeYDefault"));

            var tileArray = mapGenerator.GenerateMap(mapSize);
            var map = new Map(tileArray, new TileOccupants(), mapFunctions);

            var entityHandler = new EntityHandler();
            var effectApplier = new EffectApplier();
            var commandResolver = new CommandResolver(effectApplier, entityHandler);

            var turnEngine = new TurnEngine(commandResolver);

            var gameController = new GameController(map, commandResolver, turnEngine);
            gameController.SetManualTestingMap();

            var gridDrawer = new GridDrawer();

            var renderer = new Renderer(algorithms, gridDrawer, configProvider);
            var cameraController = new CameraController(algorithms, configProvider);

            var viewController = 
                new ViewController(
                    algorithms,
                    cameraController,
                    gameController,
                    renderer);

            var gameWindowForm = 
                new GameWindowForm(
                    renderer, 
                    cameraController,
                    viewController,
                    configProvider);

            gameWindowForm.Initialize();

            Application.Run(gameWindowForm);
        }
    }
}
