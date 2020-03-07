using MetodosNumericos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MetodosNumericos.Views.Metodos
{
    public partial class TrapecioCompuesto : System.Web.UI.Page
    {

        Trapecio_CompuestoController trapecio_compuesto;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txt_aprox_integral.ReadOnly = true;
            this.txt_error_calculado.ReadOnly = true;
            this.txt_resultado_real.ReadOnly = true;
        }

        protected void calcular_integral_Click(object sender, EventArgs e)
        {
            // verificar que los campos esten llenos 
            if (campos__llenos())

            {
                trapecio_compuesto = new Trapecio_CompuestoController(txt_ecuacion.Text, Convert.ToDouble(txt_limite_sup.Text), Convert.ToDouble(txt_limite_inf.Text), Convert.ToInt32(txt_particiones.Text));
                txt_aprox_integral.Text = Convert.ToString(trapecio_compuesto.integral_aproximada());
                txt_error_calculado.Text = Convert.ToString(trapecio_compuesto.error_porcentual())+"%";
            }


        }

        protected void btn_valor_real_Click(object sender, EventArgs e)
        {
            // calcular que los campos no esten vacios
            if (campos__llenos())
            {
                trapecio_compuesto = new Trapecio_CompuestoController(txt_ecuacion.Text, Convert.ToDouble(txt_limite_sup.Text), Convert.ToDouble(txt_limite_inf.Text), Convert.ToInt32(txt_particiones.Text));
                txt_resultado_real.Text = Convert.ToString(trapecio_compuesto.integral_real());
            }
        }

        protected void btn_graficar_funcion_Click(object sender, EventArgs e)
        {
            string _open = "window.open('Grafica.aspx', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        public Boolean campos__llenos() {

            if (txt_ecuacion.Text!="" && txt_limite_inf.Text!="" && txt_limite_sup.Text != "" 
                && txt_particiones.Text!="")
            {
                return true;
            }
            return false;
        }


    }
}