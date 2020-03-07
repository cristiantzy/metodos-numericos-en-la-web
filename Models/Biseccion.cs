using Calculus;
using System;
using System.Data;

namespace MetodosNumericos.Models
{

    public class Biseccion
    {
        private readonly string ecuacion;
        private double x1;
        private double x2;
        private double fx2;
        private double fx1;
        private double xr;
        private double xr_anterior;
        private double fxr;
        private double fxrXx2;
        private double error_aproximado;
        private int key = 0, iteracion = 0;
        private readonly double error_aux = 1 * (Math.Pow(10, -7));

        // variables y vectores de la grafica.

        private readonly int dimension_rango = 41;
        private int inicio_por_defecto=11;

        private int inicio_rango = -20;
        private int corte = 0;
        private int inicio_grafica = 0;

        private object[] datos_iniciales;
        private object[] resultado_evaluado;



        private readonly Calculo lectorDeEcuaciones;


        public Biseccion(string ecuacion, double x1, double x2)
        {
            this.ecuacion = ecuacion;
            this.x1 = x1;
            this.x2 = x2;
            this.fx2 = 0;
            this.fx1 = 0;
            this.xr = 0;
            this.xr_anterior = 0;
            this.fxr = 0;
            this.fxrXx2 = 0;

            this.error_aproximado = 100;

            this.lectorDeEcuaciones = new Calculo();

        }
        public Biseccion()
        {
            this.ecuacion = "";
            this.x1 = 0;
            this.x2 = 0;
            this.fx2 = 0;
            this.fx1 = 0;
            this.xr = 0;
            this.xr_anterior = 0;
            this.fxr = 0;
            this.fxrXx2 = 0;

            this.error_aproximado = 100;

            this.lectorDeEcuaciones = new Calculo();

        }

        

        public bool verificar_rango()
        {
            double evaluador = 0, evaluador1 = 0;

            if (lectorDeEcuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                evaluador = lectorDeEcuaciones.EvaluaFx(x1);
                evaluador1 = lectorDeEcuaciones.EvaluaFx(x2);

                if ((evaluador > 0 && evaluador1 < 0) || (evaluador1 > 0 && evaluador < 0))
                {
                    return true;
                }
            }
            return false;
        }



        public double raiz()
        {


            if (lectorDeEcuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                fx1 = lectorDeEcuaciones.EvaluaFx(x1);
                fx2 = lectorDeEcuaciones.EvaluaFx(x2);
                xr = (x1 + x2) / 2;



                while (error_aproximado >= (error_aux))
                {

                    fxr = lectorDeEcuaciones.EvaluaFx(xr);

                    fxrXx2 = (fxr * x2);

                    if (fxrXx2 < 0)
                    {
                        x1 = xr;
                        fx1 = lectorDeEcuaciones.EvaluaFx(x1);
                        xr = (x1 + x2) / 2;
                    }
                    else
                    {
                        if (fxrXx2 > 0)
                        {
                            x2 = xr;
                            fx2 = lectorDeEcuaciones.EvaluaFx(x2);
                            xr = (x1 + x2) / 2;
                        }

                    }


                    // calculo de error;
                    if (key == 1)
                    {
                        error_aproximado = Math.Abs(((xr - xr_anterior) / xr) * 100);
                    }
                    else
                    {
                        key = 1;
                    }
                    xr_anterior = xr;
                    iteracion++;

                }


            }

            return xr;
        }


        public double error_aprox()
        {

            return error_aproximado;
        }

        public int iteraciones()
        {

            return iteracion;
        }



