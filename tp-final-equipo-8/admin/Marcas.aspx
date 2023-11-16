<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="tp_carrito_compras_equipo_20.admin.Marcas" %>
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
    <h1 class="mt-6 text-2xl font-bold text-slate-300 sm:text-3xl md:text-4xl pb-3">Marcas</h1>

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
        <% foreach (var marca in marcas) { %>
        
          <tr>
            <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-500">
              <%= marca.Id %>
            </td>
            <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%= marca.Descripcion %></td>
            <td class="whitespace-nowrap px-4 py-2">
              <%--<a
                href="#"
                class="inline-block rounded bg-emerald-800 px-4 py-2 text-xs font-medium text-white hover:bg-emerald-900"
              >
                Ver
              </a>--%>

              <a href="/admin/AgregarMarca.aspx?id=<%= marca.Id %>&accion=editar" class="inline-block rounded bg-emerald-800 px-4 py-2 text-xs font-medium text-white hover:bg-emerald-900">
                Editar
              </a>

              <a href="/admin/Marcas.aspx?id=<%= marca.Id %>&accion=borrar" onclick="return confirm('¿Eliminar la marca <%= marca.Descripcion %>?')" class="inline-block rounded bg-red-900 px-4 py-2 text-xs font-medium text-white hover:bg-red-950">
                Eliminar
              </a>
            </td>
          </tr>
        <% }%>
      <%--<tr>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-500">
          CODIGO MARCA
        </td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">DESCRIPCION MARCA</td>
        <td class="whitespace-nowrap px-4 py-2">
          <a
            href="#"
            class="inline-block rounded bg-emerald-800 px-4 py-2 text-xs font-medium text-white hover:bg-emerald-900"
          >
            Ver
          </a>

            <a
            href="#"
            class="inline-block rounded bg-emerald-800 px-4 py-2 text-xs font-medium text-white hover:bg-emerald-900"
          >
            Editar
          </a>

            <a
            href="#"
            class="inline-block rounded bg-red-900 px-4 py-2 text-xs font-medium text-white hover:bg-red-950"
          >
            Eliminar
          </a>
        </td>
      </tr>

      <tr>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-500">
          CODIGO MARCA
        </td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">DESCRIPCION MARCA</td>
        <td class="whitespace-nowrap px-4 py-2">
          <a
            href="#"
            class="inline-block rounded bg-emerald-800 px-4 py-2 text-xs font-medium text-white hover:bg-emerald-900"
          >
            Ver
          </a>

            <a
            href="#"
            class="inline-block rounded bg-emerald-800 px-4 py-2 text-xs font-medium text-white hover:bg-emerald-900"
          >
            Editar
          </a>

            <a
            href="#"
            class="inline-block rounded bg-red-900 px-4 py-2 text-xs font-medium text-white hover:bg-red-950"
          >
            Eliminar
          </a>
        </td>
      <--%>/tr>
    </tbody>
  </table>
</div>
</asp:Content>
