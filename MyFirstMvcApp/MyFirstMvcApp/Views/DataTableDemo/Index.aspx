<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	jQuery DataTables/ASP.NET MVC Integrarion
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script src="../../Scripts/DataTableDemo.js" type="text/javascript"></script>
   <div id="demo">
    <h2>Index</h2>
    <table id="myDataTable" class="display">
        <thead>
            <tr>
                <th>Id</th>
                <th>Company Name</th>
                <th>Address</th>
                <th>Town</th>
            </tr>
        </thead>
    </table>
   </div>

</asp:Content>
