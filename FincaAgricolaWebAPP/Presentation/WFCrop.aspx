<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCrop.aspx.cs" Inherits="Presentation.WFCrop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Cultivos</h1>
    <div>
        <%--Id--%>
        <asp:HiddenField ID="HFCultivolId" runat="server" />

        <%--Riego de Cultivo--%>
        <a href="WFIrrigation.aspx">
            <span class="material-icons-sharp">Riego de Cultivos
            </span>
        </a>
        <%--Nombre Cultivo--%>
        <div class="form-floating">
        <asp:TextBox runat="server" class="form-control" placeholder="Ingrese nombre del cultivo" ID="TBNombre"></asp:TextBox>
        <Label>Ingrese nombre del cultivo</Label>
        </div>
        <%--Descripción--%>
        <div class="form-floating">
        <asp:TextBox runat="server" class="form-control" placeholder="Ingrese la descripción" ID="TBDescripcion"></asp:TextBox>
        <Label>Ingrese la descripción</Label>
        </div>
        <%--fKParcela--%>
        <div class="form-floating">
            <asp:Label ID="Label6" runat="server" Text="Parcela ubicación"></asp:Label>
            <asp:DropDownList ID="DDLParcel" runat="server" class="form-select" aria-label="Floating label select example"></asp:DropDownList>
        </div>
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" class="btn btn-success" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />
        <%--Lista de Cultivos--%>
        <asp:GridView ID="GVCrop" runat="server" DataKeyNames="cultivo_id" AutoGenerateColumns="false" OnSelectedIndexChanged="GVCrop_SelectedIndexChanged" OnRowDeleting="GVCrop_RowDeleting">
            <Columns>
                <asp:BoundField DataField="cultivo_id" HeaderText="Id" />
                <asp:BoundField DataField="cul_nombre" HeaderText="Nombre del Cultivo" />
                <asp:BoundField DataField="cul_descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="tbl_parcela_par_id" HeaderText="Parcela Id" />
                <asp:BoundField DataField="Parcela_ubicacion" HeaderText="Ubicacion Parcela" />
                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                <asp:BoundField></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
