<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewMessages.ascx.cs" Inherits="EntityDemo.UserControls.ViewMessages" %>
<asp:Repeater runat="server" ID="MessageList">
    <ItemTemplate>
    <%# Eval("Subject") %><br />
    </ItemTemplate>
</asp:Repeater>
