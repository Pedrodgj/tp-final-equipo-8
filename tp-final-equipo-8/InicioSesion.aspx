<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="tp_carrito_compras_equipo_20.InicioSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section
  class="relative"
>
  <div>

    <main
      class="flex items-center justify-center px-8 py-8 sm:px-12 lg:col-span-7 lg:px-16 lg:py-12 xl:col-span-6"
    >
      <div class="max-w-xl lg:max-w-3xl">

          <h2 class="mt-6 text-2xl font-bold text-white sm:text-3xl md:text-4xl pb-3">
          Iniciar sesion
        </h2>
    

        <form action="#" class="mt-8 grid grid-cols-6 gap-6">
          <div class="col-span-6 space-y-2">
            <label for="UserEmail" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="email" id="UserEmail" placeholder="Email" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Email
                </span>
            </label>
          
            <label for="Password" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="password" id="Password" placeholder="Password" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Contraseña
                </span>
            </label>
          </div>


          <div class="col-span-6 sm:flex sm:items-center sm:gap-4 pt-10">
            <button class="inline-block shrink-0 rounded-md border border-slate-700 bg-slate-800 px-12 py-3 text-sm font-medium text-white transition hover:bg-slate-800 hover:text-slate-400 focus:outline-none focus:ring active:text-slate-500">
                Iniciar sesion
            </button>

            <p class="mt-4 text-sm text-slate-300 sm:mt-0">
              No tenes una cuenta? 
              <a href="#" class="text-slate-400 underline">Registrate</a>.
            </p>
          </div>
        </form>
      </div>
    </main>
  </div>
</section>


</asp:Content>
