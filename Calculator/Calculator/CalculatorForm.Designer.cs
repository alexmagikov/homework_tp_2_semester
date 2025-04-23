namespace Calculator
{
    partial class CalculatorForm
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
            CalculatorPanel = new TableLayoutPanel();
            InputLabel = new Label();
            ButtonOperand7 = new Button();
            ButtonOperand8 = new Button();
            ButtonOperand2 = new Button();
            ButtonOperand1 = new Button();
            ButtonOperand3 = new Button();
            ButtonOperand5 = new Button();
            ButtonOperand4 = new Button();
            ButtonOperand9 = new Button();
            ButtonOperand6 = new Button();
            ButtonOperand0 = new Button();
            ButtonClear = new Button();
            ButtonOperatorResult = new Button();
            ButtonOperatorPlus = new Button();
            ButtonOperatorMinus = new Button();
            ButtonOperatorDivide = new Button();
            ButtonOperatorMultiply = new Button();
            CalculatorPanel.SuspendLayout();
            SuspendLayout();
            // 
            // CalculatorPanel
            // 
            CalculatorPanel.ColumnCount = 4;
            CalculatorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            CalculatorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            CalculatorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            CalculatorPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            CalculatorPanel.Controls.Add(InputLabel, 0, 0);
            CalculatorPanel.Controls.Add(ButtonOperand7, 0, 3);
            CalculatorPanel.Controls.Add(ButtonOperand8, 1, 3);
            CalculatorPanel.Controls.Add(ButtonOperand2, 1, 1);
            CalculatorPanel.Controls.Add(ButtonOperand1, 0, 1);
            CalculatorPanel.Controls.Add(ButtonOperand3, 2, 1);
            CalculatorPanel.Controls.Add(ButtonOperand5, 1, 2);
            CalculatorPanel.Controls.Add(ButtonOperand4, 0, 2);
            CalculatorPanel.Controls.Add(ButtonOperand9, 2, 3);
            CalculatorPanel.Controls.Add(ButtonOperand6, 2, 2);
            CalculatorPanel.Controls.Add(ButtonOperand0, 0, 4);
            CalculatorPanel.Controls.Add(ButtonClear, 1, 4);
            CalculatorPanel.Controls.Add(ButtonOperatorResult, 2, 4);
            CalculatorPanel.Controls.Add(ButtonOperatorPlus, 3, 1);
            CalculatorPanel.Controls.Add(ButtonOperatorMinus, 3, 2);
            CalculatorPanel.Controls.Add(ButtonOperatorDivide, 3, 3);
            CalculatorPanel.Controls.Add(ButtonOperatorMultiply, 3, 4);
            CalculatorPanel.Dock = DockStyle.Fill;
            CalculatorPanel.Location = new Point(0, 0);
            CalculatorPanel.Name = "CalculatorPanel";
            CalculatorPanel.RowCount = 5;
            CalculatorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13.8892822F));
            CalculatorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 21.5283928F));
            CalculatorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 21.5283928F));
            CalculatorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 21.5283928F));
            CalculatorPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 21.5255451F));
            CalculatorPanel.Size = new Size(921, 609);
            CalculatorPanel.TabIndex = 0;
            // 
            // InputLabel
            // 
            InputLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CalculatorPanel.SetColumnSpan(InputLabel, 4);
            InputLabel.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 204);
            InputLabel.Location = new Point(3, 0);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(915, 84);
            InputLabel.TabIndex = 0;
            InputLabel.Text = "Input...";
            InputLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtonOperand7
            // 
            ButtonOperand7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperand7.Location = new Point(3, 349);
            ButtonOperand7.Name = "ButtonOperand7";
            ButtonOperand7.Size = new Size(224, 125);
            ButtonOperand7.TabIndex = 7;
            ButtonOperand7.Text = "7";
            ButtonOperand7.UseVisualStyleBackColor = true;
            ButtonOperand7.Click += OnAllButtonClick;
            // 
            // ButtonOperand8
            // 
            ButtonOperand8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperand8.Location = new Point(233, 349);
            ButtonOperand8.Name = "ButtonOperand8";
            ButtonOperand8.Size = new Size(224, 125);
            ButtonOperand8.TabIndex = 8;
            ButtonOperand8.Text = "8";
            ButtonOperand8.UseVisualStyleBackColor = true;
            ButtonOperand8.Click += OnAllButtonClick;
            // 
            // ButtonOperand2
            // 
            ButtonOperand2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperand2.Location = new Point(233, 87);
            ButtonOperand2.Name = "ButtonOperand2";
            ButtonOperand2.Size = new Size(224, 125);
            ButtonOperand2.TabIndex = 2;
            ButtonOperand2.Text = "2";
            ButtonOperand2.UseVisualStyleBackColor = true;
            ButtonOperand2.Click += OnAllButtonClick;
            // 
            // ButtonOperand1
            // 
            ButtonOperand1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperand1.Location = new Point(3, 87);
            ButtonOperand1.Name = "ButtonOperand1";
            ButtonOperand1.Size = new Size(224, 125);
            ButtonOperand1.TabIndex = 1;
            ButtonOperand1.Text = "1";
            ButtonOperand1.UseVisualStyleBackColor = true;
            ButtonOperand1.Click += OnAllButtonClick;
            // 
            // ButtonOperand3
            // 
            ButtonOperand3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperand3.Location = new Point(463, 87);
            ButtonOperand3.Name = "ButtonOperand3";
            ButtonOperand3.Size = new Size(224, 125);
            ButtonOperand3.TabIndex = 3;
            ButtonOperand3.Text = "3";
            ButtonOperand3.UseVisualStyleBackColor = true;
            ButtonOperand3.Click += OnAllButtonClick;
            // 
            // ButtonOperand5
            // 
            ButtonOperand5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperand5.Location = new Point(233, 218);
            ButtonOperand5.Name = "ButtonOperand5";
            ButtonOperand5.Size = new Size(224, 125);
            ButtonOperand5.TabIndex = 5;
            ButtonOperand5.Text = "5";
            ButtonOperand5.UseVisualStyleBackColor = true;
            ButtonOperand5.Click += OnAllButtonClick;
            // 
            // ButtonOperand4
            // 
            ButtonOperand4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperand4.Location = new Point(3, 218);
            ButtonOperand4.Name = "ButtonOperand4";
            ButtonOperand4.Size = new Size(224, 125);
            ButtonOperand4.TabIndex = 4;
            ButtonOperand4.Text = "4";
            ButtonOperand4.UseVisualStyleBackColor = true;
            ButtonOperand4.Click += OnAllButtonClick;
            // 
            // ButtonOperand9
            // 
            ButtonOperand9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperand9.Location = new Point(463, 349);
            ButtonOperand9.Name = "ButtonOperand9";
            ButtonOperand9.Size = new Size(224, 125);
            ButtonOperand9.TabIndex = 9;
            ButtonOperand9.Text = "9";
            ButtonOperand9.UseVisualStyleBackColor = true;
            ButtonOperand9.Click += OnAllButtonClick;
            // 
            // ButtonOperand6
            // 
            ButtonOperand6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperand6.Location = new Point(463, 218);
            ButtonOperand6.Name = "ButtonOperand6";
            ButtonOperand6.Size = new Size(224, 125);
            ButtonOperand6.TabIndex = 6;
            ButtonOperand6.Text = "6";
            ButtonOperand6.UseVisualStyleBackColor = true;
            ButtonOperand6.Click += OnAllButtonClick;
            // 
            // ButtonOperand0
            // 
            ButtonOperand0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperand0.Location = new Point(3, 480);
            ButtonOperand0.Name = "ButtonOperand0";
            ButtonOperand0.Size = new Size(224, 126);
            ButtonOperand0.TabIndex = 10;
            ButtonOperand0.Text = "0";
            ButtonOperand0.UseVisualStyleBackColor = true;
            ButtonOperand0.Click += OnAllButtonClick;
            // 
            // ButtonClear
            // 
            ButtonClear.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonClear.Location = new Point(233, 480);
            ButtonClear.Name = "ButtonClear";
            ButtonClear.Size = new Size(224, 126);
            ButtonClear.TabIndex = 11;
            ButtonClear.Text = "Clear";
            ButtonClear.UseVisualStyleBackColor = true;
            ButtonClear.Click += OnAllButtonClick;
            // 
            // ButtonOperatorResult
            // 
            ButtonOperatorResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperatorResult.Location = new Point(463, 480);
            ButtonOperatorResult.Name = "ButtonOperatorResult";
            ButtonOperatorResult.Size = new Size(224, 126);
            ButtonOperatorResult.TabIndex = 12;
            ButtonOperatorResult.Text = "=";
            ButtonOperatorResult.UseVisualStyleBackColor = true;
            ButtonOperatorResult.Click += OnAllButtonClick;
            // 
            // ButtonOperatorPlus
            // 
            ButtonOperatorPlus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperatorPlus.Location = new Point(693, 87);
            ButtonOperatorPlus.Name = "ButtonOperatorPlus";
            ButtonOperatorPlus.Size = new Size(225, 125);
            ButtonOperatorPlus.TabIndex = 13;
            ButtonOperatorPlus.Text = "+";
            ButtonOperatorPlus.UseVisualStyleBackColor = true;
            ButtonOperatorPlus.Click += OnAllButtonClick;
            // 
            // ButtonOperatorMinus
            // 
            ButtonOperatorMinus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperatorMinus.Location = new Point(693, 218);
            ButtonOperatorMinus.Name = "ButtonOperatorMinus";
            ButtonOperatorMinus.Size = new Size(225, 125);
            ButtonOperatorMinus.TabIndex = 14;
            ButtonOperatorMinus.Text = "-";
            ButtonOperatorMinus.UseVisualStyleBackColor = true;
            ButtonOperatorMinus.Click += OnAllButtonClick;
            // 
            // ButtonOperatorDivide
            // 
            ButtonOperatorDivide.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperatorDivide.Location = new Point(693, 349);
            ButtonOperatorDivide.Name = "ButtonOperatorDivide";
            ButtonOperatorDivide.Size = new Size(225, 125);
            ButtonOperatorDivide.TabIndex = 15;
            ButtonOperatorDivide.Text = "/";
            ButtonOperatorDivide.UseVisualStyleBackColor = true;
            ButtonOperatorDivide.Click += OnAllButtonClick;
            // 
            // ButtonOperatorMultiply
            // 
            ButtonOperatorMultiply.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOperatorMultiply.Location = new Point(693, 480);
            ButtonOperatorMultiply.Name = "ButtonOperatorMultiply";
            ButtonOperatorMultiply.Size = new Size(225, 126);
            ButtonOperatorMultiply.TabIndex = 16;
            ButtonOperatorMultiply.Text = "*";
            ButtonOperatorMultiply.UseVisualStyleBackColor = true;
            ButtonOperatorMultiply.Click += OnAllButtonClick;
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 609);
            Controls.Add(CalculatorPanel);
            Name = "CalculatorForm";
            Text = "Calculator";
            CalculatorPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel CalculatorPanel;
        private Label InputLabel;
        private Button ButtonOperand1;
        private Button ButtonOperand2;
        private Button ButtonOperand3;
        private Button ButtonOperand4;
        private Button ButtonOperand7;
        private Button ButtonOperand8;
        private Button ButtonOperand5;
        private Button ButtonOperand9;
        private Button ButtonOperand6;
        private Button ButtonOperand0;
        private Button ButtonClear;
        private Button ButtonOperatorResult;
        private Button ButtonOperatorPlus;
        private Button ButtonOperatorMinus;
        private Button ButtonOperatorDivide;
        private Button ButtonOperatorMultiply;
    }
}
