using Microsoft.Identity.Client.AuthScheme.PoP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public string Items { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
        public DateTime OrdrDate { get; set; }
    }
}
