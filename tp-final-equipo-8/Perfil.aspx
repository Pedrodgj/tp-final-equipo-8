<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="tp_carrito_compras_equipo_20.Perfil" %>
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
          Perfil de Usuario
        </h2>

          <div class="max-w-2xl mx-auto">
    
    <div class="border-b border-gray-200 dark:border-gray-700 mb-4">
        <ul class="flex flex-wrap -mb-px" id="myTab" data-tabs-toggle="#myTabContent" role="tablist">
            <li class="mr-2" role="presentation">
                <button class="inline-block text-slate-400 hover:text-slate-300 hover:border-slate-300 rounded-t-lg py-4 px-4 text-sm font-medium text-center border-transparent border-b-2" id="general-tab" data-tabs-target="#general" type="button" role="tab" aria-controls="general" aria-selected="false">General</button>
            </li>
            <li class="mr-2" role="presentation">
                <button class="inline-block text-slate-400 hover:text-slate-300 hover:border-slate-300 rounded-t-lg py-4 px-4 text-sm font-medium text-center border-transparent border-b-2 active" id="pedidos-tab" data-tabs-target="#pedidos" type="button" role="tab" aria-controls="pedidos" aria-selected="true">Pedidos</button>
            </li>
            <li class="mr-2" role="presentation">
                <button class="inline-block text-slate-400 hover:text-slate-300 hover:border-slate-300 rounded-t-lg py-4 px-4 text-sm font-medium text-center border-transparent border-b-2" id="domicilio-tab" data-tabs-target="#domicilio" type="button" role="tab" aria-controls="domicilio" aria-selected="false">Domicilio</button>
            </li>
            <li role="presentation">
                <button class="inline-block text-slate-400 hover:text-slate-300 hover:border-slate-300 rounded-t-lg py-4 px-4 text-sm font-medium text-center border-transparent border-b-2" id="informacion-tab" data-tabs-target="#informacion" type="button" role="tab" aria-controls="informacion" aria-selected="false">Informacion de cuenta</button>
            </li>
        </ul>
    </div>
    <div id="myTabContent">
        <div class="p-4 rounded-lg bg-slate-900 hidden" id="general" role="tabpanel" aria-labelledby="general-tab">
            <p class="text-slate-400 text-sm">pestaña general</p>
        </div>
        <div class="p-4 rounded-lg bg-slate-900" id="pedidos" role="tabpanel" aria-labelledby="pedidos-tab">
            <p class="text-slate-400 text-sm">pestaña de pedidos</p>
        </div>
        <div class="p-4 rounded-lg bg-slate-900 hidden" id="domicilio" role="tabpanel" aria-labelledby="domicilio-tab">
            <p class="text-slate-400 text-sm">

                <div class="grid grid-cols-1 gap-6 mt-4 sm:grid-cols-2 w-max">
                    <div>
                        <label for="tbCalle" class="mb-2 text-sm font-medium text-slate-400">Calle</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbCalle" placeholder="Calle" name="calle" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>

                    <div>
                        <label for="tbCiudad" class="mb-2 text-sm font-medium text-slate-400">Ciudad/s</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbCiudad" placeholder="Ciudad" name="ciudad" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>

                    <div>
                        <label for="tbDepartamento" class="mb-2 text-sm font-medium text-slate-400">Departamento</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbDepartamento" placeholder="Departamento" name="departamento" readonly="true" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>

                    <div>
                        <label for="tbNumero" class="mb-2 text-sm font-medium text-slate-400">Numero</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbNumero" placeholder="Numero" name="numero" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>

                    <div>
                        <label for="tbPiso" class="mb-2 text-sm font-medium text-slate-400">Piso</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbPiso" placeholder="Piso" name="piso" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>

                    <div>
                        <label for="tbProvincia" class="mb-2 text-sm font-medium text-slate-400">Provincia</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbProvincia" placeholder="Provincia" name="provincia" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>

                    <div>
                        <label for="tbCP" class="mb-2 text-sm font-medium text-slate-400">Codigo Postal</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbCP" placeholder="Codigo Postal" name="cp" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>
                    <div>
                        <label for="tbReferencia" class="mb-2 text-sm font-medium text-slate-400">Referencia</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbReferencia" placeholder="Referencia" name="referencia" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>
                </div>

                <button class="inline-block shrink-0 rounded-md border border-emerald-700 bg-emerald-800 px-12 py-3 mt-5 text-sm font-medium text-white transition hover:bg-slate-800 hover:text-slate-400 focus:outline-none focus:ring active:text-slate-500">
                Guardar
            </button>
            </p>
        </div>
        <div class="p-4 rounded-lg bg-slate-900 hidden" id="informacion" role="tabpanel" aria-labelledby="informacion-tab">
            <p class="text-slate-400 text-sm space-y-2">

                <div class="grid grid-cols-1 gap-6 mt-4 sm:grid-cols-2 w-max">
                    <div class="text-slate-200">
                        Rol de usuario
                    </div>
                    <div class="text-slate-200">
                        <% string rol;
                            rol = usuario.IdTipoUsuario == 1 ? "Administrador" : "Cliente";
                        %>
                        <%: rol %>
                    </div>
                    <div>
                        <label for="tbNombres" class="mb-2 text-sm font-medium text-slate-400">Nombre/s</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbNombres" placeholder="Nombres" name="nombres" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>

                    <div>
                        <label for="tbApellido" class="mb-2 text-sm font-medium text-slate-400">Apellido/s</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbApellido" placeholder="Apellido" name="apellido" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>

                    <div>
                        <label for="tbDNI" class="mb-2 text-sm font-medium text-slate-400">DNI</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbDNI" placeholder="DNI" name="dni" readonly="true" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>

                    <div>
                        <label for="tbMail" class="mb-2 text-sm font-medium text-slate-400">Correo electronico</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbMail" placeholder="Correo electronico" name="email" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>

                    <div>
                        <label for="calFecha" class="mb-2 text-sm font-medium text-slate-400">Fecha de nacimiento</label>
                    </div>

                    <div>
                        <asp:Calendar ID="calFecha" runat="server" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:Calendar>
                    </div>

                    <div>
                        <label for="tbTel" class="mb-2 text-sm font-medium text-slate-400">Telefono</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbTel" placeholder="Telefono" name="telefono" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>

                    <div>
                        <label for="tbPwd" class="mb-2 text-sm font-medium text-slate-400">Contraseña</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tbPwd" placeholder="Contraseña" name="pwd" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>
                    <div>
                        <label for="tb2Pwd" class="mb-2 text-sm font-medium text-slate-400">Confirmar contraseña</label>
                    </div>

                    <div>
                        <asp:TextBox runat="server" type="text" id="tb2Pwd" placeholder="Confirmar contraseña" name="pwd2" cssclass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600 text-slate-200"></asp:TextBox>
                    </div>
                </div>

                <button class="inline-block shrink-0 rounded-md border border-emerald-700 bg-emerald-800 px-12 py-3 mt-5 text-sm font-medium text-white transition hover:bg-slate-800 hover:text-slate-400 focus:outline-none focus:ring active:text-slate-500">
                Guardar
            </button>

            </p>
        </div>
    </div>

    <p class="mt-5 text-slate-400">texto que siempre aparece</p>
