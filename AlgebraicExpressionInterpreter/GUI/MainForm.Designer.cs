
namespace GUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxIntervalsNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1Evaluate = new System.Windows.Forms.Button();
            this.textBoxValueForXn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxValueForX0 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExpression = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxYMax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxYMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxAdjustAutomatically = new System.Windows.Forms.CheckBox();
            this.textBoxErrors = new System.Windows.Forms.Label();
            this.functionGridView = new CustomControls.FunctionGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.functionGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxIntervalsNumber
            // 
            this.textBoxIntervalsNumber.Location = new System.Drawing.Point(370, 32);
            this.textBoxIntervalsNumber.Name = "textBoxIntervalsNumber";
            this.textBoxIntervalsNumber.Size = new System.Drawing.Size(58, 20);
            this.textBoxIntervalsNumber.TabIndex = 20;
            this.textBoxIntervalsNumber.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Number of &intervals:";
            // 
            // button1Evaluate
            // 
            this.button1Evaluate.Enabled = false;
            this.button1Evaluate.Location = new System.Drawing.Point(353, 4);
            this.button1Evaluate.Name = "button1Evaluate";
            this.button1Evaluate.Size = new System.Drawing.Size(75, 23);
            this.button1Evaluate.TabIndex = 21;
            this.button1Evaluate.Text = "&Draw";
            this.button1Evaluate.UseVisualStyleBackColor = true;
            this.button1Evaluate.Click += new System.EventHandler(this.button1Evaluate_Click);
            // 
            // textBoxValueForXn
            // 
            this.textBoxValueForXn.Location = new System.Drawing.Point(195, 32);
            this.textBoxValueForXn.Name = "textBoxValueForXn";
            this.textBoxValueForXn.Size = new System.Drawing.Size(62, 20);
            this.textBoxValueForXn.TabIndex = 18;
            this.textBoxValueForXn.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "x&N:";
            // 
            // textBoxValueForX0
            // 
            this.textBoxValueForX0.Location = new System.Drawing.Point(79, 32);
            this.textBoxValueForX0.Name = "textBoxValueForX0";
            this.textBoxValueForX0.Size = new System.Drawing.Size(62, 20);
            this.textBoxValueForX0.TabIndex = 16;
            this.textBoxValueForX0.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "x&0:";
            // 
            // textBoxExpression
            // 
            this.textBoxExpression.Location = new System.Drawing.Point(79, 6);
            this.textBoxExpression.Name = "textBoxExpression";
            this.textBoxExpression.Size = new System.Drawing.Size(258, 20);
            this.textBoxExpression.TabIndex = 14;
            this.textBoxExpression.TextChanged += new System.EventHandler(this.EquationTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "E&xpression:";
            // 
            // textBoxYMax
            // 
            this.textBoxYMax.Location = new System.Drawing.Point(195, 61);
            this.textBoxYMax.Name = "textBoxYMax";
            this.textBoxYMax.Size = new System.Drawing.Size(62, 20);
            this.textBoxYMax.TabIndex = 29;
            this.textBoxYMax.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "yMa&x:";
            // 
            // textBoxYMin
            // 
            this.textBoxYMin.Location = new System.Drawing.Point(79, 61);
            this.textBoxYMin.Name = "textBoxYMin";
            this.textBoxYMin.Size = new System.Drawing.Size(62, 20);
            this.textBoxYMin.TabIndex = 27;
            this.textBoxYMin.Text = "-1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "y&Min:";
            // 
            // checkBoxAdjustAutomatically
            // 
            this.checkBoxAdjustAutomatically.AutoSize = true;
            this.checkBoxAdjustAutomatically.Location = new System.Drawing.Point(266, 63);
            this.checkBoxAdjustAutomatically.Name = "checkBoxAdjustAutomatically";
            this.checkBoxAdjustAutomatically.Size = new System.Drawing.Size(119, 17);
            this.checkBoxAdjustAutomatically.TabIndex = 30;
            this.checkBoxAdjustAutomatically.Text = "&Adjust automatically";
            this.checkBoxAdjustAutomatically.UseVisualStyleBackColor = true;
            this.checkBoxAdjustAutomatically.CheckedChanged += new System.EventHandler(this.checkBoxAdjustAutomatically_CheckedChanged);
            // 
            // textBoxErrors
            // 
            this.textBoxErrors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxErrors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBoxErrors.Location = new System.Drawing.Point(444, 9);
            this.textBoxErrors.Name = "textBoxErrors";
            this.textBoxErrors.Size = new System.Drawing.Size(364, 23);
            this.textBoxErrors.TabIndex = 31;
            this.textBoxErrors.Text = "AAA";
            // 
            // functionGridView
            // 
            this.functionGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionGridView.BackColor = System.Drawing.SystemColors.Window;
            this.functionGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionGridView.Location = new System.Drawing.Point(12, 87);
            this.functionGridView.Name = "functionGridView";
            this.functionGridView.Size = new System.Drawing.Size(796, 351);
            this.functionGridView.TabIndex = 25;
            this.functionGridView.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(670, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "Print Preview";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // MainForm
            // 
            this.AcceptButton = this.button1Evaluate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxErrors);
            this.Controls.Add(this.checkBoxAdjustAutomatically);
            this.Controls.Add(this.textBoxYMax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxYMin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.functionGridView);
            this.Controls.Add(this.textBoxIntervalsNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1Evaluate);
            this.Controls.Add(this.textBoxValueForXn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxValueForX0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxExpression);
            this.Controls.Add(this.label2);
            this.Name = "MainForm";
            this.Text = "Expression Drawing";
            ((System.ComponentModel.ISupportInitialize)(this.functionGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIntervalsNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1Evaluate;
        private System.Windows.Forms.TextBox textBoxValueForXn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxValueForX0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxExpression;
        private System.Windows.Forms.Label label2;
        private CustomControls.FunctionGridView functionGridView;
        private System.Windows.Forms.TextBox textBoxYMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxYMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxAdjustAutomatically;
        private System.Windows.Forms.Label textBoxErrors;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}

