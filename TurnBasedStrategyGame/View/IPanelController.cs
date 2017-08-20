using System.Windows.Forms;
using TBSG.Data;

namespace TBSG.View
{
    public interface IPanelController
    {
        void OnClick(ViewState state, MouseEventArgs e);
    }
}
