﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Models
{
    public class ActorCreate
    {
        public int ActorId { get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;

    }
}
