using MetodosNumericos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MetodosNumericos.Views.Metodos
{
    public partial class NRaphson : System.Web.UI.Page
    {

        NewtonRaphsonController newton_raphson;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.resultado_raiz.ReadOnly = true;
            this.iteraciones.ReadOnly = true;
            this.error_calculado.ReadOnly = true;

            this.numero_aprox.ReadOnly = true;

        }



        protected void calcular_raiz_Click(object sender, EventArgs e)
        {
            newton_raphson = new NewtonRaphsonController(this.ecuacion_n.Text, this.ecuacion_derivada.Text, Convert.ToDouble(this.numero_aprox.Text));

            this.resultado_raiz.Text = Convert.ToString(newton_raphson.raiz_aproximada());
            this.error_calculado.Text = Convert.ToString(newton_raphson.error_aproximado())+"%";
            this.iteraciones.Text = Convert.ToString(newton_raphson.iteraciones());

        }

        protected void graficar_funcion_Click(object sender, EventArgs e)
        {
            string javaScript = "drawCurveTypes();";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "javaScript", "drawCurveTypes()", false);



            this.numero_aprox.ReadOnly = false;

        }

        protected String obtener_datos()
        {
           newton_raphson = new NewtonRaphsonController(this.ecuacion_n.Text,"", 0);
            return newton_raphson.obtener_datos();
        }





    }
}