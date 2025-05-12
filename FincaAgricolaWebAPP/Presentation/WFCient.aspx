<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCient.aspx.cs" Inherits="Presentation.WFCient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestion Clientes</h1>

    <div>
        <%--Id--%>
        <asp:HiddenField ID="HFClientId" runat="server" />


        <%--Nombre--%>
        <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre"></asp:Label>
        <asp:TextBox ID="TBName" runat="server"></asp:TextBox>
        <br />

        <%--Correo--%>
        <asp:Label ID="Label2" runat="server" Text="Ingrese el correo"></asp:Label>
        <asp:TextBox ID="TBEmail" runat="server"></asp:TextBox>


        <%--Contraseña--%>
        <asp:Label ID="Label4" runat="server" Text="Ingrese la contraseña"></asp:Label>
        <asp:TextBox ID="TBPassword" runat="server"></asp:TextBox>
        <br />


        <%--Direccion--%>
        <asp:Label ID="Label5" runat="server" Text="Ingrese la direccion"></asp:Label>
        <asp:TextBox ID="TBLocation" runat="server"></asp:TextBox>
        <br />


        <%--Ciudad--%>
        <asp:Label ID="Label6" runat="server" Text="Seleccione la ciudad"></asp:Label>
        <asp:TextBox ID="TBCity" runat="server"></asp:TextBox>
        <br />


       


        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />

        <%--Lista de Clientes--%>
        <asp:GridView ID="GVClient" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVProducts_SelectedIndexChanged1">
            <columns>
                <asp:BoundField DataField="cli_id" HeaderText="Id" />
                <asp:BoundField DataField="cli_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="cli_correo" HeaderText="Correo" />
                <asp:BoundField DataField="cli_contraseña" HeaderText="Contraseña" />
                <asp:BoundField DataField="cli_direccion" HeaderText="Direccion" />
                <asp:BoundField DataField="cli_ciudad" HeaderText="Ciudad" />
                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
            </columns>
        </asp:GridView>

    </div>
</asp:Content>
