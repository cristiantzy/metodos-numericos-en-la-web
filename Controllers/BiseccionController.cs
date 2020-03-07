using MetodosNumericos.Models;

namespace MetodosNumericos.Controllers
{


    public class BiseccionController
    {
        private readonly Biseccion biseccion;

        public BiseccionController(string ecuacion, double x1, double x2)
        {
            this.biseccion = new Biseccion(ecuacion, x1, x2);
        }
        public BiseccionController()
        {
            this.biseccion = new Biseccion();
        }

        public double raiz()
        {
            return biseccion.raiz();
        }
        public double error_aprox()
        {
            return biseccion.error_aprox();
        }
        public int iteraciones()
        {
            return biseccion.iteraciones();
        }
        public bool verificar_rango()
        {
            return biseccion.verificar_rango();
        }

        public string obtener_datos()
        {

            return biseccion.obtener_datos();
        }


    }
}