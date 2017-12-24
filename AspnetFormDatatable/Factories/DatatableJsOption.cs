using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetFormDatatable.Factories
{
    public class DatatableJsOption
    {
        public bool Processing { get; set; } = true;
        public bool ServerSide { get; set; } = true;
        public bool Ordering { get; set; } = false;
        public bool Searching { get; set; } = false;

        //public string Dom { get; set; } = "lfrtip";
        public DatatableJsOptionAjax Ajax { get; set; }
        public List<DatatableJsOptionColumn> Columns { get; set; }
        public class DatatableJsOptionColumn
        {
            public string Class { get; set; }

            //public bool Orderable { get; set; }

            public string Data { get; set; }

            public string DefaultContent { get; set; }

            public JRaw Render { get; set; }

        }

        public class DatatableJsOptionAjax
        {
            public string Url { get; set; }
            public string Type { get; set; } = "GET";
        }
    }
}
