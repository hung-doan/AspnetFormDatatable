using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetFormDatatable.Supports
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://datatables.net/manual/server-side
    /// </remarks>
    public class DatatableResponse<TModel> where TModel :class
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public IEnumerable<TModel> Data { get; set; }
        public string Error { get; set; }
    }
}
