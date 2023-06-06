using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using MailKit.Net.Smtp;
using MimeKit;
using System.Drawing;
using System.Linq;
using OfficeOpenXml;
using System.Diagnostics;

namespace PaginaPrincipal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private String cod_empresa = "";
        private String mod_ingreso = "BARR";
        private String cod_usuario = "APP";
        private SqlConnection Conexion;

        //private SqlConnection ConexionR = new SqlConnection("Server=192.168.3.5;DataBase= BaseRoyal;Integrated Security=true");

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
            DateTime fechaActual = DateTime.Now;

            DateTime fechaAnterior = fechaActual.AddDays(-1);
            lblFechaA.Text = fechaAnterior.ToString("dd/MM/yy");
            lblFechaH.Text = fechaActual.ToString("dd/MM/yy");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ParametrosFinca();
        }

        //Funcion pARAMETROS Finca
        public void ParametrosFinca()
        {
            cmbFinca.Items.Add("Continex");
            cmbFinca.Items.Add("Royal");
            cmbFinca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipComid.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOpComidas.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //Funcion para detectar la lectura de barras
        private void ConsultaTrabajador()
        {
            // Abrir conexión a la base de datos
            Conexion.Open();
            string sql = "SELECT DISTINCT [NOMBRE]Nomb_Empl,[APELLIDO]Apellido_Empl FROM [dbo].[RH_PERSON] WHERE [CODIGO]='"+txtCodigoTrab.Text+"'";
            SqlCommand command = new SqlCommand(sql, Conexion);
            SqlDataReader rdr = command.ExecuteReader();   
            // Ejecutar consulta SQL y leer resultados

            if (rdr.Read())
            {
                txtInfTrab.Text = rdr["Nomb_Empl"].ToString() + " " + rdr["Apellido_Empl"].ToString();
                Conexion.Close();
            }
            Conexion.Close();
        }
        private void ResaltarEmpleadoDuplicado(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Obtener el índice de la fila recién insertada
            int rowIndex = e.RowIndex;

            // Establecer el color de fondo de la fila en rojo
            tblRegistros.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
        }
        //Consulta para los select combox Proveedor, TipoComida, Comida
        //Consulta para la vista de nombres desde la base [dbo] Recursos Humanos
        //Insert para el registro de datos en la tabla CC_EMPL_COMIDA
        private void txtCodigoTrab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                if (cmbProveedor.Text == "Seleccionar un Proveedor")
                {
                    MessageBox.Show("No tienes Proveedor seleccionados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbTipComid.Text == "Seleccion Comida")
                {
                    MessageBox.Show("No tienes Tipo de Comida seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbOpComidas.Text == "Seleccionar una Comida")
                {
                    MessageBox.Show("No tienes Comida seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtCodigoTrab.Text != "")
                {
                    string consulta = "SELECT DISTINCT p.NOMBRE AS Nomb_Empl, p.APELLIDO AS Apellido_Empl FROM RH_PERSON p LEFT JOIN RH_EMPLOYEE r ON p.CODIGO = r.CODIGO WHERE p.CODIGO = @Cod_Emp AND r.COD_ESTADO_EMP= '1'";
                    SqlCommand comando = new SqlCommand(consulta, Conexion);
                    comando.Parameters.AddWithValue("@Cod_Emp", txtCodigoTrab.Text);
                    Conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        txtInfTrab.Text = lector["Nomb_Empl"].ToString() + " " + lector["Apellido_Empl"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("El empleado no timbro asistencia o no consta en el registro de la Finca revise el codigo.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCodigoTrab.Text = String.Empty;
                        Conexion.Close();
                        return;
                    }
                    Conexion.Close();
                }

                if (ConsultaComida(cmbOpComidas.Text, txtCodigoTrab.Text))
                {
                    MessageBox.Show("El empleado ya se registro.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodigoTrab.Text = String.Empty;
                    txtInfTrab.Text = String.Empty;
                    return;
                }

                InsertarTrabajador();
                EmpleadosTimbrados();
                NombresEmpleados();
                ConteoComidasDesayunosHoy();
                ConteoComidasAlmuerzoHoy();
                ConteoComidasMeriendaHoy();
                ConteoComidasRefrigeriosHoy();
                SumaComidasAyer();
                SumaComidasHoy();
                txtCodigoTrab.Clear();
            }
        }
        //Filtrar Informacion de Finca segun codigo empresa
        public void seleccionarFinca()
        {
            switch (cmbFinca.SelectedItem)
            {
                case "Continex":
                    Conexion = new SqlConnection("Server=192.168.4.6;DataBase=PERCONTINEX;User Id=spyral;Password=spyral;");
                    cod_empresa = "2";
                    CargarProveedor();
                    CargarTipoComidaC();
                    EmpleadosTimbrados();
                    NombresEmpleados();
                    break;
                case "Royal":
                    Conexion = new SqlConnection("Server=192.168.3.5;DataBase=PERSONALFINCA;User Id=spyral;Password=spyral;");
                    cod_empresa = "1";
                    CargarProveedor();
                    CargarTipoComidaC();
                    EmpleadosTimbrados();
                    NombresEmpleados();
                    break;
            }
        }
        //Seleccionar Proveedores de la base CC_PROV_COMIDA
        public void CargarProveedor()
        {
            Conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [COD_PROV_COMIDA] Codi_Proveedor, [NOMBRE] Nomb_Proveedor FROM [dbo].[CC_PROV_COMIDA] WHERE estado=1 and cod_empresa="+cod_empresa, Conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Conexion.Close();
            //Rellenar Filas
            DataRow fila = dt.NewRow();
            fila["Nomb_Proveedor"] = "Seleccionar un Proveedor";
            dt.Rows.InsertAt(fila, 0);
            //Llamar Datos
            cmbProveedor.ValueMember = "Codi_Proveedor";
            cmbProveedor.DisplayMember = "Nomb_Proveedor";
            cmbProveedor.DataSource = dt;
            SumaComidasAyer();
            SumaComidasHoy();
        }
        //Seleccionar Tipos de comida desde la base CC_COMIDA
        public void CargarTipoComidaC()
        {
            Conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [TIPO_COMIDA] Nomb_TipoCom FROM [dbo].[CC_COMIDA] WHERE cod_empresa=" + cod_empresa+ " AND [TIPO_COMIDA] IS NOT NULL", Conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Conexion.Close();
            //Rellenar Filas
            DataRow fila = dt.NewRow();
            fila["Nomb_TipoCom"] = "Seleccion Comida";
            dt.Rows.InsertAt(fila, 0);
            //Llamar Dato
            cmbTipComid.ValueMember = "Nomb_TipoCom";
            cmbTipComid.DisplayMember = "Nomb_TipoCom";
            cmbTipComid.DataSource = dt;
        }
        //Seleccionar Variante de Comida desde la base CC_COMIDA
        public void CargarVarianteComidaC(string id_TipoCom)
        {
            Conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [COD_COMIDA]Codi_VarComida, [NOMBRE]Nomb_VarComida FROM[dbo].[CC_COMIDA] where[TIPO_COMIDA] = @id_TipoCom AND cod_empresa =" + cod_empresa, Conexion);
            cmd.Parameters.AddWithValue("id_TipoCom", id_TipoCom);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            Conexion.Close();

            //Rellenar Filas
            DataRow fila = dt.NewRow();
            fila["Codi_VarComida"] = "Seleccionar una Comida";
            dt.Rows.InsertAt(fila, 0);
            //Llamar Datos
            cmbOpComidas.ValueMember = "Codi_VarComida";
            cmbOpComidas.DisplayMember = "Codi_VarComida";
            cmbOpComidas.DataSource = dt;

        }
        //Consulta si el trabajador ya tiembro en ese dia y en que tipo de comida lo hizo

        private bool ConsultaComida(String Comida, String usuario)
        {
            string consulta = "SELECT COUNT(*) FROM [dbo].[CC_EMPL_COMIDA] where [COD_COMIDA] = @VarComida AND [FECHA_REGISTRO] >=@Fecha AND [CODIGO]=@Cod_Emp";
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            Conexion.Open();
            cmd.Parameters.AddWithValue("@VarComida", Comida);
            cmd.Parameters.AddWithValue("@Cod_Emp", usuario);
            cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
            int cantidad = (int)cmd.ExecuteScalar();
            Conexion.Close();
            return (cantidad > 0);
        }
        //Funcion Insertar
        private void InsertarTrabajador()
        {
            // aquí iría tu código de inserción
            string query = "INSERT INTO [dbo].[CC_EMPL_COMIDA] ([COD_EMPRESA], [COD_PROV_COMIDA], [COD_COMIDA], [CODIGO], [FECHA_REGISTRO], [MODO_INGRESO], [COD_USUARIO], [FECSYS]) VALUES (@Cod_Empresa ,@Cod_Prov_Comida, @Cod_Comida, @Cod_Codigo, @Fecha_Registro, @Modo_Ingreso, @Cod_Usuario, @Fecsys)";
            Conexion.Open();
            SqlCommand comando = new SqlCommand(query, Conexion);
            comando.Parameters.AddWithValue("@Cod_Empresa", cod_empresa);
            comando.Parameters.AddWithValue("@Cod_Prov_Comida", cmbProveedor.SelectedValue);
            comando.Parameters.AddWithValue("@Cod_Comida", cmbOpComidas.SelectedValue);
            comando.Parameters.AddWithValue("@Cod_Codigo", txtCodigoTrab.Text);
            comando.Parameters.AddWithValue("@Fecha_Registro", DateTime.Now);
            comando.Parameters.AddWithValue("@Modo_Ingreso", mod_ingreso);
            comando.Parameters.AddWithValue("@Cod_usuario", cod_usuario);
            comando.Parameters.AddWithValue("@Fecsys", DateTime.Now);
            comando.ExecuteNonQuery();
            Conexion.Close();
        }        
        public void ConteoComidasDesayunosAyer()
        { 
            String consulta= "SELECT COUNT(CASE WHEN ISNUMERIC([COD_EMPRESA]) = 1 THEN CAST([COD_EMPRESA] AS INT) ELSE 0 END) AS TotalComiDesyA FROM[dbo].[CC_EMPL_COMIDA] WHERE([COD_COMIDA] = 'DES_ADMINI' OR[COD_COMIDA] = 'DES_CULTIV')  AND ([FECHA_REGISTRO]>=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-1)) AND ([FECHA_REGISTRO]<=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),0)) AND COD_EMPRESA = '" + cod_empresa + "' AND COD_PROV_COMIDA = '" + cmbProveedor.SelectedValue.ToString() + "'";
            Conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                lblTDesayunosA.Text = lector["TotalComiDesyA"].ToString();
                Conexion.Close();
                lblTDesayunosA.Refresh();
            }
        }
        public void ConteoComidasAlmuerzoAyer()
        { 
            string consulta = "SELECT COUNT(CASE WHEN ISNUMERIC([COD_EMPRESA]) = 1 THEN CAST([COD_EMPRESA] AS INT) ELSE 0 END) AS TotalComiAlmA FROM[dbo].[CC_EMPL_COMIDA] WHERE([COD_COMIDA] = 'ALM_ADMINI' OR[COD_COMIDA] = 'ALM_CHOFER' OR[COD_COMIDA] = 'ALM_CULTIV' OR[COD_COMIDA] = 'ALMSUP' OR[COD_COMIDA] = 'ALMSUPP') AND ([FECHA_REGISTRO]>=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-1)) AND ([FECHA_REGISTRO]<=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),0)) AND COD_EMPRESA = '" + cod_empresa + "' AND COD_PROV_COMIDA = '" + cmbProveedor.SelectedValue.ToString() + "'";
            Conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                lblTAlmuerzoA.Text = lector["TotalComiAlmA"].ToString();
                Conexion.Close();
                lblTAlmuerzoA.Refresh();
            }
        }
        public void ConteoComidasMeriendaAyer()
        { 
            string consulta = "SELECT COUNT(CASE WHEN ISNUMERIC([COD_EMPRESA]) = 1 THEN CAST([COD_EMPRESA] AS INT) ELSE 0 END) AS TotalComiMeredA FROM[dbo].[CC_EMPL_COMIDA] WHERE([COD_COMIDA] = 'MER_ADMINI' OR[COD_COMIDA] = 'MER_CULTIV') AND([FECHA_REGISTRO] >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), -1)) AND ([FECHA_REGISTRO]<=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),0)) AND COD_EMPRESA = '" + cod_empresa + "' AND COD_PROV_COMIDA = '" + cmbProveedor.SelectedValue.ToString() + "'";
            Conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                lblTMeriendaA.Text = lector["TotalComiMeredA"].ToString();
                Conexion.Close();
                lblTMeriendaA.Refresh();
            }
        }
        public void ConteoComidasRefrigeriosAyer()
        {
            string consulta = "SELECT COUNT(CASE WHEN ISNUMERIC([COD_EMPRESA]) = 1 THEN CAST([COD_EMPRESA] AS INT) ELSE 0 END) AS TotalComRefrigA FROM[dbo].[CC_EMPL_COMIDA]WHERE([COD_COMIDA] = 'REFRIGERIO') AND([FECHA_REGISTRO] >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), -1)) AND([FECHA_REGISTRO] <= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0)) AND COD_EMPRESA = '" + cod_empresa + "' AND COD_PROV_COMIDA = '" + cmbProveedor.SelectedValue.ToString() + "'";
            Conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                lblRefrigeriosA.Text = lector["TotalComRefrigA"].ToString();
                Conexion.Close();
                lblRefrigeriosA.Refresh();
            }
        }
        public void ConteoComidasDesayunosHoy()
        { 
            string consulta = "SELECT COUNT(CASE WHEN ISNUMERIC([COD_EMPRESA]) = 1 THEN CAST([COD_EMPRESA] AS INT) ELSE 0 END) AS TotalComiDesyH FROM[dbo].[CC_EMPL_COMIDA] WHERE([COD_COMIDA] = 'DES_ADMINI' OR[COD_COMIDA] = 'DES_CULTIV') AND ([FECHA_REGISTRO]>=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),0)) AND ([FECHA_REGISTRO]<=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),1)) AND COD_EMPRESA = '" + cod_empresa + "' AND COD_PROV_COMIDA = '" + cmbProveedor.SelectedValue.ToString() + "'";
            Conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                lblTDesayunosH.Text = lector["TotalComiDesyH"].ToString();
                Conexion.Close();
                lblTDesayunosH.Refresh();
            }
        }
        public void ConteoComidasAlmuerzoHoy()
        { 
            string consulta = "SELECT COUNT(CASE WHEN ISNUMERIC([COD_EMPRESA]) = 1 THEN CAST([COD_EMPRESA] AS INT) ELSE 0 END) AS TotalComiAlmH FROM[dbo].[CC_EMPL_COMIDA] WHERE([COD_COMIDA] = 'ALM_ADMINI' OR[COD_COMIDA] = 'ALM_CHOFER' OR[COD_COMIDA] = 'ALM_CULTIV' OR[COD_COMIDA] = 'ALMSUP' OR[COD_COMIDA] = 'ALMSUPP') AND ([FECHA_REGISTRO]>=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),0)) AND ([FECHA_REGISTRO]<=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),1)) AND COD_EMPRESA = '" + cod_empresa + "' AND COD_PROV_COMIDA = '" + cmbProveedor.SelectedValue.ToString() + "'";
            Conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                lblTAlmuerzoH.Text = lector["TotalComiAlmH"].ToString();
                Conexion.Close();
                lblTAlmuerzoH.Refresh();
            }
        }
        public void ConteoComidasMeriendaHoy()
        { 
            string consulta = "SELECT COUNT(CASE WHEN ISNUMERIC([COD_EMPRESA]) = 1 THEN CAST([COD_EMPRESA] AS INT) ELSE 0 END) AS TotalComiMeredH FROM[dbo].[CC_EMPL_COMIDA] WHERE([COD_COMIDA] = 'MER_ADMINI' OR[COD_COMIDA] = 'MER_CULTIV') AND([FECHA_REGISTRO] >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0)) AND ([FECHA_REGISTRO]<=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),1)) AND COD_EMPRESA = '" + cod_empresa + "' AND COD_PROV_COMIDA = '" + cmbProveedor.SelectedValue.ToString() + "'";
            Conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                lblTMeriendaH.Text = lector["TotalComiMeredH"].ToString();
                Conexion.Close();
                lblTMeriendaH.Refresh();
            }
        }
        public void ConteoComidasRefrigeriosHoy()
        {
            //string consulta = "SELECT COUNT(COD_COMIDA) AS TotalComiH FROM CC_EMPL_COMIDA WHERE FECHA_REGISTRO >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0) AND FECHA_REGISTRO <= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 1) AND COD_EMPRESA = '" + cod_empresa + "' AND COD_PROV_COMIDA = '" + cmbProveedor.SelectedValue.ToString() + "'";
            string consulta = "SELECT COUNT(CASE WHEN ISNUMERIC([COD_EMPRESA]) = 1 THEN CAST([COD_EMPRESA] AS INT) ELSE 0 END) AS TotalComRefrigH FROM[dbo].[CC_EMPL_COMIDA]WHERE([COD_COMIDA] = 'REFRIGERIO') AND([FECHA_REGISTRO] >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0)) AND([FECHA_REGISTRO] <= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 1)) AND COD_EMPRESA = '" + cod_empresa + "' AND COD_PROV_COMIDA = '" + cmbProveedor.SelectedValue.ToString() + "'";
            Conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                lblRefrigeriosH.Text = lector["TotalComRefrigH"].ToString();
                lblRefrigeriosH.Refresh();
                Conexion.Close();
            }
        }
        public void SumaComidasAyer()
        {
            string consulta = "SELECT COUNT(COD_COMIDA) AS TotalComiA FROM CC_EMPL_COMIDA WHERE FECHA_REGISTRO >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), -1) AND FECHA_REGISTRO <= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0) AND COD_EMPRESA = '" + cod_empresa + "' AND COD_PROV_COMIDA = '" + cmbProveedor.SelectedValue.ToString() + "'";
            //string consulta = "SELECT COUNT([COD_COMIDA]) AS TotalComiA FROM[dbo].[CC_EMPL_COMIDA] WHERE ([FECHA_REGISTRO]>=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-1)) AND ([FECHA_REGISTRO]<=DATEADD(dd,DATEDIFF(dd,0,GETDATE()),0)) AND COD_EMPRESA=" + cod_empresa+" ";
            Conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                lblTotalAyer.Text = lector["TotalComiA"].ToString();
                Conexion.Close();
                lblTotalAyer.Refresh();
            }
        }
        public void SumaComidasHoy()
        {
            string consulta = "SELECT COUNT(COD_COMIDA) AS TotalComiH FROM CC_EMPL_COMIDA WHERE FECHA_REGISTRO >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0) AND FECHA_REGISTRO <= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 1) AND COD_EMPRESA = '" + cod_empresa + "' AND COD_PROV_COMIDA = '" + cmbProveedor.SelectedValue.ToString() + "'";
            Conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                lblTotalHoy.Text = lector["TotalComiH"].ToString();
                Conexion.Close();
                lblTotalHoy.Refresh();
            }
        }
        public void EmpleadosNoTimbrados()
        {
            Conexion.Open();
            string consulta = "SELECT [dbo].[RH_EMPLOYEE].[CODIGO] FROM [dbo].[RH_EMPLOYEE] WHERE NOT EXISTS(SELECT 1 FROM[dbo].[CC_EMPL_COMIDA] WHERE[dbo].[CC_EMPL_COMIDA].[CODIGO] = [dbo].[RH_EMPLOYEE].[CODIGO] AND[dbo].[CC_EMPL_COMIDA].[FECHA_REGISTRO] >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0) AND[dbo].[CC_EMPL_COMIDA].[FECHA_REGISTRO] < DATEADD(dd, DATEDIFF(dd, 0, GETDATE()) + 1, 0)) AND[dbo].[RH_EMPLOYEE].[COD_ESTADO_EMP] = '1' ORDER BY[CODIGO] ASC; ";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, Conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DataView dataView = new DataView(dt);
            dataView = new DataView(dt, "", "[CODIGO]", DataViewRowState.CurrentRows);
            RegistroDiario.DataSource = dataView;
            Conexion.Close();
        }
        public void EmpleadosTimbrados()
        {
            Conexion.Open();
            string consulta = "SELECT DISTINCT [COD_PROV_COMIDA], [COD_COMIDA], [CODIGO], [FECHA_REGISTRO], [COD_USUARIO] FROM [dbo].[CC_EMPL_COMIDA] WHERE ([FECHA_REGISTRO] >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0)) AND [COD_EMPRESA] = " + cod_empresa + " ORDER BY [FECHA_REGISTRO] DESC";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, Conexion);
            DataSet dt = new DataSet();
            adaptador.Fill(dt);
            DataView view = new DataView(dt.Tables[0]);
            tblRegistros.DataSource = view;

            /*var codigosDuplicados = dt.AsEnumerable().GroupBy(row => row.Field<int>("CODIGO"))
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);

            // Resaltar las filas que contengan códigos duplicados
            foreach (DataGridViewRow row in tblRegistros.Rows)
            {
                if (codigosDuplicados.Contains(Convert.ToInt32(row.Cells["CODIGO"].Value)))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }*/
            Conexion.Close();
            /*// Crear un objeto de tipo Document
            Document doc = new Document();

            // Crear un objeto de tipo PdfWriter para escribir en el archivo PDF
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("Informe_Comidas.pdf", FileMode.Create));

            // Agregar encabezado al documento
            doc.AddHeader("Header1", "Encabezado del documento PDF");

            // Abrir el documento
            doc.Open();

            // Crear un objeto de tipo PdfPTable para representar la tabla de datos
            PdfPTable table = new PdfPTable(dt.Columns.Count);

            // Añadir las columnas a la tabla
            foreach (DataColumn column in dt.Columns)
            {
                table.AddCell(new PdfPCell(new Phrase(column.ColumnName)));
            }

            // Añadir las filas a la tabla
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    table.AddCell(new PdfPCell(new Phrase(row[column].ToString())));
                }
            }

            // Añadir la tabla al documento
            doc.Add(table);

            // Cerrar el documento
            doc.Close();

            // Mostrar el documento PDF en el navegador
            //System.Diagnostics.Process.Start("Informe_Comidas.pdf");

            // Crear un objeto de tipo MimeMessage para representar el correo electrónico
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Paul Heredia", "paulheredia02@gmail.com"));
            message.To.Add(new MailboxAddress("Sixto Paul Heredia Anchaguano", "sixto.heredia@royalflowersecuador.com"));
            message.Subject = "Reporte de personas que timbraron el almuerzo";

            // Crear un objeto de tipo BodyBuilder para representar el cuerpo del correo electrónico
            var builder = new BodyBuilder();
            builder.TextBody = "Se reporta los codigos de las personas que timbraron con su codigo de empleado, tipo de comida, Tipo de Proveedor y la fecha y hora en la que lo hicieron";
            builder.Attachments.Add("Informe_Comidas.pdf", File.ReadAllBytes("Informe_Comidas.pdf"), ContentType.Parse("application/pdf"));

            // Añadir el cuerpo del correo electrónico al mensaje
            message.Body = builder.ToMessageBody();

            // Configurar el cliente de correo electrónico
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("paulheredia02@gmail.com", "lkzp fvrr kbfe zkla");
                client.Send(message);
                client.Disconnect(true);
            }*/
        }

        //Generar Nombres
        public void NombresEmpleados()
        {
            Conexion.Open();
            string consulta = "SELECT RP.[NOMBRE], RP.[APELLIDO] FROM[dbo].[RH_PERSON] RP INNER JOIN[dbo].[CC_EMPL_COMIDA] CC ON RP.[CODIGO] = CC.[CODIGO] WHERE CC.[COD_EMPRESA] = " + cod_empresa + " AND CC.[FECHA_REGISTRO] >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0) ORDER BY CC.[FECHA_REGISTRO] DESC ";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, Conexion);
            DataSet dt = new DataSet();
            adaptador.Fill(dt);
            DataView view = new DataView(dt.Tables[0]);
            tblNombre.DataSource = view;
            Conexion.Close();
        }
            //Generar Excel Registros
            public void ExcelRegistros()
        {
            Conexion.Open();
            string consulta = "SELECT DISTINCT CC.[COD_EMPRESA], CC.[COD_PROV_COMIDA], CC.[COD_COMIDA], CC.[CODIGO], RP.[NOMBRE], RP.[APELLIDO], CC.[FECHA_REGISTRO], CC.[MODO_INGRESO], CC.[COD_USUARIO], CC.[FECSYS] FROM[dbo].[CC_EMPL_COMIDA] CC INNER JOIN[RH_PERSON] RP ON CC.[CODIGO] = RP.[CODIGO] WHERE CC.[FECHA_REGISTRO] >= DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0) AND CC.[COD_EMPRESA] = "+cod_empresa+" ORDER BY CC.[FECHA_REGISTRO] DESC, CC.[FECSYS] DESC";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, Conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            DataView dataView = new DataView(dt);
            dataView = new DataView(dt, "", " [COD_EMPRESA],[COD_PROV_COMIDA],[COD_COMIDA],[CODIGO],[NOMBRE],[APELLIDO],[FECHA_REGISTRO],[MODO_INGRESO],[COD_USUARIO],[FECSYS]", DataViewRowState.CurrentRows);
            tblRegistros.DataSource = dataView;

            var codigosDuplicados = dt.AsEnumerable().GroupBy(row => row.Field<int>("CODIGO"))
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);

            // Resaltar las filas que contengan códigos duplicados
            foreach (DataGridViewRow row in tblRegistros.Rows)
            {
                if (codigosDuplicados.Contains(Convert.ToInt32(row.Cells["CODIGO"].Value)))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }

            // Crear un nuevo paquete de Excel
            ExcelPackage excelPackage = new ExcelPackage();

            // Agregar una nueva hoja de Excel al paquete
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Registros");

            // Establecer los encabezados de las columnas
            for (int i = 0; i < tblRegistros.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 3].Value = tblRegistros.Columns[i].HeaderText;
            }

            // Copiar los datos de la tabla a la hoja de Excel
            for (int i = 0; i < tblRegistros.Rows.Count; i++)
            {
                for (int j = 0; j < tblRegistros.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 3].Value = tblRegistros.Rows[i].Cells[j].Value;
                }
            }

            // Guardar el paquete de Excel en un archivo
            string fileName = "Registros.xlsx";
            FileInfo fileInfo = new FileInfo(fileName);
            excelPackage.SaveAs(fileInfo);

            //Abrir el Archivo Excel
            Process.Start("Registros.xlsx", fileName);
            Conexion.Close();

            
        }
        //LLamada a la condicion para filtrar datos de finca
        private void cmbFinca_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionarFinca();
        }
        private void cmbTipComid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipComid.SelectedValue.ToString()!= null)
            {
                string id_TipoCom = cmbTipComid.SelectedValue.ToString();
                CargarVarianteComidaC(id_TipoCom);
            }
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConteoComidasDesayunosHoy();
            ConteoComidasAlmuerzoHoy();
            ConteoComidasMeriendaHoy();
            ConteoComidasRefrigeriosHoy();
            SumaComidasHoy();
            EmpleadosNoTimbrados();
            EmpleadosTimbrados();
            NombresEmpleados();
            ExcelRegistros();
        }

        private void cmbProveedor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ConteoComidasDesayunosAyer();
            ConteoComidasAlmuerzoAyer();
            ConteoComidasMeriendaAyer();
            ConteoComidasDesayunosHoy();
            ConteoComidasAlmuerzoHoy();
            ConteoComidasMeriendaHoy();
            ConteoComidasRefrigeriosHoy();
            SumaComidasAyer();
            SumaComidasHoy();
        }
    }
}
