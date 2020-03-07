using Calculus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetodosNumericos.Models
{
    public class Trapecio_Compuesto
    {
        private String ecuacion;
        private double limite_superior;
        private double limite_inferior;
        private int divisiones;

        private double aux_Dx = 0.02;
        private double Dx;

        private double error_absoluto;
        private double error_relativo;
        private double error_porcent;

        private double integral_aprox;
        private double integralReal;

        private double parte1;

        private double[] n_divisiones;
        private double[] fx_ecuacion;

        private Calculo lector_de_ecuaciones;

        public Trapecio_Compuesto(string ecuacion, double limite_superior, double limite_inferior, int particiones)
        {
            this.ecuacion = ecuacion;
            this.limite_superior = limite_superior;
            this.limite_inferior = limite_inferior;
            this.divisiones = particiones;

            this.n_divisiones = new double[divisiones+1];
            this.fx_ecuacion = new double[divisiones+1];

            lector_de_ecuaciones = new Calculo();

        }
        public Trapecio_Compuesto()
        {
            this.ecuacion ="";
            this.limite_superior = 0;
            this.limite_inferior = 0;
            this.divisiones = 0;
        }

        public double integral_aproximada() {
            // calcular el Dx
            Dx = ((limite_superior - limite_inferior) / divisiones);

            // realizar la formula por partes
            // parte 1).
            parte1 = ((limite_superior -limite_inferior)/(2*divisiones));

            // parte 2).
            n_divisiones[0] = limite_inferior;

            for (int i = 1; i < n_divisiones.Length; i++)
            {
                n_divisiones[i] = (n_divisiones[i-1] + Dx);
            }

            // verificar que la ecuacion este bien escrita
            if (lector_de_ecuaciones.Sintaxis(ecuacion,Convert.ToChar("x")))
            {
                fx_ecuacion[0] = lector_de_ecuaciones.EvaluaFx(limite_inferior);

                for (int i = 1; i < fx_ecuacion.Length-1; i++)
                {
                    fx_ecuacion[i] = 2 * (lector_de_ecuaciones.EvaluaFx(n_divisiones[i]));
                }
                fx_ecuacion[fx_ecuacion.Length -1] = lector_de_ecuaciones.EvaluaFx(limite_superior);

                // hacer sumatoria de los calculos

                for (int i = 0; i < fx_ecuacion.Length; i++)
                {
                    integral_aprox = fx_ecuacion[i] + integral_aprox;
                }

                integral_aprox = parte1 * integral_aprox;

                // integral real;
                integralReal = lector_de_ecuaciones.Integra(limite_inferior,limite_superior,aux_Dx);

            }







            return integral_aprox;
        }

        public double integral_real() {

            // verificar que la ecuacion este bien escrita
            if (lector_de_ecuaciones.Sintaxis(ecuacion,Convert.ToChar("x")))
            {
                integralReal = lector_de_ecuaciones.Integra(limite_inferior, limite_superior, aux_Dx);
            }


            return integralReal;
        }

        public double error_porcentual() {
            error_absoluto = Math.Abs(integralReal-integral_aprox);

            error_relativo = (error_absoluto / integral_aprox);

            error_porcent = (error_relativo * 100);

            return error_porcent;
        }


    }
}