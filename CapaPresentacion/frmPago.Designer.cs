namespace CapaPresentacion
{
    partial class frmPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Pendiente = new System.Windows.Forms.TabPage();
            this.btnPagar = new System.Windows.Forms.Button();
            this.dataListadoPagoPendiente = new System.Windows.Forms.DataGridView();
            this.Historico = new System.Windows.Forms.TabPage();
            this.Todos = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscarParcelaLote = new System.Windows.Forms.Button();
            this.txtIdParcela = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtlote = new System.Windows.Forms.TextBox();
            this.txtIdventa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarVenta = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Pendiente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoPagoPendiente)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Pendiente);
            this.tabControl1.Controls.Add(this.Historico);
            this.tabControl1.Controls.Add(this.Todos);
            this.tabControl1.Location = new System.Drawing.Point(12, 139);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 298);
            this.tabControl1.TabIndex = 18;
            // 
            // Pendiente
            // 
            this.Pendiente.Controls.Add(this.btnPagar);
            this.Pendiente.Controls.Add(this.dataListadoPagoPendiente);
            this.Pendiente.Location = new System.Drawing.Point(4, 22);
            this.Pendiente.Name = "Pendiente";
            this.Pendiente.Padding = new System.Windows.Forms.Padding(3);
            this.Pendiente.Size = new System.Drawing.Size(852, 272);
            this.Pendiente.TabIndex = 0;
            this.Pendiente.Text = "Pendiente";
            this.Pendiente.UseVisualStyleBackColor = true;
            this.Pendiente.Click += new System.EventHandler(this.Pendiente_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPagar.Image = global::CapaPresentacion.Properties.Resources.payment_method__1_;
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.Location = new System.Drawing.Point(769, 240);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(2);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(80, 27);
            this.btnPagar.TabIndex = 32;
            this.btnPagar.Text = "&Pagar";
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // dataListadoPagoPendiente
            // 
            this.dataListadoPagoPendiente.AllowUserToAddRows = false;
            this.dataListadoPagoPendiente.AllowUserToDeleteRows = false;
            this.dataListadoPagoPendiente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoPagoPendiente.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataListadoPagoPendiente.Location = new System.Drawing.Point(3, 3);
            this.dataListadoPagoPendiente.Margin = new System.Windows.Forms.Padding(2);
            this.dataListadoPagoPendiente.Name = "dataListadoPagoPendiente";
            this.dataListadoPagoPendiente.RowTemplate.Height = 24;
            this.dataListadoPagoPendiente.Size = new System.Drawing.Size(846, 233);
            this.dataListadoPagoPendiente.TabIndex = 32;
            this.dataListadoPagoPendiente.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListadoPagoPendiente_CellValueChanged);
            // 
            // Historico
            // 
            this.Historico.Location = new System.Drawing.Point(4, 22);
            this.Historico.Name = "Historico";
            this.Historico.Padding = new System.Windows.Forms.Padding(3);
            this.Historico.Size = new System.Drawing.Size(908, 289);
            this.Historico.TabIndex = 1;
            this.Historico.Text = "Historico";
            this.Historico.UseVisualStyleBackColor = true;
            // 
            // Todos
            // 
            this.Todos.Location = new System.Drawing.Point(4, 22);
            this.Todos.Name = "Todos";
            this.Todos.Size = new System.Drawing.Size(908, 289);
            this.Todos.TabIndex = 2;
            this.Todos.Text = "Todo";
            this.Todos.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscarParcelaLote);
            this.groupBox2.Controls.Add(this.txtIdParcela);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtlote);
            this.groupBox2.Location = new System.Drawing.Point(13, 41);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(430, 47);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            // 
            // btnBuscarParcelaLote
            // 
            this.btnBuscarParcelaLote.Image = global::CapaPresentacion.Properties.Resources.Buscar_p;
            this.btnBuscarParcelaLote.Location = new System.Drawing.Point(384, 15);
            this.btnBuscarParcelaLote.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarParcelaLote.Name = "btnBuscarParcelaLote";
            this.btnBuscarParcelaLote.Size = new System.Drawing.Size(32, 25);
            this.btnBuscarParcelaLote.TabIndex = 52;
            this.btnBuscarParcelaLote.UseVisualStyleBackColor = true;
            this.btnBuscarParcelaLote.Click += new System.EventHandler(this.btnBuscarParcelaLote_Click);
            // 
            // txtIdParcela
            // 
            this.txtIdParcela.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIdParcela.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdParcela.Location = new System.Drawing.Point(78, 17);
            this.txtIdParcela.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdParcela.Name = "txtIdParcela";
            this.txtIdParcela.Size = new System.Drawing.Size(94, 20);
            this.txtIdParcela.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 19);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Parcela:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Lote:";
            // 
            // txtlote
            // 
            this.txtlote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtlote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlote.Location = new System.Drawing.Point(266, 19);
            this.txtlote.Margin = new System.Windows.Forms.Padding(2);
            this.txtlote.Name = "txtlote";
            this.txtlote.Size = new System.Drawing.Size(94, 20);
            this.txtlote.TabIndex = 30;
            // 
            // txtIdventa
            // 
            this.txtIdventa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIdventa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdventa.Location = new System.Drawing.Point(91, 18);
            this.txtIdventa.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdventa.Name = "txtIdventa";
            this.txtIdventa.Size = new System.Drawing.Size(94, 20);
            this.txtIdventa.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Venta:";
            // 
            // btnBuscarVenta
            // 
            this.btnBuscarVenta.Image = global::CapaPresentacion.Properties.Resources.Buscar_p;
            this.btnBuscarVenta.Location = new System.Drawing.Point(208, 14);
            this.btnBuscarVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarVenta.Name = "btnBuscarVenta";
            this.btnBuscarVenta.Size = new System.Drawing.Size(32, 25);
            this.btnBuscarVenta.TabIndex = 53;
            this.btnBuscarVenta.UseVisualStyleBackColor = true;
            this.btnBuscarVenta.Click += new System.EventHandler(this.btnBuscarVenta_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdventa);
            this.groupBox1.Controls.Add(this.btnBuscarVenta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(4, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 92);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "Pagos";
            // 
            // frmPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 449);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "frmPago";
            this.Text = ".:: Pagos ::.";
            this.tabControl1.ResumeLayout(false);
            this.Pendiente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoPagoPendiente)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Pendiente;
        private System.Windows.Forms.DataGridView dataListadoPagoPendiente;
        private System.Windows.Forms.TabPage Historico;
        private System.Windows.Forms.TabPage Todos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIdParcela;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtlote;
        private System.Windows.Forms.TextBox txtIdventa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnBuscarParcelaLote;
        private System.Windows.Forms.Button btnBuscarVenta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}