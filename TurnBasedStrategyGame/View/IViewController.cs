using System.Windows.Forms;
using TBSG.Control;
using TBSG.Data.Hexmap;
using TBSG.Data.View;
using TBSG.View.Panels;

namespace TBSG.View
{
    public interface IViewController
    {
        ViewState GetViewState();
        IGameController GetGameController();
        ICameraController GetCamera();

        void SelectAt(ViewState state, HexCoordinate hex);
        GraphicsWrapper GetGraphics(PaintEventArgs e);

        FieldPanel CreateFieldPanel(PictureBox panel);
        InfoPanel CreateInfoPanel(Panel panel);
    }
}