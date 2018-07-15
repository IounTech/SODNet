<%@ Page Title="Modify Guns" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyGuns.aspx.cs" Inherits="SOD2Compendium.ModifyGuns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 runat="server" id="lblMainHeader" name ="lblMainHeader"></h1>
    <asp:HyperLink ID="hlScreenshot" runat="server">View Screenshot</asp:HyperLink>  
    <div class="form-group"><asp:Label ID="lblName" Text="Name:" runat="server"></asp:Label><asp:TextBox ID="txtName" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblAmmoType" Text="Ammo Type:" runat="server"></asp:Label><asp:DropDownList ID="cmbAmmoType" runat="server" CssClass="form-control" ></asp:DropDownList></div>
    <div class="form-group"><asp:Label ID="lblGunType" Text="Gun Type:" runat="server"></asp:Label><asp:DropDownList ID="cmbGunType" runat="server" CssClass="form-control" ></asp:DropDownList></div>
    
    <div class="form-group"><asp:Label ID="lblDescription" Text="Description:" runat="server"></asp:Label><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox></div>
    
    <div class="form-group"><asp:Label ID="lblNotes" Text="Notes:" runat="server"></asp:Label><asp:TextBox ID="txtNotes" runat="server" CssClass="form-control"  TextMode="MultiLine" Rows="10"></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblVisual" Text="Visual:" runat="server"></asp:Label><asp:TextBox ID="txtVisual" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblAudio" Text="Audio:" runat="server"></asp:Label><asp:TextBox ID="txtAudio" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblMagMod" Text="Mag Mod:" runat="server"></asp:Label><asp:TextBox ID="txtMagMod" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblDefaultMod" Text="Default Mod:" runat="server"></asp:Label><asp:TextBox ID="txtDefaultMod" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblGameID" Text="Game ID:" runat="server"></asp:Label><asp:TextBox ID="txtGameID" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblSightMod" Text="Sight Mod:" runat="server"></asp:Label><asp:TextBox ID="txtSightMod" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblScreenshot" Text="Screenshot URL:" runat="server"></asp:Label><asp:TextBox ID="txtScreenshot" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblDurability" Text="Durability:" runat="server"></asp:Label><asp:TextBox ID="txtDurability" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblCapacity" Text="Capacity:" runat="server"></asp:Label><asp:TextBox ID="txtCapacity" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblWeight" Text="Weight:" runat="server"></asp:Label><asp:TextBox ID="txtWeight" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblHasSight" Text="Has Sight:" runat="server"></asp:Label><asp:Checkbox ID="chkHasSight" runat="server" CssClass="form-control" ></asp:Checkbox></div>
    <div class="form-group"><asp:Label ID="lblOneInTheChamber" Text="Allows One In The Chamber:" runat="server"></asp:Label><asp:Checkbox ID="chkOneInTheChamber" runat="server" CssClass="form-control" ></asp:Checkbox></div>
    <div class="form-group"><asp:Label ID="lblAcceptsAttachments" Text="Attachments:" runat="server"></asp:Label><asp:Checkbox ID="chkAcceptsAttachments" runat="server" CssClass="form-control" ></asp:Checkbox></div>
    <div class="form-group"><asp:Label ID="lblBuyPrice" Text="Buy Price:" runat="server"></asp:Label><asp:TextBox ID="txtBuyPrice" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblSellPrice" Text="Sell Price:" runat="server"></asp:Label><asp:TextBox ID="txtSellPrice" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblSalvageValue" Text="Salvage Value:" runat="server"></asp:Label><asp:TextBox ID="txtSalvageValue" runat="server" CssClass="form-control" ></asp:TextBox></div>

    <h3>Fire Modes</h3>
    <div class="form-group"><asp:Label ID="lblSingle" Text="Single:" runat="server"></asp:Label><asp:Checkbox ID="chkSingle" runat="server" CssClass="form-control" ></asp:Checkbox></div>
    <div class="form-group"><asp:Label ID="lblBurst" Text="Burst:" runat="server"></asp:Label><asp:Checkbox ID="chkBurst" runat="server" CssClass="form-control" ></asp:Checkbox></div>
    <div class="form-group"><asp:Label ID="lblAuto" Text="Auto:" runat="server"></asp:Label><asp:Checkbox ID="chkAuto" runat="server" CssClass="form-control" ></asp:Checkbox></div>
   

    
    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click"/>
    <asp:Button ID="btnFlag" runat="server" Text="Flag" CssClass="btn btn-warning" OnClick="btnFlag_Click"/>
</asp:Content>
