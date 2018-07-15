<%@ Page Title="Modify Facility" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyFacility.aspx.cs" Inherits="SOD2Compendium.ModifyFacility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<!-- strName -->
<div class="form-group">
<asp:Label ID="lblName" Text="Name:" runat="server"></asp:Label>
<asp:TextBox ID="txtName" runat="server" CssClass="form-control" ></asp:TextBox>
</div>

<!-- strDescription -->
<div class="form-group">
<asp:Label ID="lblDescription" Text="Description:" runat="server"></asp:Label>
<asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"  TextMode="MultiLine" Rows="5" ></asp:TextBox>
</div>

<!-- blnCanBePlacedOutdoors -->
<div class="form-group">
<asp:Label ID="lblCanBePlacedOutdoors" Text="Can Be Placed Outdoors:" runat="server"></asp:Label>
<asp:Checkbox ID="chkCanBePlacedOutdoors" runat="server" CssClass="form-control" ></asp:Checkbox></div>

<!-- blnCanBePlacedIndoors -->
<div class="form-group">
<asp:Label ID="lblCanBePlacedIndoors" Text="Can Be Placed Indoors:" runat="server"></asp:Label>
<asp:Checkbox ID="chkCanBePlacedIndoors" runat="server" CssClass="form-control" ></asp:Checkbox></div>

    <!-- blnCanBePlacedIndoors -->
<div class="form-group">
<asp:Label ID="lblSize" Text="Size:" runat="server"></asp:Label>
<asp:DropDownList ID="cmbSize" runat="server" CssClass="form-control" ></asp:DropDownList></div>

     <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click"/>
    <asp:Button ID="btnFlag" runat="server" Text="Flag" CssClass="btn btn-warning" OnClick="btnFlag_Click"/>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>
</asp:Content>
