<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="tp_carrito_compras_equipo_20.admin.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nestedContent" runat="server">

    <div class="overflow-x-auto">
  <table class="min-w-full divide-y-2 divide-slate-700 bg-slate-900 text-sm">
    <thead class="ltr:text-left rtl:text-right">
      <tr>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          ID
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Nombre
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Email
        </th>
         <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
            Telefono
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Estado
        </th> 
         <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Tipo Usuario
        </th> 

        <th class="px-4 py-2"></th>
      </tr>
    </thead>

    <tbody class="divide-y divide-slate-600">
      <% foreach (var cliente in usuarios)
          { 
              string nombre = cliente.Nombres + " " + cliente.Apellidos;%>   
      <tr>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-500">
          <%= cliente.Id %>
        </td>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-400"><%= nombre %></td>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-400"><%= cliente.Email %></td>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-400"><%= cliente.Telefono %></td>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-400"><%: Convert.ToBoolean(cliente.Activo) ? "Activo" : "Inactivo" %></td>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-400"><%: cliente.IdTipoUsuario == 1 ? "Administrador" : "Cliente" %></td>
          
        </tr>

    <% } %>
                    </tbody>
                </table>
        </div>

</asp:Content>
