﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework
{
   public abstract class VerifyCodeStrategy
    {
        public abstract string GenCode(int num);
    }
}
