﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeBehind="AgregarMarca.aspx.cs" Inherits="tp_carrito_compras_equipo_20.admin.AgregarMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="nestedContent" runat="server">
    <% if (accion == "editar")
        { %> 
     <h1 class="mt-6 text-2xl font-bold text-slate-300 sm:text-3xl md:text-4xl pb-3">Editar Marca</h1>
    <% }
        else { %>
    <h1 class="mt-6 text-2xl font-bold text-slate-300 sm:text-3xl md:text-4xl pb-3">Agregar Marca</h1>
    <%
        }%>


    <div class="grid grid-cols-1 gap-6 mt-4 sm:grid-cols-2 w-2/3">
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
        <%--<div>
        <label for="codigo" class="mb-2 text-sm font-medium text-slate-400">Codigo de categoria</label>--%>
        <input type="hidden" id="codigo" value="<%= id %>" name="codigo" class="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600" placeholder="Codigo">
        <input type="hidden" id="accion" value="<%= accion %>" name="accion" class="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600" placeholder="Codigo">
        <%--</div>--%>

        <div>
            <label for="descripcion" class=" mb-2 text-sm font-medium text-slate-400">Descripcion</label>
            <input type="text" id="descripcion" value="<%= descripcion %>" name="descripcion" class="bg-slate-800 block w-full rounded-md border border-slate-900 px-3 py-2 shadow-sm focus-within:border-slate-600 focus-within:ring-1 focus-within:ring-slate-600" placeholder="Nombre">
        </div>
    </div>

    <button class="inline-block shrink-0 rounded-md border border-emerald-700 bg-emerald-800 px-12 py-3 mt-5 text-sm font-medium text-white transition hover:bg-slate-800 hover:text-slate-400 focus:outline-none focus:ring active:text-slate-500">
                Agregar
            </button>
</asp:Content>
