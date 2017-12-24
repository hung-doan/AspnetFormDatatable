using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AspnetFormDatatable.Factories
{
    public class DatatableJsOptionsFactory
    {
        public static string GetOptions(GridView options)
        {
            var jsOption = new DatatableJsOption();
            jsOption.Ajax = new DatatableJsOption.DatatableJsOptionAjax
            {
                Url = options.AjaxUrl
            };

            jsOption.Columns = new List<DatatableJsOption.DatatableJsOptionColumn>();

            foreach (var col in options.Columns)
            {
                var colOption = new DatatableJsOption.DatatableJsOptionColumn();
                colOption.Data = col.DataField;
                if (string.IsNullOrEmpty(colOption.Data))
                {
                    colOption.DefaultContent = "";
                }
                colOption.Render = GetColumnRenderFunction(col);

                jsOption.Columns.Add(colOption);
            }
            if (options.RowDetailTemplate != null)
            {

                jsOption.Columns.Insert(0, new DatatableJsOption.DatatableJsOptionColumn
                {
                    Class = "details-control",
                    Data = null,
                    DefaultContent = ""
                });
            }

            string output = JsonConvert.SerializeObject(jsOption,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            return output;
        }

        public static string GetDatatableDatatype(DatatableDataType? dataType)
        {
            switch (dataType)
            {
                case null:
                    return "string";
                case DatatableDataType.Number:
                    return "num";
                case DatatableDataType.DateTime:
                    return "date";
                default:
                    return "string";
            }

        }
        public static JRaw GetColumnRenderFunction(GridViewColumn columnOption)
        {
            string columnRenderScript = columnOption.ColumnRenderScript;
            
            
            if (!string.IsNullOrEmpty(columnOption.ColumnTemplate))
            {
                columnRenderScript = @"function(data, type, row, meta){
return Mustache.render('" + HttpUtility.JavaScriptStringEncode(columnOption.ColumnTemplate) + @"', row);
}";
            }

            if(columnOption.DataType != null)
            {
                switch (columnOption.DataType)
                {
                    case DatatableDataType.Number:
                        columnRenderScript = @"function(data, type, row, meta){
return stringFormat.number(data).toString();
}";
                        break;
                    case DatatableDataType.DateTime:
                        columnRenderScript = @"function(data, type, row, meta){
return stringFormat.dateTime(data).toString('MM/DD/YYYY HH:mm:ss A');
}";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(columnRenderScript))
            {
                return new JRaw(columnRenderScript);
            }
            return null;

        }
    }
}
