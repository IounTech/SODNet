<%@ Page Title="Items" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="SOD2Compendium.Items" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Items<a href="ModifyItem.aspx?ID=-1"><span style="margin:4px" class="glyphicon glyphicon-plus"></span></a></h1>
    
    <table class="table table-bordered">
        <tr><td>Name</td><td>Type</td><td>Value</td></tr>
        <asp:Repeater ID="rptItems" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                      <a href="ModifyItem.aspx?ID=<%#  (Container.DataItem as SOD2Compendium.Classes.Item).intID %>"><%# (Container.DataItem as SOD2Compendium.Classes.Item).strName %> </a>
                    </td>
                    <td>
                      <%# (Container.DataItem as SOD2Compendium.Classes.Item).strType %>
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.Item).intInfluenceSellValue %> 
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
