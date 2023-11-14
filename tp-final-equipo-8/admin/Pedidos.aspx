<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="tp_carrito_compras_equipo_20.admin.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nestedContent" runat="server">
        <h1 class="mt-6 text-2xl font-bold text-slate-300 sm:text-3xl md:text-4xl pb-3">Pedidos</h1>
<div class="overflow-x-auto">
  <table class="min-w-full divide-y-2 divide-slate-700 bg-slate-900 text-sm">
    <thead class="ltr:text-left rtl:text-right">
      <tr>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Pedido #
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Cliente
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Cantidad de productos
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Total
        </th>
          <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Estado
        </th>
        <th class="px-4 py-2"></th>
      </tr>
    </thead>

    <tbody class="divide-y divide-slate-600">
      <tr>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-500">
          CODIGO PEDIDO
        </td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">NOMBRE CLIENTE</td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">CANT PRODUCTOS</td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">TOTAL PEDIDO</td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">
            <asp:DropDownList id="marca" CssClass="bg-amber-600 block w-9/12 rounded-md border border-slate-900 px-4 py-2 text-xs font-medium text-white shadow-sm focus-within:border-amber-700 focus-within:ring-1 focus-within:ring-amber-700" runat="server">
            <asp:ListItem Enabled="true" Text= "Pendiente" Value= ""></asp:ListItem>
            <asp:ListItem Text= "En progreso" Value= ""></asp:ListItem>
                <asp:ListItem Text= "Completado" Value= ""></asp:ListItem>
            </asp:DropDownList>
        </td>
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
          CODIGO PEDIDO
        </td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">NOMBRE CLIENTE</td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">CANT PRODUCTOS</td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">TOTAL PEDIDO</td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">
            <asp:DropDownList id="DropDownList1" CssClass="bg-amber-600 block w-9/12 rounded-md border border-slate-900 px-4 py-2 text-xs font-medium text-white shadow-sm focus-within:border-amber-700 focus-within:ring-1 focus-within:ring-amber-700" runat="server">
            <asp:ListItem Enabled="true" Text= "Pendiente" Value= ""></asp:ListItem>
            <asp:ListItem Text= "En progreso" Value= ""></asp:ListItem>
                <asp:ListItem Text= "Completado" Value= ""></asp:ListItem>
            </asp:DropDownList>
        </td>
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
          CODIGO PEDIDO
        </td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">NOMBRE CLIENTE</td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">CANT PRODUCTOS</td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">TOTAL PEDIDO</td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">
            <asp:DropDownList id="DropDownList2" CssClass="bg-amber-600 block w-9/12 rounded-md border border-slate-900 px-4 py-2 text-xs font-medium text-white shadow-sm focus-within:border-amber-700 focus-within:ring-1 focus-within:ring-amber-700" runat="server">
            <asp:ListItem Enabled="true" Text= "Pendiente" Value= ""></asp:ListItem>
            <asp:ListItem Text= "En progreso" Value= ""></asp:ListItem>
                <asp:ListItem Text= "Completado" Value= ""></asp:ListItem>
            </asp:DropDownList>
        </td>
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
    </tbody>
  </table>
</div>
</asp:Content>
