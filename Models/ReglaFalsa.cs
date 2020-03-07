using Calculus;
using System;
using System.Data;

namespace MetodosNumericos.Models
{
    public class ReglaFalsa
    {
        private readonly string ecuacion;
        private double inter_izq;
        private double inter_derec;

        private double funcionX1;
        private double funcionX2;

        private double xr, xr_anterior = 0;
        private double funcionXR;

        private double multiplicacion_fxr_x2;

        private int iteranciones = 0, key = 0;
        public double error_aproximado;

        private readonly double error_aux = 1 * (Math.Pow(10, -7));

        // datos para realizar graficas
        private readonly int dimension_rango = 41;
        private int inicio_por_defecto = 11;

        private int inicio_rango = -20;
        private int corte = 0;
        private int inicio_grafica = 0;

        private object[] datos_iniciales;
        private object[] resultado_evaluado;

        private Calculo lector_de_ecuaciones;


        public ReglaFalsa(string ecuacion, double inter_izq, double inter_derec)
        {
            this.ecuacion = ecuacion;
            this.inter_izq = inter_izq;
            this.inter_derec = inter_derec;
            this.funcionX1 = 0;
            this.funcionX2 = 0;
            this.xr = 0;
            this.funcionXR = 0;
            this.multiplicacion_fxr_x2 = 0;
            this.iteranciones = 0;
            this.error_aproximado = 100;
            this.lector_de_ecuaciones = new Calculo();


        }

        public bool verificar_rango()
        {
            double evaluador = 0, evaluador1 = 0;

            if (lector_de_ecuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                evaluador = lector_de_ecuaciones.EvaluaFx(inter_izq);
                evaluador1 = lector_de_ecuaciones.EvaluaFx(inter_derec);

                if ((evaluador > 0 && evaluador1 < 0) || (evaluador1 > 0 && evaluador < 0))
                {
                    return true;
                }
            }
            return false;
        }





        public double raiz_aproximada()
        {
            // verificar que la ecuacion este bien escrita.
            if (lector_de_ecuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                funcionX1 = lector_de_ecuaciones.EvaluaFx(inter_izq);
                funcionX2 = lector_de_ecuaciones.EvaluaFx(inter_derec);
                xr = inter_derec - ((funcionX2) * (inter_izq - inter_derec) / (funcionX1 - funcionX2));



                while (error_aproximado >= (error_aux))
                {
                    funcionXR = lector_de_ecuaciones.EvaluaFx(xr);
                    multiplicacion_fxr_x2 = (funcionXR * inter_derec);

                    if (multiplicacion_fxr_x2 < 0)
                    {
                        inter_izq = xr;
                        funcionX1 = lector_de_ecuaciones.EvaluaFx(inter_izq);
                        xr = inter_derec - ((funcionX2) * (inter_izq - inter_derec) / (funcionX1 - funcionX2));
                    }
                    else
                    {
                        if (multiplicacion_fxr_x2 > 0)
                        {
                            inter_derec = xr;
                            funcionX2 = lector_de_ecuaciones.EvaluaFx(inter_derec);
                            xr = inter_derec - ((funcionX2) * (inter_izq - inter_derec) / (funcionX1 - funcionX2));
                        }

                    }

                    // calculo de errror.
                    if (key == 1)
                    {
                        error_aproximado = Math.Abs(((xr - xr_anterior) / xr) * 100);
                    }
                    else
                    {
                        key = 1;
                    }
                    xr_anterior = xr;

                    iteranciones++;
                }


            }


            return xr;
        }

        public int iteracion_total()
        {

            return iteranciones;

        }

        public double error_aprx()
        {


            return error_aproximado;
        }
        // datos de para realizar graficas
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


        public void datosFX()
        {
            double resultado = 0;


            if (ecuacion != "")
            {
                vector_a_graficar();

                // llenar datos evaluados en la funcion.
                if (lector_de_ecuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
                {
                    for (int i = 0; i < resultado_evaluado.Length; i++)
                    {
                        resultado = lector_de_ecuaciones.EvaluaFx(Convert.ToDouble(datos_iniciales[i]));

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


        public void vector_a_graficar()
        {
            // 1)  hallar el punto de corte
            // 2)  armar el vector con el rango a graficar
            datos_iniciales = new object[dimension_rango];
            resultado_evaluado = new object[dimension_rango];

            string ecuacioN = this.ecuacion;

            if (ecuacioN != "")
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
                if (lector_de_ecuaciones.Sintaxis(ecuacioN, Convert.ToChar("x")))
                {
                    for (int i = 0; i < (rango_x.Length - 1); i++)
                    {
                        resultado_actual = lector_de_ecuaciones.EvaluaFx(Convert.ToDouble(rango_x[i]));
                        resultado_siguiente = lector_de_ecuaciones.EvaluaFx(Convert.ToDouble(rango_x[i + 1]));
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

    }
}