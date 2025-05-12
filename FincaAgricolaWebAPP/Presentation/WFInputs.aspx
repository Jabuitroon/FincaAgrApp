<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFInputs.aspx.cs" Inherits="Presentation.WFInputs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Crea un Insumo</h2>
    <%--Id--%>
    <asp:HiddenField ID="HFInputsId" runat="server" />
    <%--Nombre--%>
    <div class="form-floating">
        <asp:TextBox ID="TBName" runat="server" class="form-control" placeholder="Ingresa tu Nombre"></asp:TextBox>
        <label>Nombre</label>
    </div>
    <%--Tipo--%>
    <div class="form-floating">
        <asp:TextBox ID="TBTipo" runat="server" class="form-control" placeholder="Ingrese el tipo"></asp:TextBox>
        <label>Tipo</label>
    </div>

    <%--Cantidad--%>
    <div class="form-floating">
        <asp:TextBox ID="TBQuantity" runat="server" class="form-control" placeholder="Ingrese la cantidad"></asp:TextBox>
        <label>Cantidad</label>
    </div>
    <%--FkCultivo--%>
    <div class="form-floating">
        <asp:Label ID="Label1" runat="server" Text="Seleccione el cultivo"></asp:Label>
        <asp:DropDownList ID="DDLCrops" runat="server" class="form-select"></asp:DropDownList>
    </div>
    <%--FkParcela--%>
    <div class="form-floating">
        <asp:Label ID="Label6" runat="server" Text="Seleccione la parcela"></asp:Label>
        <asp:DropDownList ID="DDLParcela" runat="server" class="form-select"></asp:DropDownList>
    </div>
    <asp:Button ID="BtnSave" runat="server" Text="Guardar" class="btn btn-success" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="BtnUpdate_Click" />
    <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
    <br />
    <div>
        <asp:GridView ID="GVInputs" runat="server" AutoGenerateColumns="False" DataKeyNames="ins_id" OnSelectedIndexChanged="GVInputs_SelectedIndexChanged" OnRowDeleting="GVInputs_RowDeleting">
            <Columns>
                <asp:BoundField DataField="ins_id" HeaderText="Id" />
                <asp:BoundField DataField="ins_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="ins_tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="ins_cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="tbl_cultivo_cul_id" HeaderText="Cultivo Id" />
                <asp:BoundField DataField="tbl_cultivo_tbl_parcela_par_id" HeaderText="Parcela Id" />
                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
