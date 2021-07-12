<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Domicilio.ascx.cs" Inherits="controlesUsuario_TextBoxAlfaNumerico" %>


<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="b" runat="server" ControlToValidate="TextBox1" ForeColor="Red" ErrorMessage="TextBox is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>