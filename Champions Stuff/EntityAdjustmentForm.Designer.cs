
namespace Champions_Stuff
{
    partial class EntityAdjustmentForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.dexterityNUD = new System.Windows.Forms.NumericUpDown();
            this.speedNUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dexterityNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(93, 76);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.Location = new System.Drawing.Point(12, 76);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            // 
            // dexterityNUD
            // 
            this.dexterityNUD.Location = new System.Drawing.Point(66, 50);
            this.dexterityNUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.dexterityNUD.Name = "dexterityNUD";
            this.dexterityNUD.Size = new System.Drawing.Size(120, 20);
            this.dexterityNUD.TabIndex = 13;
            this.dexterityNUD.ValueChanged += new System.EventHandler(this.dexterityNUD_ValueChanged);
            // 
            // speedNUD
            // 
            this.speedNUD.Location = new System.Drawing.Point(66, 12);
            this.speedNUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.speedNUD.Name = "speedNUD";
            this.speedNUD.Size = new System.Drawing.Size(120, 20);
            this.speedNUD.TabIndex = 12;
            this.speedNUD.ValueChanged += new System.EventHandler(this.speedNUD_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Dexterity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Speed";
            // 
            // EntityAdjustmentForm
            // 
            this.AcceptButton = this.addButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(207, 112);
            this.ControlBox = false;
            this.Controls.Add(this.dexterityNUD);
            this.Controls.Add(this.speedNUD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addButton);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EntityAdjustmentForm";
            this.Text = "EntityAdjustmentForm";
            ((System.ComponentModel.ISupportInitialize)(this.dexterityNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.NumericUpDown dexterityNUD;
        private System.Windows.Forms.NumericUpDown speedNUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}