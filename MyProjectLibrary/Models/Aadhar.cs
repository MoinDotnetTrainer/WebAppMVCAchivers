using Microsoft.Identity.Client.AuthScheme.PoP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.Models
{
    [Table("Tbl_Aadhar")]  // at backend db table name Tbl_Aadhar   
    public class Aadhar
    {
        [Key] // This attribute indicates that the Id property is the primary key of the Aadhar entity. 
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string FatherName { get; set; }
        public  virtual Pan Pan { get; set; }  // navigation
    }

    public class Pan
    {
        [Key]
        public int ID { get; set; }
        public string PanNo { get; set; }
        public string PanUserName { get; set; }

        public int AadharID { get; set; }  // fk
        public virtual Aadhar Aadhar { get; set; }  // navigation , ref for fk

        // Paent ID will be foreign key to Aadhar table 
    }
}
