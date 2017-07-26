using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TBSG.Data;

namespace TBSG.View
{
    public class FieldPanel : PictureBox
    {
        private GameWindowForm mGameWindowForm;

        public void Initialize(GameWindowForm gameWindowForm)
        {
            mGameWindowForm = gameWindowForm;
        }

        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            mGameWindowForm.FieldPanelClick(e);
        }
    }
}
