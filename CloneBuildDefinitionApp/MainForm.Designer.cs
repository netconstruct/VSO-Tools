namespace CloneBuildDefinitionApp
{
    partial class MainForm
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
            this.btnClone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlSourceProject = new System.Windows.Forms.ComboBox();
            this.ddlDestinationProject = new System.Windows.Forms.ComboBox();
            this.ddlBuildDefinition = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnClone
            // 
            this.btnClone.AutoSize = true;
            this.btnClone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClone.Location = new System.Drawing.Point(210, 92);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(44, 23);
            this.btnClone.TabIndex = 0;
            this.btnClone.Text = "Clone";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Build Definition";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Source Project";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Destination Project";
            // 
            // ddlSourceProject
            // 
            this.ddlSourceProject.FormattingEnabled = true;
            this.ddlSourceProject.Location = new System.Drawing.Point(172, 12);
            this.ddlSourceProject.Name = "ddlSourceProject";
            this.ddlSourceProject.Size = new System.Drawing.Size(280, 21);
            this.ddlSourceProject.TabIndex = 8;
            this.ddlSourceProject.SelectedIndexChanged += new System.EventHandler(this.ddlSourceProject_SelectedIndexChanged);
            // 
            // ddlDestinationProject
            // 
            this.ddlDestinationProject.FormattingEnabled = true;
            this.ddlDestinationProject.Location = new System.Drawing.Point(172, 65);
            this.ddlDestinationProject.Name = "ddlDestinationProject";
            this.ddlDestinationProject.Size = new System.Drawing.Size(280, 21);
            this.ddlDestinationProject.TabIndex = 9;
            // 
            // ddlBuildDefinition
            // 
            this.ddlBuildDefinition.FormattingEnabled = true;
            this.ddlBuildDefinition.Location = new System.Drawing.Point(172, 38);
            this.ddlBuildDefinition.Name = "ddlBuildDefinition";
            this.ddlBuildDefinition.Size = new System.Drawing.Size(280, 21);
            this.ddlBuildDefinition.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 121);
            this.Controls.Add(this.ddlBuildDefinition);
            this.Controls.Add(this.ddlDestinationProject);
            this.Controls.Add(this.ddlSourceProject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClone);
            this.Name = "MainForm";
            this.Text = "Clone Definition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlSourceProject;
        private System.Windows.Forms.ComboBox ddlDestinationProject;
        private System.Windows.Forms.ComboBox ddlBuildDefinition;
    }
}

