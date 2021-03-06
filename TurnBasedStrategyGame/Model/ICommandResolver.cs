﻿using TBSG.Data;
using TBSG.Model.Hexmap;

namespace TBSG.Model
{
    public interface ICommandResolver
    {
        bool IsValid(Command command, IMap map);
        IMap Resolve(Command command, IMap map);
    }
}
