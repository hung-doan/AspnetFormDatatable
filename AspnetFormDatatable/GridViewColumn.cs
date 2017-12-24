using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace AspnetFormDatatable
{
    public class GridViewColumn
    {
        public string DataField { get; set; }
        public DatatableDataType? DataType { get; set; }
        public string Format { get; set; }
        public string HeaderText { get; set; } = "";
        public string Width { get; set; }

        /// <summary>
        /// Using mustache as View Engine
        /// If ColumnRenderScript was defined, this propety will be ignored
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public string ColumnTemplate { get; set; }
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public string ColumnRenderScript { get; set; }
    }
}
