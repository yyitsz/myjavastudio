<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Copyrights.ascx.cs" Inherits="FNHCustomProviders.SampleApp.copyrights" %>
<table style="width: 100%;" >
    <tr><td><br /><br /><br /><br /><br /></td></tr>
    <tr>
    <td  align="center" >
        <asp:HyperLink ID="HyperLink1"  NavigateUrl ="~/License.txt" Text = "Copyright (c)" Target ="_blank" runat="server">  </asp:HyperLink>  &nbsp;Suhel Shah 2009-<%= DateTime.Now.Year %>. All Rights Reserved.
    </td>

    </tr>

</table>
