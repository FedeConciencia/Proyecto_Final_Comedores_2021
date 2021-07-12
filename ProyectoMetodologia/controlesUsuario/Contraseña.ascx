<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contraseña.ascx.cs" Inherits="controlesUsuario_WebUserControl" %>


<asp:TextBox ID="TextBox1" TextMode="Password" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="TextBox is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Password Format Invalid" Text="*" Display="Dynamic" ValidationExpression="^([a-zA-Z0-9@*#]{8,15})$"></asp:RegularExpressionValidator>