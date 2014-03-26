<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FNHCustomProviders.SampleApp._Default" %>
<%@ Register TagPrefix ="uc1" TagName ="Copyright"  src="~/Copyrights.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sample FluentNHibernate Provider Application</title>
    <link href="/App_Themes/Blue/Simple.css" type = "text/css" rel="stylesheet" />
     
</head>
<body>
    <form id="form1" runat="server">
    <h2 class="styleM" style="font-weight: bold">Welcome to Fluent Nhibernate Provider Sample App</h2>
    <h3 class="styleM">This app is used to demonstrate how to use the Custom Fluent Nhibernate Provider</h3>
    <h3 class="styleP" >Please log into your account</h3>
    <div align ="center">
    
        <asp:Login ID="Login1" runat="server" Height="168px" Width="305px" 
            BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
            ForeColor="#333333" 
            DisplayRememberMe="false" RememberMeSet="false"
            onauthenticate="Login1_Authenticate">
            
            <TextBoxStyle Font-Size="0.8em" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                ForeColor="White" />
        </asp:Login>
        <br />
    <asp:HyperLink  ID="lnkForgotPwd"  class="styleL"  NavigateUrl="~/ForgotPassword.aspx" runat="server">Forgot Passwod</asp:HyperLink><br />
    <asp:HyperLink  ID="HyperLink1" class="styleL"  NavigateUrl="~/CreateUser.aspx" runat="server">Create a new account</asp:HyperLink>
    </div>
    
    <uc1:Copyright id="copyright1" runat ="server"></uc1:Copyright>
    </form>
</body>
</html>
