
using MetodosNumericos.Controllers;
using System;

namespace MetodosNumericos.Views.Metodos
{
    public partial class MBiseccion : System.Web.UI.Page
    {
        BiseccionController biseccion;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.resultado_raiz.ReadOnly = true;
            this.error_calculado.ReadOnly = true;
            this.iteraciones.ReadOnly = true;
            this.lado_izq.ReadOnly = true;
            this.lado_derc.ReadOnly = true;
        }


        protected String obtener_datos()
        {
            biseccion = new BiseccionController(this.ecuacion_n.Text, 0, 0);
            return biseccion.obtener_datos();
        }


        protected void graficar_funcion_Click(object sender, EventArgs e)
        {
            string javaScript = "drawCurveTypes();";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "javaScript", "drawCurveTypes()", false);

            this.lado_izq.ReadOnly = false;
            this.lado_derc.ReadOnly = false;
        }

        protected void calcular_raiz_Click(object sender, EventArgs e)
        {
            biseccion = new BiseccionController(this.ecuacion_n.Text, Convert.ToDouble(this.lado_izq.Text),Convert.ToDouble(this.lado_derc.Text));

            if (biseccion.verificar_rango())
            {
                this.resultado_raiz.Text = Convert.ToString(biseccion.raiz());
                this.error_calculado.Text = Convert.ToString(biseccion.error_aprox())+"%";
                this.iteraciones.Text = Convert.ToString(biseccion.iteraciones());
            }
            else {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire({type: 'error',title: 'Rangos Incorrectos',text: 'Ingrese nuevos rangos!'}) </script>");
                this.lado_izq.ReadOnly = false;
                this.lado_derc.ReadOnly = false;
                this.resultado_raiz.Text = "";
                this.error_calculado.Text = "";
                this.iteraciones.Text = "";
            }
        }
    }
}