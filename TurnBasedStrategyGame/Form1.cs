using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurnBasedStrategyGame
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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
        }
    }
}
