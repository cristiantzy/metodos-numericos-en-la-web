using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetodosNumericos.Models
{
   
    public class ABabilonica
    {
        private double numero;
        private int numero_aux;
        private int resultado;
        private double valor_verdadero;
        private double error;
        private double error_relativo;
        private double error_porcentual;
        private double raiz_n;

        private double base0;
        private double base1;
        private double altura0;
        private double altura1;

        public ABabilonica(double numero)
        {
            this.numero = numero;
            this.numero_aux = 1;
            this.resultado = 0;
            this.valor_verdadero = Math.Pow(numero,2) ;
            this.error = 0;
            this.error_relativo = 0;
            this.error_porcentual = 0;
            this.base0 = 0;
            this.base1 = 0;
            this.altura0 = 0;
            this.altura1 = 0;
            this.raiz_n = 0;
        }

        public int multipl_aproximada(double numero) {
            do
            {
                resultado = (numero_aux * numero_aux);
                numero_aux++;
            } while (resultado<numero);

            return (numero_aux-1);
        }

        public double raiz_calculada() {
            base0 = multipl_aproximada(numero);

            altura0 = numero / base0;

            while (error<0.00001)
            {
                base1 = (base0+altura0) / 2;
                altura1 = (numero/base1);

                error = (valor_verdadero - altura1);

                base0 = base1;
                altura0 = altura1;
            }

            raiz_n = altura1;
            return raiz_n;

        }

        public double calculo_d_error() {
            error_relativo = (error/valor_verdadero);
            error_porcentual = (error_relativo * 100);

            return error;
        }

    }
}