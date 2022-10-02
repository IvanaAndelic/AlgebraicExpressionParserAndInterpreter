
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
            this.EnterFunctionTextBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ValueForX0TextBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ValueForXnTextBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1Fx = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.textBoxErrors = new System.Windows.Forms.TextBox();
            this.button1Evaluate = new System.Windows.Forms.Button();
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
            // EnterFunctionTextBox1
            // 
            this.EnterFunctionTextBox1.Location = new System.Drawing.Point(301, 73);
            this.EnterFunctionTextBox1.Name = "EnterFunctionTextBox1";
            this.EnterFunctionTextBox1.Size = new System.Drawing.Size(100, 20);
            this.EnterFunctionTextBox1.TabIndex = 2;
            this.EnterFunctionTextBox1.TextChanged += new System.EventHandler(this.EnterFunctionTextBox1_TextChanged);
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
            // ValueForX0TextBox1
            // 
            this.ValueForX0TextBox1.Location = new System.Drawing.Point(301, 116);
            this.ValueForX0TextBox1.Name = "ValueForX0TextBox1";
            this.ValueForX0TextBox1.Size = new System.Drawing.Size(100, 20);
            this.ValueForX0TextBox1.TabIndex = 4;
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
            // ValueForXnTextBox1
            // 
            this.ValueForXnTextBox1.Location = new System.Drawing.Point(532, 116);
            this.ValueForXnTextBox1.Name = "ValueForXnTextBox1";
            this.ValueForXnTextBox1.Size = new System.Drawing.Size(100, 20);
            this.ValueForXnTextBox1.TabIndex = 6;
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
            // richTextBox1Fx
            // 
            this.richTextBox1Fx.Location = new System.Drawing.Point(287, 188);
            this.richTextBox1Fx.Name = "richTextBox1Fx";
            this.richTextBox1Fx.Size = new System.Drawing.Size(114, 152);
            this.richTextBox1Fx.TabIndex = 11;
            this.richTextBox1Fx.Text = "";
            this.richTextBox1Fx.TextChanged += new System.EventHandler(this.richTextBox1Fx_TextChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(522, 188);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(110, 152);
            this.richTextBox2.TabIndex = 12;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1Evaluate);
            this.Controls.Add(this.textBoxErrors);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1Fx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ValueForXnTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ValueForX0TextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EnterFunctionTextBox1);
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
        private System.Windows.Forms.TextBox EnterFunctionTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ValueForX0TextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ValueForXnTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1Fx;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.TextBox textBoxErrors;
        private System.Windows.Forms.Button button1Evaluate;
    }
}

