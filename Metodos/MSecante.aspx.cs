using MetodosNumericos.Controllers;
using System;

namespace MetodosNumericos.Views.Metodos
{
    public partial class MSecante : System.Web.UI.Page
    {

        SecanteController secante;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.resultado_raiz.ReadOnly = true;
            this.error_calculado.ReadOnly = true;
            this.iteraciones.ReadOnly = true;

            this.lado_derc.ReadOnly = true;
            this.lado_izq.ReadOnly = true;

        }

        protected String obtener_datos()
        {
           secante = new SecanteController(this.ecuacion_n.Text, 0, 0);
            return secante.obtener_datos();
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
            secante = new SecanteController(this.ecuacion_n.Text,Convert.ToDouble(this.lado_izq.Text),Convert.ToDouble(this.lado_derc.Text));
            this.resultado_raiz.Text =Convert.ToString(secante.raiz_aproximada());
            this.error_calculado.Text = Convert.ToString(secante.error_aproximado())+"%";
            this.iteraciones.Text = Convert.ToString(secante.iteraciones());

        }
    }
}