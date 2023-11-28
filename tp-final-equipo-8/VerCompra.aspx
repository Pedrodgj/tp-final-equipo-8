<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerCompra.aspx.cs" Inherits="tp_carrito_compras_equipo_20.VerCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <main class="flex items-center justify-center px-8 py-8 sm:px-12 lg:col-span-7 lg:px-16 lg:py-12 xl:col-span-6">
    <div class="w-9/12 mb-2 text-sm font-medium text-slate-400">
        <h2 class="mt-6 text-2xl font-bold text-white sm:text-3xl md:text-4xl pb-3">
          Detalles de pedido #<%: id %>
        </h2>

    <p>Fecha de compra: <%: compra.FechaCompra.ToString() %></p>
    <p>Estado del pedido: <%: compra.Estado %></p>
    <p>Codigo de seguimiento: <%: compra.CodigoSeguimiento %></p>

    <table class="min-w-full divide-y-2 divide-slate-700 bg-slate-900 text-sm mt-3">
                    <thead class="ltr:text-left rtl:text-right">
                        <tr>
                            <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
                                Producto
                            </th>
                            <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
                                Cantidad
                            </th>
                            <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
                                Precio unitario
                            </th>
                            <th class="px-4 py-2"></th>
                        </tr>
                    </thead>

                    <tbody class="divide-y divide-slate-600">
                        <% foreach (var detalle in detallePedido)
                            {
                                articulo = Negocio.Articulos.Ver(Convert.ToString(detalle.IdArticulo));
                                %>
                        <tr>
                            <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%: articulo.Nombre %></td>
                            <td class="whitespace-wrap px-4 py-2 text-slate-500 min-w-[12rem] max-w-[20rem] text-center"><%:  detalle.Cantidad %></td>
                            <td class="whitespace-wrap px-4 py-2 text-slate-500 min-w-[12rem] max-w-[20rem] text-center"><%: string.Format(pesos, "{0:C}", detalle.PrecioUnitario) %></td>
                      </tr>
                        <%} %>
                    </tbody>
                </table>
        </div>
        </main>
</asp:Content>
