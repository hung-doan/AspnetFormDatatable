using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AspnetFormDatatable.Factories
{
    public class DatatableJsExtentionFactory
    {
        
        public static string GetScripts(GridView options, string datatableVar)
        {
            var jsBuilder = new StringBuilder();
            if (options.RowDetailTemplate != null)
            {
                jsBuilder.Append(GenerateDataRowScripts(options, datatableVar));
            }
            return jsBuilder.ToString();
        }

        private static string GenerateDataRowScripts(GridView options, string datatableVar)
        {

            var jsBuilder = new StringBuilder();
            jsBuilder.Append(@"
    // Array to track the ids of the details displayed rows
    var detailRows = [];
 
    $('#" + options.ID + @"').on( 'click', 'tr td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = "+ datatableVar + @".row( tr );
        var idx = $.inArray( tr.attr('id'), detailRows );
 
        if ( row.child.isShown() ) {
            tr.removeClass( 'details' );
            row.child.hide();
 
            // Remove from the 'open' array
            detailRows.splice( idx, 1 );
        }
        else {
            tr.addClass( 'details' );
            row.child(Mustache.render('" + HttpUtility.JavaScriptStringEncode(options.RowDetailTemplate) + @"', row.data())).show();
 
            // Add to the 'open' array
            if ( idx === -1 ) {
                detailRows.push( tr.attr('id') );
            }
        }
    } );
 
    // On each draw, loop over the `detailRows` array and show any child rows
    dt.on( 'draw', function () {
        $.each( detailRows, function ( i, id ) {
            $('#'+id+' td.details-control').trigger( 'click' );
        } );
    } );
");
            return jsBuilder.ToString();
        }
    }
}
