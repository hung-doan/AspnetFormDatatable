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
                        <button type="button" class="btn">Detail</button>
                    </ColumnTemplate>
                </datatable:GridViewColumn>
            </Columns>
            <RowDetailTemplate>
                This is row detail template for row with name "{{name}}"
            </RowDetailTemplate>
        </datatable:GridView>
    </div>
</asp:Content>
