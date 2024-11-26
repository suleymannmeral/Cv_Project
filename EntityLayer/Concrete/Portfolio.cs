using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public int Budget{ get; set; }
        public bool Status{ get; set; }
        public int Completion{ get; set; }
        public string? ProjectLink{ get; set; }
 
       
    }
}
