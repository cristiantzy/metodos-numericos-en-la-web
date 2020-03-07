using MetodosNumericos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MetodosNumericos.Views.Metodos
{
    public partial class TrapecioSimple : System.Web.UI.Page
    {
        TrapecioSimpleController trapecio_simple;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txt_aprox_integral.ReadOnly = true;
            this.txt_error_calculado.ReadOnly = true;
            this.txt_resultado_real.ReadOnly = true;
            this.txt_particiones.ReadOnly = true;
        }

        protected void calcular_integral_Click(object sender, EventArgs e)
        {
            if (campos_llenos())
            {
                trapecio_simple = new TrapecioSimpleController(txt_ecuacion.Text, Convert.ToDouble(txt_limite_sup.Text), Convert.ToDouble(txt_limite_inf.Text), Convert.ToInt32(txt_particiones.Text));

                this.txt_aprox_integral.Text = Convert.ToString(trapecio_simple.integral_aproximada());
                this.txt_error_calculado.Text = Convert.ToString(trapecio_simple.error_porcentual())+"%";
               
            }
            else {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire({type: 'error',title: 'Campos incompletos',text: 'Complete los campos!'}) </script>");
            }

        }

        protected void btn_valor_real_Click(object sender, EventArgs e)
        {
            if (campos_llenos())
            {
                trapecio_simple = new TrapecioSimpleController(txt_ecuacion.Text, Convert.ToDouble(txt_limite_sup.Text), Convert.ToDouble(txt_limite_inf.Text), Convert.ToInt32(txt_particiones.Text));
                this.txt_resultado_real.Text = Convert.ToString(trapecio_simple.integral_real());
            }
            else {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script> Swal.fire({type: 'error',title: 'Campos incompletos',text: 'Complete los campos!'}) </script>");
            }
            
        }

        protected void graficar_funcion_Click(object sender, EventArgs e)
        {
            string _open = "window.open('Grafica.aspx', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        public Boolean campos_llenos() {
            if (txt_ecuacion.Text!="" && txt_limite_sup.Text !="" && txt_limite_inf.Text != "")
            {
                return true;
            }

            return false;
        }

    }
}