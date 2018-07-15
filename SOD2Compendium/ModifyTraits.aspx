<%@ Page Title="Modify Trait" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyTraits.aspx.cs" Inherits="SOD2Compendium.ModifyTraits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="hlScreenshot" runat="server">View Screenshot</asp:HyperLink>
     <h1 runat="server" id="lblMainHeader" name ="lblMainHeader"></h1>
    <div class="form-group"><asp:Label ID="lblName" Text="Name:" runat="server"></asp:Label><asp:TextBox ID="txtName" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblDescription" Text="Description:" runat="server"></asp:Label><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblNotes" Text="Notes:" runat="server"></asp:Label><asp:TextBox ID="txtNotes" runat="server" CssClass="form-control"  TextMode="MultiLine" Rows="10"></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblScreenshot" Text="Screenshot URL:" runat="server"></asp:Label><asp:TextBox ID="txtScreenshot" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblLinkedHeroBonus" Text="Linked Hero Bonus:" runat="server"></asp:Label><asp:DropDownList ID="cmbLinkedHeroBonus" runat="server" CssClass="form-control" ></asp:DropDownList></div>

    <h3>Effects<a href="ModifyTraitEffects.aspx?TID=<%=Request.QueryString["ID"]%>&EID=-1"><span style="margin:4px" class="glyphicon glyphicon-plus"></span></a></h3>
    <asp:Repeater ID="rptEffects" runat="server">
        <ItemTemplate>
            <%# (Container.DataItem as SOD2Compendium.Classes.TraitEffect).Text%><a href="ModifyTraitEffects.aspx?TID=<%=Request.QueryString["ID"]%>&EID=<%# (Container.DataItem as SOD2Compendium.Classes.TraitEffect).intTraitEffectID%>"><span style="margin:4px" class=" glyphicon glyphicon-pencil"></span></a><br />
        </ItemTemplate>

    </asp:Repeater>

    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click"/>
    <asp:Button ID="btnFlag" runat="server" Text="Flag" CssClass="btn btn-warning" OnClick="btnFlag_Click"/>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>

</asp:Content>
