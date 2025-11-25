<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormVehiculo.aspx.vb" Inherits="ControlVehiculos.FormVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:hiddenField ID="editando" runat="server" />

    <div class="container d-flex flex-column mb-3 gap-2">
        <asp:DropDownList ID="Ddl_personas" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione Persona" Value="" />
        </asp:DropDownList>
      
        <asp:TextBox ID="Txt_marca" Placeholder="Marca" runat="server"></asp:TextBox>
        <asp:TextBox ID="Txt_modelo" Placeholder="Modelo" runat="server"></asp:TextBox> 
        <asp:TextBox ID="Txt_placa" Placeholder="Placa" runat="server"></asp:TextBox>
        <asp:TextBox ID="Txt_idPropietario" Placeholder="IdPropietario" runat="server"></asp:TextBox>

         <asp:Button ID="Btn_guardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="Btn_guardar_Click" />
         <asp:Button ID="BtnActualizar" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="BtnActualizar_Click" />
         <asp:Button ID="Btn_Cancelar" CssClass="btn btn-secondary btn-hover-move" runat="server" Text="Cancelar" OnClick="Btn_Cancelar_Click" />
        <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>
    </div>

    <asp:GridView ID="Gv_vehiculos" runat="server" CssClass="table" AutoGenerateColumns="False" DataKeyNames="idVehiculo" DataSourceID="SqlDataSourceVehiculos" Width="742px"
        OnRowDeleting="Gv_vehiculos_RowDeleting" 
        OnRowEditing="Gv_vehiculos_RowEditing" 
        OnRowCancelingEdit="Gv_vehiculos_RowCancelingEdit" 
        OnRowUpdating="Gv_vehiculos_RowUpdating" 
        OnSelectedIndexChanged="Gv_vehiculos_SelectedIndexChanged" >

        <Columns>
            <asp:CommandField ShowSelectButton="true"  ControlStyle-CssClass="btn btn-success" />
            <asp:BoundField DataField="IdVehiculo" Visible="false" HeaderText="IdVehiculo" ReadOnly="True" SortExpression="IdVehiculo" />
            <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
            <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" />
            <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa" />
            <asp:CommandField ShowEditButton="True"  ControlStyle-CssClass="btn btn-primary" />
            <asp:CommandField ShowdeleteButton="True"  ControlStyle-CssClass="btn btn-danger" />
            </Columns>
        </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceVehiculos" runat="server"
        ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:II-46ConnectionString.ProviderName %>" 
        SelectCommand="SELECT * FROM [Vehiculos]"></asp:SqlDataSource>
</asp:Content>
