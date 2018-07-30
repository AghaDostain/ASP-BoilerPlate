﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlate.Models
{
    public class KeyedModel<T> where T : IEquatable<T>
    {
        public T Id { get; set; }
    }
}
