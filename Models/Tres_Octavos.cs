using Calculus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MetodosNumericos.Models
{
    public class Tres_Octavos
    {
        private String ecuacion;
        private String ecuacion1;

        private double limite_superior;
        private double limite_inferior;
        private int divisiones;

        private Calculo lector_de_ecuaciones;

        private double resultado_integ_aprox=0;
        private double resultado_integ_real;

        private double error_absoluto;
        private double error_relativo;
        private double error_porcent;

        private double aux_Dx= 0.05;
        private double Dx;

        private double[] Xn;
        private double[] Fx_ecuacion;

        private double parte1;

        // variables y vectores de la grafica.

        private readonly int dimension_rango = 41;
        private int inicio_por_defecto = 11;

        private int inicio_rango = -20;
        private int corte = 0;
        private int inicio_grafica = 0;

        private object[] datos_iniciales;
        private object[] resultado_evaluado;
        private object[] resultado_evaluado1;

        public double suma_media = 0;




        public Tres_Octavos(string ecuacion, String ecuacion1, double limite_superior, double limite_inferior, int divisiones)
        {
            this.ecuacion = ecuacion;
            this.ecuacion1 = ecuacion1;
            this.limite_superior = limite_superior;
            this.limite_inferior = limite_inferior;
            this.divisiones = divisiones;
            this.Xn = new double[divisiones];
             this.Fx_ecuacion = new double[divisiones];

            this.lector_de_ecuaciones = new Calculo();
        }


        public double integral_aproximada()
        {
            // calacular Dx
            Dx = (limite_superior - limite_inferior) / divisiones;

            // calcular las Xn
            Xn[0] = limite_inferior;
            Xn[divisiones-1] = limite_superior;

            for (int i = 1; i < Xn.Length-1; i++)
            {
                Xn[i] = Xn[i - 1] + Dx;
            }
          
            // calcular parte 1 de la formula
            parte1 = (3*Dx)/8;


            // verificar que la ecuacion este bien escrita
            if (lector_de_ecuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                // calcular los fx en la ecuacion,
                for (int i = 0; i < Fx_ecuacion.Length; i++)
                {
                    Fx_ecuacion[i] = lector_de_ecuaciones.EvaluaFx(Xn[i]);
                }

                // iteracion para la formula terminos medios, se saca el primero y el ultimo
                for (int i = 1; i < (Fx_ecuacion.Length-1); i++)
                {
                    suma_media= ((3 * Fx_ecuacion[i]) +suma_media);

                }

                


                resultado_integ_aprox = Fx_ecuacion[0] + suma_media + Fx_ecuacion[Fx_ecuacion.Length - 1];

                resultado_integ_aprox = parte1 * resultado_integ_aprox;

                // calcular integral real;
                resultado_integ_real = lector_de_ecuaciones.Integra(limite_inferior, limite_superior, aux_Dx);

            }









            return resultado_integ_aprox;
        }

        public double integral_real()
        {

            // verificar que la ecuacion este bien escrita
            if (lector_de_ecuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                // calcular integral real;
                resultado_integ_real = lector_de_ecuaciones.Integra(limite_inferior,limite_superior, aux_Dx);

            }

            return resultado_integ_real;
        }

        public double error_porcentual()
        {

            error_absoluto = Math.Abs(resultado_integ_real - resultado_integ_aprox);
            error_relativo = (error_absoluto / resultado_integ_real);

            error_porcent = (error_relativo * 100);


            return error_porcent;
        }

        // Analisis grafico

        public string obtener_datos()
        {
             datosFX();


            DataTable datos = new DataTable();

            // columna de los datos
            datos.Columns.Add(new DataColumn("X", typeof(string)));
            datos.Columns.Add(new DataColumn("F(x)", typeof(string)));
            datos.Columns.Add(new DataColumn("G(x)", typeof(string)));

            //datos de las columnas(mostrar en el shart)
            for (int i = 0; i < resultado_evaluado.Length; i++)
            {
                datos.Rows.Add(new object[] { datos_iniciales[i], resultado_evaluado[i], resultado_evaluado1[i]});
            }
            string strDatos;
            strDatos = "[";
            foreach (DataRow item in datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + item[0].ToString().Replace(",", ".") + "," + item[1].ToString().Replace(",", ".") + "," + item[2].ToString().Replace(",", ".");
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";
            return strDatos;
        }

        // datos
        public void datosFX()
        {
            double resultado = 0;


            if (ecuacion != "")
            {
                vector_a_graficar();

                // llenar datos evaluados en la primera funcion. Fx
                if (lector_de_ecuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
                {
                    for (int i = 0; i < resultado_evaluado.Length; i++)
                    {
                        resultado = lector_de_ecuaciones.EvaluaFx(Convert.ToDouble(datos_iniciales[i]));

                        resultado_evaluado[i] = resultado;
                    }
                }

                // llenar datos evaluados en la segunda funcion. Gx
                if (lector_de_ecuaciones.Sintaxis(ecuacion1, Convert.ToChar("x")))
                {
                    for (int i = 0; i < resultado_evaluado.Length; i++)
                    {
                        resultado = lector_de_ecuaciones.EvaluaFx(Convert.ToDouble(datos_iniciales[i]));

                        resultado_evaluado1[i] = resultado;
                    }
                }
            }
            else
            {
                // crear vectores de acuerdo a la dimension datos base

                datos_iniciales = new object[inicio_por_defecto];
                resultado_evaluado = new object[inicio_por_defecto];
                resultado_evaluado1 = new object[inicio_por_defecto];

                for (int i = 0; i < resultado_evaluado.Length; i++)
                {
                    resultado_evaluado[i] = 0;
                    resultado_evaluado1[i] = 0;

                }
                double aux_inicio = -5;
                for (int i = 0; i < datos_iniciales.Length; i++)
                {
                    datos_iniciales[i] = aux_inicio;
                    
                    aux_inicio = (aux_inicio + 1);
                }

            }

        }

        // inicializar valores del eje x, para realizar la grafica (automatico)
        public void vector_a_graficar()
        {
            // 1)  hallar el punto de corte
            // 2)  armar el vector con el rango a graficar
            datos_iniciales = new object[dimension_rango];
            resultado_evaluado = new object[dimension_rango];
            resultado_evaluado1 = new object[dimension_rango];

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