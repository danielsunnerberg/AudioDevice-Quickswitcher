namespace AudioDevice_Quickswitcher.views
{
    partial class DeviceFoundView
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
            this.detailsLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Location = new System.Drawing.Point(16, 48);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(268, 13);
            this.detailsLabel.TabIndex = 5;
            this.detailsLabel.Text = "The wizard has successfully identified your headset as: ";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(248, 39);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Headset found";
            // 
            // continueButton
            // 
            this.continueButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.continueButton.Location = new System.Drawing.Point(397, 277);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 6;
            this.continueButton.Text = "Finish";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(12, 277);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(75, 23);
            this.restartButton.TabIndex = 7;
            this.restartButton.Text = "Try again";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // DeviceFoundView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 312);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.detailsLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "DeviceFoundView";
            this.Text = "Setup: Complete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label detailsLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button restartButton;
    }
}