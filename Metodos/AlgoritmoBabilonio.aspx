<%@ Page Title="Algoritmo Babilonio" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AlgoritmoBabilonio.aspx.cs" Inherits="MetodosNumericos.Views.Metodos.AlgoritmoBabilonio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MigajaDePan" runat="server">
    <div class="page-breadcrumb">
        <div class="row">
            <div class="col-12 d-flex no-block align-items-center" style="margin-top: -11px;">
                <h4 class="page-title"><%: Page.Title %></h4>
                <div class="ml-auto text-right">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="/Views/Usuario/Inicio.aspx"><span class="mdi mdi-home"></span>&nbsp;Inicio</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Algoritmo Babilonio</li>

                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentInicio" runat="server">
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <div class="container-fluid" style="margin-top: -13px;">
        <!-- ============================================================== -->
        <!-- Start Page Content -->
        <!-- ============================================================== -->
        <div class="row">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">
                            <p>
                                El método babilónico de resolución de raíces cuadradas se centra en el hecho de que cada lado de un cuadrado es la raíz cuadrada del área. Fue usado durante muchos años para calcular raíces cuadradas a mano debido a su gran eficacia y rapidez.

                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <asp:UpdatePanel ID="panel1" runat="server">
                        <ContentTemplate>


                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title" style="text-align: center;">DATOS</h5>
                                    <div class="container-fluid">
                                        <div class="form-row">
                                            <div class="col-md-12 mb-3">
                                                <label for="numero_raiz">Numero</label>
                                                <asp:TextBox ID="numero_raiz" type="number" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>

                                            </div>
                                            <div class="col-md-4 mb-3">
                                                <asp:LinkButton ID="calcular_raiz" class="btn btn-primary" runat="server" OnClick="calcular_raiz_Click"><span class="mdi mdi-calculator"></span>  Calcular</asp:LinkButton>
                                            </div>
                                        </div>

                                    </div>
                                    <hr />
                                    <div class="container-fluid">
                                        <div class="form-row">
                                            <div class="col-md-12 mb-3">
                                                <label for="numero_raiz">Raiz Cuadrada</label>
                                                <asp:TextBox ID="resultado_raiz" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>

                                            </div>
                                            <div class="col-md-12 mb-3">
                                                <label for="numero_raiz">Error</label>
                                                <asp:TextBox ID="error_raiz" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>

                <div class="col-md-8">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="d-md-flex align-items-center">
                                        <div>
                                            <h4 class="card-title">Analisis Grafico</h4>
                                            <h5 class="card-subtitle">Resumen de tiempo actual</h5>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <!-- column -->
                                        <div class="col-lg-12">
                                            <div class="flot-chart">
                                                <div class="flot-chart-content" id="flot-line-chart"></div>
                                            </div>
                                        </div>
                                        <%--                                       <div class="col-lg-3">

                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>











            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
