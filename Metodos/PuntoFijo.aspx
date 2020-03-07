<%@ Page Title="Punto Fijo" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="PuntoFijo.aspx.cs" Inherits="MetodosNumericos.Views.Metodos.PuntoFijo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" lang="javascript">
        google.charts.load('current', { packages: ['corechart', 'line'] });
        google.charts.setOnLoadCallback(drawCurveTypes);
        function drawCurveTypes() {
            var data = new google.visualization.DataTable();
            data.addColumn('number', 'X');
            data.addColumn('number', 'F(x)');

            data.addRows(<%=obtener_datos()%>);
            var options = {
                'width': 700,
                'height': 323,
                axisTitlesPosition: 'none',
                chartArea: {
                    left: 45,
                    top: 5,
                    width: '82%',
                    height: '91%'
                },

                hAxis: {
                    gridlines: {
                        count: 10
                    },
                    viewWindowMode: 'pretty',
                    minorGridlines: { count: 0 },
                    textStyle: {
                        color: 'black',
                        fontSize: 10,
                        fontName: 'Arial',
                        bold: false,
                        italic: true
                    }
                },

                vAxis: {
                    gridlines: {
                        count: 10
                    },

                    textStyle: {
                        color: 'black',
                        fontSize: 10,
                        bold: false
                    }
                },
                colors: ['red', '#097138'],
                lineWidth: 1.5,
                explorer: {
                    axis: 'horizontal',
                    keepInBounds: true,
                    maxZoomIn: 4.0 }
            };
            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>

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
                            <li class="breadcrumb-item active" aria-current="page">Metodo Punto Fijo</li>

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
            







            <div class="col-md-4">
               

                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title" style="text-align: center;">DATOS</h5>
                                <div class="container-fluid">
                                    <div class="form-row">
                                        <div class="col-md-12 mb-3">
                                            <label for="ecuacion_n">Ecuacion</label>
                                            <asp:TextBox ID="ecuacion_n" type="text" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>

                                        </div>
                                        <div class="col-md-12 mb-3">
                                        <label for="ecuacion_derivada">X (despejar x de la ecuacion)</label>
                                            <asp:TextBox ID="ecuacion_despejada" type="text" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>

                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <asp:LinkButton ID="graficar_funcion" class="btn btn-primary" runat="server" OnClick="graficar_funcion_Click"><span class="mdi mdi-chart-bar"></span>  Graficar</asp:LinkButton>
                                        </div>
                                    </div>

                                </div>
                                <hr />
                                <div class="container-fluid">
                                    <div class="form-row">
                                        <div class="col-md-12 mb-3">
                                            <label for="numero_aprox">Numero Aproximado</label>
                                            <asp:TextBox ID="numero_aprox" type="number" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                  

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
                                     <div class="col-lg-12" runat="server" id="panelGrafico2">
                                        <div class="flot-chart" style="margin-left: -20px; margin-top: -6px;">
                                            <div runat="server" id="grafica_content" class="flot-chart-content">
                                                <div id="chart_div">
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

            <div class="col-md-12">
                

                        <div class="card">
                            <div class="card-body">
                                <div class="container-fluid">
                                    <div class="form-row">
                                        <div class="col-md-4 mb-3">
                                            <asp:LinkButton ID="calcular_raiz" class="btn btn-primary" runat="server" OnClick="calcular_raiz_Click"><span class="mdi mdi-calculator"></span>  Calcular Raiz</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="resultado_raiz" class="col-sm-3 text-right control-label col-form-label">Resultado</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="resultado_raiz" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="error_calculado" class="col-sm-3 text-right control-label col-form-label">Error</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="error_calculado" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="iteraciones" class="col-sm-3 text-right control-label col-form-label">Numero de Interaciones</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="iteraciones" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                   

            </div>
        </div>





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
                                                            <h5 class="card-title">Método de Punto Fijo</h5>
                                                            <p>
                                                                Tiene como fin de resolver ecuaciones no lineales F(x)=0.
                                                                Basándose, en la idea de punto fijo de una función que se logra dando la forma que no es única,
                                                                el método de iteración de punto fijo, también denominado método de aproximación sucesiva, requiere 
                                                                volver a escribir la ecuación <b>f(x)= 0</b> en la forma <b>x = g(x)</b>.
                                                              
                                                            </p>
                                                              <br />
                                            <h5>Pasos a seguir</h5>
                                            <p>
                                                1. Se ubica la raíz de f(x) analizando la gráfica. 
                                               <br />
                                                2. Se obtiene un despeje x = g(x) de la función.
                                                <br />
                                                3. Obtenemos de x = g(x) su derivada g´(x).
                                                <br />
                                                4. Resolviendo la desigualdad -1 ≤ g´(x).≤ 1 obtenemos el rango de valores en los cuales está el punto fijo llamado R.
                                                <br />
                                                5. Con R buscamos la raíz en g(x), es decir g(R) = R haciendo iteración de las operaciones.


                                            </p>
                                                            <div style="margin-left: 34%; width: 50%;">
                                                            <img src="../../Gif/punto_fijo.gif" class="img-fluid" style="height: 200px;"/>

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
                                                -  Seleccionar el valor a evaluar, que se debe encontrar dentro del rango graficado
                                             
                                                <br />
                                                <br />
                                                FUNCIONES ADMITIDAS
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
