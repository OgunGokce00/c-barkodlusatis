namespace VetRx
{
    partial class Fhizlibtnekle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fhizlibtnekle));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LbutonId = new System.Windows.Forms.Label();
            this.Texturunara = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Chtumu = new System.Windows.Forms.CheckBox();
            this.DataGridUrunler = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUrunler)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LbutonId);
            this.splitContainer1.Panel1.Controls.Add(this.Texturunara);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.Chtumu);
          
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DataGridUrunler);
            this.splitContainer1.Size = new System.Drawing.Size(603, 804);
            this.splitContainer1.SplitterDistance = 153;
            this.splitContainer1.TabIndex = 0;
            // 
            // LbutonId
            // 
            this.LbutonId.AutoSize = true;
            this.LbutonId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LbutonId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LbutonId.Location = new System.Drawing.Point(176, 14);
            this.LbutonId.Name = "LbutonId";
            this.LbutonId.Size = new System.Drawing.Size(96, 25);
            this.LbutonId.TabIndex = 6;
            this.LbutonId.Text = "buton no";
            this.LbutonId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Texturunara
            // 
            this.Texturunara.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Texturunara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Texturunara.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Texturunara.Location = new System.Drawing.Point(236, 104);
            this.Texturunara.Margin = new System.Windows.Forms.Padding(1);
            this.Texturunara.Name = "Texturunara";
            this.Texturunara.Size = new System.Drawing.Size(250, 38);
            this.Texturunara.TabIndex = 2;
            this.Texturunara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Texturunara.TextChanged += new System.EventHandler(this.Texturunara_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Buton numarsı :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "ÜRÜN ARA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Chtumu
            // 
            this.Chtumu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Chtumu.AutoSize = true;
            this.Chtumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Chtumu.ForeColor = System.Drawing.Color.Black;
            this.Chtumu.Location = new System.Drawing.Point(323, 47);
            this.Chtumu.Name = "Chtumu";
            this.Chtumu.Size = new System.Drawing.Size(245, 36);
            this.Chtumu.TabIndex = 4;
            this.Chtumu.Text = "Tümünü Göster";
            this.Chtumu.UseVisualStyleBackColor = true;
            this.Chtumu.CheckedChanged += new System.EventHandler(this.Chtumu_CheckedChanged);
            // 
            // DataGridUrunler
            // 
            this.DataGridUrunler.AllowUserToAddRows = false;
            this.DataGridUrunler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridUrunler.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridUrunler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridUrunler.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DataGridUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridUrunler.Location = new System.Drawing.Point(0, 0);
            this.DataGridUrunler.Margin = new System.Windows.Forms.Padding(1);
            this.DataGridUrunler.Name = "DataGridUrunler";
            this.DataGridUrunler.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridUrunler.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridUrunler.RowHeadersVisible = false;
            this.DataGridUrunler.RowHeadersWidth = 51;
            this.DataGridUrunler.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.DataGridUrunler.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DataGridUrunler.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridUrunler.RowTemplate.Height = 32;
            this.DataGridUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridUrunler.Size = new System.Drawing.Size(603, 647);
            this.DataGridUrunler.TabIndex = 2;
            this.DataGridUrunler.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridUrunler_CellContentDoubleClick);
            // 
            // Fhizlibtnekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(603, 804);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(621, 851);
            this.MinimumSize = new System.Drawing.Size(621, 851);
            this.Name = "Fhizlibtnekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hızlı Buton Ürün Ekleme";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridUrunler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DataGridUrunler;
        private System.Windows.Forms.TextBox Texturunara;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Chtumu;
        public System.Windows.Forms.Label LbutonId;
        private System.Windows.Forms.Label label1;
    }
}