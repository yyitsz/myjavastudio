<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignRole.aspx.cs" Inherits="FNHCustomProviders.SampleApp.AssignRole" %>
<%@ Register TagPrefix ="uc1" TagName ="UserInfo"  src="~/StatusControl.ascx" %>
<%@ Register TagPrefix ="uc1" TagName ="Copyright"  src="~/Copyrights.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Assign roles to users</title>
      <link href="/App_Themes/Blue/Simple.css" type = "text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div align ="right"  >
        <uc1:UserInfo id="UserInfo1" runat ="server"></uc1:UserInfo>
    </div>
    <div align="left" style="padding:25px;">
    <asp:Label  class="styleP" ID="lblg" runat="server" Text="List of registered users in system"></asp:Label><br /><br />
       <asp:GridView ID="gridviewUsers" runat="server" CellPadding="7" ForeColor="#333333" 
           GridLines="None" AutoGenerateColumns="False" CellSpacing="1">
           <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
           <Columns>
               <asp:BoundField DataField="UserName" HeaderText="UserName" />
               <asp:BoundField DataField="Email" HeaderText="Email" />
               <asp:BoundField DataField="PasswordQuestion" HeaderText="PasswordQuestion" />
               <asp:BoundField DataField="IsApproved" HeaderText="IsApproved" />
               <asp:BoundField DataField="IsLockedOut" HeaderText="IsLockedOut" />
               <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" />
               <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" />
           </Columns>
           <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
           <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
           <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
           <EditRowStyle BackColor="#999999" />
           <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
       </asp:GridView>
            <br />
            <asp:HyperLink ID="lnkAddUser"   class="styleL" NavigateUrl="~/CreateUser.aspx" runat="server">Add a new user</asp:HyperLink><br /><br />
            
            
            
            <br />
            
            <hr size=".5"  />
             <br /><br />
           <asp:Label  class="styleP" ID="Label1" runat="server" Text="List of available roles with users in System"></asp:Label><br /><br />
          
            <asp:GridView ID="gridviewRoles" runat="server" CellPadding="7" 
            ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
            CellSpacing="1">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="Key" HeaderText="Role" />
                    <asp:BoundField DataField="Value" HeaderText="Users in Role" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        <br />
           
           <!--Add/remove role-->
           <br /><asp:Label  class="styleP" ID="Label2" runat="server" Text="Add a new Role"></asp:Label>
            &nbsp;&nbsp;<asp:Label  class="styleN" ID="Label3" runat="server" Text="Role Name: "></asp:Label>
            &nbsp;<asp:TextBox ID="txtrolename" runat="server" EnableViewState="False"></asp:TextBox>
            &nbsp;&nbsp;<asp:Button ID="btnAddrole" runat="server" Text="AddRole" 
            onclick="btnAddrole_Click" EnableViewState="False" />
            
            <br /><br /><asp:Label  class="styleP" ID="Label4" runat="server" Text="Remove a Role"></asp:Label>
            &nbsp;&nbsp;<asp:Label  class="styleN" ID="Label5" runat="server" Text="Select a role to remove: "></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlRoles" runat="server"></asp:DropDownList>
            &nbsp;&nbsp;<asp:Button ID="btnRemoveRole" runat="server" 
            Text="Remove Role" onclick="btnRemoveRole_Click" EnableViewState="False" />
            
            <!--Add/remove role from a user-->
            <hr size=".5"  />
            <br /><asp:Label  class="styleP" ID="Label6" runat="server" Text="Add Role to a User"></asp:Label>
            &nbsp;&nbsp;<asp:Label  class="styleN" ID="Label7" runat="server" Text="Select a User: "></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlUser" runat="server"></asp:DropDownList>
            &nbsp;&nbsp;<asp:Label  class="styleN" ID="Label8" runat="server" Text="Select a Role: "></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlRoles2" runat="server"></asp:DropDownList>
            &nbsp;&nbsp;<asp:Button ID="btnAddRoleToUser" runat="server" 
            Text="Add Role to User" onclick="btnAddRoleToUser_Click" 
            EnableViewState="False" />
            
             <br /><br /><asp:Label  class="styleP" ID="Label9" runat="server" Text="Remove Role from User"></asp:Label>
            &nbsp;&nbsp;<asp:Label  class="styleN" ID="Label10" runat="server" Text="Select a User: "></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlUser3" runat="server"></asp:DropDownList>
            &nbsp;&nbsp;<asp:Label  class="styleN" ID="Label11" runat="server" Text="Select a Role to remove: "></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlRoles3" runat="server"></asp:DropDownList>
            &nbsp;&nbsp;<asp:Button ID="btnRemoveRoledFromUser" runat="server" 
            Text="Remove Role from User" 
            EnableViewState="False" onclick="btnRemoveRoleFromUser_Click" />
            
            <br /><br /><br /><asp:Label   ID="lblMessage" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
           
    </div>
    
    <uc1:Copyright id="copyright1" runat ="server"></uc1:Copyright>
    </form>
</body>
</html>
