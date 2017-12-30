using System.Drawing;
using System.Windows.Forms;
using TBSG.Data;
using TBSG.Data.Hexmap;

namespace TBSG.View.Panels
{
    public class InfoPanel : IPanelController
    {
        private readonly Panel mPanel;
        private readonly IViewController mViewController;
        private readonly IAlgorithms mAlgorithms; // Someone else's responsibility?
        private readonly IRenderer mRenderer;

        public InfoPanel(
            Panel panel,
            IViewController viewController,
            IAlgorithms algorithms,
            IRenderer renderer)
        {
            mPanel = panel;
            mViewController = viewController;
            mAlgorithms = algorithms;
            mRenderer = renderer;

            mPanel.TabIndex = 1;
            mPanel.Paint += new PaintEventHandler(info_Paint);
            mPanel.BackColor = Color.DarkGray;
        }

        public void OnClick(object sender, MouseEventArgs e)
        {
            
        }

        #region Private

        public void info_Paint(object sender, PaintEventArgs e)
        {
            var graphics = mViewController.GetGraphics(e);

            var size = XY.Screen(mPanel.Size.Width, mPanel.Size.Height);
            mRenderer.DrawInfoGraphics(graphics, size);
        }

        #endregion
    }
}
