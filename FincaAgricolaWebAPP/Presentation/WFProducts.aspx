<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFProducts.aspx.cs" Inherits="Presentation.WFProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Crea un Producto</h2>
    <%--Id--%>
    <asp:HiddenField ID="HFProductId" runat="server" />
    <%--Nombre--%>
    <div class="form-floating">
        <asp:TextBox ID="TBName" runat="server" class="form-control" placeholder="Ingresa un NIT"></asp:TextBox>
        <label>Nombre del Producto</label>
    </div>
    <%--Descripción--%>
    <div class="form-floating">
    <asp:TextBox ID="TBDescription" runat="server" class="form-control" placeholder="Ingresa una Descripción"></asp:TextBox>
    <Label runat="server">Descripción</Label>
    </div>
    <%--Cantidad inventario--%>
    <div class="form-floating">
    <asp:TextBox ID="TBCantidad" runat="server" class="form-control" placeholder="Ingresa Cantidad (Unds)"></asp:TextBox>
    <Label>Cantidad en Inventario (Unds)</Label>
    </div>
    <%--Contenido--%>
    <div class="form-floating">
    <asp:TextBox ID="TBContenido" runat="server" class="form-control" placeholder="Contenido de producto"></asp:TextBox>
    <Label>Contenido de producto</Label>
    </div>
    <%--Precio--%>
    <div class="form-floating">
    <asp:TextBox ID="TBPrecio" runat="server" class="form-control" placeholder="Ingresa Cantidad (Unds)"></asp:TextBox>
    <Label>Precio</Label>
    </div>
    <%--Imagen--%>
    <div class="form-floating">
    <asp:TextBox ID="TBImg" runat="server" class="form-control"></asp:TextBox>
    <Label>Añade una Imagen</Label>
    </div>
    <%--fkfinca--%>
    <div class="form-floating">
    <asp:DropDownList ID="DDLFinca" runat="server" class="form-select"></asp:DropDownList>
    </div>
    <%--fKCategoria--%>
    <div class="form-floating">
    <asp:DropDownList ID="DDLCategory" class="form-select" runat="server"></asp:DropDownList>
    </div>
    <asp:Button ID="BtnSave" runat="server" Text="Guardar" class="btn btn-success" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="BtnUpdate_Click" />
    <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GVPriducts" runat="server" DataKeyNames="producto_id" AutoGenerateColumns="False" OnSelectedIndexChanged="GVPriducts_SelectedIndexChanged" OnRowDeleting="GVProduct_RowDeleting">
        <Columns>
            <asp:BoundField DataField="producto_id" HeaderText="Id" />
            <asp:BoundField DataField="pro_nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="pro_descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="pro_cantidad_inventario" HeaderText="En inventario" />
            <asp:BoundField DataField="pro_contenido" HeaderText="Cantidad (Unds)" />
            <asp:BoundField DataField="pro_precio" HeaderText="Precio" />
            <asp:BoundField DataField="pro_img" HeaderText="LinkFoto" />
            <asp:BoundField DataField="Finca_ID" HeaderText="Finca ID" />
            <asp:BoundField DataField="Nombre_Finca" HeaderText="Nombre de Finca" />
            <asp:BoundField DataField="tbl_categoria_cat_id" HeaderText="Categoría Id" />
            <asp:BoundField DataField="cat_nombre" HeaderText="Nombre Categoría" />
            <asp:CommandField ShowSelectButton="true" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
