<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyMod.aspx.cs" Inherits="SOD2Compendium.ModifyMod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Mod</h1>
    <div class="form-group"><asp:Label ID="lblName" Text="Name:" runat="server"></asp:Label><asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblDescription" Text="Description:" runat="server"></asp:Label><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox></div>
    
    <div class="form-group"><asp:Label ID="lblScreenshot" Text="Screenshot URL:" runat="server"></asp:Label><asp:TextBox ID="txtScreenshot" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="Label1" Text="Files to Add:" runat="server"></asp:Label><asp:FileUpload ID="fuModFiles" runat="server" CssClass="form-control-file"/></div>

    

    <table class="table table-bordered">
        <tr><td>Name</td><td>Version</td><td>Description</td><td>Delete</td></tr>
        <asp:Repeater ID="rptFiles" runat="server" OnItemCommand="rptFiles_ItemCommand">
            <ItemTemplate>
                <tr>
                    
                    <td>
                    <%# (Container.DataItem as SOD2Compendium.Classes.ModFile).strName %>
                    </td>
                    <td>
                      <%# (Container.DataItem as SOD2Compendium.Classes.ModFile).strVersion %>
                    </td>
                    <td>
                        <%# (Container.DataItem as SOD2Compendium.Classes.ModFile).strDescription %> 
                    </td>
                    <td>
                      <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument="<%# (Container.DataItem as SOD2Compendium.Classes.ModFile).intID %>" CssClass="btn btn-success" OnClick="btnDelete_Click1"/>
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    
    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click"/>
   

</asp:Content>
