using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string PersonName { get; set; }
    }

    public class Passport
    {
        [Key]
        public int ID { get; set; }
        public string PassportNumber { get; set; }

        public int refid { get; set; }  // fk
        public virtual Person Person { get; set; }  // ref
    }
}
