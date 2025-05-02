namespace TheEscapeButton
{
    partial class TheEscapeButtonForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            escapeButton = new Button();
            SuspendLayout();
            // 
            // escapeButton
            // 
            escapeButton.Anchor = AnchorStyles.None;
            escapeButton.BackColor = SystemColors.ActiveCaption;
            escapeButton.Location = new Point(173, 92);
            escapeButton.Margin = new Padding(0);
            escapeButton.Name = "escapeButton";
            escapeButton.Size = new Size(30, 30);
            escapeButton.TabIndex = 0;
            escapeButton.UseVisualStyleBackColor = false;
            escapeButton.Click += OnButtonClick;
            escapeButton.MouseEnter += OnMouseEnter;
            // 
            // TheEscapeButtonForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(escapeButton);
            Name = "TheEscapeButtonForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button escapeButton;
    }
}
