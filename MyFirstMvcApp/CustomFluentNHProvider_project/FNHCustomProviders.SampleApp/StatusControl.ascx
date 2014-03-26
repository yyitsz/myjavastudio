<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatusControl.ascx.cs" Inherits="FNHCustomProviders.SampleApp.StatusControl" %>
        <asp:Label  class="styleP" ID="lblUserName" runat="server" Text=""></asp:Label>
          &nbsp;|
        <asp:LoginStatus ID="LoginStatus1" runat="server" 
            LoginText="[Sign In]" 
            LogoutText="[Sign Out]" 
            LogoutPageUrl="~/Default.aspx" 
            LogoutAction="Redirect" />
          &nbsp;|&nbsp;<asp:HyperLink ID="hypHome" NavigateUrl ="~/Default.aspx" runat="server">Home</asp:HyperLink>