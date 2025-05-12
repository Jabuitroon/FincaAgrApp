<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCategory.aspx.cs" Inherits="Presentation.WFCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Crea una Categoría</h2>
    <%--Id--%>
    <asp:HiddenField ID="HFCategoryId" runat="server" />
    <%--Nombre--%>
    <div class="form-floating">
        <asp:TextBox ID="TBName" runat="server" class="form-control" placeholder="Ingresa un Nombre"></asp:TextBox>
        <label>Ingresa un nombre</label>
    </div>
    <%--Ubicación--%>
    <div class="form-floating">
        <asp:TextBox ID="TBDescription" runat="server" class="form-control" placeholder="Ingresa un Nombre"></asp:TextBox>
        <label>Descripción</label>
    </div>
    <asp:Button ID="BtnSave" runat="server" Text="Guardar" class="btn btn-success" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="BtnUpdate_Click" />
    <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GVCategory" runat="server" AutoGenerateColumns="False" DataKeyNames="cat_id" OnSelectedIndexChanged="GVFarm_SelectedIndexChanged" OnRowDeleting="GVFarm_RowDeleting">
        <Columns>
            <asp:BoundField DataField="cat_id" HeaderText="Id" />
            <asp:BoundField DataField="cat_nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="cat_descripcion" HeaderText="Descripción" />
            <asp:CommandField ShowSelectButton="true" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
