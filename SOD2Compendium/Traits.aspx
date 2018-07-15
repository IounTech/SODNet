<%@ Page Title="Traits" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Traits.aspx.cs" Inherits="SOD2Compendium.Traits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Traits<a href="ModifyTraits.aspx?ID=-1"><span style="margin:4px" class="glyphicon glyphicon-plus"></span></a></h1>
    <asp:TextBox ID="txtSearch" runat="server" placeholder="Search Traits..."></asp:TextBox><br />
    <asp:CheckBox ID="chkMissingScreenshots" runat="server" Text="Missing Screenshots" AutoPostBack="true"/>
    <table class="table table-bordered">
        <tr><td><b>Name</b></td><td><b>Effects</b></td><td><b>Description</b></td></b></tr>
        <asp:Repeater ID="rptTraits" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                      <a class="traitname" href="ModifyTraits.aspx?ID=<%#  (Container.DataItem as SOD2Compendium.Classes.Trait).intID %>">  <%# (Container.DataItem as SOD2Compendium.Classes.Trait).strName %></a>
                    </td>
                    <td>
                        <asp:Repeater ID="rptTraitEffects" runat="server" DataSource="<%#(Container.DataItem as SOD2Compendium.Classes.Trait).Effects.Values %>">
                            <ItemTemplate>
                                <%# (Container.DataItem as SOD2Compendium.Classes.TraitEffect).Text %>
                                <br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.Trait).strDescription %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <script>
       
        $(document).ready(function () {
             var strText = $('#<%= txtSearch.ClientID %>').val();
                 $('.traitname').parent().parent().show();
                 $(".traitname:not(:contains('" + strText + "'))").parent().parent().hide();

            // NEW selector
            jQuery.expr[':'].Contains = function (a, i, m) {
                return jQuery(a).text().toUpperCase()
                    .indexOf(m[3].toUpperCase()) >= 0;
            };

            // OVERWRITES old selecor
            jQuery.expr[':'].contains = function (a, i, m) {
                return jQuery(a).text().toUpperCase()
                    .indexOf(m[3].toUpperCase()) >= 0;
            };
             $('#<%= txtSearch.ClientID %>').on('keyup', function(){
                 var strText = $('#<%= txtSearch.ClientID %>').val();
                 $('.traitname').parent().parent().show();
                 $(".traitname:not(:contains('" + strText + "'))").parent().parent().hide();

             });
    });
    </script>
</asp:Content>
