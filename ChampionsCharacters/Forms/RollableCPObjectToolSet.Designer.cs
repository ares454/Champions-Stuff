
namespace Champions.Forms
{
    partial class RollableCPObjectToolSet
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cpLabel = new Champions.Forms.CPLabel();
            this.cpObjectNUD = new Champions.Forms.CPObjectNumericUpDown();
            this.nameLabel = new Champions.Forms.NameLabel();
            this.rollableObjectLabel = new Champions.Forms.RollableObjectLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cpObjectNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // cpLabel
            // 
            this.cpLabel.AutoSize = true;
            this.cpLabel.Location = new System.Drawing.Point(201, 5);
            this.cpLabel.Name = "cpLabel";
            this.cpLabel.Size = new System.Drawing.Size(51, 13);
            this.cpLabel.TabIndex = 2;
            this.cpLabel.Text = "cpLabel1";
            // 
            // cpObjectNUD
            // 
            this.cpObjectNUD.Location = new System.Drawing.Point(74, 3);
            this.cpObjectNUD.Name = "cpObjectNUD";
            this.cpObjectNUD.Size = new System.Drawing.Size(120, 20);
            this.cpObjectNUD.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(3, 5);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(65, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "nameLabel1";
            // 
            // rollableObjectLabel
            // 
            this.rollableObjectLabel.AutoSize = true;
            this.rollableObjectLabel.Location = new System.Drawing.Point(258, 5);
            this.rollableObjectLabel.Name = "rollableObjectLabel";
            this.rollableObjectLabel.Size = new System.Drawing.Size(103, 13);
            this.rollableObjectLabel.TabIndex = 3;
            this.rollableObjectLabel.Text = "rollableObjectLabel1";
            // 
            // RollableCPObjectToolSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rollableObjectLabel);
            this.Controls.Add(this.cpLabel);
            this.Controls.Add(this.cpObjectNUD);
            this.Controls.Add(this.nameLabel);
            this.Name = "RollableCPObjectToolSet";
            this.Size = new System.Drawing.Size(366, 32);
            ((System.ComponentModel.ISupportInitialize)(this.cpObjectNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NameLabel nameLabel;
        private CPObjectNumericUpDown cpObjectNUD;
        private CPLabel cpLabel;
        private RollableObjectLabel rollableObjectLabel;
    }
}
