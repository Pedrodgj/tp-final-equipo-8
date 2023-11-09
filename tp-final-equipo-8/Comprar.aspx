<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Comprar.aspx.cs" Inherits="tp_carrito_compras_equipo_20.Comprar" %>
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
        <ul class="space-y-4 pb-4">

            <button type="button" class="accordion flex items-center justify-between w-full p-5 font-medium text-left text-slate-300 bg-slate-900" data-accordion-target="#accordion-collapse-body-1" aria-expanded="true" aria-controls="accordion-collapse-body-1">
              <span>Informacion de contacto</span>
              <svg data-accordion-icon class="w-3 h-3 rotate-180 shrink-0" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 10 6">
                <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5 5 1 1 5"/>
              </svg>
            </button>
            <div id="accordion-collapse-body-1" class="panel" aria-labelledby="accordion-collapse-heading-1">
                <div class="p-5 bg-slate-900">
                  <form action="#" class="mt-8 grid grid-cols-6 gap-6">
          <div class="col-span-6 space-y-2">
            <label for="Nombre" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="text" id="Nombre" placeholder="Nombre" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400  transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Nombre
                </span>
            </label>

            <label for="Apellido" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="text" id="Apellido" placeholder="Apellido" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400  transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Apellido
                </span>
            </label>
          
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
          
            <label for="PasswordConfirmation" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="password" id="PasswordConfirmation" placeholder="Password Confirmation" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Confirmar contraseña
                </span>
            </label>
          </div>


          <div class="col-span-6 pt-3 pb-3">
            <p class="text-sm text-slate-200">
              Se creara una cuenta automaticamente al realizar este pedido. Al crear una cuenta, aceptas nuestros
              <a href="#" class="text-slate-300 underline">
                terminos y condiciones
              </a>
              y 
              <a href="#" class="text-slate-300 underline">politica de privacidad</a>.
            </p>
          </div>

          <div class="col-span-6 sm:flex sm:items-center sm:gap-4 space-y-2">
              <p class="mt-4 text-sm text-slate-300 sm:mt-0">
              Ya tenes una cuenta?
              <a href="#" class="text-slate-400 underline">Iniciar sesion</a>.
            </p>

            

            
          </div>

                <div class="col-span-6 sm:flex sm:items-end sm:gap-4 space-y-2 pt-2 float-right">
                    <button class="inline-block shrink-0 rounded-md border border-slate-700 bg-slate-800 px-12 py-3 text-sm font-medium text-white transition hover:bg-slate-800 hover:text-slate-400 focus:outline-none focus:ring active:text-slate-500">
                        Continuar
                    </button>
                </div>
        </form>
                </div>
            </div>

            <button type="button" class="accordion flex items-center justify-between w-full p-5 font-medium text-left text-slate-300 bg-slate-900" data-accordion-target="#accordion-collapse-body-1" aria-expanded="true" aria-controls="accordion-collapse-body-1">
              <span>Envio</span>
              <svg data-accordion-icon class="w-3 h-3 rotate-180 shrink-0" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 10 6">
                <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5 5 1 1 5"/>
              </svg>
            </button>
        <div id="accordion-collapse-body-1" class="panel" aria-labelledby="accordion-collapse-heading-1">
            <div class="p-5 bg-slate-900">
                <div class="flex items-center mb-4">
                    <input id="acordarEnvio" type="radio" value="" name="default-radio" class="w-4 h-4 text-slate-600 bg-slate-900 border-slate-300 focus:ring-slate-500 focus:ring-2">
                    <label for="acordarEnvio" class="ml-2 text-sm font-medium text-slate-300">Acordar con el vendedor</label>
                </div>
                <div class="flex items-center">
                    <input checked id="retiroEnvio" type="radio" value="" name="default-radio" class="w-4 h-4 text-slate-600 bg-slate-900 border-slate-300 focus:ring-slate-500 focus:ring-2 ">
                    <label for="retiroEnvio" class="ml-2 text-sm font-medium text-slate-300 ">Retirar por domicilio del vendedor</label>
                </div>
                <div class="col-span-6 sm:flex sm:items-end sm:gap-4 space-y-2 pt-2 float-right">
                <button class="inline-block shrink-0 rounded-md border border-slate-700 bg-slate-800 px-12 py-3 text-sm font-medium text-white transition hover:bg-slate-800 hover:text-slate-400 focus:outline-none focus:ring active:text-slate-500">
                    Continuar
                </button>
            </div>
            </div>

            
        </div>

         
        </ul>

        <div class="mt-8 flex justify-end border-t border-slate-700 pt-8">
          <div class="w-screen max-w-lg space-y-4">
            <dl class="space-y-0.5 text-sm text-slate-300">
              <div class="flex justify-between">
                <dt>Subtotal</dt>
                <dd>PRECIO</dd>
              </div>

              <div class="flex justify-between">
                <dt>IVA</dt>
                <dd>IVA</dd>
              </div>

              <div class="flex justify-between !text-base font-medium">
                <dt>Total</dt>
                <dd>TOTAL</dd>
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

<script>
    var acc = document.getElementsByClassName("accordion");
    var i;

        for (i = 0; i < acc.length; i++) {
            acc[i].addEventListener("click", function () {
                /* Toggle between adding and removing the "active" class,
                to highlight the button that controls the panel */
                this.classList.toggle("active");

                /* Toggle between hiding and showing the active panel */
                var panel = this.nextElementSibling;
                if (panel.style.display === "block") {
                    panel.style.display = "none";
                } else {
                    panel.style.display = "block";
                }
            });
        }
</script>
</asp:Content>
