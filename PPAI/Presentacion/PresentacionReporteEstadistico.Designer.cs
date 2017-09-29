namespace Presentacion
{
    partial class PresentacionReporteEstadistico
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
            this.cb_metodos_estadisticos = new System.Windows.Forms.ComboBox();
            this.lbl_metodos_estadisticos = new System.Windows.Forms.Label();
            this.clb_zonas = new System.Windows.Forms.CheckedListBox();
            this.lbl_zonas = new System.Windows.Forms.Label();
            this.tb_estadisticas = new System.Windows.Forms.TextBox();
            this.lbl_estadisticas = new System.Windows.Forms.Label();
            this.btn_generar = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.lbl_desde = new System.Windows.Forms.Label();
            this.dtp_desde = new System.Windows.Forms.DateTimePicker();
            this.dtp_hasta = new System.Windows.Forms.DateTimePicker();
            this.lbl_hasta = new System.Windows.Forms.Label();
            this.lbl_categorias = new System.Windows.Forms.Label();
            this.clb_categorias = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // cb_metodos_estadisticos
            // 
            this.cb_metodos_estadisticos.DisplayMember = "0";
            this.cb_metodos_estadisticos.FormattingEnabled = true;
            this.cb_metodos_estadisticos.Location = new System.Drawing.Point(420, 47);
            this.cb_metodos_estadisticos.Name = "cb_metodos_estadisticos";
            this.cb_metodos_estadisticos.Size = new System.Drawing.Size(307, 21);
            this.cb_metodos_estadisticos.TabIndex = 5;
            this.cb_metodos_estadisticos.SelectedIndexChanged += new System.EventHandler(this.cb_metodos_estadisticos_SelectedIndexChanged);
            // 
            // lbl_metodos_estadisticos
            // 
            this.lbl_metodos_estadisticos.AutoSize = true;
            this.lbl_metodos_estadisticos.Location = new System.Drawing.Point(313, 50);
            this.lbl_metodos_estadisticos.Name = "lbl_metodos_estadisticos";
            this.lbl_metodos_estadisticos.Size = new System.Drawing.Size(101, 13);
            this.lbl_metodos_estadisticos.TabIndex = 1;
            this.lbl_metodos_estadisticos.Text = "Método estadístico:";
            // 
            // clb_zonas
            // 
            this.clb_zonas.CheckOnClick = true;
            this.clb_zonas.FormattingEnabled = true;
            this.clb_zonas.Location = new System.Drawing.Point(160, 106);
            this.clb_zonas.Name = "clb_zonas";
            this.clb_zonas.Size = new System.Drawing.Size(98, 304);
            this.clb_zonas.TabIndex = 4;
            // 
            // lbl_zonas
            // 
            this.lbl_zonas.AutoSize = true;
            this.lbl_zonas.Location = new System.Drawing.Point(157, 81);
            this.lbl_zonas.Name = "lbl_zonas";
            this.lbl_zonas.Size = new System.Drawing.Size(40, 13);
            this.lbl_zonas.TabIndex = 3;
            this.lbl_zonas.Text = "Zonas:";
            // 
            // tb_estadisticas
            // 
            this.tb_estadisticas.Enabled = false;
            this.tb_estadisticas.Location = new System.Drawing.Point(316, 106);
            this.tb_estadisticas.Name = "tb_estadisticas";
            this.tb_estadisticas.Size = new System.Drawing.Size(411, 20);
            this.tb_estadisticas.TabIndex = 4;
            this.tb_estadisticas.Visible = false;
            // 
            // lbl_estadisticas
            // 
            this.lbl_estadisticas.AutoSize = true;
            this.lbl_estadisticas.Location = new System.Drawing.Point(313, 81);
            this.lbl_estadisticas.Name = "lbl_estadisticas";
            this.lbl_estadisticas.Size = new System.Drawing.Size(68, 13);
            this.lbl_estadisticas.TabIndex = 5;
            this.lbl_estadisticas.Text = "Estadísticas:";
            this.lbl_estadisticas.Visible = false;
            // 
            // btn_generar
            // 
            this.btn_generar.Enabled = false;
            this.btn_generar.Location = new System.Drawing.Point(160, 428);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(98, 23);
            this.btn_generar.TabIndex = 6;
            this.btn_generar.Text = "Generar";
            this.btn_generar.UseVisualStyleBackColor = true;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.Location = new System.Drawing.Point(33, 428);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(98, 23);
            this.btn_actualizar.TabIndex = 7;
            this.btn_actualizar.Text = "Actualizar Datos";
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // lbl_desde
            // 
            this.lbl_desde.AutoSize = true;
            this.lbl_desde.Location = new System.Drawing.Point(28, 20);
            this.lbl_desde.Name = "lbl_desde";
            this.lbl_desde.Size = new System.Drawing.Size(41, 13);
            this.lbl_desde.TabIndex = 8;
            this.lbl_desde.Text = "Desde:";
            // 
            // dtp_desde
            // 
            this.dtp_desde.CustomFormat = "dd\'/\'MM\'/\'yyyy";
            this.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_desde.Location = new System.Drawing.Point(75, 18);
            this.dtp_desde.MaxDate = new System.DateTime(2017, 9, 29, 0, 0, 0, 0);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(95, 20);
            this.dtp_desde.TabIndex = 1;
            this.dtp_desde.Value = new System.DateTime(2017, 9, 29, 0, 0, 0, 0);
            this.dtp_desde.ValueChanged += new System.EventHandler(this.dtp_desde_ValueChanged);
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.CustomFormat = "dd\'/\'MM\'/\'yyyy";
            this.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_hasta.Location = new System.Drawing.Point(75, 48);
            this.dtp_hasta.MaxDate = new System.DateTime(2017, 9, 29, 0, 0, 0, 0);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(95, 20);
            this.dtp_hasta.TabIndex = 2;
            this.dtp_hasta.Value = new System.DateTime(2017, 9, 29, 0, 0, 0, 0);
            this.dtp_hasta.ValueChanged += new System.EventHandler(this.dtp_hasta_ValueChanged);
            // 
            // lbl_hasta
            // 
            this.lbl_hasta.AutoSize = true;
            this.lbl_hasta.Location = new System.Drawing.Point(28, 50);
            this.lbl_hasta.Name = "lbl_hasta";
            this.lbl_hasta.Size = new System.Drawing.Size(38, 13);
            this.lbl_hasta.TabIndex = 10;
            this.lbl_hasta.Text = "Hasta:";
            // 
            // lbl_categorias
            // 
            this.lbl_categorias.AutoSize = true;
            this.lbl_categorias.Location = new System.Drawing.Point(30, 81);
            this.lbl_categorias.Name = "lbl_categorias";
            this.lbl_categorias.Size = new System.Drawing.Size(62, 13);
            this.lbl_categorias.TabIndex = 13;
            this.lbl_categorias.Text = "Categorías:";
            // 
            // clb_categorias
            // 
            this.clb_categorias.CheckOnClick = true;
            this.clb_categorias.FormattingEnabled = true;
            this.clb_categorias.Location = new System.Drawing.Point(33, 106);
            this.clb_categorias.Name = "clb_categorias";
            this.clb_categorias.Size = new System.Drawing.Size(98, 304);
            this.clb_categorias.TabIndex = 3;
            // 
            // PresentacionReporteEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 475);
            this.Controls.Add(this.lbl_categorias);
            this.Controls.Add(this.clb_categorias);
            this.Controls.Add(this.dtp_hasta);
            this.Controls.Add(this.lbl_hasta);
            this.Controls.Add(this.dtp_desde);
            this.Controls.Add(this.lbl_desde);
            this.Controls.Add(this.btn_actualizar);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.lbl_estadisticas);
            this.Controls.Add(this.tb_estadisticas);
            this.Controls.Add(this.lbl_zonas);
            this.Controls.Add(this.clb_zonas);
            this.Controls.Add(this.lbl_metodos_estadisticos);
            this.Controls.Add(this.cb_metodos_estadisticos);
            this.Name = "PresentacionReporteEstadistico";
            this.Text = "Generar Reporte Estadístico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_metodos_estadisticos;
        private System.Windows.Forms.Label lbl_metodos_estadisticos;
        private System.Windows.Forms.CheckedListBox clb_zonas;
        private System.Windows.Forms.Label lbl_zonas;
        private System.Windows.Forms.TextBox tb_estadisticas;
        private System.Windows.Forms.Label lbl_estadisticas;
        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Label lbl_desde;
        private System.Windows.Forms.DateTimePicker dtp_desde;
        private System.Windows.Forms.DateTimePicker dtp_hasta;
        private System.Windows.Forms.Label lbl_hasta;
        private System.Windows.Forms.Label lbl_categorias;
        private System.Windows.Forms.CheckedListBox clb_categorias;
    }
}

