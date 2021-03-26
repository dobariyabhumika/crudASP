<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebApplication7.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="background-color:aquamarine">User Information</h1>
        </div>
        <div>
            <asp:Label runat="server" ID="namelbl" Text="Name"></asp:Label>
            <asp:TextBox runat="server" ID="name"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="validateName" ErrorMessage="Name required" ControlToValidate="name" ValidationGroup="userData"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label runat="server" ID="addresslbl" Text="Address"></asp:Label>
            <asp:TextBox runat="server" ID="address"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="validateAddress" ErrorMessage="Address required" ControlToValidate="address" ValidationGroup="userData"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label runat="server" ID="mobilenolbl" Text="MobileNo"></asp:Label>
            <asp:TextBox runat="server" ID="mobileno"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="validateMobileno" ErrorMessage="MobileNo required" ControlToValidate="mobileno" ValidationGroup="userData"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label runat="server" ID="emaillbl" Text="Email"></asp:Label>
            <asp:TextBox runat="server" ID="email"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="validateEmail" ErrorMessage="Email required" ControlToValidate="email" ValidationGroup="userData"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Button runat="server" ID="submitBtn" Text="Submit" ValidationGroup="userData" OnClick="submitBtn_Click"/>
            <asp:Button runat="server" ID="updateBtn" Text="Update" ValidationGroup="userData" OnClick="updateBtn_Click"/>
            <asp:Button runat="server" ID="resetBtn" Text="Reset" ValidationGroup="userData" OnClick="resetBtn_Click"/>
        </div>

        <br />

        <div>
            <asp:GridView runat="server" ID="usersList" AllowPaging="true" AutoGenerateColumns="false" OnRowEditing="usersList_RowEditing" OnRowDeleting="usersList_RowDeleting" OnPageIndexChanging="usersList_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblId" Text='<%# Eval("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblName" Text='<%# Eval("name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblAddress" Text='<%# Eval("address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobileno">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblMobileno" Text='<%# Eval("mobileno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblEmail" Text='<%# Eval("email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="editBtn" Text="Edit" CommandName="Edit"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="deleteBtn" Text="Delete" CommandName="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
