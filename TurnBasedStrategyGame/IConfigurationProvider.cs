﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSG
{
    public interface IConfigurationProvider
    {
        T GetValue<T>(string configurationKey);
    }
}
