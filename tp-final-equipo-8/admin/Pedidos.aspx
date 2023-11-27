<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="tp_carrito_compras_equipo_20.admin.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nestedContent" runat="server">
        <h1 class="mt-6 text-2xl font-bold text-slate-300 sm:text-3xl md:text-4xl pb-3">Pedidos</h1>
        <% if (Session["Msg_error"] != null)
            { %>
            <div class="bg-red-200 p-10 absolute top-2 right-2 text-white">
                <%= Session["Msg_error"] %>
                <% Session["Msg_error"] = null; %>
            </div>
        <%} %>
        <% if (Session["Msg_ok"] != null)
            { %>
            <div class="bg-green-200 p-10 absolute top-2 right-2 text-black">
                <%= Session["Msg_ok"] %>
                <% Session["Msg_ok"] = null; %>
            </div>
        <%} %>
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
            Realizar Envio
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
           Siguiente Estado
         </th>
        <th class="px-4 py-2"></th>
      </tr>
    </thead>

    <tbody class="divide-y divide-slate-600">
      <% foreach (var com in compras) 
          { %>   
      <tr>
        <td class="whitespace-nowrap px-4 py-2 font-medium text-slate-500">
          <%= com.CodigoSeguimiento == " " ? "No tiene" : com.CodigoSeguimiento %>
        </td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%= com.Id %></td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%= com.Envio == false ? "Retiro por domicilio" : "Envio" %></td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500">
            <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded openModalBtn">
                Abrir Modal
            </button>
        </td>
        <td class="whitespace-nowrap px-4 py-2 text-slate-500"><%= string.Format(pesos, "{0:C}", com.Total) %>
          <div class="modal hidden fixed top-0 left-0 w-full h-full bg-black bg-opacity-50 flex justify-center items-center myModal">
            <div class="bg-white p-8 rounded shadow-md">
                <span class="block font-bold mb-4">Detalle Compra</span>
                <table class="table-fixed">
                    <thead class="ltr:text-left rtl:text-right">
                        <tr>
                            <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">Articulo</th>
                            <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">Cantidad</th>
                            <th class="whitespace-nowrap px-4 py-2 font-medium text-slate-400">Total</th>
                        </tr>
                    </thead>
                    <tbody class="divide-y divide-slate-600">
                        <%foreach (var detalle in com.Detalles)
                            {%>
                            <% dominio.Articulo art = Negocio.Articulos.Ver(detalle.IdArticulo.ToString()); %>
                                <tr>
                                    <td class="whitespace-wrap px-4 py-2 text-slate-500 min-w-[12rem] max-w-[20rem] text-center"><%= art.Nombre %></td>
                                    <td class="whitespace-wrap px-4 py-2 text-slate-500 min-w-[12rem] max-w-[20rem] text-center"><%= detalle.Cantidad %></td>
                                    <td class="whitespace-wrap px-4 py-2 text-slate-500 min-w-[12rem] max-w-[20rem] text-center"><%= string.Format(pesos, "{0:C}", detalle.Total) %></td>
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
            <% switch (com.Estado)
                {
                    case "NUEVO": {%>
                            <asp:Label runat="server" CssClass="bg-amber-600 block w-11/12 rounded-md border border-slate-900 px-4 py-2 text-xs font-medium text-white shadow-sm focus-within:border-amber-700 focus-within:ring-1 focus-within:ring-amber-700">Aceptado</asp:Label>
                        <%} break;%>
                    <% case "ACEPTADO": {%>
                            <% if(com.Envio == true) {%>
                                <asp:Label runat="server" CssClass="bg-amber-600 block w-11/12 rounded-md border border-slate-900 px-4 py-2 text-xs font-medium text-white shadow-sm focus-within:border-amber-700 focus-within:ring-1 focus-within:ring-amber-700">Realizar Envio</asp:Label>
                            <%} else {%>
                                <asp:Label runat="server" CssClass="bg-amber-600 block w-11/12 rounded-md border border-slate-900 px-4 py-2 text-xs font-medium text-white shadow-sm focus-within:border-amber-700 focus-within:ring-1 focus-within:ring-amber-700">Listo para Retirar</asp:Label>
                                <%}%>
                        <%} break;%>
                        <% case "ENVIADO": {%>
                            <asp:Label runat="server" CssClass="bg-amber-600 block w-11/12 rounded-md border border-slate-900 px-4 py-2 text-xs font-medium text-white shadow-sm focus-within:border-amber-700 focus-within:ring-1 focus-within:ring-amber-700">Completado</asp:Label>
                        <%} break;%>
                         <% case "LISTO_PARA_RETIRAR": {%>
                        <asp:Label runat="server" CssClass="bg-amber-600 block w-11/12 rounded-md border border-slate-900 px-4 py-2 text-xs font-medium text-white shadow-sm focus-within:border-amber-700 focus-within:ring-1 focus-within:ring-amber-700">Completado</asp:Label>
                    <%} break;%>
                        <% default:%> 
                        <asp:Label runat="server" CssClass="bg-amber-600 block w-11/12 rounded-md border border-slate-900 px-4 py-2 text-xs font-medium text-white shadow-sm focus-within:border-amber-700 focus-within:ring-1 focus-within:ring-amber-700">" "</asp:Label>
                        <%break;
                        } %>
            <%--<asp:DropDownList runat="server" CssClass="bg-amber-600 block w-9/12 rounded-md border border-slate-900 px-4 py-2 text-xs font-medium text-white shadow-sm focus-within:border-amber-700 focus-within:ring-1 focus-within:ring-amber-700">
            <asp:ListItem id="ddlAceptado" Text="Aceptado" Value= "ACEPTADO"></asp:ListItem>
            <asp:ListItem id="ddlEnProgreso" Text= "En progreso" Value= "EN_PROGRESO"></asp:ListItem>
            <asp:ListItem id="ddlCompletado" Text= "Completado" Value= "COMPLETADO"></asp:ListItem>
            </asp:DropDownList>  --%>         
        </td>
        <td class="whitespace-nowrap px-4 py-2">
          
            <%if(com.Estado == nuevo.ToString() || com.Estado == aceptado.ToString() || com.Estado == envio.ToString() || com.Estado == retirar.ToString()) 
                {%>
                <a class="inline-block rounded bg-emerald-800 px-4 py-2 text-xs font-medium text-white hover:bg-emerald-900" 
                    type ="button" href="Pedidos.aspx?id=<%: com.Id %>">Informar Estado</a>
                <a class="inline-block rounded bg-red-900 px-4 py-2 text-xs font-medium text-white hover:bg-red-950" type ="button" href="Pedidos.aspx?id=<%: com.Id %>&delete=true">Cancelar Pedido</a>
                <%} else {%>
                      <label class="inline-block rounded bg-blue-900 px-4 py-2 text-xs font-medium ">Estado Final</label>
                <%}%>
        
        </td>
      </tr>
    <% } %>
    </tbody>
  </table>
</div>

    <script src="../modal.js"></script>
    
</asp:Content>
