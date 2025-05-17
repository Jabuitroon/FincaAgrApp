<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFMachinery.aspx.cs" Inherits="Presentation.WFMachinery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TBId" runat="server"></asp:TextBox>
    <br />
    <h2>Crea una Maquinaria</h2>
    <%--Id--%>
    <asp:HiddenField ID="HFMachineryId" runat="server" />
    <%--Nombre--%>
    <div class="form-floating">
        <asp:TextBox ID="TBName" runat="server" class="form-control" placeholder="Ingresa tu Nombre"></asp:TextBox>
        <label>Nombre</label>
    </div>
    <%--Descripcion--%>
    <div class="form-floating">
        <asp:TextBox ID="TBDescription" runat="server" class="form-control" placeholder="Ingresa tu Descripcion"></asp:TextBox>
        <label>Descripcion</label>
    </div>
    <%--Clasisicacion--%>
    <div class="form-floating">
        <asp:TextBox ID="TBClassification" runat="server" class="form-control" placeholder="Ingrese la Clasificacion"></asp:TextBox>
        <label>Clasisicacion</label>
    </div>
    <%--FkCultivo--%>
    <div class="form-floating">
        <asp:Label ID="Label1" runat="server" Text="Seleccione el cultivo"></asp:Label>
        <asp:DropDownList ID="DDLCrops" runat="server" class="form-select" aria-label="Floating label select example"></asp:DropDownList>
    </div>
    <%--FkParcela--%>
    <div class="form-floating">
        <asp:Label ID="Label6" runat="server" Text="Seleccione la parcela"></asp:Label>
        <asp:DropDownList ID="DDLParcela" runat="server" class="form-select" aria-label="Floating label select example"></asp:DropDownList>
    </div>

    <asp:Button ID="BtnSave" runat="server" Text="Guardar" class="btn btn-success" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="BtnUpdate_Click" />
    <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
    <br />
    <div>
        <asp:GridView ID="GVMachinery" runat="server" AutoGenerateColumns="False" DataKeyNames="ma_id" OnSelectedIndexChanged="GVMachinery_SelectedIndexChanged" OnRowDeleting="GVMachinery_RowDeleting">
            <Columns>
                <asp:BoundField DataField="ma_id" HeaderText="Id" />
                <asp:BoundField DataField="ma_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="ma_descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="ma_clasificacion" HeaderText="Clasificacion" />
                <asp:BoundField DataField="cultivo_id" HeaderText="Cultivo ID" />
                <asp:BoundField DataField="cultivo_nombre" HeaderText="Nombre de Cultivo" />
                <asp:BoundField DataField="parcela_id" HeaderText="Parcela Id" />
                <asp:BoundField DataField="parcela_ubicacion" HeaderText="Ubicada en" />
                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
