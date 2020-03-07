using MetodosNumericos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MetodosNumericos.Views.Metodos
{
    public partial class Grafica : System.Web.UI.Page
    {
        Tres_OctavosController simpson_tres_octavos;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected String obtener_datos()
        {
            simpson_tres_octavos = new Tres_OctavosController(this.txt_ecuacion.Text,this.txt_ecuacion1.Text, 0, 0, 0);

            return simpson_tres_octavos.obtener_datos();
        }

        protected void btn_grafica_Click(object sender, EventArgs e)
        {
            if (campos_llenos())
            {
                string javaScript = "drawCurveTypes();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "javaScript", "drawCurveTypes()", false);

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire({type: 'error',title: 'Campos incompletos',text: 'Complete los campos!'}) </script>");
            }
        }


        public Boolean campos_llenos()
        {
            if (txt_ecuacion.Text != "" && txt_ecuacion1.Text != "" )
            {
                return true;
            }

            return false;
        }

    }
}