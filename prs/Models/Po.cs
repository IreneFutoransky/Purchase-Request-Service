using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prs.Models
{
    public class Po
    {
        public Vendor Vendor { get; set; }
        public IList<RequestLine> PoLines { get; set; }
        public decimal Total { get; set; }

        public Po()
        {
            PoLines = new List<RequestLine>();
        }

    }
}
