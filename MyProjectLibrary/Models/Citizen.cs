using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.Models
{
    public class Citizen
    {
        [Key]
        public int ID { get; set; }
        public string CitizenName { get; set; }
    }

    public class Voters
    {
        [Key]
        public int ID { get; set; }
        public string VoterName { get; set; }

        public int refid { get; set; }  // fk

        [ForeignKey("refid")]
        public Citizen Citizen { get; set; }
    }
}
