<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="tp_carrito_compras_equipo_20.Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="comments">comments</div>

<div class="grid grid-cols-5 gap-3">
  <div>

<div class="space-y-2 mt-6 ml-2">

    Filtrar
    <form method="post" id="formCategorias" accept-charset="UTF-8">
  <details
    class="overflow-hidden rounded border border-gray-300 [&_summary::-webkit-details-marker]:hidden"
  >
    <summary
      class="flex cursor-pointer items-center justify-between gap-2 bg-white p-4 text-gray-900 transition"
    >
      <span class="text-sm font-medium"> Categoria </span>

      <span class="transition group-open:-rotate-180">
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
            d="M19.5 8.25l-7.5 7.5-7.5-7.5"
          />
        </svg>
      </span>
    </summary>

    <div class="border-t border-gray-200 bg-white">
      <header class="flex items-center justify-between p-4">
        <span class="text-sm text-gray-700"> <span id="numCat">0</span> Seleccionados </span>

        
          <asp:button id="button1" runat="server" text="Reset" onclientclick="return limpiarCats()" UseSubmitBehavior="False" CssClass="text-sm text-gray-900 underline underline-offset-4"/>
      </header>


      <ul class="space-y-1 border-t border-gray-200 p-4">
          <% foreach (var categoria in cats)
              {
                  
                  %>
          <li>
          <label for="<%: categoria.Descripcion %>" class="inline-flex items-center gap-2">
            <input
              type="checkbox"
              id="<%: categoria.Descripcion %>" value="<%: categoria.Descripcion %>"
              class="h-5 w-5 rounded border-gray-300 chkboxCat"
            />

            <span class="text-sm font-medium text-gray-700">
              <%: categoria.Descripcion %>
            </span>
          </label>
        </li>
              <%}%>
      </ul>
    </div>
  </details>
        </form>

    <form method="post" id="formMarcas" accept-charset="UTF-8">
  <details
    class="overflow-hidden rounded border border-gray-300 [&_summary::-webkit-details-marker]:hidden"
  >
    <summary
      class="flex cursor-pointer items-center justify-between gap-2 bg-white p-4 text-gray-900 transition"
    >
      <span class="text-sm font-medium"> Marca </span>

      <span class="transition group-open:-rotate-180">
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
            d="M19.5 8.25l-7.5 7.5-7.5-7.5"
          />
        </svg>
      </span>
    </summary>

    <div class="border-t border-slate-800 bg-slate-900">
      <header class="flex items-center justify-between p-4">
        <span class="text-sm text-gray-700"> <span id="numMar">0</span> Seleccionados </span>

        <asp:button id="button2" runat="server" text="Reset" onclientclick="return limpiarMars()" UseSubmitBehavior="False" CssClass="text-sm text-gray-900 underline underline-offset-4"/>
      </header>


      <ul class="space-y-1 border-t border-gray-200 p-4">
          <% foreach (var marca in marcas)
              {
                  %>
          <li>
          <label for="<%: marca.Descripcion %>" class="inline-flex items-center gap-2">
            <input
              type="checkbox"
              id="<%: marca.Descripcion %>" value="<%: marca.Descripcion %>"
              class="h-5 w-5 rounded border-gray-300 chkboxMar"
            />

            <span class="text-sm font-medium text-gray-700">
              <%: marca.Descripcion %>
            </span>
          </label>
        </li>
              <%}%>
      </ul>
    </div>
  </details>
        </form>
</div>
      </div>
            <div class="col-span-4">
  <div class="mx-auto max-w-2xl px-4 py-16 sm:px-6 sm:py-24 lg:max-w-7xl lg:px-8">
    <h2 class="sr-only">Productos</h2>

    <div class="grid grid-cols-1 gap-x-6 gap-y-10 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 xl:gap-x-8">

        <% foreach (var art in articulos)
            {
                infoProducto.Text = art.Nombre;
                //infoProducto.NavigateUrl = "VerProducto.aspx?id=" + art.Id;
                string imagen = "";
                if (art.Imagenes.Count >
                   0)
                {
                    imagen = art.Imagenes[0].Url;
                }
                else imagen = @"imagenes\imagen.png";
        %>

        <a href="VerProducto.aspx?id=<%: art.Id %>" class="group" data-categoria="<%: art.Categoria %>" data-marca="<%: art.Marca %>">
        <div class="aspect-h-1 aspect-w-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-h-8 xl:aspect-w-7">
          <img src="<%: imagen %>" alt="Ejemplo" class="h-full w-full object-cover object-center group-hover:opacity-75">
        </div>
        <h3 class="mt-4 text-sm text-gray-700">
            <asp:Label ID="infoProducto" runat="server"></asp:Label></h3>
        <p class="mt-1 text-lg font-medium text-gray-900"><%: string.Format(pesos, "{0:C}" , art.Precio) %></p>
      </a>
                    <% } %>

            </div>
  </div>
</div>

        </div>

    <script>
        $(".chkboxCat").change(function () {
            var check = $('.chkboxCat:checkbox:checked').length;
            $('#numCat').text(check);
        });
    </script>

    <script>
        $(".chkboxMar").change(function () {
            var check = $('.chkboxMar:checkbox:checked').length;
            $('#numMar').text(check);
        });
    </script>

    <script>
        function limpiarCats() {

            $('.chkboxCat').prop('checked', false);
            $('#numCat').text(0);
            $(".group").show();
        }
    </script>

    <script>
        function limpiarMars() {

            $('.chkboxMar').prop('checked', false);
            $('#numMar').text(0);
            $(".group").show();
        }
    </script>

    <script>
        $(".chkboxCat:checkbox").click(function () {
            var check = $('.chkboxCat:checkbox:checked').length;

            if (check != 0) {
                $(".group").hide();
                $(".chkboxCat:checkbox:checked").each(function () {
                    var categoria = $(this).val();
                    $("[data-categoria='" + categoria + "']").show();

                });
            }

            else $(".group").show();

        });

    </script>

    <script>
        $(".chkboxMar:checkbox").click(function () {
            var check = $('.chkboxMar:checkbox:checked').length;

            if (check != 0) {
                $(".group").hide();
                $(".chkboxMar:checkbox:checked").each(function () {
                    var marca = $(this).val();
                    $("[data-marca='" + marca + "']").show();

                });
            }

            else $(".group").show();

        });

    </script>
</asp:Content>
