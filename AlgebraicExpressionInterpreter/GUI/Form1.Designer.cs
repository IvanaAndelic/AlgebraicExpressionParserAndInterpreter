
namespace GUI
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
            this.textBoxEquation = new System.Windows.Forms.TextBox();
            this.EnterEquation = new System.Windows.Forms.Label();
            this.textBoxValueForX = new System.Windows.Forms.TextBox();
            this.EnterX = new System.Windows.Forms.Label();
            this.Evaluate = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.textBoxErrors = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxEquation
            // 
            this.textBoxEquation.Location = new System.Drawing.Point(309, 65);
            this.textBoxEquation.Name = "textBoxEquation";
            this.textBoxEquation.Size = new System.Drawing.Size(189, 20);
            this.textBoxEquation.TabIndex = 0;
            this.textBoxEquation.TextChanged += new System.EventHandler(this.EquationTextChanged);
            // 
            // EnterEquation
            // 
            this.EnterEquation.AutoSize = true;
            this.EnterEquation.Location = new System.Drawing.Point(223, 68);
            this.EnterEquation.Name = "EnterEquation";
            this.EnterEquation.Size = new System.Drawing.Size(80, 13);
            this.EnterEquation.TabIndex = 1;
            this.EnterEquation.Text = "Enter Equation:";
            // 
            // textBoxValueForX
            // 
            this.textBoxValueForX.Location = new System.Drawing.Point(309, 127);
            this.textBoxValueForX.Name = "textBoxValueForX";
            this.textBoxValueForX.Size = new System.Drawing.Size(100, 20);
            this.textBoxValueForX.TabIndex = 2;
            // 
            // EnterX
            // 
            this.EnterX.AutoSize = true;
            this.EnterX.Location = new System.Drawing.Point(216, 134);
            this.EnterX.Name = "EnterX";
            this.EnterX.Size = new System.Drawing.Size(87, 13);
            this.EnterX.TabIndex = 3;
            this.EnterX.Text = "Enter value for x:";
            // 
            // Evaluate
            // 
            this.Evaluate.Location = new System.Drawing.Point(226, 194);
            this.Evaluate.Name = "Evaluate";
            this.Evaluate.Size = new System.Drawing.Size(75, 23);
            this.Evaluate.TabIndex = 4;
            this.Evaluate.Text = "Evaluate";
            this.Evaluate.UseVisualStyleBackColor = true;
            this.Evaluate.Click += new System.EventHandler(this.EvaluateButtonClick);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(344, 196);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(100, 20);
            this.textBoxResult.TabIndex = 5;
            // 
            // textBoxErrors
            // 
            this.textBoxErrors.Location = new System.Drawing.Point(226, 244);
            this.textBoxErrors.Name = "textBoxErrors";
            this.textBoxErrors.ReadOnly = true;
            this.textBoxErrors.Size = new System.Drawing.Size(272, 20);
            this.textBoxErrors.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxErrors);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.Evaluate);
            this.Controls.Add(this.EnterX);
            this.Controls.Add(this.textBoxValueForX);
            this.Controls.Add(this.EnterEquation);
            this.Controls.Add(this.textBoxEquation);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEquation;
        private System.Windows.Forms.Label EnterEquation;
        private System.Windows.Forms.TextBox textBoxValueForX;
        private System.Windows.Forms.Label EnterX;
        private System.Windows.Forms.Button Evaluate;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.TextBox textBoxErrors;
    }
}

