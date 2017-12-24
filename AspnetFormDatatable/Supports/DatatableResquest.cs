using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetFormDatatable.Supports
{
    /// <summary>
    /// https://datatables.net/manual/server-side
    /// </summary>
    public class DatatableResquest
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
    }
}
