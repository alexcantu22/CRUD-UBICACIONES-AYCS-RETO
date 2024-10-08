using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//capas
using BILL;
using DAL;


namespace CrudUbicaciones_AYCS
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        ubicaciones_BILL oubicaciones_BILL;
        ubicaciones_DAL oubicaciones_DAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarUbicaciones();
            }
            ListarUbicaciones();

        }

        // metodo encargado de listar los datos de bd en driview
        public void ListarUbicaciones()
        {
            oubicaciones_DAL = new ubicaciones_DAL();
            gvUbicaciones.DataSource = oubicaciones_DAL.Listar();
            gvUbicaciones.DataBind();
        }
        //metodo encargado de recolectar datos de la interfaz

        public ubicaciones_BILL datosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oubicaciones_BILL = new ubicaciones_BILL();


            //recolectar datos de la capa de presentacion
            oubicaciones_BILL.ID = ID;
            oubicaciones_BILL.Ubicacion = txtUbicacion.Text;
            oubicaciones_BILL.Latitud = txtLat.Text;
            oubicaciones_BILL.Longitud = txtLong.Text;

            return oubicaciones_BILL;

        }



        protected void gvUbicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oubicaciones_DAL = new ubicaciones_DAL();
            oubicaciones_DAL.Agregar(datosUbicacion());
            ListarUbicaciones(); //para mostrar en el gv
        }
        protected void EliminarRegistro(object sender, EventArgs e)
        {
            oubicaciones_DAL = new ubicaciones_DAL();
            oubicaciones_DAL.Eliminar(datosUbicacion());
            ListarUbicaciones(); //para mostrar en el gv
        }

        protected void  ModificarRegistro(object sender, EventArgs e)
        {
            oubicaciones_DAL = new ubicaciones_DAL();
            oubicaciones_DAL.Modificar(datosUbicacion());
            ListarUbicaciones(); //para mostrar en el gv
        }

        protected void SeleccionarRegistro(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int FilaSeleccionada = int.Parse(e.CommandArgument.ToString());

            txtID.Value = gvUbicaciones.Rows[FilaSeleccionada].Cells[1].Text;
            txtUbicacion.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[2].Text;
            txtLat.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[3].Text;
            txtLong.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[4].Text;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnAgregar.Enabled = true;
        }
    }
}