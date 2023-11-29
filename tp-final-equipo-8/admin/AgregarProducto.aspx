<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="tp_carrito_compras_equipo_20.admin.AgregarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nestedContent" runat="server">
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

    <h1 class="mt-6 text-2xl font-bold text-slate-300 sm:text-3xl md:text-4xl pb-3">
        <% if (id > 0)
        { %> 
    Editar producto
    <% }
        else { %> 
    Agregar producto
    <% }%>
    </h1>


    <div class="grid grid-cols-1 gap-6 mt-4 sm:grid-cols-2 w-2/3">
        <div>
        <label for="codigo" class="mb-2 text-sm font-medium text-slate-400">Codigo del producto</label>
        <asp:TextBox runat="server" id="tbCodigo" type="text" class="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600" placeholder="Codigo"></asp:TextBox>
        </div>

        <div>
        <label for="Nombre" class=" mb-2 text-sm font-medium text-slate-400">Nombre del producto</label>
        <asp:TextBox runat="server" id="tbNombre" type="text" class="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600" placeholder="Nombre"></asp:TextBox>
        </div>

        <div>
        <label for="Descripcion" class=" mb-2 text-sm font-medium text-slate-400">Descripcion del producto</label>
        <asp:TextBox runat="server" id="tbDescripcion" type="text" class="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600" placeholder="Descripcion"></asp:TextBox>
        </div>

        <div>
        <label for="categoria" class=" mb-2 text-sm font-medium text-slate-400">Categoria</label>
        <asp:DropDownList id="ddlCategoria" CssClass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600" runat="server">
            <asp:ListItem Enabled="true" Text= "Seleccionar" Value= ""></asp:ListItem>
            <asp:ListItem Text= "Categoria" Value= ""></asp:ListItem>
        </asp:DropDownList>
        </div>

        <div>
        <label for="marca" class=" mb-2 text-sm font-medium text-slate-400">Marca</label>
        <asp:DropDownList id="ddlMarca" CssClass="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600" runat="server">
            <asp:ListItem Enabled="true" Text= "Seleccionar" Value= ""></asp:ListItem>
            <asp:ListItem Text= "Marca" Value= ""></asp:ListItem>
        </asp:DropDownList>
        </div>

        <div>
        <label for="Precio" class=" mb-2 text-sm font-medium text-slate-400">Precio del producto</label>
        <asp:TextBox runat="server" id="tbPrecio" type="number" class="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600" placeholder="Precio"></asp:TextBox>
        </div>

        <%--<div class="col-span-2">
            <label for="multiple_files" class="block mb-2 text-sm font-medium text-slate-400">Imagenes</label>
            <input class="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600" id="multiple_files" type="file" multiple>
        </div>--%>
    </div>

    <asp:Button runat="server" id="btnAgregar" onclick="btnAgregar_Click" cssclass="inline-block shrink-0 rounded-md border border-emerald-700 bg-emerald-800 px-12 py-3 mt-5 text-sm font-medium text-white transition hover:bg-slate-800 hover:text-slate-400 focus:outline-none focus:ring active:text-slate-500"></asp:Button>
</asp:Content>
