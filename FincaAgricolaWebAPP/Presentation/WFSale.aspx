<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFSale.aspx.cs" Inherits="Presentation.WFSale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Ventas</h1>
    <div>
        <%--Id--%>
        <asp:HiddenField ID="HFSaleId" runat="server" />
        <%--Fecha--%>
        <asp:Label ID="Label1" runat="server" Text="Agrega una Fecha de Venta"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Calendar ID="Calendar" runat="server" Height="55px" Width="353px"></asp:Calendar>
        <br />
        <%--fKProductoId--%>
        <div class="form-floating">
        <asp:DropDownList ID="DDLProcucts" runat="server" class="form-select" aria-label="Floating label select example"></asp:DropDownList>
        </div>
        <%--fKCliente--%>
        <div class="form-floating">
        <asp:DropDownList ID="DDLClients" runat="server" class="form-select" aria-label="Floating label select example"></asp:DropDownList>
        </div>
        <%--Total--%>
        <asp:Label ID="Label2" runat="server" Text="Total"></asp:Label>
        <asp:TextBox ID="TBTotal" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="BtnSave" runat="server" Text="Vender" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />
        <asp:GridView ID="GVSale" runat="server" DataKeyNames="Venta ID" OnRowDeleting="GVSale_RowDeleting" OnSelectedIndexChanged="GVSale_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
            </Columns>
        </asp:GridView>
</asp:Content>
