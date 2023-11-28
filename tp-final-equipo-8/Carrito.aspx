<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="tp_carrito_compras_equipo_20.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section>
  <div class="mx-auto max-w-screen-xl px-4 py-8 sm:px-6 sm:py-12 lg:px-8">
    <div class="mx-auto max-w-3xl">
      <header class="text-center">
        <h1 class="text-xl font-bold text-slate-300 sm:text-3xl">Tu carrito</h1>
      </header>

      <div class="mt-8">
        <ul class="space-y-4">
            <%
                foreach (var art in articulos)
                {
                    string imagen = "";
                    if (art.Imagenes == null)
                    {
                        imagen = @"imagenes\imagen.png";
                        return;
                    }

                    if (art.Imagenes.Count > 0)
                    {
                        imagen = art.Imagenes[0].Url;
                    }
                    else imagen = @"imagenes\imagen.png";
                
            %>

          <li class="flex items-center gap-4">
            <img
              src="<%: imagen %>"
              alt=""
              class="h-32 w-32 rounded object-cover"
            />

            <div>
              <h3 class="text-sm text-slate-300"><%: art.Nombre %></h3>

              <dl class="mt-0.5 space-y-px text-[15px] text-slate-500">
                <div>
                  <dt class="inline">Descripcion:</dt>
                  <dd class="inline"><%: art.Descripcion %></dd>
                </div>

                <div>
                  <dt class="inline">Precio: </dt>
                   <%string precio = string.Format(pesos, "{0:C}", art.Precio); %>
                  <dd class="inline"><%: precio %></dd>
                </div>
              </dl>
            </div>

            <div class="flex flex-1 items-center justify-end gap-2">
              <form>
                <label for="CANTIDADARTICULO3" class="sr-only"> Cantidad </label>

                  <div>

                  <div class="flex items-center gap-1">
                      <a type="button" href="Carrito.aspx?id=<%: art.Id %>&delete=true"
                      class="w-15 h-10 leading-10 text-slate-600 transition hover:opacity-75">&minus;</a>
                    <input
                      type="number"
                      id="CANTIDADARTICULO3"
                      value="<%: art.Cantidad %>"
                      min="1"
                      disabled
                      class="h-10 w-16 rounded border-slate-700 bg-slate-800 text-slate-400 [-moz-appearance:_textfield] sm:text-sm [&::-webkit-outer-spin-button]:m-0 [&::-webkit-outer-spin-button]:appearance-none [&::-webkit-inner-spin-button]:m-0 [&::-webkit-inner-spin-button]:appearance-none"
                    />

                    <a type="button" href="Carrito.aspx?id=<%: art.Id %>" class="w-10 h-10 leading-10 text-slate-600 transition hover:opacity-75">&plus;</a>
                  </div>
                </div>
              </form>
                            
                <a class="text-gray-600 transition hover:text-red-600" type="button" href="Carrito.aspx?id=<%: art.Id %>&deleteAll=true">
                <span class="sr-only">Eliminar producto</span>
    
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke-width="1.5"
                  stroke="currentColor"
                  class="h-4 w-4"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    d="M14.74 9l-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 01-2.244 2.077H8.084a2.25 2.25 0 01-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 00-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 013.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 00-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 00-7.5 0"
                  />
                </svg>
              </a>
            </div>
          </li>
           <%}%>

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

            

            <div class="flex justify-end">
              <a
                href="Comprar.aspx"
                class="block rounded bg-slate-700 px-5 py-3 text-sm text-slate-100 transition hover:bg-slate-600"
              >
                Comprar
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>


</asp:Content>
