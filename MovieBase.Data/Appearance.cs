using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Data
{
    public class Appearance
    {
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("Actor"), Key, Column(Order = 0)]
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        [ForeignKey("Movie"), Key, Column(Order = 1),]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
