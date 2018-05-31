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
        GameState GetGameState();
        IGameController GetGameController();
        ICameraController GetCamera();

        void PassTurn();
        void SelectAt(ViewState state, HexCoord hex);
        GraphicsWrapper GetGraphics(PaintEventArgs e);

        FieldPanel CreateFieldPanel(PictureBox panel);
        InfoPanel CreateInfoPanel(Panel panel);
    }
}