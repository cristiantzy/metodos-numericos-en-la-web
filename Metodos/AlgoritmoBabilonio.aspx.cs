using MetodosNumericos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MetodosNumericos.Views.Metodos
{
    public partial class AlgoritmoBabilonio : System.Web.UI.Page

    {
        ABabilonicaController alg_babilonico;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.resultado_raiz.ReadOnly = true;
            this.error_raiz.ReadOnly = true;
        }

        protected void calcular_raiz_Click(object sender, EventArgs e)
        {
            alg_babilonico = new ABabilonicaController(Convert.ToDouble(this.numero_raiz.Text));
            this.resultado_raiz.Text = Convert.ToString(alg_babilonico.raiz_calculada());
            this.error_raiz.Text = Convert.ToString(alg_babilonico.calculo_d_error());


        }
    }
}