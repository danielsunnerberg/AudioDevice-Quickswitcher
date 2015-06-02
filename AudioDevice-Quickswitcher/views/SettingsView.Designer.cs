namespace AudioDevice_Quickswitcher.views
{
    partial class SettingsView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
            this.setupDevices = new System.Windows.Forms.Button();
            this.setupKeyBinds = new System.Windows.Forms.Button();
            this.automaticStartupCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // setupDevices
            // 
            this.setupDevices.AutoSize = true;
            this.setupDevices.Location = new System.Drawing.Point(12, 74);
            this.setupDevices.Name = "setupDevices";
            this.setupDevices.Size = new System.Drawing.Size(85, 23);
            this.setupDevices.TabIndex = 1;
            this.setupDevices.Text = "Setup devices";
            this.setupDevices.UseVisualStyleBackColor = true;
            this.setupDevices.Click += new System.EventHandler(this.setupDevices_Click);
            // 
            // setupKeyBinds
            // 
            this.setupKeyBinds.AutoSize = true;
            this.setupKeyBinds.Location = new System.Drawing.Point(103, 74);
            this.setupKeyBinds.Name = "setupKeyBinds";
            this.setupKeyBinds.Size = new System.Drawing.Size(90, 23);
            this.setupKeyBinds.TabIndex = 2;
            this.setupKeyBinds.Text = "Setup keybinds";
            this.setupKeyBinds.UseVisualStyleBackColor = true;
            this.setupKeyBinds.Click += new System.EventHandler(this.setupKeyBinds_Click);
            // 
            // automaticStartupCheckbox
            // 
            this.automaticStartupCheckbox.AutoSize = true;
            this.automaticStartupCheckbox.Location = new System.Drawing.Point(12, 51);
            this.automaticStartupCheckbox.Name = "automaticStartupCheckbox";
            this.automaticStartupCheckbox.Size = new System.Drawing.Size(180, 17);
            this.automaticStartupCheckbox.TabIndex = 3;
            this.automaticStartupCheckbox.Text = "Start program at windows startup";
            this.automaticStartupCheckbox.UseVisualStyleBackColor = true;
            this.automaticStartupCheckbox.CheckedChanged += new System.EventHandler(this.automaticStartupCheckbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "AudioDevice Quickswitcher";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AudioDevice Quickswitcher";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 116);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.automaticStartupCheckbox);
            this.Controls.Add(this.setupKeyBinds);
            this.Controls.Add(this.setupDevices);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsView";
            this.Text = "AudioDevice Quickswitcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setupDevices;
        private System.Windows.Forms.Button setupKeyBinds;
        private System.Windows.Forms.CheckBox automaticStartupCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}