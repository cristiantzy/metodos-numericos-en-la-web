using MetodosNumericos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetodosNumericos.Controllers
{
    public class ABabilonicaController
    {
        ABabilonica alg_babilonio;

        public ABabilonicaController(double numero_digitado)
        {
            alg_babilonio = new ABabilonica(numero_digitado);
        }

        public double raiz_calculada()
        {
            return alg_babilonio.raiz_calculada();
        }

        public double calculo_d_error()
        {
            return alg_babilonio.calculo_d_error();
        }


        }
}