<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyHeroBonus.aspx.cs" Inherits="SOD2Compendium.ModifyHeroBonus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="hlScreenshot" runat="server">View Screenshot</asp:HyperLink>
    <div class="form-group"><asp:Label ID="lblName" Text="Name:" runat="server"></asp:Label><asp:TextBox ID="txtName" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblEffects" Text="Effects:" runat="server"></asp:Label><asp:TextBox ID="txtEffects" runat="server" CssClass="form-control" ></asp:TextBox></div>
    
    <div class="form-group"><asp:Label ID="lblDescription" Text="Description:" runat="server"></asp:Label><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblNotes" Text="Notes:" runat="server"></asp:Label><asp:TextBox ID="txtNotes" runat="server" CssClass="form-control"  TextMode="MultiLine" Rows="10"></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblGameID" Text="Game ID:" runat="server"></asp:Label><asp:TextBox ID="txtGameID" runat="server" CssClass="form-control" ></asp:TextBox></div>
 
    <div class="form-group"><asp:Label ID="lblScreenshot" Text="Screenshot URL:" runat="server"></asp:Label><asp:TextBox ID="txtScreenshot" runat="server" CssClass="form-control" ></asp:TextBox></div>

    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click"/>
    <asp:Button ID="btnFlag" runat="server" Text="Flag" CssClass="btn btn-warning" OnClick="btnFlag_Click"/>

</asp:Content>
