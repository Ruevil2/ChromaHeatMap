namespace Razer_Chroma_Heat_Map
{
    partial class Form1
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
			this.colorChoiceListBox = new System.Windows.Forms.ListBox();
			this.applyButton = new System.Windows.Forms.Button();
			this.exitButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.maxHeatValueTextBox = new System.Windows.Forms.TextBox();
			this.buildRateTextBox = new System.Windows.Forms.TextBox();
			this.decayRateTextBox = new System.Windows.Forms.TextBox();
			this.coldOFFCheckBox = new System.Windows.Forms.CheckBox();
			this.scaleBrightnessCheckbox = new System.Windows.Forms.CheckBox();
			this.timerTypeListBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// colorChoiceListBox
			// 
			this.colorChoiceListBox.FormattingEnabled = true;
			this.colorChoiceListBox.Items.AddRange(new object[] {
            "Items added via loader"});
			this.colorChoiceListBox.Location = new System.Drawing.Point(12, 82);
			this.colorChoiceListBox.Name = "colorChoiceListBox";
			this.colorChoiceListBox.Size = new System.Drawing.Size(181, 121);
			this.colorChoiceListBox.TabIndex = 0;
			// 
			// applyButton
			// 
			this.applyButton.Location = new System.Drawing.Point(12, 232);
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new System.Drawing.Size(98, 27);
			this.applyButton.TabIndex = 1;
			this.applyButton.Text = "Apply";
			this.applyButton.UseVisualStyleBackColor = true;
			this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
			// 
			// exitButton
			// 
			this.exitButton.Location = new System.Drawing.Point(213, 232);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(98, 27);
			this.exitButton.TabIndex = 2;
			this.exitButton.Text = "Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(202, 82);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Maximum Heat Value";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(202, 121);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Build Rate";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(202, 164);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Decay Rate";
			// 
			// maxHeatValueTextBox
			// 
			this.maxHeatValueTextBox.Location = new System.Drawing.Point(209, 98);
			this.maxHeatValueTextBox.Name = "maxHeatValueTextBox";
			this.maxHeatValueTextBox.Size = new System.Drawing.Size(87, 20);
			this.maxHeatValueTextBox.TabIndex = 6;
			this.maxHeatValueTextBox.Text = "1000";
			// 
			// buildRateTextBox
			// 
			this.buildRateTextBox.Location = new System.Drawing.Point(209, 137);
			this.buildRateTextBox.Name = "buildRateTextBox";
			this.buildRateTextBox.Size = new System.Drawing.Size(66, 20);
			this.buildRateTextBox.TabIndex = 7;
			this.buildRateTextBox.Text = "10";
			// 
			// decayRateTextBox
			// 
			this.decayRateTextBox.Location = new System.Drawing.Point(209, 180);
			this.decayRateTextBox.Name = "decayRateTextBox";
			this.decayRateTextBox.Size = new System.Drawing.Size(66, 20);
			this.decayRateTextBox.TabIndex = 8;
			this.decayRateTextBox.Text = "1";
			// 
			// coldOFFCheckBox
			// 
			this.coldOFFCheckBox.AutoSize = true;
			this.coldOFFCheckBox.Checked = true;
			this.coldOFFCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.coldOFFCheckBox.Location = new System.Drawing.Point(12, 209);
			this.coldOFFCheckBox.Name = "coldOFFCheckBox";
			this.coldOFFCheckBox.Size = new System.Drawing.Size(129, 17);
			this.coldOFFCheckBox.TabIndex = 9;
			this.coldOFFCheckBox.Text = "Keep LEDs lit on Cold";
			this.coldOFFCheckBox.UseVisualStyleBackColor = true;
			// 
			// scaleBrightnessCheckbox
			// 
			this.scaleBrightnessCheckbox.AutoSize = true;
			this.scaleBrightnessCheckbox.Checked = true;
			this.scaleBrightnessCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.scaleBrightnessCheckbox.Location = new System.Drawing.Point(163, 209);
			this.scaleBrightnessCheckbox.Name = "scaleBrightnessCheckbox";
			this.scaleBrightnessCheckbox.Size = new System.Drawing.Size(105, 17);
			this.scaleBrightnessCheckbox.TabIndex = 10;
			this.scaleBrightnessCheckbox.Text = "Scale Brightness";
			this.scaleBrightnessCheckbox.UseVisualStyleBackColor = true;
			// 
			// timerTypeListBox
			// 
			this.timerTypeListBox.FormattingEnabled = true;
			this.timerTypeListBox.Items.AddRange(new object[] {
            "Items added via loader"});
			this.timerTypeListBox.Location = new System.Drawing.Point(12, 12);
			this.timerTypeListBox.Name = "timerTypeListBox";
			this.timerTypeListBox.Size = new System.Drawing.Size(181, 56);
			this.timerTypeListBox.TabIndex = 11;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(321, 271);
			this.Controls.Add(this.timerTypeListBox);
			this.Controls.Add(this.scaleBrightnessCheckbox);
			this.Controls.Add(this.coldOFFCheckBox);
			this.Controls.Add(this.decayRateTextBox);
			this.Controls.Add(this.buildRateTextBox);
			this.Controls.Add(this.maxHeatValueTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.applyButton);
			this.Controls.Add(this.colorChoiceListBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Heat Map";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox colorChoiceListBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox maxHeatValueTextBox;
        private System.Windows.Forms.TextBox buildRateTextBox;
        private System.Windows.Forms.TextBox decayRateTextBox;
        private System.Windows.Forms.CheckBox coldOFFCheckBox;
        private System.Windows.Forms.CheckBox scaleBrightnessCheckbox;
        private System.Windows.Forms.ListBox timerTypeListBox;
    }
}

