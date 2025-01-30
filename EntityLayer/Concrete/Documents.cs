using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Documents
    {
        [Key]
        public int DocumentID { get; set; }
        public string CourseName { get; set; }
        public string? Title { get; set; }
        public string? PdfLink { get; set; }
        
    }
}
