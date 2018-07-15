<%@ Page Title="View Screenshot" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewScreenshot.aspx.cs" Inherits="SOD2Compendium.ViewScreenshot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Image ID="imgScreenshot" runat="server" />
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Width="100%" CssClass="btn" />
</asp:Content>
