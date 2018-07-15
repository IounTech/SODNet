<%@ Page Title="Guns" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Guns.aspx.cs" Inherits="SOD2Compendium.Guns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Guns<a href="ModifyGuns.aspx?ID=-1"><span style="margin:4px" class="glyphicon glyphicon-plus"></span></a></h1>
    
    <table class="table table-bordered">
        <tr><td>Name</td><td>Durability(0 = ?)</td><td>Ammo(Cap X Type)</td></tr>
        <asp:Repeater ID="rptGuns" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                      <a href="ModifyGuns.aspx?ID=<%#  (Container.DataItem as SOD2Compendium.Classes.Gun).intID %>" <%# (Container.DataItem as SOD2Compendium.Classes.Gun).blnRequiresModding == true ? "class=\"text-warning\"" : "" %>>  <%# (Container.DataItem as SOD2Compendium.Classes.Gun).strName %></a>
                    </td>
                    <td>
                      <%# (Container.DataItem as SOD2Compendium.Classes.Gun).intDurabilityInRounds %>
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.Gun).intCapacity %> x <%# (Container.DataItem as SOD2Compendium.Classes.Gun).clsAmmoType.strName %>
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
