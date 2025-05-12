<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFWeather.aspx.cs" Inherits="Presentation.WFWeather" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestión de clima</h1>
    <div>
        <%--Id--%>
        <asp:HiddenField ID="HFWhatherId" runat="server" />

        <%--Temperatura--%>
        <div class="form-floating">
        <asp:TextBox runat="server" class="form-control" placeholder="Ingresa una Temperatura" ID="TBTemperatra"></asp:TextBox>
        <Label>Ingrese la temperatura</Label>
        </div>

        <%--humedad--%>
        <div class="form-floating">
        <asp:TextBox runat="server" class="form-control" placeholder="Ingresa una Humedad" ID="TBHumedad"></asp:TextBox>
        <Label  runat="server">Ingrese la humedad</Label>
        </div>

        <asp:Button ID="BtnSave" runat="server" Text="Guardar" class="btn btn-success" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="BtnUpdate_Click" />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />
        
        <%--Lista de Climas--%>
    <asp:GridView ID="GVWeather" runat="server" DataKeyNames="clim_id" AutoGenerateColumns="false" OnSelectedIndexChanged="GVWeather_SelectedIndexChanged" OnRowDeleting="GVWeather_RowDeleting">
            <Columns>
                <asp:BoundField DataField="clim_id" HeaderText="Id" />
                <asp:BoundField DataField="clim_temperatura" HeaderText="Temperatura" />
                <asp:BoundField DataField="clim_humedad" HeaderText="Humedad" />
                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                <asp:BoundField></asp:BoundField>

            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
