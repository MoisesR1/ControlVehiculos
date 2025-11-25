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


<asp:TextBox ID="Txt_nombre" Placeholder="Nombre" runat="server"></asp:TextBox>
<asp:TextBox ID="Txt_apellido1" Placeholder="Primer Apellido" runat="server"></asp:TextBox>
<asp:TextBox ID="Txt_apellido2" Placeholder="Segundo Apellido" runat="server"></asp:TextBox>
<asp:TextBox ID="Txt_nacionalidad" Placeholder="Nacionalidad" runat="server"></asp:TextBox>
<asp:TextBox ID="Txt_FechaNacimiento"  Placeholder="Fecha de Nacimiento" TextMode="Date" runat="server"></asp:TextBox>
<asp:TextBox ID="Txt_Telefono" Placeholder="Telefono" runat="server"></asp:TextBox>



<asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>

  </div>
</asp:Content>
