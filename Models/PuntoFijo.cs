using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Calculus;

namespace MetodosNumericos.Models
{
    public class PuntoFijo
    {
        private String ecuacion;
        private String x_despejada;
        private double error_aprox;
        private double numero_inicial;

        private double error;
        private double raiz_anterior;

        private int iteraciones;

        // variables y vectores de la grafica.

        private readonly int dimension_rango = 41;
        private int inicio_por_defecto = 11;

        private int inicio_rango = -20;
        private int corte = 0;
        private int inicio_grafica = 0;

        private object[] datos_iniciales;
        private object[] resultado_evaluado;



        private Calculo lector_de_ecuacion;


        public PuntoFijo(string ecuacion, string x_despejada, double numero_inicial)
        {
            this.ecuacion = ecuacion;
            this.x_despejada = x_despejada;
            this.error_aprox = 100;
            this.numero_inicial = numero_inicial;
            this.iteraciones = 0;

            this.error = 1 * Math.Pow(10, -7);

            this.lector_de_ecuacion = new Calculo();

            this.raiz_anterior = numero_inicial;
        }

        public double raiz() {
            if (lector_de_ecuacion.Sintaxis(x_despejada,Convert.ToChar("x")))
            {
                while (error_aprox>=error)
                {
                   

                    numero_inicial = lector_de_ecuacion.EvaluaFx(numero_inicial);
                    


                    error_aprox = Math.Abs(((numero_inicial-raiz_anterior)/numero_inicial)*100);

                    raiz_anterior = numero_inicial;
                    iteraciones++;
                }
            }


            return numero_inicial;
        }

        public double error_calculado() {

            return error_aprox;
        }

        public int iteraciones_() {

            return iteraciones;
        }

        // graficar datos automaticos

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
                if (lector_de_ecuacion.Sintaxis(ecuacion, Convert.ToChar("x")))
                {
                    for (int i = 0; i < resultado_evaluado.Length; i++)
                    {
                        resultado = lector_de_ecuacion.EvaluaFx(Convert.ToDouble(datos_iniciales[i]));

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
                if (lector_de_ecuacion.Sintaxis(ecuacioN, Convert.ToChar("x")))
                {
                    for (int i = 0; i < (rango_x.Length - 1); i++)
                    {
                        resultado_actual = lector_de_ecuacion.EvaluaFx(Convert.ToDouble(rango_x[i]));
                        resultado_siguiente = lector_de_ecuacion.EvaluaFx(Convert.ToDouble(rango_x[i + 1]));
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