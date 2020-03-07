using Calculus;
using System;

namespace MetodosNumericos.Models
{
    public class TraprecioSimple
    {
        private String ecuacion;
        private double limite_superior;
        private double limite_inferior;
        private int particiones;

        private double fx_limt_sup;
        private double fx_limt_inf;

        private double aprox_integral;
        private double aprox_real;
        private double error_porcent;
        private double error_absoluto;
        private double error_relativo;


        private double Dx = 0.05;

        Calculo lector_de_ecuaciones;

        public TraprecioSimple(String aux_ecuacion,double limit_sup, double limit_inf, int aux_part)
        {
            this.ecuacion = aux_ecuacion;
            this.limite_superior = limit_sup;
            this.limite_inferior = limit_inf;
            this.particiones = aux_part;
            lector_de_ecuaciones = new Calculo();

        }

        
        public TraprecioSimple()
        {
            this.ecuacion = "";
            this.limite_superior = 0;
            this.limite_inferior = 0;
            this.particiones = 0;

            lector_de_ecuaciones = new Calculo();
        }

        public double integral_aproximada()
        {


            // verificar que la ecuacion este bien escrita
            if (lector_de_ecuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                fx_limt_inf = lector_de_ecuaciones.EvaluaFx(limite_inferior);
                fx_limt_sup = lector_de_ecuaciones.EvaluaFx(limite_superior);

                aprox_integral = ((limite_superior - limite_inferior) * ((fx_limt_inf + limite_superior) / 2));

                // integral real
                aprox_real = lector_de_ecuaciones.Integra(limite_inferior, limite_superior, Dx);


            }
            return aprox_integral;
        }

        public double integral_real()
        {


            // verificar que este bien escrita
            if (lector_de_ecuaciones.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                aprox_real = lector_de_ecuaciones.Integra(limite_inferior, limite_superior, Dx);
            }
            return aprox_real;
        }

        public double error_porcentual()
        {

            error_absoluto = Math.Abs(aprox_real - aprox_integral);
            error_relativo = (error_absoluto / aprox_real);

            error_porcent = (error_relativo * 100);

            return error_porcent;
        }


    }
}