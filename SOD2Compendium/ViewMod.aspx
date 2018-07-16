<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMod.aspx.cs" Inherits="SOD2Compendium.ViewMod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 runat="server" id="lblName"></h1>
    <asp:Image ID="imgScreenshot" runat="server" />
    <p runat="server" id="lblDescription"></p>

   <table class="table table-bordered">
        <tr><td>Name</td><td>Version</td><td>Description</td></tr>
        <asp:Repeater ID="rptFiles" runat="server" OnItemCommand="rptFiles_ItemCommand">
            <ItemTemplate>
                <tr>
                    
                    <td>
                    <asp:LinkButton ID="lbtnDownload" CommandName="Download" CommandArgument="<%# (Container.DataItem as SOD2Compendium.Classes.ModFile).intID %>" runat="server"><%# (Container.DataItem as SOD2Compendium.Classes.ModFile).strName %></asp:LinkButton>
                    </td>
                    <td>
                      <%# (Container.DataItem as SOD2Compendium.Classes.ModFile).strVersion %>
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.ModFile).strDescription %> 
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

</asp:Content>
