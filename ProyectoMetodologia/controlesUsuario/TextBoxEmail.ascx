<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextBoxEmail.ascx.cs" Inherits="controlesUsuario_TextBoxEmail" %>

<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Email is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBox1"  ForeColor="Red" ErrorMessage="Email format error" Text="*" Display="Dynamic" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>

