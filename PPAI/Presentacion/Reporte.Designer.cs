﻿namespace Presentacion
{
    partial class Reporte
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txt_estadisticas = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).BeginInit();
            this.SuspendLayout();
            // 
            // grafico
            // 
            chartArea3.AxisX.Title = "Categorías";
            chartArea3.AxisY.Title = "Promedio de m3 consumidos";
            chartArea3.Name = "Area1";
            this.grafico.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.grafico.Legends.Add(legend3);
            this.grafico.Location = new System.Drawing.Point(12, 316);
            this.grafico.Name = "grafico";
            series3.ChartArea = "Area1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.grafico.Series.Add(series3);
            this.grafico.Size = new System.Drawing.Size(750, 345);
            this.grafico.TabIndex = 15;
            this.grafico.Visible = false;
            // 
            // txt_estadisticas
            // 
            this.txt_estadisticas.Location = new System.Drawing.Point(12, 12);
            this.txt_estadisticas.Multiline = true;
            this.txt_estadisticas.Name = "txt_estadisticas";
            this.txt_estadisticas.ReadOnly = true;
            this.txt_estadisticas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_estadisticas.Size = new System.Drawing.Size(750, 298);
            this.txt_estadisticas.TabIndex = 16;
            this.txt_estadisticas.Visible = false;
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 673);
            this.Controls.Add(this.txt_estadisticas);
            this.Controls.Add(this.grafico);
            this.Name = "Reporte";
            this.Text = "Reporte";
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grafico;
        private System.Windows.Forms.TextBox txt_estadisticas;
    }
}