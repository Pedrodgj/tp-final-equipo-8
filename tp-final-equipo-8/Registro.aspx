<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="tp_carrito_compras_equipo_20.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section
  class="relative bg-[linear-gradient(to_right_bottom,rgba(51,65,85,0.7),rgba(2,6,23,0.9)),url(https://images.pexels.com/photos/3520692/pexels-photo-3520692.jpeg)] bg-cover bg-center bg-no-repeat bg-opacity-30"
>
  <div class="lg:grid lg:min-h-screen lg:grid-cols-12">

          <% if (Session["Msg_error"] != null)
              { %>
              <div class="w-[50%] bg-red-200 p-10 absolute top-2 right-2">
                  <%= Session["Msg_error"] %>
                  <% Session["Msg_error"] = null; %>
              </div>
          <%} %>
          <% if (Session["Msg_ok"] != null)
              { %>
              <div class="w-[50%] bg-green-200 p-10 absolute top-2 right-2">
                  <%= Session["Msg_ok"] %>
                  <% Session["Msg_ok"] = null; %>
              </div>
          <%} %>

    <main
      class="flex items-center justify-center px-8 py-8 sm:px-12 lg:col-span-7 lg:px-16 lg:py-12 xl:col-span-6"
    >
      <div class="max-w-xl lg:max-w-3xl">

          <h2 class="mt-6 text-2xl font-bold text-white sm:text-3xl md:text-4xl pb-3">
          Bienvenido a ECommerce
        </h2>
    

        <form action="#" class="mt-8 grid grid-cols-6 gap-6">
          <div class="col-span-6 space-y-2">
            <label for="Nombre" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="text" id="Nombre" name="nombre" required placeholder="Nombre" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm text-slate-300"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400  transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Nombre
                </span>
            </label>

            <label for="Apellido" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="text" id="Apellido" name="apellido" required placeholder="Apellido" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm text-slate-300"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400  transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Apellido
                </span>
            </label>
          
            <label for="UserEmail" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="email" id="UserEmail" name="mail" required placeholder="Email" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm text-slate-300"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Email
                </span>
            </label>
              
            <label for="dni" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="number" id="Dni" required name="dni" placeholder="Password Confirmation" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm text-slate-300"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    DNI
                </span>
            </label>

            <label for="telefono" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="text" id="Telefono" required name="telefono" placeholder="Password Confirmation" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm text-slate-300"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Telefono
                </span>
            </label>
              
            <label for="fecha_nacimiento" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="date" id="Fecha_Nacimiento" required name="fecha_nacimiento" placeholder="Fecha Nacimiento" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm text-slate-300"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Fecha de Nacimiento
                </span>
            </label>
          
            <label for="Password" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="password" id="Password" name="password" required placeholder="Password" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm text-slate-300"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Contraseña
                </span>
            </label>
          
            <label for="PasswordConfirmation" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="password" id="PasswordConfirmation" required name="password_confirmacion" placeholder="Password Confirmation" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm text-slate-300"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Confirmar contraseña
                </span>
            </label>
          </div>


          <div class="col-span-6 pt-3 pb-3">
            <p class="text-sm text-slate-200">
              Al crear una cuenta, aceptas nuestros
              <a href="#" class="text-slate-300 underline">
                terminos y condiciones
              </a>
              y 
              <a href="#" class="text-slate-300 underline">politica de privacidad</a>.
            </p>
          </div>

          <div class="col-span-6 sm:flex sm:items-center sm:gap-4">
            <button
              class="inline-block shrink-0 rounded-md border border-slate-900 bg-slate-900 px-12 py-3 text-sm font-medium text-white transition hover:bg-slate-800 hover:text-slate-400 focus:outline-none focus:ring active:text-slate-500"
            >
              Crear una cuenta
            </button>

            <p class="mt-4 text-sm text-slate-300 sm:mt-0">
              Ya tenes una cuenta?
              <a href="/InicioSesion.aspx" class="text-slate-400 underline">Iniciar sesion</a>.
            </p>
          </div>
        </form>
      </div>
    </main>
  </div>
</section>


</asp:Content>
