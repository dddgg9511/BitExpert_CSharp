namespace HumanResource
{
    partial class Data_GridView
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
            this.dataGridView_Jobs = new System.Windows.Forms.DataGridView();
            this.dataGridView_Locations = new System.Windows.Forms.DataGridView();
            this.Locations = new iTalk.iTalk_Label();
            this.iTalk_Label1 = new iTalk.iTalk_Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Jobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Locations)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Jobs
            // 
            this.dataGridView_Jobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Jobs.Location = new System.Drawing.Point(24, 274);
            this.dataGridView_Jobs.Name = "dataGridView_Jobs";
            this.dataGridView_Jobs.RowTemplate.Height = 23;
            this.dataGridView_Jobs.Size = new System.Drawing.Size(742, 176);
            this.dataGridView_Jobs.TabIndex = 0;
            // 
            // dataGridView_Locations
            // 
            this.dataGridView_Locations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Locations.Location = new System.Drawing.Point(24, 47);
            this.dataGridView_Locations.Name = "dataGridView_Locations";
            this.dataGridView_Locations.RowTemplate.Height = 23;
            this.dataGridView_Locations.Size = new System.Drawing.Size(742, 185);
            this.dataGridView_Locations.TabIndex = 1;
            // 
            // Locations
            // 
            this.Locations.AutoSize = true;
            this.Locations.BackColor = System.Drawing.Color.Transparent;
            this.Locations.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Locations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.Locations.Location = new System.Drawing.Point(21, 19);
            this.Locations.Name = "Locations";
            this.Locations.Size = new System.Drawing.Size(62, 13);
            this.Locations.TabIndex = 2;
            this.Locations.Text = "Locateions";
            // 
            // iTalk_Label1
            // 
            this.iTalk_Label1.AutoSize = true;
            this.iTalk_Label1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label1.Location = new System.Drawing.Point(21, 248);
            this.iTalk_Label1.Name = "iTalk_Label1";
            this.iTalk_Label1.Size = new System.Drawing.Size(30, 13);
            this.iTalk_Label1.TabIndex = 2;
            this.iTalk_Label1.Text = "Jobs";
            // 
            // Data_GridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.iTalk_Label1);
            this.Controls.Add(this.Locations);
            this.Controls.Add(this.dataGridView_Locations);
            this.Controls.Add(this.dataGridView_Jobs);
            this.Name = "Data_GridView";
            this.Text = "Data_GridView";
            this.Load += new System.EventHandler(this.Data_GridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Jobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Locations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Jobs;
        private System.Windows.Forms.DataGridView dataGridView_Locations;
        private iTalk.iTalk_Label Locations;
        private iTalk.iTalk_Label iTalk_Label1;
    }
}