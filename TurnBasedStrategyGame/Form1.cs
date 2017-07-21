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

        public GameWindowForm(IRenderer renderer, ICamera camera)
        {
            mRenderer = renderer;
            mCamera = camera;

            InitializeComponent();

            mCamera.SetSize(panel2.Size);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            panel2.Invalidate();
        }

        private void DrawIt()
        {
            System.Drawing.Graphics graphics = this.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
                50, 100, 150, 150);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
            graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawIt();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var rekt = e.ClipRectangle;
            rekt.Inflate(-1, -1);
            g.DrawRectangle(Pens.Black, rekt);
            g.DrawRectangle(Pens.Green, new Rectangle(50, 50, 50, 50));
        }

        private void field_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var rekt = e.ClipRectangle;
            rekt.Inflate(-1, -1);
            g.DrawRectangle(Pens.Black, rekt);

            var gw = new GraphicsWrapper(g);

            mRenderer.DrawGrid(gw, mCamera);

            var mouseLoc = panel2.PointToClient(Cursor.Position);

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
