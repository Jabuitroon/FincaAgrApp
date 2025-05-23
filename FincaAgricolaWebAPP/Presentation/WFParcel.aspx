﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFParcel.aspx.cs" Inherits="Presentation.WFParcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de Parcela</h1>
        <%--Id--%>
        <asp:HiddenField ID="HFParcelId" runat="server" />

        <%--Dimensiones--%>
        <div class="form-floating">
            <asp:TextBox runat="server" class="form-control" placeholder="Ingrese las dimensiones" ID="TBDimensiones"></asp:TextBox>
            <label>Ingrese las dimensiones</label>
        </div>

        <%--Ubicación--%>
        <div class="form-floating">
            <asp:TextBox runat="server" class="form-control" placeholder="Ingrese la ubicación" ID="TBUbicacion"></asp:TextBox>
            <label>Ingrese la ubicación</label>
        </div>
        <%--Temperatura--%>
        <div class="form-floating">
            <asp:TextBox runat="server" class="form-control" placeholder="Temperatura" ID="TBTemperatura"></asp:TextBox>
            <label>Temperatura</label>
        </div>
        <%--Humedad--%>
        <div class="form-floating">
            <asp:TextBox runat="server" class="form-control" placeholder="Humedad" ID="TBHumedad"></asp:TextBox>
            <label>Humedad</label>
        </div>
            <%--fKFinca--%>
            <div class="form-floating">
                <asp:Label ID="Label6" runat="server" Text="Finca"> Seleccione una finca</asp:Label>
                <asp:DropDownList ID="DDLFarm" runat="server" class="form-select" aria-label="Floating label select example"></asp:DropDownList>
            </div>
            <asp:Button ID="BtnSave" runat="server" Text="Guardar" class="btn btn-success" OnClick="BtnSave_Click" />
            <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="BtnUpdate_Click" />
            <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
            <%--Lista de Parcelas--%>
            <asp:GridView ID="GVParcel" runat="server" DataKeyNames="parcela_id" AutoGenerateColumns="false" OnSelectedIndexChanged="GVParcel_SelectedIndexChanged" OnRowDeleting="GVParcel_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="parcela_id" HeaderText="Id" />
                    <asp:BoundField DataField="par_dimensiones" HeaderText="Dimensiones" />
                    <asp:BoundField DataField="par_ubicacion" HeaderText="Ubicación" />
                    <asp:BoundField DataField="par_temperatura" HeaderText="Temperatura" />
                    <asp:BoundField DataField="par_humedad" HeaderText="Humedad" />
                    <asp:BoundField DataField="tbl_finca_fin_id" HeaderText="Finca Id" />
                    <asp:BoundField DataField="Finca_nombre" HeaderText="Nombre de la finca" />
                    <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                    <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                </Columns>
            </asp:GridView>
</asp:Content>
