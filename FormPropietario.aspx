<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPropietario.aspx.vb" Inherits="ControlVehiculos.FormPropietario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
           <asp:DropDownList ID="Ddl_personas" runat="server" CssClass="form-control"> 
               <asp:ListItem Text="Seleccione Persona" Value="" />
           </asp:DropDownList>
           <asp:Button ID="btnGuardar" runat="server" Text="Button" OnClick="btnGuardar_Click" />
           <asp:GridView ID="Gv_Propietarios" runat="server" AutoGenerateColumns="False" DataKeyNames="IdPropietario" DataSourceID="SqlDataSource1">
               <Columns>
                   <asp:BoundField DataField="IdPropietario" HeaderText="IdPropietario" InsertVisible="False" ReadOnly="True" SortExpression="IdPropietario" />
                   <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" SortExpression="IdPersona" />
               </Columns>


           </asp:GridView>


           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" SelectCommand="SELECT * FROM [Propietarios]"></asp:SqlDataSource>


  </div>
</asp:Content>
