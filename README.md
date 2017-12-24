## Installation
1. Add AspnetFormDatatable to your references
2. Include following dependencies
```html
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.16/css/dataTables.bootstrap.min.css" />
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    
    <link href="Content/aspnet-form-datatable.css" rel="stylesheet" />
    
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.16/js/dataTables.bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/numeral.js/2.0.6/numeral.min.js"></script>
    <script src="https://momentjs.com/downloads/moment.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/mustache.js/2.3.0/mustache.min.js"></script>
    
    <script src="Scripts/support/string-format.js"></script>
```

## How to use ?
* Open an .aspx page and register assembly for your page
```
<%@ Register Assembly="AspnetFormDatatable" TagPrefix="datatable" Namespace="AspnetFormDatatable" %>
```

Example : 

```asp
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="DatatableDemo.aspx.cs" Inherits="DatatableDemo" %>

<%@ Register Assembly="AspnetFormDatatable" TagPrefix="datatable" Namespace="AspnetFormDatatable" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <datatable:GridView runat="server"
            ID="datatableAjax"
            AjaxUrl="/api/DatatableDemo/List?total=1000">
            <Columns>
                <datatable:GridViewColumn HeaderText="Id" DataField="id" />
                <datatable:GridViewColumn HeaderText="Name" DataField="name" />
                <datatable:GridViewColumn HeaderText="Total" DataField="total" DataType="Number" />
                <datatable:GridViewColumn HeaderText="Created Date" DataField="createdDate" DataType="DateTime" Format="dd/MM/yyyy HH:mm:ss" />
                <datatable:GridViewColumn>
                    <ColumnTemplate>
                        <a href="/DatatableDemoDetail?id={{id}}" class="btn">Detail</a>
                    </ColumnTemplate>
                </datatable:GridViewColumn>
            </Columns>
            <RowDetailTemplate>
                This is row detail for row with name "{{name}}"
            </RowDetailTemplate>
        </datatable:GridView>
    </div>
</asp:Content>

```
