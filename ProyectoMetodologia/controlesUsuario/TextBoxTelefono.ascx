<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextBoxTelefono.ascx.cs" Inherits="controlesUsuario_TextBoxTelefono" %>


<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Telefono is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox1"  ForeColor="Red" ErrorMessage="Wrong mobile format" Text="*" Display="Dynamic" ValidationExpression="^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$"></asp:RegularExpressionValidator>