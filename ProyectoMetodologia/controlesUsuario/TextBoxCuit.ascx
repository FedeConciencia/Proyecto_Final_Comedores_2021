<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextBoxCuit.ascx.cs" Inherits="controlesUsuario_TextBoxCuit" %>


<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="b" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="TextBox is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="b" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Format Cuit is Invalid" Text="*" Display="Dynamic" ValidationExpression="^[0-9]{2}-[0-9]{8}-[0-9]$"></asp:RegularExpressionValidator>