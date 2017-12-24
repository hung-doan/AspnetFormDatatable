using AspnetFormDatatable.Factories;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspnetFormDatatable
{
    [ParseChildren(true)]
    [ToolboxData("<{0}:GridView runat='server'></{0}:GridView>")]
    public class GridView : WebControl
    {
        public string AjaxUrl { get; set; }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<GridViewColumn> Columns { get; set; }

        [TemplateInstance(TemplateInstance.Single)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public string RowDetailTemplate { get; set; }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            // Render table
            writer.Write($"<table id=\"{ID}\" class=\"table\">");

            writer.Write("<thead><tr>");
            if (RowDetailTemplate != null)
            {
                // Add Row detail
                writer.Write($"<th></th>");
            }
            foreach (var col in Columns)
            {
                writer.Write($"<th>{col.HeaderText}</th>");
            }
            writer.Write("</tr><thead>");

            writer.Write("</table>");

            // Render configuration scripts
            writer.Write($@"
<script>
$(document).ready(function() {{
    var dt = $('#{ID}').DataTable({DatatableJsOptionsFactory.GetOptions(this)});
    {DatatableJsExtentionFactory.GetScripts(this, "dt")}
}} );
</script>
");
        }



    }

}
