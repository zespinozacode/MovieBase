using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Data
{
    public class Actor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Appearance> Appearances { get; set; }
    }
}
