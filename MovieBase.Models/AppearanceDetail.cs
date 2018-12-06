using MovieBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Models
{
    public class AppearanceDetail
    {
        public int AppearanceId { get; set; }

        public int ActorId { get; set; }

        public int MovieId { get; set; }

        public Appearance Appearance { get; set; }

    }
}
