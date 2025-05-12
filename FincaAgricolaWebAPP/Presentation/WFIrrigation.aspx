<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFIrrigation.aspx.cs" Inherits="Presentation.WFIrrigation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Gestión de Cultivos</h1>
<div>
    <%--Id--%>
    <asp:HiddenField ID="HFIrrigationId" runat="server" />

    <%--Tipo de Riego--%>
    <asp:Label ID="Label1" runat="server" Text="Tipo de Riego"></asp:Label>
    <asp:TextBox ID="TBType" runat="server"></asp:TextBox>
    <br />

    <%--Cantidad Agua--%>
    <asp:Label ID="Label2" runat="server" Text="Cantidad de Agua"></asp:Label>
    <asp:TextBox ID="TBWater" runat="server"></asp:TextBox>
    <br />

    <%--Frecuencia de Riego--%>
    <asp:Label ID="Label3" runat="server" Text="Frecuencia de Riego"></asp:Label>
    <asp:TextBox ID="TBFrequency" runat="server"></asp:TextBox>
    <br />

    <%--fKCultivo--%>
    <asp:Label ID="Label6" runat="server" Text="Cultivo"></asp:Label>
    <asp:DropDownList ID="DDLCrops" runat="server"></asp:DropDownList>
    <br />

    <%--fKParcela--%>
    <asp:Label ID="Label4" runat="server" Text="Parcela"></asp:Label>
    <asp:DropDownList ID="DDLParcela" runat="server"></asp:DropDownList>
    <br />

    <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
    <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
    <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
    <br />
    <asp:GridView ID="GVIrrigation" runat="server" DataKeyNames="rie_id" OnSelectedIndexChanged="GVIrrigation_SelectedIndexChanged" OnRowDeleting="GVIrrigation_RowDeleting">
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
