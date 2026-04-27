using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.Models
{
    public class Country
    {
        [Key]
        public int ID { get; set; }
        public string CountryName { get; set; }
        public ICollection<State> States { get; set; }
    }

    public class State
    {
        [Key]
        public int StateID { get; set; }

        public string StateName { get; set; }

        public int CountryID { get; set; }  //fk
        public Country Country { get; set; }
    }
}
