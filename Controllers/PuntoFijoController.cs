using MetodosNumericos.Models;

namespace MetodosNumericos.Controllers
{
    public class PuntoFijoController
    {
        private readonly PuntoFijo punto_fijo;

        public PuntoFijoController(string ecuacion, string x_despejada, int inicio)
        {
            punto_fijo = new PuntoFijo(ecuacion, x_despejada, inicio);
        }

        public double raiz()
        {
            return punto_fijo.raiz();
        }

        public double error_calculado()
        {
            return punto_fijo.error_calculado();
        }

        public int iteraciones_()
        {
            return punto_fijo.iteraciones_();
        }

        public string obtener_datos()
        {

            return punto_fijo.obtener_datos();
        }


    }
}