using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TBSG.Data;

namespace TBSG
{
    public partial class GameWindowForm : Form
    {
        private readonly IRenderer mRenderer;
        private readonly ICamera mCamera;
        private readonly IConfigurationProvider mConfigurationProvider;

        public GameWindowForm(
            IRenderer renderer,
            ICamera camera,
            IConfigurationProvider configProvider)
        {
            mRenderer = renderer;
            mCamera = camera;
            mConfigurationProvider = configProvider;

            InitializeComponent();

            mCamera.SetSize(fieldPanel.Size);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            fieldPanel.Invalidate();
        }

        private void field_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var gw = new GraphicsWrapper(g);

            mRenderer.DrawGrid(gw, mCamera);

            var mouseLoc = fieldPanel.PointToClient(Cursor.Position);

            var algs = new Algorithms();
            var tile = algs.WorldToHex(new WorldCoordinate(mouseLoc.X, mouseLoc.Y), 32);

            g.DrawString(mouseLoc.ToString(), DefaultFont, Brushes.Red, new PointF(0, 0));
            g.DrawString(tile.ToString(), DefaultFont, Brushes.Red, new PointF(100, 0));
        }

        private void GameWindowForm_KeyPress(object sender, KeyEventArgs e)
        {
            var scale = mCamera.GetScale();
            switch (e.KeyCode)
            {
                case Keys.W://Up:
                    mCamera.MoveBy(new WorldCoordinate(0, -scale));
                    break;
                case Keys.S://Down:
                    mCamera.MoveBy(new WorldCoordinate(0, scale));
                    break;
                case Keys.A://Left:
                    mCamera.MoveBy(new WorldCoordinate(-scale, 0));
                    break;
                case Keys.D://Right:
                    mCamera.MoveBy(new WorldCoordinate(scale, 0));
                    break;
            }
        }

        private void GameWindowForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
    }
}
