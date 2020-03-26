namespace HumanResource
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.직원조회ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Inq_Indi_Employee = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Inq_All_Employee = new System.Windows.Forms.ToolStripMenuItem();
            this.직무이력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.조회ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.직원조회ToolStripMenuItem,
            this.직무이력ToolStripMenuItem,
            this.조회ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 직원조회ToolStripMenuItem
            // 
            this.직원조회ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Inq_Indi_Employee,
            this.Menu_Inq_All_Employee});
            this.직원조회ToolStripMenuItem.Name = "직원조회ToolStripMenuItem";
            this.직원조회ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.직원조회ToolStripMenuItem.Text = "직원조회";
            // 
            // Menu_Inq_Indi_Employee
            // 
            this.Menu_Inq_Indi_Employee.Name = "Menu_Inq_Indi_Employee";
            this.Menu_Inq_Indi_Employee.Size = new System.Drawing.Size(180, 22);
            this.Menu_Inq_Indi_Employee.Text = "개별 직원 조회";
            this.Menu_Inq_Indi_Employee.Click += new System.EventHandler(this.Menu_Inq_Indi_Employee_Click);
            // 
            // Menu_Inq_All_Employee
            // 
            this.Menu_Inq_All_Employee.Name = "Menu_Inq_All_Employee";
            this.Menu_Inq_All_Employee.Size = new System.Drawing.Size(180, 22);
            this.Menu_Inq_All_Employee.Text = "모든 직원 조회";
            this.Menu_Inq_All_Employee.Click += new System.EventHandler(this.Menu_Inq_All_Employee_Click);
            // 
            // 직무이력ToolStripMenuItem
            // 
            this.직무이력ToolStripMenuItem.Name = "직무이력ToolStripMenuItem";
            this.직무이력ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.직무이력ToolStripMenuItem.Text = "직무 이력";
            this.직무이력ToolStripMenuItem.Click += new System.EventHandler(this.직무이력ToolStripMenuItem_Click);
            // 
            // 조회ToolStripMenuItem
            // 
            this.조회ToolStripMenuItem.Name = "조회ToolStripMenuItem";
            this.조회ToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.조회ToolStripMenuItem.Text = "기타정보조회";
            this.조회ToolStripMenuItem.Click += new System.EventHandler(this.조회ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 직원조회ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu_Inq_Indi_Employee;
        private System.Windows.Forms.ToolStripMenuItem Menu_Inq_All_Employee;
        private System.Windows.Forms.ToolStripMenuItem 직무이력ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 조회ToolStripMenuItem;
    }
}

