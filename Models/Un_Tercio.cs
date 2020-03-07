using Calculus;
using System;

namespace MetodosNumericos.Models
{
    public class Un_Tercio
    {
        private String ecuacion;
        private double limite_superior;
        private double limite_infererior;
        private int divisiones;

        private Calculo lector_de_ecuacioens;

        private double resultado_inte_aprox;
        private double resultado_inte_real;

        private double error_absoluto;
        private double error_relativo;
        private double error_porcent;

        private double valor_h;

        private double[] Xn;
        private double[] Fx_funcion;

        private int limite_sumatoria1;
        private int salto_xn_sumatoria1;
        private int salto_xn_sumatoria2;
        private double resultado_sumatoria1=0;
        private double resultado_sumatoria2=0;

        private double parte1;

        private double aux_dx=0.2;


        public Un_Tercio(string ecuacion, double limite_superior, double limite_infererior, int divisiones)
        {
            this.ecuacion = ecuacion;
            this.limite_superior = limite_superior;
            this.limite_infererior = limite_infererior;
            this.divisiones = divisiones;
            this.lector_de_ecuacioens = new Calculo();

            this.Xn = new double[divisiones+1];
            this.Fx_funcion = new double[divisiones+1];


        }

        public double integral_aproximada()
        {

            valor_h = ((limite_superior - limite_infererior) / divisiones);

            // cacular primera parte de la formula
            parte1 = valor_h / 3;
            


            // calcular los Xo
            Xn[0] = limite_infererior;
            Xn[(Xn.Length-1)] = limite_superior;

            for (int i = 1; i < Xn.Length-1; i++)
            {
                Xn[i] = (limite_infererior + (i * valor_h));
            }
            
            // verificar que la ecuacion este bien escrita
            if (lector_de_ecuacioens.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                // calcular los Fx
                for (int i = 0; i < Fx_funcion.Length; i++)
                {
                    Fx_funcion[i] = lector_de_ecuacioens.EvaluaFx(Xn[i]);

                }

                // calcula primera sumatoria

                limite_sumatoria1 = ((divisiones-2)/2);
                for (int i = 0; i <= limite_sumatoria1; i++)
                {
                    salto_xn_sumatoria1 = (2 * i + 1);
                    resultado_sumatoria1 = resultado_sumatoria1 + Fx_funcion[salto_xn_sumatoria1];
                }

                resultado_sumatoria1 = 4 * (resultado_sumatoria1);

                // segunda sumatoria
                for (int i = 1; i <= limite_sumatoria1; i++)
                {
                    salto_xn_sumatoria2 = (2*i);
                    resultado_sumatoria2 = resultado_sumatoria2 + Fx_funcion[salto_xn_sumatoria2];
                     
                }
                resultado_sumatoria2 = 2* (resultado_sumatoria2);

                resultado_inte_aprox = Fx_funcion[0] + Fx_funcion[(Fx_funcion.Length - 1)] + resultado_sumatoria1 +resultado_sumatoria2;

                resultado_inte_aprox = parte1 * resultado_inte_aprox;

                // calcular integral real

                resultado_inte_real = lector_de_ecuacioens.Integra(limite_infererior, limite_superior, aux_dx);





            }





            return resultado_inte_aprox ;
        }

        public double integral_real()
        {
            // verificar que la ecuacion este bien escrita
            if (lector_de_ecuacioens.Sintaxis(ecuacion, Convert.ToChar("x")))
            {
                // calcular integral real

                resultado_inte_real = lector_de_ecuacioens.Integra(limite_infererior, limite_superior, aux_dx);



            }

            return resultado_inte_real;
        }

        public double error_porcentual()
        {
            error_absoluto = Math.Abs(resultado_inte_real- resultado_inte_aprox);
            error_relativo = (error_absoluto / resultado_inte_real);

            error_porcent = (error_relativo * 100);


            return error_porcent;
        }




    }
}