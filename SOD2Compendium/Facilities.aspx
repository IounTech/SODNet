<%@ Page Title="Facilities" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Facilities.aspx.cs" Inherits="SOD2Compendium.Facilitys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Facilities<a href="ModifyFacility.aspx?ID=-1"><span style="margin:4px" class="glyphicon glyphicon-plus"></span></a></h1>
    
    <table class="table table-bordered">
        <tr><td>Name</td><td>Size</td><td>Indoor</td><td>Outdoor</td><td>Description</td></tr>
        <asp:Repeater ID="rptFacilities" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                      <a href="ModifyFacility.aspx?ID=<%#  (Container.DataItem as SOD2Compendium.Classes.Facility).intID %>">   <%# (Container.DataItem as SOD2Compendium.Classes.Facility).strName %></a>
                    </td>
                     <td>
                      <%# (Container.DataItem as SOD2Compendium.Classes.Facility).clsSize.strName %>
                    </td>
                    <td>
                      <%# (Container.DataItem as SOD2Compendium.Classes.Facility).blnCanBePlacedIndoors %>
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.Facility).blnCanBePlacedOutdoors %> 
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.Facility).strDescription %> 
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
