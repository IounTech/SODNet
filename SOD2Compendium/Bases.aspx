<%@ Page Title="Bases" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bases.aspx.cs" Inherits="SOD2Compendium.Bases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Bases<a href="ModifyBase.aspx?ID=-1"><span style="margin:4px" class="glyphicon glyphicon-plus"></span></a></h1>
    
    <table class="table table-bordered">
        <tr><td>Name</td><td>Map</td><td>Price</td><td>Survivors</td><td>Total Slots</td></tr>
        <asp:Repeater ID="rptBases" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                      <a href="ModifyBase.aspx?ID=<%#  (Container.DataItem as SOD2Compendium.Classes.Base).intID %>">   <%# (Container.DataItem as SOD2Compendium.Classes.Base).strName %></a>
                    </td>
                    <td>
                      <%# (Container.DataItem as SOD2Compendium.Classes.Base).clsMap.strName %>
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.Base).intInfluenceCost %> 
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.Base).intSurvivorsRequired %> 
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.Base).TotalSlots %> 
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
