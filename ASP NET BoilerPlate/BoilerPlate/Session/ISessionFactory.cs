﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlate.Common
{
    public interface ISessionFactory
    {
        IUser GetUser();
    }
}
