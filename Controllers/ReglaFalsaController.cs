using MetodosNumericos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MetodosNumericos.Controllers
{
    public class ReglaFalsaController
    {
        ReglaFalsa regla_falsa;

        public ReglaFalsaController(String funcion, double inter_izq, double inter_derec)
        {
            this.regla_falsa = new ReglaFalsa(funcion, inter_izq, inter_derec);
        }

        public Double raiz_aproximada()
        {
            return regla_falsa.raiz_aproximada();
        }

        public int iteracion_total()
        {
            return regla_falsa.iteracion_total();
        }

        public Double error_aprx()
        {
            return regla_falsa.error_aprx();
        }
        public Boolean verificar_rango() {
            return regla_falsa.verificar_rango();
        }
        public string obtener_datos()
        {
            

            return regla_falsa.obtener_datos();
        }

       
    }
}