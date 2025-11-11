<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="ControlVehiculos.FormPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
    <asp:hiddenField ID="editando" runat="server" />

    <style>
         .btn-hover-move {
            transition: transform 0.5s ease, box-shadow 0.2s;
          }
         .btn-hover-move:hover{
            transform: translate(-4px) scale(1.04);
            box-shadow: 0 6px 18px rgb(0 148 255);
          }
    </style>

     <div class="container d-flex flex-column mb-3 gap-2"> 

  <asp:TextBox ID="Txt_nombre" Placeholder="Nombre" runat="server"></asp:TextBox>
  <asp:TextBox ID="Txt_apellido1" Placeholder="Primer Apellido" runat="server"></asp:TextBox>
  <asp:TextBox ID="Txt_apellido2" Placeholder="Segundo Apellido" runat="server"></asp:TextBox>
  <asp:TextBox ID="Txt_nacionalidad" Placeholder="Nacionalidad" runat="server"></asp:TextBox>
  <asp:TextBox ID="Txt_FechaNacimiento"  Placeholder="Fecha de Nacimiento" TextMode="Date" runat="server"></asp:TextBox>
  <asp:TextBox ID="Txt_Telefono" Placeholder="Telefono" runat="server"></asp:TextBox>
  

  <asp:Button ID="Btn_guardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="Btn_guardar_Click" />
  <asp:Button ID="BtnActualizar" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="BtnActualizar_Click" />
  <asp:Button ID="Btn_Cancelar" CssClass="btn btn-secondary btn-hover-move" runat="server" Text="Cancelar" OnClick="Btn_Cancelar_Click" />
  <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>

    </div>
    <asp:GridView ID="Gv_personas" runat="server" AutoGenerateColumns="False" DataKeyNames="idPersona" DataSourceID="SqlDataSource" Width="742px"
        OnRowDeleting="Gv_personas_RowDeleting" 
        OnRowEditing="Gv_personas_RowEditing" 
        OnRowCancelingEdit="Gv_personas_RowCancelingEdit" 
        OnRowUpdating="Gv_personas_RowUpdating" 
        
        OnSelectedIndexChanged="Gv_personas_SelectedIndexChanged" >
        <Columns>
            <asp:CommandField ShowSelectButton="true"  ControlStyle-CssClass="btn btn-success" />
            <asp:BoundField DataField="IdPersona" Visible="false" HeaderText="IdPersona" ReadOnly="True" SortExpression="IdPersona" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido1" HeaderText="Apellido1" SortExpression="Apellido1" />
            <asp:BoundField DataField="Apellido2" HeaderText="Apellido2" SortExpression="Apellido2" />
            <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" SortExpression="Nacionalidad" />
            <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
            <asp:CommandField ShowEditButton="True"  ControlStyle-CssClass="btn btn-primary" />
            <asp:CommandField ShowdeleteButton="True"  ControlStyle-CssClass="btn btn-danger" />
            </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource" runat="server" 
    ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:II-46ConnectionString.ProviderName %>" 
    SelectCommand="SELECT * FROM [Persona]"></asp:SqlDataSource>

</asp:Content>
