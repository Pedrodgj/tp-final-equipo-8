<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="tp_carrito_compras_equipo_20.admin.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nestedContent" runat="server">
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
    <h1 class="mt-6 text-2xl font-bold text-slate-300 sm:text-3xl md:text-4xl pb-3">Categorias</h1>
    <div class="overflow-x-auto">
  <table class="min-w-full divide-y-2 divide-slate-700 bg-slate-900 text-sm">
    <thead class="ltr:text-left rtl:text-right">
      <tr>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Codigo
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Descripcion
        </th>
        <th class="px-4 py-2"></th>
      </tr>
    </thead>

    <tbody class="divide-y divide-slate-600">
        <% foreach (var cat in categorias) { %>
            <tr>
                <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-500">
                  <%= cat.Id %>
                </td>
                <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%= cat.Descripcion %></td>
                <td class="whitespace-nowrap px-4 py-2">
                  <a
                    href="/admin/AgregarCategoria.aspx?id=<%= cat.Id %>"
                    class="inline-block rounded bg-emerald-800 px-4 py-2 text-xs font-medium text-white hover:bg-emerald-900"
                  >
                    Editar
                  </a>

                    <a
                    href="/admin/Categorias.aspx?id=<%= cat.Id %>"
                    class="inline-block rounded bg-red-900 px-4 py-2 text-xs font-medium text-white hover:bg-red-950"
                    onclick="return confirm('¿Eliminar Categoria <%= cat.Descripcion %>?')"
                  >
                    Eliminar
                  </a>
                </td>
              </tr>
        <% } %>
    </tbody>
  </table>
</div>

</asp:Content>
