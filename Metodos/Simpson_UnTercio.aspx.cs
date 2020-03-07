using MetodosNumericos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MetodosNumericos.Views.Metodos
{
    public partial class Simpson_UnTercio : System.Web.UI.Page
    {

        Un_TercioController simpson_un_tercio;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txt_aprox_integral.ReadOnly = true;
            this.txt_error_calculado.ReadOnly = true;
            this.txt_resultado_real.ReadOnly = true;
        }


        protected void btn_calcular_integral_Click(object sender, EventArgs e)
        {
            if (campos_llenos())
            {
                simpson_un_tercio = new Un_TercioController(this.txt_ecuacion.Text, Convert.ToDouble(txt_limite_sup.Text), Convert.ToDouble(txt_limite_inf.Text), Convert.ToInt32(txt_particiones.Text));
                txt_aprox_integral.Text = Convert.ToString(simpson_un_tercio.integral_aproximada());
                txt_error_calculado.Text = Convert.ToString(simpson_un_tercio.error_porcentual()) + "%";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire({type: 'error',title: 'Campos incompletos',text: 'Complete los campos!'}) </script>");
            }

        }


        protected void btn_graficar_funcion_Click(object sender, EventArgs e)
        {
            string _open = "window.open('Grafica.aspx', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }


        protected void btn_valor_real_Click(object sender, EventArgs e)
        {
            if (campos_llenos())
            {                simpson_un_tercio = new Un_TercioController(this.txt_ecuacion.Text, Convert.ToDouble(txt_limite_sup.Text), Convert.ToDouble(txt_limite_inf.Text), Convert.ToInt32(txt_particiones.Text));
                txt_resultado_real.Text = Convert.ToString(simpson_un_tercio.integral_aproximada());
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire({type: 'error',title: 'Campos incompletos',text: 'Complete los campos!'}) </script>");
            }
        }
        public Boolean campos_llenos()
        {
            if (txt_ecuacion.Text != "" && txt_limite_sup.Text != "" && txt_limite_inf.Text != "")
            {
                return true;
            }

            return false;
        }

    }
}