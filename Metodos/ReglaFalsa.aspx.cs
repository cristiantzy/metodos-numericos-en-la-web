using MetodosNumericos.Controllers;
using System;

namespace MetodosNumericos.Views.Metodos
{
    public partial class ReglaFalsa : System.Web.UI.Page
    {

        ReglaFalsaController regla_falsa;

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
            regla_falsa = new ReglaFalsaController(this.ecuacion_n.Text, 0, 0);
            return regla_falsa.obtener_datos();
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
            regla_falsa = new ReglaFalsaController(this.ecuacion_n.Text, Convert.ToDouble(this.lado_izq.Text),Convert.ToDouble( this.lado_derc.Text));

            if (regla_falsa.verificar_rango())
            {
                this.resultado_raiz.Text = Convert.ToString(regla_falsa.raiz_aproximada());
                this.error_calculado.Text = Convert.ToString(regla_falsa.error_aprx())+"%";
                this.iteraciones.Text = Convert.ToString(regla_falsa.iteracion_total());

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