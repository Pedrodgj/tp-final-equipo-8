<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="tp_carrito_compras_equipo_20.admin.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="nestedContent" runat="server">
    <% if (Session["Msg_error"] != null)
              { %>
              <div class="bg-red-200 p-10 absolute top-2 right-2">
                  <%= Session["Msg_error"] %>
                  <% Session["Msg_error"] = null; %>
              </div>
          <%} %>
          <% if (Session["Msg_ok"] != null)
              { %>
              <div class="bg-green-200 p-10 absolute top-2 right-2">
                  <%= Session["Msg_ok"] %>
                  <% Session["Msg_ok"] = null; %>
              </div>
          <%} %>

    <h1 class="mt-6 text-2xl font-bold text-slate-300 sm:text-3xl md:text-4xl pb-3">Productos</h1>
<div class="overflow-x-auto">
  <table class="min-w-full divide-y-2 divide-slate-700 bg-slate-900 text-sm">
    <thead class="ltr:text-left rtl:text-right">
      <tr>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Codigo
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Nombre
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Descripcion
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Marca
        </th>
          <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Categoria
        </th>
        <th class="px-4 py-2"></th>
      </tr>
    </thead>

    <tbody class="divide-y divide-slate-600">
        <% foreach (var art in articulos)
            { %>
      <tr>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-500">
          <%: art.Codigo %>
        </td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%: art.Nombre %></td>
        <td class="whitespace-wrap px-4 py-2 text-slate-500 min-w-[12rem] max-w-[20rem]"><%: art.Descripcion %></td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%: art.Marca %></td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%: art.Categoria %></td>
        <td class="whitespace-nowrap px-4 py-2">
          <a
            href="#"
            class="inline-block rounded bg-emerald-800 px-4 py-2 text-xs font-medium text-white hover:bg-emerald-900"
          >
            Ver
          </a>
            <% linkId = Convert.ToString(art.Id); %>
            <asp:LinkButton runat="server" Id="lnkButton" Text="Editar" onclick="lnkButton_Click" CommandArgument='<%# Eval(linkId) %>' class="inline-block rounded bg-emerald-800 px-4 py-2 text-xs font-medium text-white hover:bg-emerald-900"/>
            <a href="/admin/Productos.aspx?id=<%= art.Id %>" class="inline-block rounded bg-red-900 px-4 py-2 text-xs font-medium text-white hover:bg-red-950" onclick="return confirm('¿Eliminar producto <%= art.Nombre %>?')">
                    Eliminar
            </a>
        </td>
      </tr>
        <%} %>
    </tbody>
  </table>
</div>

</asp:Content>
