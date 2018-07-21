<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyMod.aspx.cs" Inherits="SOD2Compendium.ModifyMod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Mod</h1>
    <div class="form-group"><asp:Label ID="lblName" Text="Name:" runat="server"></asp:Label><asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblDescription" Text="Description:" runat="server"></asp:Label><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox></div>
    
    <div class="form-group"><asp:Label ID="lblScreenshot" Text="Screenshot URL:" runat="server"></asp:Label><asp:TextBox ID="txtScreenshot" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblFilesToAdd" Text="Files to Add:" runat="server"></asp:Label><asp:FileUpload ID="fuModFiles" runat="server" CssClass="form-control-file"/></div>

    <div class="form-group"><asp:Label ID="Label1" Text="Only used if adding new files:" runat="server"></asp:Label></div>

     <div class="form-group"><asp:Label ID="lblFileVersion" Text="File Version:" runat="server"></asp:Label><asp:TextBox ID="txtFileVersion" runat="server"  CssClass="form-control" ></asp:TextBox></div>
    <div class="form-group"><asp:Label ID="lblFileDescription" Text="File Description:" runat="server"></asp:Label><asp:TextBox ID="txtFileDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox></div>


    <table class="table table-bordered">
        <tr><td>Name</td><td>Version</td><td>Description</td><td>Save</td><td>Delete</td></tr>
        <asp:Repeater ID="rptFiles" runat="server" OnItemCommand="rptFiles_ItemCommand">
            <ItemTemplate>
                <tr>
                    
                    <td>
                    <%# (Container.DataItem as SOD2Compendium.Classes.ModFile).strName %>
                    </td>
                    <td>
                      <asp:TextBox ID="txtVersion" runat="server" Text="<%# (Container.DataItem as SOD2Compendium.Classes.ModFile).strVersion %>"></asp:TextBox>
                    </td>
                    <td>
                       <asp:TextBox ID="txtDescription" runat="server" Text=" <%# (Container.DataItem as SOD2Compendium.Classes.ModFile).strDescription %> "></asp:TextBox>
                    </td>
                    <td>
                      <asp:LinkButton ID="btnSave" runat="server" Text="Save" CommandName="Save" CommandArgument="<%# (Container.DataItem as SOD2Compendium.Classes.ModFile).intID %>" CssClass="btn btn-success" OnClick="btnSave_Click1"/>
                    </td>
                    <td>
                      <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument="<%# (Container.DataItem as SOD2Compendium.Classes.ModFile).intID %>" CssClass="btn btn-danger" OnClick="btnDelete_Click1"/>
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    
    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click"/>
   

</asp:Content>