        // inicializar valores del eje x, para realizar la grafica (automatico)
        public void vector_a_graficar()
        {
            // 1)  hallar el punto de corte
            // 2)  armar el vector con el rango a graficar
            datos_iniciales = new object[dimension_rango];
            resultado_evaluado = new object[dimension_rango];

            string ecuacioN = this.ecuacion;

            if (ecuacioN!="")
            {
                double resultado_actual = 0, resultado_siguiente = 0;
                object[] punto_corte = new object[2];
                punto_corte[0] = 0;
                punto_corte[1] = 0;

                // llenando el rango para buscar el punto de corte.
                object[] rango_x = new object[dimension_rango];


                for (int i = 0; i < rango_x.Length; i++)
                {
                    rango_x[i] = inicio_rango;
                    inicio_rango = (inicio_rango + 1);
                }

                //llenando la funcion 
                if (lectorDeEcuaciones.Sintaxis(ecuacioN, Convert.ToChar("x")))
                {
                    for (int i = 0; i < (rango_x.Length - 1); i++)
                    {
                        resultado_actual = lectorDeEcuaciones.EvaluaFx(Convert.ToDouble(rango_x[i]));
                        resultado_siguiente = lectorDeEcuaciones.EvaluaFx(Convert.ToDouble(rango_x[i + 1]));
                        // evaluar el inidice actual y el siguiente.. y detectar el punto de corte...

                        if (resultado_actual > 0 && resultado_siguiente < 0)//inicia graficando desde la parte positiva.
                        {
                            punto_corte[0] = rango_x[i];
                        }
                        else
                        {
                            if (resultado_actual < 0 && resultado_siguiente > 0)//inicia graficando la parte negativa.
                            {
                                punto_corte[1] = rango_x[i];
                            }
                        }
                    }
                    //buscar el dato a graficar
                    if (Convert.ToInt16(punto_corte[1]) != 0)
                    {
                        //hay un dato en la segunda posicion, realizar grafica positiva
                        corte = Convert.ToInt16(punto_corte[1]);
                    }
                    else
                    {
                        //realizar la grafica negativa ()
                        corte = Convert.ToInt16(punto_corte[0]);
                    }

                    //añadir datos de lado y lado al punto de corte, para graficar.
                    // dato negativo 
                    // dimensionar vector
                    datos_iniciales = new object[inicio_por_defecto];
                    resultado_evaluado = new object[inicio_por_defecto];

                    inicio_grafica = corte - 5;

                    // 2) ARMAR EL VECTOR A GRAFICAR
                    for (int i = 0; i < datos_iniciales.Length; i++)
                    {
                        datos_iniciales[i] = inicio_grafica;
                        inicio_grafica = (inicio_grafica + 1);
                    }


                }

            }

        }
        public void datosFX()
        {
            double resultado = 0;


            if (ecuacion != "")
            {
                vector_a_graficar();

                // llenar datos evaluados en la funcion.
                if (lectorDeEcuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
                {
                    for (int i = 0; i < resultado_evaluado.Length; i++)
                    {
                        resultado = lectorDeEcuaciones.EvaluaFx(Convert.ToDouble(datos_iniciales[i]));

                        resultado_evaluado[i] = resultado;
                    }
                }
            }
            else
            {
                // crear vectores de acuerdo a la dimension

                datos_iniciales = new object[inicio_por_defecto];
                resultado_evaluado = new object[inicio_por_defecto];
            
                for (int i = 0; i < resultado_evaluado.Length; i++)
                {
                    resultado_evaluado[i] = 0;
                }
                double aux_inicio = -5;
                for (int i = 0; i < datos_iniciales.Length; i++)
                {
                    datos_iniciales[i] = aux_inicio;
                    aux_inicio = (aux_inicio + 1);
                }

            }

        }

     
        public string obtener_datos()
        {
            datosFX();


            DataTable datos = new DataTable();

            // columna de los datos
            datos.Columns.Add(new DataColumn("X", typeof(string)));
            datos.Columns.Add(new DataColumn("F(x)", typeof(string)));

            //datos de las columnas(mostrar en el shart)
            for (int i = 0; i < resultado_evaluado.Length; i++)
            {
                datos.Rows.Add(new object[] { datos_iniciales[i], resultado_evaluado[i] });
            }
            string strDatos;
            strDatos = "[";
            foreach (DataRow item in datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + item[0].ToString().Replace(",", ".") + "," + item[1].ToString().Replace(",", ".");
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";
            return strDatos;
        }


    }
}