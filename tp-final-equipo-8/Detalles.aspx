<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="tp_carrito_compras_equipo_20.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="fs-3"><%: Titulo %></h3>
    <div class="row row-cols-1 g-4">
        <div class="col">
            <div class="card">
                <div class="row">
                    <div class="col-4">
                        <img src="<%: articulo.Imagenes[0].Url %>" class="card-img-top img-thumbnail " height="300" onerror="this.src='<%: URL_NO_IMAGEN %>'" >
                    </div>
                    <div class="col-8">
                        <div class="card-body d-flex flex-column justify-content-between h-100">
                            <div>
                                <h5 class="card-title"><%: Titulo %></h5>
                                <p class="card-text"><%: articulo.Descripcion %></p>
                            </div>
                            <div class=" d-flex justify-content-end gap-1 pb-1">
                                <%--<asp:Button class="btn btn-success btn-sm text-white" ID="Button1" runat="server" Text="Agregar al carrito" />--%>
                                <a class="btn btn-success btn-sm text-white">Agregar al carrito</a>
                                <a href="Default.aspx" class="btn btn-primary btn-sm text-white">Volver</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
