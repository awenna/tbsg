using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TBSG.Control;
using TBSG.Data;
using TBSG.Model;

namespace TBSG.View.Forms
{
    public partial class GameWindowForm : Form
    {
        private readonly IRenderer mRenderer;
        private readonly ICameraController mCameraController;

        public ViewState viewState { get; private set; }

        private GameState gameState { get; set; }

        public GameWindowForm(
            IAlgorithms algorithms,
            IGameController gameController,
            IMap map,
            IRenderer renderer,
            ICameraController cameraController,
            IConfigurationProvider configProvider)
        {
            mRenderer = renderer;
            mCameraController = cameraController;

            InitializeComponent();

            viewState = new ViewState {
                Camera = mCameraController.GetCamera(),
                Selection = new Selection()
            };
            var fieldSize = FieldPanel.Size;
            mCameraController.SetViewSize(XY.Screen(fieldSize.Width, fieldSize.Height));

            var fieldPanelController = 
                new FieldPanelController(
                    FieldPanel, 
                    this, 
                    algorithms,
                    cameraController,
                    mRenderer,
                    gameController, 
                    map);
        }

        public void Initialize()
        {
            InitializeGameWindow();
            //mFieldpanel.Initialize();

            InitializeInfoPanel();
            InitializeSidePanel();
            InitializeMinimap();

            SuspendLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            FieldPanel.Invalidate();
            InfoPanel.Invalidate();
            SidePanel.Invalidate();
        }

        public void info_Paint(object sender, PaintEventArgs e)
        {
            var graphics = GetGraphics(e);

            var size = XY.Screen(InfoPanel.Size.Width, InfoPanel.Size.Height);
            mRenderer.DrawInfoGraphics(graphics, size);
        }

        public void minimap_paint(object sender, PaintEventArgs e)
        {
            var graphics = GetGraphics(e);

            var size = XY.Screen(Minimap.Size.Width, Minimap.Size.Height);
            mRenderer.DrawMinimap(graphics, size, mCameraController);
        }

        public void sidepanel_paint(object sender, PaintEventArgs e)
        {
            TurnCounter.Text = "Turn is: " + gameState.TurnNumber;
        }

        public void GameWindowForm_KeyPress(object sender, KeyEventArgs e)
        {
            var scale = mCameraController.GetCamera().Scale;
            switch (e.KeyCode)
            {
                case Keys.W://Up:
                    mCameraController.MoveBy(new WorldCoordinate(0, -scale));
                    break;
                case Keys.S://Down:
                    mCameraController.MoveBy(new WorldCoordinate(0, scale));
                    break;
                case Keys.A://Left:
                    mCameraController.MoveBy(new WorldCoordinate(-scale, 0));
                    break;
                case Keys.D://Right:
                    mCameraController.MoveBy(new WorldCoordinate(scale, 0));
                    break;
            }
        }

        #region Private

        private GraphicsWrapper GetGraphics(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            return new GraphicsWrapper(g);
        }

        private void InitializeGameWindow()
        {
            KeyDown += new KeyEventHandler(GameWindowForm_KeyPress);

            var timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            /*ClientSize = new Size(
                mConfigurationProvider.GetValue<int>("WindowSizeX"),
                mConfigurationProvider.GetValue<int>("WindowSizeY"));*/
            Name = "GameWindowForm";
            Text = "GameWindowForm";
            Load += new EventHandler(Form1_Load);
            ResumeLayout(false);
        }

        private void InitializeInfoPanel()
        {
            InfoPanel.TabIndex = 1;
            InfoPanel.Paint += new PaintEventHandler(info_Paint);
            InfoPanel.BackColor = Color.DarkGray;
        }

        private void InitializeSidePanel()
        {
            SideInfoBox.Paint += new PaintEventHandler(sidepanel_paint);
        }

        private void InitializeMinimap()
        {
            Minimap.Paint += new PaintEventHandler(minimap_paint);
        }

        #endregion
    }
}
