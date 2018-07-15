<%@ Page Title="Hero Bonuses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HeroBonuses.aspx.cs" Inherits="SOD2Compendium.HeroBonuses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Hero Bonuses<a href="ModifyHeroBonus.aspx?ID=-1"><span style="margin:4px" class="glyphicon glyphicon-plus"></span></a></h1>
    
    <table class="table table-bordered">
        <tr><td>Name</td><td>Effects</td><td>Description</td></tr>
        <asp:Repeater ID="rptHeroBonuses" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                      <a href="ModifyHeroBonus.aspx?ID=<%#  (Container.DataItem as SOD2Compendium.Classes.HeroBonus).intID %>"><%# (Container.DataItem as SOD2Compendium.Classes.HeroBonus).strName %> </a>
                    </td>
                    <td>
                      <%# (Container.DataItem as SOD2Compendium.Classes.HeroBonus).strEffects %>
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.HeroBonus).strDescription %> 
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
