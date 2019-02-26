using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prs.Models
{
    public class Request              
                    
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [StringLength(30)]
        public string Description { get; set; }
        [StringLength(30)]
        public string Justification { get; set; }
        public string DeliveryMode { get; set; }
        public DateTime  ReviewDate { get; set; }
        public string Status { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal Total { get; set; }        
        public bool Active { get; set; } = true;

        public virtual User User { get; set; }
        public virtual IList<RequestLine> RequestLines { get; set; }
        



        public Request() { }


    }
}
