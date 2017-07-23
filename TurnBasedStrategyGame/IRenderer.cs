﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TBSG
{
    public interface IRenderer
    {
        void DrawGrid(IGraphics g, ICamera camera);
        void DrawUnits(IGraphics g, ICamera camera);
    }
}
