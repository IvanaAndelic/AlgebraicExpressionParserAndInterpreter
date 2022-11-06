
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxValueForX0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxValueForXn = new System.Windows.Forms.TextBox();
            this.textBoxErrors = new System.Windows.Forms.TextBox();
            this.button1Evaluate = new System.Windows.Forms.Button();
            this.textBoxIntervalsNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listViewExpressionValues = new System.Windows.Forms.ListView();
            this.columnHeaderX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderExpressionValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "E&xpression:";
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
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "x&0:";
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
            this.label4.Location = new System.Drawing.Point(442, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "x&N:";
            // 
            // textBoxValueForXn
            // 
            this.textBoxValueForXn.Location = new System.Drawing.Point(495, 73);
            this.textBoxValueForXn.Name = "textBoxValueForXn";
            this.textBoxValueForXn.Size = new System.Drawing.Size(100, 20);
            this.textBoxValueForXn.TabIndex = 6;
            // 
            // textBoxErrors
            // 
            this.textBoxErrors.Location = new System.Drawing.Point(236, 390);
            this.textBoxErrors.Name = "textBoxErrors";
            this.textBoxErrors.ReadOnly = true;
            this.textBoxErrors.Size = new System.Drawing.Size(396, 20);
            this.textBoxErrors.TabIndex = 12;
            this.textBoxErrors.TabStop = false;
            // 
            // button1Evaluate
            // 
            this.button1Evaluate.Location = new System.Drawing.Point(119, 178);
            this.button1Evaluate.Name = "button1Evaluate";
            this.button1Evaluate.Size = new System.Drawing.Size(75, 23);
            this.button1Evaluate.TabIndex = 9;
            this.button1Evaluate.Text = "E&valuate";
            this.button1Evaluate.UseVisualStyleBackColor = true;
            this.button1Evaluate.Click += new System.EventHandler(this.button1Evaluate_Click);
            // 
            // textBoxIntervalsNumber
            // 
            this.textBoxIntervalsNumber.Location = new System.Drawing.Point(554, 120);
            this.textBoxIntervalsNumber.Name = "textBoxIntervalsNumber";
            this.textBoxIntervalsNumber.Size = new System.Drawing.Size(58, 20);
            this.textBoxIntervalsNumber.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Number of &intervals:";
            // 
            // listViewExpressionValues
            // 
            this.listViewExpressionValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewExpressionValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderX,
            this.columnHeaderExpressionValue});
            this.listViewExpressionValues.FullRowSelect = true;
            this.listViewExpressionValues.HideSelection = false;
            this.listViewExpressionValues.Location = new System.Drawing.Point(301, 205);
            this.listViewExpressionValues.Name = "listViewExpressionValues";
            this.listViewExpressionValues.Size = new System.Drawing.Size(331, 167);
            this.listViewExpressionValues.TabIndex = 11;
            this.listViewExpressionValues.UseCompatibleStateImageBehavior = false;
            this.listViewExpressionValues.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderX
            // 
            this.columnHeaderX.Text = "X";
            // 
            // columnHeaderExpressionValue
            // 
            this.columnHeaderExpressionValue.Text = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "&Expression values:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewExpressionValues);
            this.Controls.Add(this.textBoxIntervalsNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1Evaluate);
            this.Controls.Add(this.textBoxErrors);
            this.Controls.Add(this.textBoxValueForXn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxValueForX0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFunction);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Evaluate Expression";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFunction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxValueForX0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxValueForXn;
        private System.Windows.Forms.TextBox textBoxErrors;
        private System.Windows.Forms.Button button1Evaluate;
        private System.Windows.Forms.TextBox textBoxIntervalsNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listViewExpressionValues;
        private System.Windows.Forms.ColumnHeader columnHeaderX;
        private System.Windows.Forms.ColumnHeader columnHeaderExpressionValue;
        private System.Windows.Forms.Label label1;
    }
}

