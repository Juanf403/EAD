namespace LexicoV2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirCodigo = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirTokens = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarCodigo = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarTokens = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabla = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaDeTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaDeGramaticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblLinea = new System.Windows.Forms.Label();
            this.lblTotalLineas = new System.Windows.Forms.Label();
            this.lblErrores = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSintactico = new System.Windows.Forms.Button();
            this.btnSemantico = new System.Windows.Forms.Button();
            this.barra = new System.Windows.Forms.ProgressBar();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNotaciones = new System.Windows.Forms.Button();
            this.btntriplos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DGIdentificadores = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.DGTokens = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.DGConstantesNum = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.DGCadena = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.Operador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatoFuente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatoObjeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tripletas = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGIdentificadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGConstantesNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGCadena)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tripletas)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAbrir,
            this.MenuGuardar,
            this.menuTabla,
            this.tablaDeTokensToolStripMenuItem,
            this.tablaDeGramaticaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1121, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuAbrir
            // 
            this.MenuAbrir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirCodigo,
            this.abrirTokens});
            this.MenuAbrir.Name = "MenuAbrir";
            this.MenuAbrir.Size = new System.Drawing.Size(54, 24);
            this.MenuAbrir.Text = "Abrir";
            this.MenuAbrir.Click += new System.EventHandler(this.MenuAbrir_Click);
            // 
            // abrirCodigo
            // 
            this.abrirCodigo.Name = "abrirCodigo";
            this.abrirCodigo.Size = new System.Drawing.Size(213, 26);
            this.abrirCodigo.Text = "Archivo con codigo";
            this.abrirCodigo.Click += new System.EventHandler(this.abrirCodigo_Click);
            // 
            // abrirTokens
            // 
            this.abrirTokens.Name = "abrirTokens";
            this.abrirTokens.Size = new System.Drawing.Size(213, 26);
            this.abrirTokens.Text = "Archivo con tokens";
            this.abrirTokens.Click += new System.EventHandler(this.abrirTokens_Click);
            // 
            // MenuGuardar
            // 
            this.MenuGuardar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarCodigo,
            this.guardarTokens});
            this.MenuGuardar.Name = "MenuGuardar";
            this.MenuGuardar.Size = new System.Drawing.Size(74, 24);
            this.MenuGuardar.Text = "Guardar";
            // 
            // guardarCodigo
            // 
            this.guardarCodigo.Name = "guardarCodigo";
            this.guardarCodigo.Size = new System.Drawing.Size(190, 26);
            this.guardarCodigo.Text = "Guardar Codigo";
            this.guardarCodigo.Click += new System.EventHandler(this.guardarCodigo_Click);
            // 
            // guardarTokens
            // 
            this.guardarTokens.Name = "guardarTokens";
            this.guardarTokens.Size = new System.Drawing.Size(190, 26);
            this.guardarTokens.Text = "Guardas Tokens";
            this.guardarTokens.Click += new System.EventHandler(this.guardarTokens_Click);
            // 
            // menuTabla
            // 
            this.menuTabla.Name = "menuTabla";
            this.menuTabla.Size = new System.Drawing.Size(63, 24);
            this.menuTabla.Text = "Matriz";
            this.menuTabla.Visible = false;
            this.menuTabla.Click += new System.EventHandler(this.menuTabla_Click);
            // 
            // tablaDeTokensToolStripMenuItem
            // 
            this.tablaDeTokensToolStripMenuItem.Name = "tablaDeTokensToolStripMenuItem";
            this.tablaDeTokensToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.tablaDeTokensToolStripMenuItem.Text = "Tabla de Tokens";
            this.tablaDeTokensToolStripMenuItem.Visible = false;
            this.tablaDeTokensToolStripMenuItem.Click += new System.EventHandler(this.tablaDeTokensToolStripMenuItem_Click);
            // 
            // tablaDeGramaticaToolStripMenuItem
            // 
            this.tablaDeGramaticaToolStripMenuItem.Name = "tablaDeGramaticaToolStripMenuItem";
            this.tablaDeGramaticaToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.tablaDeGramaticaToolStripMenuItem.Text = "Tabla de Gramatica";
            this.tablaDeGramaticaToolStripMenuItem.Visible = false;
            this.tablaDeGramaticaToolStripMenuItem.Click += new System.EventHandler(this.tablaDeGramaticaToolStripMenuItem_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox1.Location = new System.Drawing.Point(51, 49);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(360, 150);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(474, 50);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(421, 151);
            this.richTextBox2.TabIndex = 14;
            this.richTextBox2.Text = "";
            this.richTextBox2.WordWrap = false;
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSiguiente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSiguiente.Location = new System.Drawing.Point(51, 215);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(100, 50);
            this.btnSiguiente.TabIndex = 16;
            this.btnSiguiente.Text = "Tokens";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.txtSiguiente_Click);
            // 
            // lblLinea
            // 
            this.lblLinea.AutoSize = true;
            this.lblLinea.Location = new System.Drawing.Point(46, 10);
            this.lblLinea.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(71, 25);
            this.lblLinea.TabIndex = 0;
            this.lblLinea.Text = "Linea: ";
            // 
            // lblTotalLineas
            // 
            this.lblTotalLineas.AutoSize = true;
            this.lblTotalLineas.Location = new System.Drawing.Point(469, 10);
            this.lblTotalLineas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalLineas.Name = "lblTotalLineas";
            this.lblTotalLineas.Size = new System.Drawing.Size(150, 25);
            this.lblTotalLineas.TabIndex = 8;
            this.lblTotalLineas.Text = "Total de lineas: ";
            // 
            // lblErrores
            // 
            this.lblErrores.AutoSize = true;
            this.lblErrores.Location = new System.Drawing.Point(788, 250);
            this.lblErrores.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(86, 25);
            this.lblErrores.TabIndex = 9;
            this.lblErrores.Text = "Errores: ";
            this.lblErrores.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLimpiar.Location = new System.Drawing.Point(969, 102);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 50);
            this.btnLimpiar.TabIndex = 20;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSintactico
            // 
            this.btnSintactico.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSintactico.Enabled = false;
            this.btnSintactico.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSintactico.Location = new System.Drawing.Point(474, 206);
            this.btnSintactico.Name = "btnSintactico";
            this.btnSintactico.Size = new System.Drawing.Size(100, 50);
            this.btnSintactico.TabIndex = 26;
            this.btnSintactico.Text = "Sintaxis";
            this.btnSintactico.UseVisualStyleBackColor = false;
            this.btnSintactico.Click += new System.EventHandler(this.btnSintactico_Click);
            // 
            // btnSemantico
            // 
            this.btnSemantico.BackColor = System.Drawing.Color.Lime;
            this.btnSemantico.Enabled = false;
            this.btnSemantico.ForeColor = System.Drawing.Color.Black;
            this.btnSemantico.Location = new System.Drawing.Point(92, 138);
            this.btnSemantico.Name = "btnSemantico";
            this.btnSemantico.Size = new System.Drawing.Size(100, 50);
            this.btnSemantico.TabIndex = 29;
            this.btnSemantico.Text = "Semantico";
            this.btnSemantico.UseVisualStyleBackColor = false;
            this.btnSemantico.Visible = false;
            this.btnSemantico.Click += new System.EventHandler(this.btnSemantico_Click);
            // 
            // barra
            // 
            this.barra.Location = new System.Drawing.Point(325, 375);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(488, 23);
            this.barra.TabIndex = 30;
            this.barra.Visible = false;
            this.barra.Click += new System.EventHandler(this.barra_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(51, 270);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(360, 211);
            this.richTextBox3.TabIndex = 32;
            this.richTextBox3.Text = "";
            this.richTextBox3.WordWrap = false;
            this.richTextBox3.TextChanged += new System.EventHandler(this.richTextBox3_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(777, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 37);
            this.button1.TabIndex = 33;
            this.button1.Text = "Notaciones";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNotaciones
            // 
            this.btnNotaciones.BackColor = System.Drawing.Color.Fuchsia;
            this.btnNotaciones.Enabled = false;
            this.btnNotaciones.ForeColor = System.Drawing.Color.White;
            this.btnNotaciones.Location = new System.Drawing.Point(92, 82);
            this.btnNotaciones.Name = "btnNotaciones";
            this.btnNotaciones.Size = new System.Drawing.Size(100, 50);
            this.btnNotaciones.TabIndex = 34;
            this.btnNotaciones.Text = "Notaciones";
            this.btnNotaciones.UseVisualStyleBackColor = false;
            this.btnNotaciones.Visible = false;
            this.btnNotaciones.Click += new System.EventHandler(this.button2_Click);
            // 
            // btntriplos
            // 
            this.btntriplos.BackColor = System.Drawing.Color.Yellow;
            this.btntriplos.Enabled = false;
            this.btntriplos.Location = new System.Drawing.Point(1470, 800);
            this.btntriplos.Name = "btntriplos";
            this.btntriplos.Size = new System.Drawing.Size(100, 50);
            this.btntriplos.TabIndex = 36;
            this.btntriplos.Text = "Triplos";
            this.btntriplos.UseVisualStyleBackColor = false;
            this.btntriplos.Visible = false;
            this.btntriplos.Click += new System.EventHandler(this.btntriplos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.DarkGray;
            this.btnSalir.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnSalir.Location = new System.Drawing.Point(969, 158);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 49);
            this.btnSalir.TabIndex = 38;
            this.btnSalir.Text = "Cerrar";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 194);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 30);
            this.textBox1.TabIndex = 35;
            this.textBox1.Visible = false;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(59, 33);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(884, 434);
            this.dataGridView2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Location = new System.Drawing.Point(854, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 10);
            this.panel3.TabIndex = 28;
            this.panel3.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(11, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 10);
            this.panel1.TabIndex = 15;
            this.panel1.Visible = false;
            // 
            // DGIdentificadores
            // 
            this.DGIdentificadores.AllowUserToAddRows = false;
            this.DGIdentificadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGIdentificadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGIdentificadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Valor,
            this.DATOS});
            this.DGIdentificadores.Location = new System.Drawing.Point(523, 36);
            this.DGIdentificadores.Margin = new System.Windows.Forms.Padding(2);
            this.DGIdentificadores.Name = "DGIdentificadores";
            this.DGIdentificadores.ReadOnly = true;
            this.DGIdentificadores.Size = new System.Drawing.Size(543, 181);
            this.DGIdentificadores.TabIndex = 0;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Token";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // DATOS
            // 
            this.DATOS.HeaderText = "TIPO";
            this.DATOS.Name = "DATOS";
            this.DATOS.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(548, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Identificadores";
            // 
            // DGTokens
            // 
            this.DGTokens.AllowUserToAddRows = false;
            this.DGTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.DGTokens.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.DGTokens.Location = new System.Drawing.Point(17, 32);
            this.DGTokens.Margin = new System.Windows.Forms.Padding(2);
            this.DGTokens.Name = "DGTokens";
            this.DGTokens.ReadOnly = true;
            this.DGTokens.Size = new System.Drawing.Size(443, 181);
            this.DGTokens.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Token";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Palabra reservada";
            // 
            // DGConstantesNum
            // 
            this.DGConstantesNum.AllowUserToAddRows = false;
            this.DGConstantesNum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGConstantesNum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.DGConstantesNum.Location = new System.Drawing.Point(519, 272);
            this.DGConstantesNum.Margin = new System.Windows.Forms.Padding(2);
            this.DGConstantesNum.Name = "DGConstantesNum";
            this.DGConstantesNum.ReadOnly = true;
            this.DGConstantesNum.Size = new System.Drawing.Size(448, 193);
            this.DGConstantesNum.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Token";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 250;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 250);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Constante Numerica";
            // 
            // DGCadena
            // 
            this.DGCadena.AllowUserToAddRows = false;
            this.DGCadena.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGCadena.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.DGCadena.Location = new System.Drawing.Point(17, 272);
            this.DGCadena.Margin = new System.Windows.Forms.Padding(2);
            this.DGCadena.Name = "DGCadena";
            this.DGCadena.ReadOnly = true;
            this.DGCadena.Size = new System.Drawing.Size(443, 184);
            this.DGCadena.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Token";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 250;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 250);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Cadena";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.DGCadena);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.DGConstantesNum);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.DGTokens);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.DGIdentificadores);
            this.panel2.Location = new System.Drawing.Point(837, 122);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 10);
            this.panel2.TabIndex = 24;
            this.panel2.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(777, 19);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(13, 20);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(92, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 50);
            this.button2.TabIndex = 40;
            this.button2.Text = "tripletas";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Operador
            // 
            this.Operador.HeaderText = "Operador";
            this.Operador.Name = "Operador";
            // 
            // DatoFuente
            // 
            this.DatoFuente.HeaderText = "Dato Fuente";
            this.DatoFuente.Name = "DatoFuente";
            // 
            // DatoObjeto
            // 
            this.DatoObjeto.HeaderText = "Dato Objeto";
            this.DatoObjeto.Name = "DatoObjeto";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatoObjeto,
            this.DatoFuente,
            this.Operador});
            this.dataGridView3.Location = new System.Drawing.Point(123, 43);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(607, 326);
            this.dataGridView3.TabIndex = 37;
            this.dataGridView3.Visible = false;
            // 
            // tripletas
            // 
            this.tripletas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tripletas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tripletas.Location = new System.Drawing.Point(211, 26);
            this.tripletas.Name = "tripletas";
            this.tripletas.ReadOnly = true;
            this.tripletas.Size = new System.Drawing.Size(421, 211);
            this.tripletas.TabIndex = 39;
            this.tripletas.Visible = false;
            this.tripletas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tripletas_CellContentClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(940, 550);
            this.tabControl1.TabIndex = 41;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox3);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.btnSintactico);
            this.tabPage1.Controls.Add(this.lblLinea);
            this.tabPage1.Controls.Add(this.lblTotalLineas);
            this.tabPage1.Controls.Add(this.richTextBox2);
            this.tabPage1.Controls.Add(this.btnSiguiente);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(932, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "EAD-C";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tabPage2.Controls.Add(this.tripletas);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.barra);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.btnSemantico);
            this.tabPage2.Controls.Add(this.btnNotaciones);
            this.tabPage2.Controls.Add(this.dataGridView3);
            this.tabPage2.Controls.Add(this.lblErrores);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(932, 512);
            this.tabPage2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1121, 639);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btntriplos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EAD-C";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGIdentificadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGConstantesNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGCadena)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tripletas)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuAbrir;
        private System.Windows.Forms.ToolStripMenuItem abrirCodigo;
        private System.Windows.Forms.ToolStripMenuItem abrirTokens;
        private System.Windows.Forms.ToolStripMenuItem MenuGuardar;
        private System.Windows.Forms.ToolStripMenuItem guardarCodigo;
        private System.Windows.Forms.ToolStripMenuItem guardarTokens;
        private System.Windows.Forms.ToolStripMenuItem menuTabla;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.ToolStripMenuItem tablaDeTokensToolStripMenuItem;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.Label lblTotalLineas;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSintactico;
        private System.Windows.Forms.ToolStripMenuItem tablaDeGramaticaToolStripMenuItem;
        private System.Windows.Forms.Button btnSemantico;
        private System.Windows.Forms.ProgressBar barra;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNotaciones;
        private System.Windows.Forms.Button btntriplos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DGIdentificadores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATOS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGTokens;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DGConstantesNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DGCadena;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operador;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatoFuente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatoObjeto;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView tripletas;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

