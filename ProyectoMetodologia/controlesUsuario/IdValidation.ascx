<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IdValidation.ascx.cs" Inherits="controlesUsuario_TextBoxOnlyNumbers" %>



<asp:TextBox ID="TextBoxEmptyNum" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="a" runat="server" ControlToValidate="TextBoxEmptyNum" ForeColor="Red" ErrorMessage="Box is Empty" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="a" runat="server" ControlToValidate="TextBoxEmptyNum" ForeColor="Red" ErrorMessage="Numbers Only" Text="*" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>