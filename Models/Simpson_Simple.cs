using Calculus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetodosNumericos.Models
{
    public class Simpson_Simple
    {
        private String ecuacion;
        private double limite_superior;
        private double limite_inferior;

        private Calculo lector_de_ecuaciones;


        private double resultado_integ_aprox;
        private double resultado_integ_real;

        private double parte1_formula;

        private double fx_a;
        private double fx_c_intermedio;
        private double fx_b;
        private double c_intermedio;




        private double aux_Dx=0.05;

        private double error_absoluto;
        private double error_relativo;
        private double error_porcent;

        public Simpson_Simple(string aux_ecuacion, double aux_limite_superior, double aux_limite_inferior)
        {
            this.ecuacion = aux_ecuacion;
            this.limite_superior = aux_limite_superior;
            this.limite_inferior = aux_limite_inferior;
            this.lector_de_ecuaciones = new Calculo();
        }

        public double integral_aproximada() {

            double aux;
            // verificar que la ecuacion este bien escrita 
            if (lector_de_ecuaciones.Sintaxis(ecuacion,Convert.ToChar("x")))
            {
                c_intermedio = ((limite_superior+ limite_inferior) / 2);

                parte1_formula = ((limite_superior-limite_inferior) / 6);

                fx_a = lector_de_ecuaciones.EvaluaFx(limite_inferior);
                fx_b = lector_de_ecuaciones.EvaluaFx(limite_superior);

                aux = lector_de_ecuaciones.EvaluaFx(c_intermedio);
                fx_c_intermedio = (4 * (lector_de_ecuaciones.EvaluaFx(c_intermedio)));


                resultado_integ_aprox = (parte1_formula) * (fx_a + fx_c_intermedio + fx_b);

                // calcular integral real
                resultado_integ_real = lector_de_ecuaciones.Integra(limite_inferior,limite_superior,aux_Dx);

            }

            return resultado_integ_aprox;
        }

        public double integral_real() {
            // verificar que la ecuacion este bien escrita 
            if (lector_de_ecuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                resultado_integ_real = lector_de_ecuaciones.Integra(limite_inferior, limite_superior, aux_Dx);
            }

                return resultado_integ_real;
        }

        public double error_porcentual() {
            error_absoluto = Math.Abs(resultado_integ_real - resultado_integ_aprox);

            error_relativo = (error_absoluto / resultado_integ_real);

            error_porcent = (error_relativo*100);



            return error_porcent;
        }


    }
}