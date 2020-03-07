<%@ Page Title="Simpson Simple" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="SimpsonSimple.aspx.cs" Inherits="MetodosNumericos.Views.Metodos.SimpsonSimple" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MigajaDePan" runat="server">
    <div class="page-breadcrumb">
        <div class="row">
            <div class="col-12 d-flex no-block align-items-center" style="margin-top: -11px;">
                <h4 class="page-title">Regla de <%: Page.Title %></h4>
                <div class="ml-auto text-right">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="/Views/Usuario/Inicio.aspx"><span class="mdi mdi-home"></span>&nbsp;Inicio</a></li>
                            <li class="breadcrumb-item"><a href="#"><span class=""></span>Integración Numerica</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Regla de Simpson Simple</li>

                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentInicio" runat="server">

    <div class="container-fluid" style="margin-top: -13px;">
        <!-- ============================================================== -->
        <!-- Start Page Content -->
        <!-- ============================================================== -->
        <div class="row">
            <div class="col-md-4">
                <div class="card">

                    <div class="card-body">
                        <h5 class="card-title" style="text-align: center;">DATOS</h5>

                        <div class="container-fluid">
                            <div class="form-row">
                                <div class="col-md-12 mb-3">
                                    <label for="ecuacion_n">Integral</label>
                                    <asp:TextBox ID="txt_ecuacion" type="text" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>

                                </div>
                                <div class="col-md-12 mb-3">
                                    <label for="numero_raiz">Limites Superior (b)</label>
                                    <asp:TextBox ID="txt_limite_sup" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>

                                </div>
                                <div class="col-md-12 mb-3">
                                    <label for="numero_raiz">Limite Inferior (a)</label>
                                    <asp:TextBox ID="txt_limite_inf" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>

                                </div>
                                <div class="col-md-12 mb-3">
                                    <label for="numero_raiz">Numero de particiones (n)</label>
                                    <asp:TextBox ID="txt_particiones" type="number" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;">1</asp:TextBox>

                                </div>
                                <div class="col-md-4 mb-3">
                                    <asp:LinkButton ID="calcular_integral" class="btn btn-primary" OnClick="calcular_integral_Click" runat="server"><span class="mdi mdi-calculator"></span>  Calcular </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <hr />
                    </div>
                </div>
            </div>

            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title" style="text-align: center;">RESULTADO</h5>
                        <div class="form-group row">
                            <label for="resultado_raiz" class="col-sm-3 text-right control-label col-form-label">Aproximación</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txt_aprox_integral" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label for="error_calculado" class="col-sm-3 text-right control-label col-form-label">Error</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txt_error_calculado" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>
                            </div>
                        </div>
                        <hr />
                    </div>
                </div>

                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title" style="text-align: center;">VALOR REAL</h5>
                        <div class="form-group row" style="height: 157px;">
                            <label for="resultado_raiz" class="col-sm-3 text-right control-label col-form-label">Resultado</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txt_resultado_real" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-4 mb-3">
                                    <asp:LinkButton ID="btn_valor_real" Style="margin-top: 12px; margin-left: 180px;" class="btn btn-primary" OnClick="btn_valor_real_Click" runat="server"><span class="mdi mdi-calculator"></span>  Calcular </asp:LinkButton>

                                    <asp:LinkButton ID="btn_graficar_funcion" Style="margin-top: -60px; margin-left: 290px;" class="btn btn-success" OnClick="btn_graficar_funcion_Click" runat="server"><span class="mdi mdi-chart-bar"></span>  Graficar</asp:LinkButton>

                                </div>
                            </div>
                        </div>
                        <hr />
                    </div>
                </div>
            </div>
        </div>

        <!-- Informcacion del metodo -->
        <div class="accordion" id="accordionExample">
            <div class="card m-b-0 border-top">
                <div class="card-header" id="headingTwo">
                    <h5 class="mb-0">
                        <a class="collapsed" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                            <i class="mdi mdi-asterisk" aria-hidden="true"></i>
                            <span style="cursor: pointer;">Consultar Más Información del Método</span>
                        </a>
                    </h5>
                </div>
                <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                    <div class="card-body">

                        <div id="Toggle-1" class="collapse show multi-collapse">
                            <div class="card">
                                <!-- Nav tabs -->
                                <ul class="nav nav-tabs" role="tablist">
                                    <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#home" role="tab"><span class="hidden-sm-up"></span><span class="hidden-xs-down">Definicion</span></a> </li>
                                    <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#profile" role="tab"><span class="hidden-sm-up"></span><span class="hidden-xs-down">Guia del Metodo</span></a> </li>

                                </ul>
                                <!-- Tab panes -->
                                <div class="tab-content tabcontent-border">
                                    <div class="tab-pane active" id="home" role="tabpanel">
                                        <div class="p-20">
                                            <div class="row">
                                                <div class="col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <h5 class="card-title">Regla de Simpson Simple</h5>
                                                            <p>
                                                                En análisis numérico, la regla o método de Simpson
                                                                (nombrada así en honor de Thomas Simpson) y a veces llamada 
                                                                regla de Kepler es un método de integración numérica que se 
                                                                utiliza para obtener la aproximación de la integral:
                                                            </p>

                                                            <div style="margin-left: 30%; width: 50%;">

                                                                <img src="../../Image/SimpsonSimple.png" class="img-fluid">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="tab-pane  p-20" id="profile" role="tabpanel">
                                        <div class="p-20">

                                            <p class="m-t-10">

                                                <br />
                                                -  En la parte de la integral de debe ingresar la funcion a integrar.
                                                <br />

                                                -  En la opcion de la grafica, se debe ingresar dos ecuaciones, puede ser la misma
                                                para juntas entradas (F(x) y G(x)), si no se cuenta con otra ecuacion para graficar.
                                                <br />
                                                NOTA ***Escribir un punto (.) para representar decimales en la ecuacion.
                                                <br />
                                                NOTA ***Escribir una coma (,) para reprensetar decimales en los limites.
                                               
                                              
                                                <br />
                                                <br />
                                                <b>FUNCIONES ADMITIDAS</b>
                                                <br />
                                                - seno=sin(x) ó sen(x)
                                                <br />
                                                - Asen=asn(x)
                                                <br />
                                                - Acos=acs(x)
                                                <br />
                                                - Atan=atn(x)
                                                <br />
                                                - coseno= cos(x)
                                                <br />
                                                - tangente=tan(x)
                                                <br />
                                                - absoluto=abs(x)
                                                <br />
                                                - logaritmo natural=Ln=log(x)
                                                <br />
                                                - exponencial=e=exp(x)
                                                <br />
                                                - raíz cuadrada =sqr(x)
                                                <br />
                                                Nota="es importante colocar los * para las multiplicaciones"
                                            </p>
                                        </div>
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
