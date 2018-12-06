using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Data
{
    [Table("Appearance")]
    public class Appearance
    {
        [Key]
        public int AppearanceId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
