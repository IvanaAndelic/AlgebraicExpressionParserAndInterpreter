
namespace GUI2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxValueForX0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxValueForXn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxErrors = new System.Windows.Forms.TextBox();
            this.button1Evaluate = new System.Windows.Forms.Button();
            this.textBoxIntervalsNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxExpressionValues = new System.Windows.Forms.ListBox();
            this.listBoxXvalues = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unos Funkcije";
            // 
            // textBoxFunction
            // 
            this.textBoxFunction.Location = new System.Drawing.Point(301, 73);
            this.textBoxFunction.Name = "textBoxFunction";
            this.textBoxFunction.Size = new System.Drawing.Size(100, 20);
            this.textBoxFunction.TabIndex = 2;
            this.textBoxFunction.TextChanged += new System.EventHandler(this.EnterFunctionTextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vrijednost za x0:";
            // 
            // textBoxValueForX0
            // 
            this.textBoxValueForX0.Location = new System.Drawing.Point(301, 116);
            this.textBoxValueForX0.Name = "textBoxValueForX0";
            this.textBoxValueForX0.Size = new System.Drawing.Size(100, 20);
            this.textBoxValueForX0.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Vrijednost za xN";
            // 
            // textBoxValueForXn
            // 
            this.textBoxValueForXn.Location = new System.Drawing.Point(532, 116);
            this.textBoxValueForXn.Name = "textBoxValueForXn";
            this.textBoxValueForXn.Size = new System.Drawing.Size(100, 20);
            this.textBoxValueForXn.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "X(0-N):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "f(x):";
            // 
            // textBoxErrors
            // 
            this.textBoxErrors.Location = new System.Drawing.Point(236, 390);
            this.textBoxErrors.Name = "textBoxErrors";
            this.textBoxErrors.Size = new System.Drawing.Size(396, 20);
            this.textBoxErrors.TabIndex = 13;
            // 
            // button1Evaluate
            // 
            this.button1Evaluate.Location = new System.Drawing.Point(119, 178);
            this.button1Evaluate.Name = "button1Evaluate";
            this.button1Evaluate.Size = new System.Drawing.Size(75, 23);
            this.button1Evaluate.TabIndex = 14;
            this.button1Evaluate.Text = "Evaluate";
            this.button1Evaluate.UseVisualStyleBackColor = true;
            this.button1Evaluate.Click += new System.EventHandler(this.button1Evaluate_Click);
            // 
            // textBoxIntervalsNumber
            // 
            this.textBoxIntervalsNumber.Location = new System.Drawing.Point(532, 152);
            this.textBoxIntervalsNumber.Name = "textBoxIntervalsNumber";
            this.textBoxIntervalsNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxIntervalsNumber.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(442, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "N:";
            // 
            // listBoxExpressionValues
            // 
            this.listBoxExpressionValues.FormattingEnabled = true;
            this.listBoxExpressionValues.Location = new System.Drawing.Point(281, 188);
            this.listBoxExpressionValues.Name = "listBoxExpressionValues";
            this.listBoxExpressionValues.Size = new System.Drawing.Size(120, 173);
            this.listBoxExpressionValues.TabIndex = 17;
            // 
            // listBoxXvalues
            // 
            this.listBoxXvalues.FormattingEnabled = true;
            this.listBoxXvalues.Location = new System.Drawing.Point(512, 188);
            this.listBoxXvalues.Name = "listBoxXvalues";
            this.listBoxXvalues.Size = new System.Drawing.Size(120, 173);
            this.listBoxXvalues.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxXvalues);
            this.Controls.Add(this.listBoxExpressionValues);
            this.Controls.Add(this.textBoxIntervalsNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1Evaluate);
            this.Controls.Add(this.textBoxErrors);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxValueForXn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxValueForX0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFunction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFunction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxValueForX0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxValueForXn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxErrors;
        private System.Windows.Forms.Button button1Evaluate;
        private System.Windows.Forms.TextBox textBoxIntervalsNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBoxExpressionValues;
        private System.Windows.Forms.ListBox listBoxXvalues;
    }
}

