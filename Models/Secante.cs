using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Calculus;

namespace MetodosNumericos.Models
{
    public class Secante
    {
        private String ecuacion;
        private double inicio;
        private double inicio_anterior;

        private double fxi;
        private double fxi_anterior;
        private double xi_menos_anterior;

        private double error_aprox=100;
        private double error;
        public double guard_anterior;
        private int iterar;
        private int key;

        // variables y vectores de la grafica.

        private readonly int dimension_rango = 41;
        private int inicio_por_defecto = 11;

        private int inicio_rango = -20;
        private int corte = 0;
        private int inicio_grafica = 0;

        private object[] datos_iniciales;
        private object[] resultado_evaluado;


        private Calculo lector_de_funciones;

        public Secante(string ecuacion, double inicio, double inicio_anterior) { 
            this.ecuacion = ecuacion;
            this.inicio = inicio;
            this.inicio_anterior = inicio_anterior;
            this.fxi = 0;
            this.fxi_anterior = 0;
            this.xi_menos_anterior = 0;
            this.error_aprox = 100;
            this.error = 1 * Math.Pow(10,-7);
            this.iterar = 0;
            this.guard_anterior = inicio;

            this.lector_de_funciones = new Calculo();

            this.key = 0;

        }

        public double raiz_aproximada() {
            if (lector_de_funciones.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                while (error_aprox>=error) {

                    fxi = lector_de_funciones.EvaluaFx(inicio);
                    fxi_anterior = lector_de_funciones.EvaluaFx(inicio_anterior);

                    xi_menos_anterior = inicio - inicio_anterior;

                    inicio_anterior = inicio;
                    inicio = inicio - ((fxi*xi_menos_anterior)/(fxi-fxi_anterior));



                    if (key == 1)
                    {
                        error_aprox = Math.Abs(((inicio-inicio_anterior)/inicio)*100);
                    }
                    else {

                        key = 1;
                    }

                    iterar++;
                }
            }
            return inicio;
        }

        public double error_aproximado() {

            return error_aprox;
        }

        public int iteraciones() {

            return iterar;

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
                if (lector_de_funciones.Sintaxis(ecuacion, Convert.ToChar("x")))
                {
                    for (int i = 0; i < resultado_evaluado.Length; i++)
                    {
                        resultado = lector_de_funciones.EvaluaFx(Convert.ToDouble(datos_iniciales[i]));

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
                punto_corte[0] = 666;
                punto_corte[1] = 666;

                // llenando el rango para buscar el punto de corte.
                object[] rango_x = new object[dimension_rango];


                for (int i = 0; i < rango_x.Length; i++)
                {
                    rango_x[i] = inicio_rango;
                    inicio_rango = (inicio_rango + 1);
                }

                //llenando la funcion 
                if (lector_de_funciones.Sintaxis(ecuacioN, Convert.ToChar("x")))
                {
                    for (int i = 0; i < (rango_x.Length - 1); i++)
                    {
                        resultado_actual = lector_de_funciones.EvaluaFx(Convert.ToDouble(rango_x[i]));
                        resultado_siguiente = lector_de_funciones.EvaluaFx(Convert.ToDouble(rango_x[i + 1]));
                        // evaluar el inidice actual y el siguiente.. y detectar el punto de corte...

                        if (resultado_actual >= 0 && resultado_siguiente <= 0)//inicia graficando desde la parte positiva.
                        {
                            punto_corte[0] = rango_x[i];
                        }
                        else
                        {
                            if (resultado_actual <= 0 && resultado_siguiente >= 0)//inicia graficando la parte negativa.
                            {
                                punto_corte[1] = rango_x[i];
                            }
                        }
                    }
                    //buscar el dato a graficar
                    if (Convert.ToInt16(punto_corte[1]) != 666)
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