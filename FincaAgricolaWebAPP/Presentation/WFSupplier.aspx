<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFSupplier.aspx.cs" Inherits="Presentation.WFSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestion de Proveedores</h1>
    <%--Id--%>
    <asp:HiddenField ID="HFSupplierId" runat="server" />
    <%--Nit--%>
    <div class="form-floating">
        <asp:TextBox ID="TBNit" runat="server" class="form-control" placeholder="Ingrese un NIT"></asp:TextBox>
        <label>Ingrese un NIT</label>
    </div>
    <%--Nombre--%>
    <div class="form-floating">
        <asp:TextBox ID="TBName" runat="server" class="form-control" placeholder="Ingresa un NIT"></asp:TextBox>
        <label>Nombre de Proveedor</label>
    </div>
    <%--DDL FInca--%>
    <div class="form-floating">
        <asp:DropDownList ID="DDLFarm" runat="server" class="form-select" aria-label="Floating label select example"></asp:DropDownList>
    </div>
    <asp:Button ID="BtnSave" runat="server" Text="Guardar" class="btn btn-success" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="BtnUpdate_Click" />
    <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
    <br />
    <asp:GridView ID="GVSupplier" runat="server" DataKeyNames="pro_id" AutoGenerateColumns="False" CellPadding="4" OnSelectedIndexChanged="GVSupplier_SelectedIndexChanged" OnRowDeleting="GVSupplier_RowDeleting">
        <Columns>
            <asp:BoundField DataField="pro_id" HeaderText="id" />
            <asp:BoundField DataField="pro_nit" HeaderText="NIT" />
            <asp:BoundField DataField="pro_nombre" HeaderText="Nombre de Proveedor" />
            <asp:BoundField DataField="tbl_finca_fin_id" HeaderText="Id Finca" />
            <asp:BoundField DataField="fin_nombre" HeaderText="Nombre de Finca" />
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
