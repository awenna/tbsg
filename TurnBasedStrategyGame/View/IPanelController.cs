using System.Windows.Forms;

namespace TBSG.View
{
    public interface IPanelController
    {
        void OnClick(ViewState state, MouseEventArgs e);
    }
}
