<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="MetodosNumericos.Views.Usuario.Inicio" %>



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
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentInicio" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title" style="font-family: ff-din-web-pro, ff-din-web, Trebuchet MS, Lucida Sans Unicode, Lucida Grande, Lucida Sans, Arial, sans-serif;">Definición</h5>
                        <p>
                            <span style="font-size: 16px !important; font-family: ff-din-web-pro; line-height: 115%;">Los métodos numéricos son técnicas mediante las cuales es posible formular
                                    problemas matemáticos de tal forma que puedan resolverse usando operaciones aritméticas.
                            </span>
                        </p>
                        <p>
                            <span style="font-size: 16px !important; font-family: ff-din-web-pro; line-height: 115%;">El análisis numérico trata de diseñar métodos para “aproximar” de una manera eficiente las
                                    soluciones de problemas expresados matemáticamente
                            </span>
                        </p>
                        <p>
                            <span style="font-size: 16px !important; font-family: ff-din-web-pro; line-height: 115%;">El objetivo principal del análisis numérico es encontrar soluciones “aproximadas” 
                                    a problemas complejos utilizando sólo las operaciones más simples de la aritmética. 
                                    Se requiere de una secuencia de operaciones algebraicas y lógicas que producen la 
                                    aproximación al problema matemático.
                            <br />
                                La eficiencia en el cálculo de dicha aproximación
                                depende, en parte, de la facilidad de implementación del algoritmo y de las
                                características especiales y limitaciones de los instrumentos de cálculo (los
                                computadores). En general, al emplear estos instrumentos de cálculo se
                                introducen errores llamados de redondeo. 


                            </span>
                        </p>
                        <p>
                            <span style="font-size: 16px !important; font-family: ff-din-web-pro; line-height: 115%;">En general, estos métodos se aplican cuando se necesita un valor numérico como solución a 
                            un problema matemático, y los procedimientos "exactos" o "analíticos" (manipulaciones algebraicas, 
                            teoría de ecuaciones diferenciales, métodos de integración, etc.) son incapaces de dar una respuesta.
                            Debido a ello, son procedimientos de uso frecuente por físicos e ingenieros, y cuyo desarrollo se ha 
                            visto favorecido por la necesidad de éstos de obtener soluciones, aunque la precisión no sea completa.
                            Debe recordarse que la física experimental, por ejemplo, nunca arroja valores exactos sino intervalos
                            que engloban la gran mayoría de resultados experimentales obtenidos, ya que no es habitual que dos 
                            medidas del mismo fenómeno arrojen valores exactamente iguales.

                            </span>

                        </p>


                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Características</h5>
                        <p>
                            <span style="font-size: 16px !important; font-family: ff-din-web-pro; line-height: 115%;">Los métodos numéricos pueden ser aplicados para resolver procedimientos matemáticos en:
                           
                            
                            <ul>
                                <li>
                                    <span lang="ES-AR" style="font-size: 10.5pt; line-height: 115%; font-family: ff-din-web-pro;">Cálculo de derivadas
                                    </span>
                                    <span style="font-family: ff-din-web-pro;"></span>
                                </li>
                                <li>
                                    <span lang="ES-AR" style="font-size: 10.5pt; line-height: 115%; font-family: ff-din-web-pro;">Integrales
                                    </span>
                                    <span style="font-family: ff-din-web-pro;"></span>
                                </li>
                                <li>
                                    <span lang="ES-AR" style="font-size: 10.5pt; line-height: 115%; font-family: ff-din-web-pro;">Ecuaciones diferenciales
                                    </span>
                                    <span style="font-family: ff-din-web-pro;"></span>
                                </li>
                                <li>
                                    <span lang="ES-AR" style="font-size: 10.5pt; line-height: 115%; font-family: ff-din-web-pro;">Operaciones con matrices
                                    </span>
                                    <span style="font-family: ff-din-web-pro;"></span>
                                </li>
                                <li>
                                    <span lang="ES-AR" style="font-size: 10.5pt; line-height: 115%; font-family: ff-din-web-pro;">Interpolaciones
                                    </span>
                                    <span style="font-family: ff-din-web-pro;"></span>
                                </li>
                                <li>
                                    <span lang="ES-AR" style="font-size: 10.5pt; line-height: 115%; font-family: ff-din-web-pro;">Ajuste de curvas
                                    </span>
                                    <span style="font-family: ff-din-web-pro;"></span>
                                </li>
                                <li>
                                    <span lang="ES-AR" style="font-size: 10.5pt; line-height: 115%; font-family: ff-din-web-pro;">Polinomios
                                    </span>
                                    <span style="font-family: ff-din-web-pro;"></span>
                                </li>
                            </ul>
                            </span>
                            <br />
                            <img src="../../Image/interpolacion.png" />

                        </p>
                    </div>
                </div>
            </div>

        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="img-fluid">
                    <%-- <img src="../../Image/metodos.jpg" width="1060" height="250" />--%>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
