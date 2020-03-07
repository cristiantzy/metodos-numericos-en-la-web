using MetodosNumericos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MetodosNumericos.Views.Metodos
{
    public partial class PuntoFijo : System.Web.UI.Page
    {

        PuntoFijoController punto_fijo;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.resultado_raiz.ReadOnly = true;
            this.error_calculado.ReadOnly = true;
            this.iteraciones.ReadOnly = true;

            this.numero_aprox.ReadOnly = true;

        }

        protected void calcular_raiz_Click(object sender, EventArgs e)
        {
            punto_fijo = new PuntoFijoController(this.ecuacion_n.Text, this.ecuacion_despejada.Text, Convert.ToInt32(this.numero_aprox.Text));

            this.resultado_raiz.Text = Convert.ToString(punto_fijo.raiz());
            this.iteraciones.Text = Convert.ToString(punto_fijo.iteraciones_());
            this.error_calculado.Text = Convert.ToString(punto_fijo.error_calculado())+"%";
        }

        protected void graficar_funcion_Click(object sender, EventArgs e)
        {
            string javaScript = "drawCurveTypes();";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "javaScript", "drawCurveTypes()", false);

            this.numero_aprox.ReadOnly = false;


        }

        protected String obtener_datos()
        {
            punto_fijo = new PuntoFijoController(this.ecuacion_n.Text, "", 0);
            return punto_fijo.obtener_datos();
        }

    }
}