<%@ Page Title="Modify Trait Effect" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyTraitEffects.aspx.cs" Inherits="SOD2Compendium.ModifyTraitEffects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group"><asp:Label ID="lblType" Text="Effect Type:" runat="server"></asp:Label><asp:DropDownList ID="cmbEffectType" runat="server" CssClass="form-control"></asp:DropDownList></div>
    
        <div class="form-group"><asp:Label ID="lblValue" Text="Value:" runat="server"></asp:Label><asp:TextBox ID="txtValue" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox></div>
       <div class="form-group"><asp:Label ID="lblIsGlobal" Text="Global?:" runat="server"></asp:Label><asp:Checkbox ID="chkIsGlobal" runat="server" CssClass="form-control"></asp:Checkbox></div>

    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click"/>
    <asp:Button ID="btnFlag" runat="server" Text="Flag" CssClass="btn btn-warning" OnClick="btnFlag_Click"/>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>

</asp:Content>
