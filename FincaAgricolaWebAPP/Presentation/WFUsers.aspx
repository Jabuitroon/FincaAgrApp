<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFUsers.aspx.cs" Inherits="Presentation.WFUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Crea un usuario</h2>
    <%--Id--%>
    <asp:HiddenField ID="HFUsersId" runat="server" />
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

    <%--Rol--%>
    <div class="form-floating">
        <asp:TextBox ID="TBRol" runat="server" class="form-control" placeholder="Ingresa tu Rol"></asp:TextBox>
        <label>Rol</label>
    </div>



    <asp:Button ID="BtnSave" runat="server" Text="Guardar" class="btn btn-success" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar"  class="btn btn-primary" OnClick="BtnUpdate_Click" />
    <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
    <%-- Agregando nombres en las columnas para identificarlos en el front--%>
    <asp:GridView ID="GVUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="usu_id" OnSelectedIndexChanged="GVUsers_SelectedIndexChanged" OnRowDeleting="GVUsers_RowDeleting">
        <Columns>
            <asp:BoundField DataField="usu_id" HeaderText="Id" />
            <asp:BoundField DataField="usu_nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="usu_correo" HeaderText="Correo" />
            <asp:BoundField DataField="usu_contrasena" HeaderText="Contraseña" />
            <asp:BoundField DataField="usu_rol" HeaderText="Rol" />
            <asp:CommandField ShowSelectButton="true" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
