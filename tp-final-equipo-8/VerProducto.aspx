<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerProducto.aspx.cs" Inherits="tp_carrito_compras_equipo_20.VerProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section class="overflow-hidden bg-white py-11 font-poppins dark:bg-gray-800">

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

                        <div class="px-6 pb-6 mt-6 border-t border-gray-300 dark:border-gray-400 ">

                            <div class="flex flex-wrap items-center mt-6">

                                texto

                            </div>

                        </div>

                    </div>

                </div>

                <div class="w-full px-4 md:w-1/2 ">

                    <div class="lg:pl-20">

                        <div class="mb-8 ">

                            <h2 class="max-w-xl mb-6 text-2xl font-bold dark:text-gray-400 md:text-4xl">

                                <%: articulo.Nombre %></h2>

                            <p class="inline-block mb-6 text-4xl font-bold text-gray-700 dark:text-gray-400 ">

                                <span><%: string.Format(pesos, "{0:C}" , articulo.Precio) %></span>

                            </p>

                            <p class="max-w-md text-gray-700 dark:text-gray-400">

                                <%: articulo.Descripcion %>

                            </p>

                        </div>

                        <div class="mb-8">

                            <h2

                                class="w-16 pb-1 mb-4 text-2xl font-bold border-b border-blue-300 dark:text-gray-400 dark:border-gray-600">

                                Colores</h2>

                            <div class="flex flex-wrap -mx-2 -mb-2">

                                <button class="p-1 mb-2 mr-3 ">

                                    <div class="w-6 h-6 rounded-full bg-stone-400"></div>

                                </button>

                                <button class="p-1 mb-2 mr-3 ">

                                    <div class="w-6 h-6 bg-gray-700 rounded-full"></div>

                                </button>

                                <button class="p-1 mb-2 ">

                                    <div class="w-6 h-6 bg-blue-200 rounded-full"></div>

                                </button>

                            </div>

                        </div>

                        <div class="mb-8 ">

                            <h2

                                class="w-16 pb-1 mb-4 text-xl font-semibold border-b border-blue-300 dark:border-gray-600 dark:text-gray-400">

                                RAM</h2>

                            <div>

                                <div class="flex flex-wrap -mb-2">

                                    <button

                                        class="px-4 py-2 mb-2 mr-4 font-semibold border rounded-md hover:border-blue-400 dark:border-gray-400 hover:text-blue-600 dark:hover:border-gray-300 dark:text-gray-400">

                                        8 GB

                                    </button>

                                    <button

                                        class="px-4 py-2 mb-2 mr-4 font-semibold border rounded-md hover:border-blue-400 hover:text-blue-600 dark:border-gray-400 dark:hover:border-gray-300 dark:text-gray-400">

                                        16 GB

                                    </button>

                                    <button

                                        class="px-4 py-2 mb-2 font-semibold border rounded-md hover:border-blue-400 hover:text-blue-600 dark:border-gray-400 dark:hover:border-gray-300 dark:text-gray-400">

                                        1 TB

                                    </button>

                                </div>

                            </div>

                        </div>

                        <div class="mb-8">

                            <h2

                                class="w-16 pb-1 mb-6 text-xl font-semibold border-b border-blue-300 dark:border-gray-600 dark:text-gray-400">

                                Almacenamiento</h2>

                            <div>

                                <div class="flex flex-wrap -mx-2 -mb-2">

                                    <button

                                        class="px-4 py-2 mb-2 mr-4 font-semibold border rounded-md hover:border-blue-400 dark:border-gray-400 hover:text-blue-600 dark:hover:border-gray-300 dark:text-gray-400">

                                        256 GB

                                    </button>

                                    <button

                                        class="px-4 py-2 mb-2 mr-4 font-semibold border rounded-md hover:border-blue-400 hover:text-blue-600 dark:border-gray-400 dark:hover:border-gray-300 dark:text-gray-400">

                                        112 GB

                                    </button>

                                    <button

                                        class="px-4 py-2 mb-2 mr-2 font-semibold border rounded-md hover:border-blue-400 hover:text-blue-600 dark:border-gray-400 dark:hover:border-gray-300 dark:text-gray-400">

                                        1 TB

                                    </button>

                                </div>

                            </div>

                        </div>

                        <div class="w-32 mb-8 ">

                            <label for=""

                                class="w-full pb-1 text-xl font-semibold text-gray-700 border-b border-blue-300 dark:border-gray-600 dark:text-gray-400">Quantity</label>

                            <div class="relative flex flex-row w-full h-10 mt-6 bg-transparent rounded-lg">

                                <button

                                    class="w-20 h-full text-gray-600 bg-gray-300 rounded-l outline-none cursor-pointer dark:hover:bg-gray-700 dark:text-gray-400 hover:text-gray-700 dark:bg-gray-900 hover:bg-gray-400">

                                    <span class="m-auto text-2xl font-thin">-</span>

                                </button>

                                <input type="number"

                                    class="flex items-center w-full font-semibold text-center text-gray-700 placeholder-gray-700 bg-gray-300 outline-none dark:text-gray-400 dark:placeholder-gray-400 dark:bg-gray-900 focus:outline-none text-md hover:text-black"

                                    placeholder="1">

                                <button

                                    class="w-20 h-full text-gray-600 bg-gray-300 rounded-r outline-none cursor-pointer dark:hover:bg-gray-700 dark:text-gray-400 dark:bg-gray-900 hover:text-gray-700 hover:bg-gray-400">

                                    <span class="m-auto text-2xl font-thin">+</span>

                                </button>

                            </div>

                        </div>

                        <div class="flex flex-wrap items-center gap-4">

                            <button

                                class="w-full p-4 bg-blue-500 rounded-md lg:w-2/5 dark:text-gray-200 text-gray-50 hover:bg-blue-600 dark:bg-blue-500 dark:hover:bg-blue-700">

                                Agregar al carrito</button>

                        </div>

                    </div>

                </div>

            </div>

        </div>

    </section> 

</asp:Content>
