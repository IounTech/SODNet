<%@ Page Title="Modify Base" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyBase.aspx.cs" Inherits="SOD2Compendium.ModifyBase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  

    <!-- strName -->
    <div class="form-group">
        <asp:Label ID="lblName" Text="Name:" runat="server"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <!-- intMapID -->
    <div class="form-group">
        <asp:Label ID="lblMap" Text="Map:" runat="server"></asp:Label>
        <asp:DropDownList ID="cmbMap" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>

    <!-- intSmallExternalEmptyCount -->
    <div class="form-group">
        <asp:Label ID="lblSmallExternalEmptyCount" Text="Small External Empty Count:" runat="server"></asp:Label>
        <asp:TextBox ID="txtSmallExternalEmptyCount" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <!-- intSmallInternalEmptyCount -->
    <div class="form-group">
        <asp:Label ID="lblSmallInternalEmptyCount" Text="Small Internal Empty Count:" runat="server"></asp:Label>
        <asp:TextBox ID="txtSmallInternalEmptyCount" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <!-- intParkingCount -->
    <div class="form-group">
        <asp:Label ID="lblParkingCount" Text="Parking Count:" runat="server"></asp:Label>
        <asp:TextBox ID="txtParkingCount" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <!-- intSizeID -->
    <div class="form-group">
        <asp:Label ID="lblSize" Text="Size:" runat="server"></asp:Label>
        <asp:DropDownList ID="cmbSize" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>

    <!-- intInfluenceCost -->
    <div class="form-group">
        <asp:Label ID="lblInfluenceCost" Text="Influence Cost:" runat="server"></asp:Label>
        <asp:TextBox ID="txtInfluenceCost" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <!-- intSurvivorsRequired -->
    <div class="form-group">
        <asp:Label ID="lblSurvivorsRequired" Text="Survivors Required:" runat="server"></asp:Label>
        <asp:TextBox ID="txtSurvivorsRequired" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <!-- intLargeEmptyCount -->
    <div class="form-group">
        <asp:Label ID="lblLargeEmptyCount" Text="Large Empty Count:" runat="server"></asp:Label>
        <asp:TextBox ID="txtLargeEmptyCount" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <!-- strLocationScreenshotLocation -->
    <div class="form-group">
        <asp:Label ID="lblLocationScreenshotLocation" Text="Location Screenshot Location:" runat="server"></asp:Label>
        <asp:TextBox ID="txtLocationScreenshotLocation" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <!-- strSlotsScreenshotLocation -->
    <div class="form-group">
        <asp:Label ID="lblSlotsScreenshotLocation" Text="SlotsScreenshotLocation:" runat="server"></asp:Label>
        <asp:TextBox ID="txtSlotsScreenshotLocation" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <h3>Prebuilt Facilities<a href="ModifyPrebuiltFacility.aspx?BID=<%=Request.QueryString["ID"]%>&PID=-1"><span style="margin:4px" class="glyphicon glyphicon-plus"></span></a></h3>

    <table class="table table-bordered">
        <tr>
            <td>
                Name
            </td>
                        <td>
                Acts As...
            </td>
                        <td>
                Notes
            </td>
        </tr>
    <asp:Repeater ID="rptPrebuilts" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                  <a href="ModifyPrebuiltFacility.aspx?BID=<%=Request.QueryString["ID"]%>&PID=<%#(Container.DataItem as SOD2Compendium.Classes.PrebuiltFacility).intID%>">   <%# (Container.DataItem as SOD2Compendium.Classes.PrebuiltFacility).strName %></a>
                </td>
                 <td>
                     <%# (Container.DataItem as SOD2Compendium.Classes.PrebuiltFacility).clsFacility.strName %>
                </td>
                 <td>
                     <%# (Container.DataItem as SOD2Compendium.Classes.PrebuiltFacility).strNotes %>
                </td>



            </tr>
        </ItemTemplate>
    </asp:Repeater>
        </table>
     <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click"/>
    <asp:Button ID="btnFlag" runat="server" Text="Flag" CssClass="btn btn-warning" OnClick="btnFlag_Click"/>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>
</asp:Content>
