<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PedidoFinalizado.aspx.cs" Inherits="tp_carrito_compras_equipo_20.PedidoFinalizado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
     
  <div class="mx-auto max-w-screen-xl px-4 py-8 sm:px-6 sm:py-12 lg:px-8">
    <div class="mx-auto max-w-3xl">
      <header class="text-center">
        <h1 class="text-xl font-bold text-slate-300 sm:text-3xl">Gracias por tu compra!</h1>
      </header>

      <div class="mt-8 text-slate-300">
        Detalles del pedido
          <table class="min-w-full divide-y-2 divide-slate-700 bg-slate-900 text-sm">
    <thead class="ltr:text-left rtl:text-right">
      <tr>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Producto
        </th>
        <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Cantidad
        </th>
          <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">
          Precio por unidad
        </th>
        <th class="px-4 py-2"></th>
      </tr>
    </thead>

    <tbody class="divide-y divide-slate-600">
        <% foreach (var art in articulos)
            { %>
        
          <tr>
            <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-500 text-center"><%= art.Nombre %></td>
            <td class="whitespace-nowrap px-4 py-2 text-slate-500 text-center"><%= art.Cantidad %></td>
              <td class="whitespace-nowrap px-4 py-2 text-slate-500 text-center"><%= art.Precio %></td>
          </tr>
        <%} %>
    </tbody>
  </table>

        <div class="mt-8 flex justify-end border-t border-slate-700 pt-8">
          <div class="w-screen max-w-lg space-y-4">
            <dl class="space-y-0.5 text-sm text-slate-300">
              <div class="flex justify-between">
                <dt>Subtotal</dt>
                <asp:Label ID="lblTotal" runat="server" Text="$" class="form-control" readonly="true"></asp:Label>
              </div>

              <div class="flex justify-between">
                <dt>IVA</dt>
                <asp:Label ID="lblIva" runat="server" Text="$" class="form-control" readonly="true"></asp:Label>
              </div>

              <div class="flex justify-between !text-base font-medium">
                <dt>Total</dt>
                <asp:Label ID="lblTotalPagar" runat="server" Text="$" class="form-control" readonly="true"></asp:Label>
              </div>
            </dl>

            
             <div class="flex justify-between">
                <h1 class="text-4xl font-bold mb-4">
                    <asp:Literal ID="MensajeLiteral"  runat="server"></asp:Literal>
                </h1>
            </div>
       

            <div class="flex justify-end">
              <a
                href="Inicio.aspx"
                class="block rounded bg-slate-700 px-5 py-3 text-sm text-slate-100 transition hover:bg-slate-600"
              >
                Volver al inicio
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</asp:Content>
