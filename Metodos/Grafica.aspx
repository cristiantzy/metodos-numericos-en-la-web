<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grafica.aspx.cs" Inherits="MetodosNumericos.Views.Metodos.Grafica" %>

<!DOCTYPE html>

<html>
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />


    <title>Grafica | Metodos Numericos</title>


    <link rel="icon" type="image/png" sizes="16x16" href="~/favicon_ico.png">

    <!-- Custom CSS -->
    <link href="/Content/assets/libs/flot/css/float-chart.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="/Content/dist/css/style.min.css" rel="stylesheet">

    <link href="/Content/dist/css/sweetalert2.min.css" rel="stylesheet" />
    <script src="/Content/dist/js/sweetalert2.all.min.js" type="text/javascript"></script>

    <link href="Content/styleCss.css" rel="stylesheet" />



    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>


    <script type="text/javascript" lang="javascript">

                        google.charts.load('current', { packages: ['corechart', 'line'] });
                        google.charts.setOnLoadCallback(drawCurveTypes);
                        function drawCurveTypes() {
                            var data = new google.visualization.DataTable();
                            data.addColumn('number', 'X');
                            data.addColumn('number', 'F(x)');
                            data.addColumn('number', 'G(x)');

                            data.addRows(<%=obtener_datos()%>);
                            var options = {
                                'width': 1000,
                                'height': 345,
                                axisTitlesPosition: 'none',
                                chartArea: {
                                    left: 100,
                                    top: 5,
                                    width: '78%',
                                    height: '94%'
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
                                lineWidth: 1.7,
                                explorer: {
                                    axis: 'horizontal',
                                    keepInBounds: true,
                                    maxZoomIn: 4.0}
                            };
                            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
                            chart.draw(data, options);
                        }
                    </script>









</head>
<body>
    <form id="form1" runat="server">
        <div class="preloader">
            <div class="lds-ripple">
                <div class="lds-pos"></div>
                <div class="lds-pos"></div>
            </div>
        </div>
        <div id="main-wrapper" class="mini-sidebar" data-sidebartype="mini-sidebar">
            <header class="topbar" data-navbarbg="skin5">
                <nav class="navbar top-navbar navbar-expand-md navbar-dark">
                    <div class="navbar-header" data-logobg="skin5">

                        <a class="nav-toggler waves-effect waves-light d-block d-md-none" href="javascript:void(0)"><i class="ti-menu ti-close"></i></a>
                        <a class="navbar-brand" href="#">

                            <b class="logo-icon p-l-10">
                                <img src="/Image/icon_modific.png" alt="homepage" class="light-logo" />

                            </b>
                            
                        </a>
                        <a class="topbartoggler d-block d-md-none waves-effect waves-light" href="javascript:void(0)" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><i class="ti-more"></i></a>
                    </div>
                    <div class="navbar-collapse collapse" id="navbarSupportedContent" data-navbarbg="skin5">
                        <ul class="navbar-nav float-left mr-auto">
                            <li class="nav-item d-none d-md-block">
                                <a href="#" >
                                    <span class="logo-text">
                                  <img src="/Image/modific_ico.png" alt="homepage" class="light-logo" style="margin-left: 12px;"/>

                            </span>
                                </a>

                            </li>

                        </ul>
                        <ul class="navbar-nav float-right">
                            <li class="nav-item dropdown">
                                <a class="nav-link dropdown-toggle waves-effect waves-dark" href="#" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">

                                    <i></i>

                                </a>
                            </li>

                        </ul>
                    </div>
                </nav>
            </header>

            <aside class="left-sidebar" data-sidebarbg="skin5">
            </aside>

            <div class="page-wrapper">

                <div class="container-fluid" style="margin-top: -13px;">
                    <!-- ============================================================== -->
                    <!-- Start Page Content -->
                    <!-- ============================================================== -->
                    <div class="row" >
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="d-md-flex align-items-center">
                                        <div>
                                            <h4 class="card-title">Analisis Grafico</h4>
                                            <h5 class="card-subtitle">Resumen de tiempo actual</h5>
                                        </div>
                                    </div>
                                    <div class="row" style="height: 370px;">
                                        <!-- column -->
                                        <div class="col-lg-12" runat="server" id="panelGrafico2">
                                            <div class="flot-chart" style="margin-left: -20px; margin-top: -6px;">
                                                    <div id="chart_div">
                                                    
                                                </div>
                                            </div>
                                        </div>


                                    </div>


                                    <div class="modal-footer">
                                        <div class="container-fluid">
                                            <div class="form-row">
                                                <div class="col-md-6 mb-3">
                                                    <label for="ecuacion_n">Ecuación F(x)</label>
                                                    <asp:TextBox ID="txt_ecuacion" type="text" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;" placeholder="Digite la ecuación F(x)"></asp:TextBox>

                                                </div>
                                                <div class="col-md-6 mb-3">
                                                    <label for="ecuacion_n">Ecuación G(x)</label>
                                                    <asp:TextBox ID="txt_ecuacion1" type="text" class="form-control" runat="server" Style="border: 1px solid#776c6c !important;" placeholder="Digite la ecuación G(x)"></asp:TextBox>

                                                </div>



                                            </div>

                                        </div>
                                        <asp:LinkButton ID="btn_grafica" class="btn btn-success" Style="margin-top: 10px;" OnClick="btn_grafica_Click" runat="server"><span class="mdi mdi-chart-bar"></span>  Graficar</asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <!-- ============================================================== -->
                <!-- ============================================================== -->
                <!-- footer -->
                <!-- ============================================================== -->
                <footer class="footer text-center">
                    <p>&copy; <%: DateTime.Now.Year %> - Metodos Numericos</p>
                    All Rights Reserved by UNIAMAZONIA. Designed and Developed by <a href="#">Cristian Tisoy</a>.
                </footer>
                <!-- ============================================================== -->
                <!-- End footer -->
                <!-- ============================================================== -->
            </div>
        </div>











    </form>
    <script src="/Content/assets/libs/jquery/dist/jquery.min.js"></script>

    <script src="/Content/assets/libs/popper.js/dist/umd/popper.min.js"></script>
    <script src="/Content/assets/libs/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="/Content/assets/libs/perfect-scrollbar/dist/perfect-scrollbar.jquery.min.js"></script>
    <script src="/Content/assets/extra-libs/sparkline/sparkline.js"></script>

    <script src="/Content/dist/js/waves.js"></script>
    <!--Menu sidebar -->
    <script src="/Content/dist/js/sidebarmenu.js"></script>
    <!--Custom JavaScript -->
    <script src="/Content/dist/js/custom.min.js"></script>
    <!--This page JavaScript -->
    <!-- <script src="../../dist/js/pages/dashboards/dashboard1.js"></script> -->
    <!-- Charts js Files -->
    <script src="/Content/assets/libs/flot/excanvas.js"></script>
    <script src="/Content/assets/libs/flot/jquery.flot.js"></script>
    <script src="/Content/assets/libs/flot/jquery.flot.pie.js"></script>
    <script src="/Content/assets/libs/flot/jquery.flot.time.js"></script>
    <script src="/Content/assets/libs/flot/jquery.flot.stack.js"></script>
    <script src="/Content/assets/libs/flot/jquery.flot.crosshair.js"></script>
    <script src="/Content/assets/libs/flot.tooltip/js/jquery.flot.tooltip.min.js"></script>
    <script src="/Content/dist/js/pages/chart/chart-page-init.js"></script>

</body>
</html>
