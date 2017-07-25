<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClient.Default" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
        <table style="width:80%;align-self:center">
          <tr>
            <td><h3>Get All Available Products</h3></td>
            <td><h3>Get Certain Product</h3>&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            <td><h3>Delete Certain Product</h3></td>
            <td><h3>Create New Product</h3></td>
                          <td><h3>Get sth</h3></td>
          </tr>
          <tr>
            <td><asp:Button ID="ButtonGetAllProducts" runat="server" Text="Get Products" OnClick="Button_GetAllProducts_Click" /></td>
            <td><asp:Button ID="ButtonGetProductbyId" runat="server" Text="Get Product" OnClick="Button_GetProductbyId_Click" /></td> 
            <td><asp:Button ID="ButtonDeleteProduct" runat="server" Text="Delete Product" OnClick="Button_DeleteProduct_Click" /></td> 
           <td><asp:Button ID="ButtonCreateProduct" runat="server" Text="Create Product" OnClick="Button_CreateProduct_Click" /></td> 
                    <td><asp:Button ID="Button1" runat="server" Text="sth " OnClick="Button1_Click" /></td> 
               </tr>
          <tr>
            <td><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                          <td><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
          </tr>
        </table>

        
   


            <br/>
            <br/>
            <br/>

        <%--<asp:Button ID="btnGetAllProducts" runat="server" Text="Get Products" OnClick="btnGetAllProducts_Click" />--%>
            


    </div>
        </form>
</body>
</html>
