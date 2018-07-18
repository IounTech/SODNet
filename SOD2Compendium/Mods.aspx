<%@ Page Title="Mods" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mods.aspx.cs" Inherits="SOD2Compendium.Mods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h1>Mods<a href="AddMod.aspx"><span style="margin:4px" class="glyphicon glyphicon-plus"></span></a></h1>
    
    <table class="table table-bordered">
        <tr><td><b>Name</b></td><td><b>Description</b></td><td><b>Downloads</b></td></tr>
        <asp:Repeater ID="rptMods" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                      <a href="ViewMod.aspx?ID=<%#  (Container.DataItem as SOD2Compendium.Classes.Mod).intID %>"><%# (Container.DataItem as SOD2Compendium.Classes.Mod).strName %> </a>
                    </td>
                    <td>
                      <%# (Container.DataItem as SOD2Compendium.Classes.Mod).strDescription.Replace("|lb|", "<br/>") %>
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.Mod).intScore %> 
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
