using System.Windows.Forms;
using TBSG.Control;
using TBSG.Data;
using TBSG.View.Forms;

namespace TBSG.View
{
    public interface IViewController
    {
        ViewState GetViewState();
        IGameController GetGameController();
        ICameraController GetCamera();

        FieldPanelController CreateFieldPanelController(PictureBox panel);
    }
}