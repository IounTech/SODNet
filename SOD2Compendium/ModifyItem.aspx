<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyItem.aspx.cs" Inherits="SOD2Compendium.ModifyItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="hlScreenshot" runat="server">View Screenshot</asp:HyperLink>  
    <div class="form-group"><asp:Label ID="lblName" Text="Name:" runat="server"></asp:Label><asp:TextBox ID="txtName" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox></div>
    
    <div class="form-group"><asp:Label ID="lblDescription" Text="Description:" runat="server"></asp:Label><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox></div>
    
    <div class="form-group"><asp:Label ID="lblNotes" Text="Notes:" runat="server"></asp:Label><asp:TextBox ID="txtNotes" runat="server" CssClass="form-control"  TextMode="MultiLine" Rows="10"></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblType" Text="Type:" runat="server"></asp:Label><asp:TextBox ID="txtType" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblMaxLockerStackSize" Text="Max Locker Stack Size:" runat="server"></asp:Label><asp:TextBox ID="txtMaxLockerStackSize" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblMaxInventoryStackSize" Text="Max Inventory Stack Size:" runat="server"></asp:Label><asp:TextBox ID="txtMaxInventoryStackSize" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblScreenshot" Text="Screenshot URL:" runat="server"></asp:Label><asp:TextBox ID="txtScreenshot" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblWeight" Text="Weight:" runat="server"></asp:Label><asp:TextBox ID="txtWeight" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblIsConsumable" Text="Is Consumable:" runat="server"></asp:Label><asp:Checkbox ID="chkIsConsumable" runat="server" CssClass="form-control" ></asp:Checkbox></div>
    <div class="form-group"><asp:Label ID="lblIsBaseResource" Text="Base Resource:" runat="server"></asp:Label><asp:Checkbox ID="ckhIsBaseResource" runat="server" CssClass="form-control" ></asp:Checkbox></div>
    <div class="form-group"><asp:Label ID="lblBuyPrice" Text="Buy Price:" runat="server"></asp:Label><asp:TextBox ID="txtBuyPrice" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblSellPrice" Text="Sell Price:" runat="server"></asp:Label><asp:TextBox ID="txtSellPrice" runat="server" CssClass="form-control" ></asp:TextBox></div>


    
   <%-- <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" OnClick="btnSave_Click"/>--%>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click"/>
    <asp:Button ID="btnFlag" runat="server" Text="Flag" CssClass="btn btn-warning" OnClick="btnFlag_Click"/>
</asp:Content>
