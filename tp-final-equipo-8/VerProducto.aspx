<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerProducto.aspx.cs" Inherits="tp_carrito_compras_equipo_20.VerProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section class="overflow-hidden bg-slate-900 py-11 font-poppins">

        <div class="max-w-6xl px-4 py-4 mx-auto lg:py-8 md:px-6">

            <div class="flex flex-wrap -mx-4">

                <div class="w-full mb-8 md:w-1/2 md:mb-0">

                    <div class="sticky top-0 z-50 overflow-hidden ">

                        <%
            foreach (var img in imagenes)
            {
                
                if (imagenes.First()== img)
                {
                    %>

                        <div class="relative mb-6 lg:mb-10 lg:h-2/4 ">

                            <img src="<%: img.Url %>" alt=""

                                class="object-cover w-full lg:h-full ">

                        </div>

                        <div class="flex-wrap hidden md:flex ">

        <%
                }

            else
        
                %>

                            <div class="w-1/2 p-2 sm:w-1/4">

                                <a href="#" class="block border border-blue-300 hover:border-blue-300">

                                    <img src="<%: img.Url %>" alt=""

                                        class="object-cover w-full lg:h-20">

                                </a>

                            </div>
        <%
                
            }

          %>

                        </div>

                        <div class="px-6 pb-6 mt-6 border-t border-slate-400">

                            <div class="flex flex-wrap items-center mt-6">

                                texto

                            </div>

                        </div>

                    </div>

                </div>

                <div class="w-full px-4 md:w-1/2 ">

                    <div class="lg:pl-20">

                        <div class="mb-8 ">

                            <h2 class="max-w-xl mb-6 text-2xl font-bold text-slate-400 md:text-4xl">

                                <%: articulo.Nombre %></h2>

                            <p class="inline-block mb-6 text-4xl font-bold text-slate-400">

                                <span><%: string.Format(pesos, "{0:C}" , articulo.Precio) %></span>

                            </p>

                            <p class="max-w-md text-slate-400">

                                <%: articulo.Descripcion %>

                            </p>

                        </div>

                        

                        <div class="w-32 mb-8 ">

                            <label for=""

                                class="w-full pb-1 text-xl font-semibold text-slate-400 border-b border-slate-600">Cantidad</label>

                            <div class="relative flex flex-row w-full h-10 mt-6 bg-transparent rounded-lg">

                                <button

                                    class="w-20 h-fullrounded-l outline-none cursor-pointer hover:bg-slate-700 text-slate-400 hover:text-slate-700 bg-slate-900" onclick="subCantidad()">

                                    <span class="m-auto text-2xl font-thin">-</span>

                                </button>

                                <input type="number" id="cantidad"

                                    class="flex items-center w-full font-semibold text-center outline-none text-slate-400 placeholder-slate-400 bg-slate-900 focus:outline-none text-md hover:text-slate-400"

                                    placeholder="1">

                                <button

                                    class="w-20 h-full rounded-r outline-none cursor-pointer hover:bg-slate-700 text-slate-400 bg-slate-900 hover:text-slate-700 addCantidad">

                                    <span class="m-auto text-2xl font-thin">+</span>

                                </button>

                            </div>

                        </div>

                        <div class="flex flex-wrap items-center gap-4">
                                <a href="Carrito.aspx?id=<%: articulo.Id %>" class="w-full p-4 bg-emerald-800 rounded-md lg:w-2/5 text-whitehover:bg-emerald-700">Agregar al carrito</a>
                        </div>

                    </div>

                </div>

            </div>

        </div>

    </section> 

    <script>
        $('.addCantidad').on('click', function (e) {
            var cant = parseInt(document.getElementById('cantidad').value, 10);
            cant = isNaN(cant) ? 0 : cant;
            cant++;
            document.getElementById('cantidad').value = cant;
        });
    </script>
    <script>
        $('.subCantidad').on('click', function (a) {
            var cant = parseInt(document.getElementById('cantidad').value, 10);
            cant = isNaN(cant) ? 0 : cant;
            if (cant >= 0) { cant -= 1; }
            document.getElementById('cantidad').value = cant;
        });
    </script>
    

</asp:Content>
