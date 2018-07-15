<%@ Page Title="Modify Prebuilt Facility" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyPrebuiltFacility.aspx.cs" Inherits="SOD2Compendium.ModifyPrebuiltFacility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- intBaseID -->
<div class="form-group">
<asp:Label ID="lblBaseID" Text="Base:" runat="server"></asp:Label>
<asp:DropDownList ID="cmbBase" runat="server" CssClass="form-control" ></asp:DropDownList>
</div>

<!-- intFacilityID -->
<div class="form-group">
<asp:Label ID="lblFacilityID" Text="Facility:" runat="server"></asp:Label>
<asp:DropDownList ID="cmbFacility" runat="server" CssClass="form-control" ></asp:DropDownList>
</div>

<!-- strName -->
<div class="form-group">
<asp:Label ID="lblName" Text="Name:" runat="server"></asp:Label>
<asp:TextBox ID="txtName" runat="server" CssClass="form-control" ></asp:TextBox>
</div>

<!-- strDescription -->
<div class="form-group">
<asp:Label ID="lblDescription" Text="Description:" runat="server"></asp:Label>
<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" ></asp:TextBox>
</div>

<!-- intEffectiveLevel -->
<div class="form-group">
<asp:Label ID="lblEffectiveLevel" Text="Effective Level:" runat="server"></asp:Label>
<asp:TextBox ID="txtEffectiveLevel" runat="server" CssClass="form-control" ></asp:TextBox>
</div>

<!-- blnIsDestroyable -->
<div class="form-group">
<asp:Label ID="lblIsDestroyable" Text="Is Destroyable:" runat="server"></asp:Label>
<asp:Checkbox ID="txtIsDestroyable" runat="server" CssClass="form-control" ></asp:Checkbox></div>

<!-- strNotes -->
<div class="form-group">
<asp:Label ID="lblNotes" Text="Notes:" runat="server"></asp:Label>
<asp:TextBox ID="txtNotes" runat="server" CssClass="form-control" ></asp:TextBox>
</div>

<!-- strScreenshotLocation -->
<div class="form-group">
<asp:Label ID="lblScreenshotLocation" Text="Screenshot Location:" runat="server"></asp:Label>
<asp:TextBox ID="txtScreenshotLocation" runat="server" CssClass="form-control" ></asp:TextBox>
</div>

     <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click"/>
    <asp:Button ID="btnFlag" runat="server" Text="Flag" CssClass="btn btn-warning" OnClick="btnFlag_Click"/>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>
</asp:Content>
