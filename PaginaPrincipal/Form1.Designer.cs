
namespace PaginaPrincipal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbFinca = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbOpComidas = new System.Windows.Forms.ComboBox();
            this.cmbTipComid = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCodigoTrab = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtInfTrab = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.RegistroDiario = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblRefrigeriosH = new System.Windows.Forms.Label();
            this.lblRefrigeriosA = new System.Windows.Forms.Label();
            this.lblRefrigerios = new System.Windows.Forms.Label();
            this.lblFechaH = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblFechaA = new System.Windows.Forms.Label();
            this.lblTDesayunosH = new System.Windows.Forms.Label();
            this.lblTAlmuerzoH = new System.Windows.Forms.Label();
            this.lblTMeriendaH = new System.Windows.Forms.Label();
            this.lblTAlmuerzoA = new System.Windows.Forms.Label();
            this.lblTMeriendaA = new System.Windows.Forms.Label();
            this.lblTDesayunosA = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalHoy = new System.Windows.Forms.Label();
            this.lblTotalAyer = new System.Windows.Forms.Label();
            this.horafecha = new System.Windows.Forms.Timer(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tblNombre = new System.Windows.Forms.DataGridView();
            this.tblRegistros = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegistroDiario)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRegistros)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblHora);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Font = new System.Drawing.Font("Arial Black", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha/Hora";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 20F);
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha:";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Arial Black", 20F);
            this.lblHora.Location = new System.Drawing.Point(140, 39);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(87, 38);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "Hora";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Arial Black", 20F);
            this.lblFecha.Location = new System.Drawing.Point(433, 39);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(106, 38);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbFinca);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbOpComidas);
            this.groupBox2.Controls.Add(this.cmbTipComid);
            this.groupBox2.Controls.Add(this.cmbProveedor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Arial Black", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(2, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 206);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacion Comida";
            // 
            // cmbFinca
            // 
            this.cmbFinca.Font = new System.Drawing.Font("Arial Black", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFinca.FormattingEnabled = true;
            this.cmbFinca.Location = new System.Drawing.Point(114, 46);
            this.cmbFinca.Name = "cmbFinca";
            this.cmbFinca.Size = new System.Drawing.Size(121, 34);
            this.cmbFinca.TabIndex = 11;
            this.cmbFinca.SelectedIndexChanged += new System.EventHandler(this.cmbFinca_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 12F);
            this.label6.Location = new System.Drawing.Point(93, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 23);
            this.label6.TabIndex = 10;
            // 
            // cmbOpComidas
            // 
            this.cmbOpComidas.Font = new System.Drawing.Font("Arial Black", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOpComidas.FormattingEnabled = true;
            this.cmbOpComidas.Location = new System.Drawing.Point(459, 154);
            this.cmbOpComidas.Name = "cmbOpComidas";
            this.cmbOpComidas.Size = new System.Drawing.Size(329, 34);
            this.cmbOpComidas.TabIndex = 9;
            // 
            // cmbTipComid
            // 
            this.cmbTipComid.Font = new System.Drawing.Font("Arial Black", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipComid.FormattingEnabled = true;
            this.cmbTipComid.Location = new System.Drawing.Point(99, 154);
            this.cmbTipComid.Name = "cmbTipComid";
            this.cmbTipComid.Size = new System.Drawing.Size(214, 34);
            this.cmbTipComid.TabIndex = 8;
            this.cmbTipComid.SelectedIndexChanged += new System.EventHandler(this.cmbTipComid_SelectedIndexChanged);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.Font = new System.Drawing.Font("Arial Black", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(183, 100);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(420, 34);
            this.cmbProveedor.TabIndex = 7;
            this.cmbProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbProveedor_SelectedIndexChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 20F);
            this.label5.Location = new System.Drawing.Point(319, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 38);
            this.label5.TabIndex = 6;
            this.label5.Text = "Comida:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 20F);
            this.label4.Location = new System.Drawing.Point(2, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 38);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tipo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 20F);
            this.label3.Location = new System.Drawing.Point(1, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "Proveedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 20F);
            this.label2.Location = new System.Drawing.Point(1, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "Finca:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCodigoTrab);
            this.groupBox3.Font = new System.Drawing.Font("Arial Black", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(2, 307);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 80);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Codigo";
            // 
            // txtCodigoTrab
            // 
            this.txtCodigoTrab.Font = new System.Drawing.Font("Arial Black", 20F);
            this.txtCodigoTrab.Location = new System.Drawing.Point(6, 29);
            this.txtCodigoTrab.Name = "txtCodigoTrab";
            this.txtCodigoTrab.Size = new System.Drawing.Size(142, 45);
            this.txtCodigoTrab.TabIndex = 0;
            this.txtCodigoTrab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoTrab_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtInfTrab);
            this.groupBox4.Font = new System.Drawing.Font("Arial Black", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(2, 393);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(577, 79);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Informacion";
            // 
            // txtInfTrab
            // 
            this.txtInfTrab.Font = new System.Drawing.Font("Arial Black", 20F);
            this.txtInfTrab.Location = new System.Drawing.Point(6, 28);
            this.txtInfTrab.Name = "txtInfTrab";
            this.txtInfTrab.Size = new System.Drawing.Size(565, 45);
            this.txtInfTrab.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.RegistroDiario);
            this.groupBox5.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(839, 483);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(393, 215);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Codigo Personal que no Timbro en Dia";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Black", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(310, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 80);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generar Tabla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegistroDiario
            // 
            this.RegistroDiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RegistroDiario.Location = new System.Drawing.Point(19, 22);
            this.RegistroDiario.Name = "RegistroDiario";
            this.RegistroDiario.Size = new System.Drawing.Size(285, 179);
            this.RegistroDiario.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblRefrigeriosH);
            this.groupBox6.Controls.Add(this.lblRefrigeriosA);
            this.groupBox6.Controls.Add(this.lblRefrigerios);
            this.groupBox6.Controls.Add(this.lblFechaH);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.lblFechaA);
            this.groupBox6.Controls.Add(this.lblTDesayunosH);
            this.groupBox6.Controls.Add(this.lblTAlmuerzoH);
            this.groupBox6.Controls.Add(this.lblTMeriendaH);
            this.groupBox6.Controls.Add(this.lblTAlmuerzoA);
            this.groupBox6.Controls.Add(this.lblTMeriendaA);
            this.groupBox6.Controls.Add(this.lblTDesayunosA);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.lblTotalHoy);
            this.groupBox6.Controls.Add(this.lblTotalAyer);
            this.groupBox6.Font = new System.Drawing.Font("Arial Black", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(802, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(430, 340);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tabla de Registro";
            // 
            // lblRefrigeriosH
            // 
            this.lblRefrigeriosH.AutoSize = true;
            this.lblRefrigeriosH.Location = new System.Drawing.Point(341, 239);
            this.lblRefrigeriosH.Name = "lblRefrigeriosH";
            this.lblRefrigeriosH.Size = new System.Drawing.Size(27, 30);
            this.lblRefrigeriosH.TabIndex = 19;
            this.lblRefrigeriosH.Text = "0";
            // 
            // lblRefrigeriosA
            // 
            this.lblRefrigeriosA.AutoSize = true;
            this.lblRefrigeriosA.Location = new System.Drawing.Point(225, 239);
            this.lblRefrigeriosA.Name = "lblRefrigeriosA";
            this.lblRefrigeriosA.Size = new System.Drawing.Size(27, 30);
            this.lblRefrigeriosA.TabIndex = 18;
            this.lblRefrigeriosA.Text = "0";
            // 
            // lblRefrigerios
            // 
            this.lblRefrigerios.AutoSize = true;
            this.lblRefrigerios.Location = new System.Drawing.Point(2, 239);
            this.lblRefrigerios.Name = "lblRefrigerios";
            this.lblRefrigerios.Size = new System.Drawing.Size(137, 30);
            this.lblRefrigerios.TabIndex = 17;
            this.lblRefrigerios.Text = "Refrigerios";
            // 
            // lblFechaH
            // 
            this.lblFechaH.AutoSize = true;
            this.lblFechaH.Location = new System.Drawing.Point(308, 32);
            this.lblFechaH.Name = "lblFechaH";
            this.lblFechaH.Size = new System.Drawing.Size(107, 30);
            this.lblFechaH.TabIndex = 16;
            this.lblFechaH.Text = "Fecha H";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(2, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(174, 30);
            this.label17.TabIndex = 15;
            this.label17.Text = "Comida\\Fecha";
            // 
            // lblFechaA
            // 
            this.lblFechaA.AutoSize = true;
            this.lblFechaA.Location = new System.Drawing.Point(177, 32);
            this.lblFechaA.Name = "lblFechaA";
            this.lblFechaA.Size = new System.Drawing.Size(105, 30);
            this.lblFechaA.TabIndex = 14;
            this.lblFechaA.Text = "Fecha A";
            // 
            // lblTDesayunosH
            // 
            this.lblTDesayunosH.AutoSize = true;
            this.lblTDesayunosH.Location = new System.Drawing.Point(343, 87);
            this.lblTDesayunosH.Name = "lblTDesayunosH";
            this.lblTDesayunosH.Size = new System.Drawing.Size(27, 30);
            this.lblTDesayunosH.TabIndex = 13;
            this.lblTDesayunosH.Text = "0";
            // 
            // lblTAlmuerzoH
            // 
            this.lblTAlmuerzoH.AutoSize = true;
            this.lblTAlmuerzoH.Location = new System.Drawing.Point(343, 132);
            this.lblTAlmuerzoH.Name = "lblTAlmuerzoH";
            this.lblTAlmuerzoH.Size = new System.Drawing.Size(27, 30);
            this.lblTAlmuerzoH.TabIndex = 12;
            this.lblTAlmuerzoH.Text = "0";
            // 
            // lblTMeriendaH
            // 
            this.lblTMeriendaH.AutoSize = true;
            this.lblTMeriendaH.Location = new System.Drawing.Point(343, 182);
            this.lblTMeriendaH.Name = "lblTMeriendaH";
            this.lblTMeriendaH.Size = new System.Drawing.Size(27, 30);
            this.lblTMeriendaH.TabIndex = 11;
            this.lblTMeriendaH.Text = "0";
            // 
            // lblTAlmuerzoA
            // 
            this.lblTAlmuerzoA.AutoSize = true;
            this.lblTAlmuerzoA.Location = new System.Drawing.Point(225, 132);
            this.lblTAlmuerzoA.Name = "lblTAlmuerzoA";
            this.lblTAlmuerzoA.Size = new System.Drawing.Size(27, 30);
            this.lblTAlmuerzoA.TabIndex = 10;
            this.lblTAlmuerzoA.Text = "0";
            // 
            // lblTMeriendaA
            // 
            this.lblTMeriendaA.AutoSize = true;
            this.lblTMeriendaA.Location = new System.Drawing.Point(225, 182);
            this.lblTMeriendaA.Name = "lblTMeriendaA";
            this.lblTMeriendaA.Size = new System.Drawing.Size(27, 30);
            this.lblTMeriendaA.TabIndex = 9;
            this.lblTMeriendaA.Text = "0";
            // 
            // lblTDesayunosA
            // 
            this.lblTDesayunosA.AutoSize = true;
            this.lblTDesayunosA.Location = new System.Drawing.Point(225, 87);
            this.lblTDesayunosA.Name = "lblTDesayunosA";
            this.lblTDesayunosA.Size = new System.Drawing.Size(27, 30);
            this.lblTDesayunosA.TabIndex = 8;
            this.lblTDesayunosA.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 30);
            this.label9.TabIndex = 7;
            this.label9.Text = "Meriendas";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 30);
            this.label8.TabIndex = 6;
            this.label8.Text = "Almuerzos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "Desayunos";
            // 
            // lblTotalHoy
            // 
            this.lblTotalHoy.AutoSize = true;
            this.lblTotalHoy.Font = new System.Drawing.Font("Arial Black", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHoy.Location = new System.Drawing.Point(330, 295);
            this.lblTotalHoy.Name = "lblTotalHoy";
            this.lblTotalHoy.Size = new System.Drawing.Size(27, 30);
            this.lblTotalHoy.TabIndex = 4;
            this.lblTotalHoy.Text = "0";
            // 
            // lblTotalAyer
            // 
            this.lblTotalAyer.AutoSize = true;
            this.lblTotalAyer.Font = new System.Drawing.Font("Arial Black", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAyer.Location = new System.Drawing.Point(217, 295);
            this.lblTotalAyer.Name = "lblTotalAyer";
            this.lblTotalAyer.Size = new System.Drawing.Size(27, 30);
            this.lblTotalAyer.TabIndex = 3;
            this.lblTotalAyer.Text = "0";
            // 
            // horafecha
            // 
            this.horafecha.Enabled = true;
            this.horafecha.Tick += new System.EventHandler(this.horafecha_Tick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tblNombre);
            this.groupBox7.Controls.Add(this.tblRegistros);
            this.groupBox7.Font = new System.Drawing.Font("Arial Black", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(2, 483);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(831, 216);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Empleados Registrados Comedor";
            // 
            // tblNombre
            // 
            this.tblNombre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblNombre.Location = new System.Drawing.Point(491, 25);
            this.tblNombre.Name = "tblNombre";
            this.tblNombre.Size = new System.Drawing.Size(334, 179);
            this.tblNombre.TabIndex = 1;
            // 
            // tblRegistros
            // 
            this.tblRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblRegistros.Location = new System.Drawing.Point(6, 25);
            this.tblRegistros.Name = "tblRegistros";
            this.tblRegistros.Size = new System.Drawing.Size(476, 179);
            this.tblRegistros.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 701);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Royal Flowers Comidas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RegistroDiario)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRegistros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbOpComidas;
        private System.Windows.Forms.ComboBox cmbTipComid;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoTrab;
        private System.Windows.Forms.TextBox txtInfTrab;
        private System.Windows.Forms.Timer horafecha;
        private System.Windows.Forms.DataGridView RegistroDiario;
        private System.Windows.Forms.ComboBox cmbFinca;
        private System.Windows.Forms.Label lblTotalHoy;
        private System.Windows.Forms.Label lblTotalAyer;
        private System.Windows.Forms.Label lblFechaH;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblFechaA;
        private System.Windows.Forms.Label lblTDesayunosH;
        private System.Windows.Forms.Label lblTAlmuerzoH;
        private System.Windows.Forms.Label lblTMeriendaH;
        private System.Windows.Forms.Label lblTAlmuerzoA;
        private System.Windows.Forms.Label lblTMeriendaA;
        private System.Windows.Forms.Label lblTDesayunosA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView tblRegistros;
        private System.Windows.Forms.Label lblRefrigerios;
        private System.Windows.Forms.Label lblRefrigeriosH;
        private System.Windows.Forms.Label lblRefrigeriosA;
        private System.Windows.Forms.DataGridView tblNombre;
    }
}

