<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Nombre.ascx.cs" Inherits="controlesUsuario_CajaOnlyTextEmpty" %>



<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="b" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="TextBox is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="b" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="Text Characters Only" Text="*" Display="Dynamic" ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$"></asp:RegularExpressionValidator>