<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextBoxMultiLine.ascx.cs" Inherits="controlesUsuario_TextBoxMultiLine" %>


<asp:TextBox ID="TextBox1" TextMode="MultiLine" MaxLength="200" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="TextBox is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>