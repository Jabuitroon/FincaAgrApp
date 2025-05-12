<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFClient.aspx.cs" Inherits="Presentation.WFClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Crea un Cliente</h2>
    <%--Id--%>
    <asp:HiddenField ID="HFClientId" runat="server" />

    <%--Nombre--%>
    <div class="form-floating">
        <asp:TextBox runat="server" class="form-control" placeholder="Ingresa un Nombre" ID="TBName"></asp:TextBox>
        <label>Ingresa un Nombre</label>
    </div>

    <%--Correo--%>
    <div class="form-floating">
        <asp:TextBox ID="TBEmail" runat="server" class="form-control" placeholder="Ingresa el correo"></asp:TextBox>
        <label>Correo</label>
    </div>
    <%--Contraseña--%>
    <div class="form-floating">
        <asp:TextBox ID="TBPassword" runat="server" class="form-control" placeholder="Ingresa la contraseña"></asp:TextBox>
        <label>Contraseña</label>
    </div>

    <%--Direccion--%>
    <div class="form-floating">
        <asp:TextBox ID="TBLocation" runat="server" class="form-control" placeholder="Elige tu Direccion"></asp:TextBox>
        <label>Direccion</label>
    </div>

    <%--Ciudad--%>
    <div class="form-floating">
        <asp:TextBox ID="TBCity" runat="server" class="form-control" placeholder="Elige tu Ciudad"></asp:TextBox>
        <label>Ciudad</label>
    </div>


    <asp:Button ID="Button1" runat="server" Text="Guardar" class="btn btn-success" OnClick="BtnSave_Click" />
    <asp:Button ID="Button2" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="BtnUpdate_Click" />
    <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>

    <%-- Agregando nombres en las columnas para identificarlos en el front--%>
    <asp:GridView ID="GVClient" runat="server" DataKeyNames="cli_id" AutoGenerateColumns="False" OnSelectedIndexChanged="GVClient_SelectedIndexChanged" OnRowDeleting="GVClient_RowDeleting">
        <Columns>
            <asp:BoundField DataField="cli_id" HeaderText="Id" />
            <asp:BoundField DataField="cli_nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="cli_correo" HeaderText="Correo" />
            <asp:BoundField DataField="cli_contrasena" HeaderText="Contraseña" />
            <asp:BoundField DataField="cli_direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="cli_ciudad" HeaderText="Ciudad" />
            <asp:CommandField ShowSelectButton="true" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
