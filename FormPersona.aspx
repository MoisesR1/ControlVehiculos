<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="ControlVehiculos.FormPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:hiddenField ID="editando" runat="server" />

     <asp:TextBox ID="Txt_nombre" Placeholder="Nombre" runat="server"></asp:TextBox>
  <asp:TextBox ID="Txt_apellido" Placeholder="Apellido" runat="server"></asp:TextBox>
  <asp:TextBox ID="Txt_edad" Placeholder="Edad" runat="server"></asp:TextBox>
  <asp:Button ID="Btn_guardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="Btn_guardar_Click" />
  <asp:Button ID="BtnActualizar" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="BtnActualizar_Click" />
  <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>

    
    <asp:GridView ID="Gv_personas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource" Width="742px" 
        OnRowDeleting="Gv_personas_RowDeleting" 
        OnRowEditing="Gv_personas_RowEditing" 
        OnRowCancelingEdit="Gv_personas_RowCancelingEdit" 
        OnRowUpdating="Gv_personas_RowUpdating" 
        
        OnSelectedIndexChanged="Gv_personas_SelectedIndexChanged" >
        <Columns>
            <asp:CommandField ShowSelectButton="true"  ControlStyle-CssClass="btn btn-success" />
            <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger"  />
           
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" ProviderName="<%$ ConnectionStrings:II-46ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Personas]"></asp:SqlDataSource>

</asp:Content>
