using MathNet.Numerics.RootFinding;
using MetodosNumericos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetodosNumericos.Controllers
{


    public class NewtonRaphsonController
    {
        NewtonRaphsonn newton_raphson;

        public NewtonRaphsonController(String funcion, String derivada_func, double inicio)
        {
            this.newton_raphson = new NewtonRaphsonn(funcion, derivada_func, inicio);
        }

        public Double raiz_aproximada() {
            return newton_raphson.raiz_aproximada();
        }

        public Double error_aproximado() {
            return newton_raphson.error_aproximado();
        }

        public int iteraciones() {
            return newton_raphson.iteraciones();
        }

        public string obtener_datos()
        {

            return newton_raphson.obtener_datos();
        }
    }
} 