</div>

<script src="https://unpkg.com/@themesberg/flowbite@1.2.0/dist/flowbite.bundle.js"></script>
    

        <form action="#" class="mt-8 grid grid-cols-6 gap-6">
            
          <% if (Session["Msg_error"] != null)
              { %>
              <div class="bg-red-200 p-10 absolute top-2 right-2">
                  <%= Session["Msg_error"] %>
                  <% Session["Msg_error"] = null; %>
              </div>
          <%} %>
          <% if (Session["Msg_ok"] != null)
              { %>
              <div class="bg-green-200 p-10 absolute top-2 right-2">
                  <%= Session["Msg_ok"] %>
                  <% Session["Msg_ok"] = null; %>
              </div>
          <%} %>

<%--          <div class="col-span-6 space-y-2">
            <label for="UserEmail" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="email" id="UserEmail" placeholder="Email" name="mail" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Email
                </span>
            </label>
          
            <label for="Password" class="bg-slate-800 relative block overflow-hidden rounded-md border border-slate-900 px-3 pt-3 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600">
                <input type="password" id="Password" placeholder="Password" name="password" class="peer h-8 w-full border-none bg-transparent p-0 placeholder-transparent focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm"/>

                <span class="absolute start-3 top-3 -translate-y-1/2 text-xs text-slate-400 transition-all peer-placeholder-shown:top-1/2 peer-placeholder-shown:text-sm peer-focus:top-3 peer-focus:text-xs">
                    Contraseña
                </span>
            </label>
          </div>--%>


          <%--<div class="col-span-6 sm:flex sm:items-center sm:gap-4 pt-10">
            <button class="inline-block shrink-0 rounded-md border border-slate-700 bg-slate-800 px-12 py-3 text-sm font-medium text-white transition hover:bg-slate-800 hover:text-slate-400 focus:outline-none focus:ring active:text-slate-500">
                Cerrar Sesión
            </button>
          </div>--%>

            <div class="col-span-6 sm:flex sm:items-center sm:gap-4 pt-10">
                <asp:Button ID="btnCerrarSesion" runat="server" CssClass="inline-block shrink-0 rounded-md border border-slate-700 bg-slate-800 px-12 py-3 text-sm font-medium text-white transition hover:bg-slate-800 hover:text-slate-400 focus:outline-none focus:ring active:text-slate-500"
                    Text="Cerrar Sesión" />
            </div>


             <%--<p class="mt-4 text-sm text-slate-300 sm:mt-0">
              No tenes una cuenta? 
              <a href="/Registro.aspx" class="text-slate-400 underline">Registrate</a>.
            </p>--%>
        </form>
      </div>
    </main>
  </div>
</section>


</asp:Content>
