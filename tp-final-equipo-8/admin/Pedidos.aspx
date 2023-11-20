﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="tp_carrito_compras_equipo_20.admin.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nestedContent" runat="server">
        <h1 class="mt-6 text-2xl font-bold text-slate-300 sm:text-3xl md:text-4xl pb-3">Pedidos</h1>
<div class="overflow-x-auto">
  <table class="min-w-full divide-y-2 divide-slate-700 bg-slate-900 text-sm">
    <thead class="ltr:text-left rtl:text-right">
      <tr>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Codigo Seguimiento #
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Id Compra #
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Detalles
        </th>
       
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Total
        </th>
          <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Actual Estado
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
           Nuevo Estado
         </th>
        <th class="px-4 py-2"></th>
      </tr>
    </thead>

    <tbody class="divide-y divide-slate-600">
      <% foreach (var com in compras) 
          { %>   
      <tr>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-500">
          <asp:Label ID="lblCodigo" runat="server" CssClass="whitespace-nowrap px-4 py-2 font-medium text-slate-500" Text="Codigo"></asp:Label>
        </td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%= com.Id %></td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">
            <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded openModalBtn">
                Abrir Modal
            </button>
        </td>
        <% decimal totalPrecio = com.Detalles.Sum(prod => prod.Total); %>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%= string.Format(pesos, "{0:C}", totalPrecio) %>
        <%--<td class="whitespace-nowrap px-4 py-2 text-slate-500">--%>
          <div class="modal hidden fixed top-0 left-0 w-full h-full bg-black bg-opacity-50 flex justify-center items-center myModal">
            <div class="bg-white p-8 rounded shadow-md">
                <span class="block font-bold mb-4">Detalle Compra</span>
                <table class="table-fixed">
                    <thead>
                        <tr>
                            <th>Articulo Id</th>
                            <th>Cantidad</th>
                            <th>Precio Unitario</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%foreach (var detalle in com.Detalles)
                            {%>
                                <tr>
                                    <td><%= detalle.IdArticulo %></td>
                                    <td><%= detalle.Cantidad %></td>
                                    <td><%= string.Format(pesos, "{0:C}", detalle.PrecioUnitario) %></td>
                                </tr>

                           <% } %>
                    </tbody>
                </table>
                <button type="button" class="mt-4 bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded closeModalBtn">
                    Cerrar Modal
                </button>
             </div>
          </div>
        </td>

        <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%= com.Estado %></td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">
            <asp:DropDownList id="marca" CssClass="bg-amber-600 block w-9/12 rounded-md border border-slate-900 px-4 py-2 text-xs font-medium text-white shadow-sm focus-within:border-amber-700 focus-within:ring-1 focus-within:ring-amber-700" runat="server">
            <asp:ListItem Enabled="true" Text= "Nuevo" Value= ""></asp:ListItem>
            <asp:ListItem Text= "Aceptado" Value= ""></asp:ListItem>
            <asp:ListItem Text= "En progreso" Value= ""></asp:ListItem>
            <asp:ListItem Text= "Cancelado" Value= ""></asp:ListItem>
            <asp:ListItem Text= "Completado" Value= ""></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="whitespace-nowrap px-4 py-2">
          <a
            href="#"
            class="inline-block rounded bg-emerald-800 px-4 py-2 text-xs font-medium text-white hover:bg-emerald-900"
          >
            Informar Estado
          </a>

            <a
            href="#"
            class="inline-block rounded bg-red-900 px-4 py-2 text-xs font-medium text-white hover:bg-red-950"
          >
            Cancelar Pedido
          </a>
        </td>
      </tr>
    <% } %>
    </tbody>
  </table>

    
</div>
    <script src="../modal.js"></script>
</asp:Content>
