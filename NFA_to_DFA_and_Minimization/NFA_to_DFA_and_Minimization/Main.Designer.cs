namespace NFA_to_DFA_and_Minimization
{
    partial class Main
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
            this.NFAPath = new System.Windows.Forms.TextBox();
            this.DFAPath = new System.Windows.Forms.TextBox();
            this.MinimizedDFAPath = new System.Windows.Forms.TextBox();
            this.NFALabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DFALabel = new System.Windows.Forms.Label();
            this.LoadNFA = new System.Windows.Forms.Button();
            this.GenerateDFA = new System.Windows.Forms.Button();
            this.MinimizeDFA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 28.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(562, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "NFA to DFA and DFA Minimizer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cornsilk;
            this.label2.Location = new System.Drawing.Point(602, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "By Mirzaei and Pirhadi";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // NFAPath
            // 
            this.NFAPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.NFAPath.Location = new System.Drawing.Point(608, 80);
            this.NFAPath.Multiline = true;
            this.NFAPath.Name = "NFAPath";
            this.NFAPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.NFAPath.Size = new System.Drawing.Size(340, 50);
            this.NFAPath.TabIndex = 5;
            this.NFAPath.TextChanged += new System.EventHandler(this.NFAPath_TextChanged);
            // 
            // DFAPath
            // 
            this.DFAPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.DFAPath.Location = new System.Drawing.Point(608, 155);
            this.DFAPath.Multiline = true;
            this.DFAPath.Name = "DFAPath";
            this.DFAPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DFAPath.Size = new System.Drawing.Size(340, 50);
            this.DFAPath.TabIndex = 6;
            this.DFAPath.TextChanged += new System.EventHandler(this.DFAPath_TextChanged);
            // 
            // MinimizedDFAPath
            // 
            this.MinimizedDFAPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.MinimizedDFAPath.Location = new System.Drawing.Point(608, 231);
            this.MinimizedDFAPath.Multiline = true;
            this.MinimizedDFAPath.Name = "MinimizedDFAPath";
            this.MinimizedDFAPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MinimizedDFAPath.Size = new System.Drawing.Size(340, 50);
            this.MinimizedDFAPath.TabIndex = 7;
            this.MinimizedDFAPath.TextChanged += new System.EventHandler(this.MinimizedDFAPath_TextChanged);
            // 
            // NFALabel
            // 
            this.NFALabel.AutoSize = true;
            this.NFALabel.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NFALabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.NFALabel.Location = new System.Drawing.Point(17, 84);
            this.NFALabel.Name = "NFALabel";
            this.NFALabel.Size = new System.Drawing.Size(236, 29);
            this.NFALabel.TabIndex = 11;
            this.NFALabel.Text = "NFA Input Text Path:";
            this.NFALabel.Click += new System.EventHandler(this.optimizedSOPLabel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(17, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Minimized DFA Output Text Path:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // DFALabel
            // 
            this.DFALabel.AutoSize = true;
            this.DFALabel.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFALabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.DFALabel.Location = new System.Drawing.Point(17, 159);
            this.DFALabel.Name = "DFALabel";
            this.DFALabel.Size = new System.Drawing.Size(250, 29);
            this.DFALabel.TabIndex = 13;
            this.DFALabel.Text = "DFA Output Text Path:";
            // 
            // LoadNFA
            // 
            this.LoadNFA.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadNFA.Location = new System.Drawing.Point(966, 80);
            this.LoadNFA.Name = "LoadNFA";
            this.LoadNFA.Size = new System.Drawing.Size(131, 50);
            this.LoadNFA.TabIndex = 14;
            this.LoadNFA.Text = "Load NFA";
            this.LoadNFA.UseVisualStyleBackColor = true;
            this.LoadNFA.Click += new System.EventHandler(this.GenerateNFA_Click);
            // 
            // GenerateDFA
            // 
            this.GenerateDFA.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateDFA.Location = new System.Drawing.Point(967, 155);
            this.GenerateDFA.Name = "GenerateDFA";
            this.GenerateDFA.Size = new System.Drawing.Size(131, 50);
            this.GenerateDFA.TabIndex = 15;
            this.GenerateDFA.Text = "Generate DFA";
            this.GenerateDFA.UseVisualStyleBackColor = true;
            this.GenerateDFA.Click += new System.EventHandler(this.GenerateDFA_Click);
            // 
            // MinimizeDFA
            // 
            this.MinimizeDFA.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeDFA.Location = new System.Drawing.Point(967, 231);
            this.MinimizeDFA.Name = "MinimizeDFA";
            this.MinimizeDFA.Size = new System.Drawing.Size(131, 50);
            this.MinimizeDFA.TabIndex = 16;
            this.MinimizeDFA.Text = "Minimize DFA";
            this.MinimizeDFA.UseVisualStyleBackColor = true;
            this.MinimizeDFA.Click += new System.EventHandler(this.MinimizeDFA_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1118, 313);
            this.Controls.Add(this.MinimizeDFA);
            this.Controls.Add(this.GenerateDFA);
            this.Controls.Add(this.LoadNFA);
            this.Controls.Add(this.DFALabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NFALabel);
            this.Controls.Add(this.MinimizedDFAPath);
            this.Controls.Add(this.DFAPath);
            this.Controls.Add(this.NFAPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NFAPath;
        private System.Windows.Forms.TextBox DFAPath;
        private System.Windows.Forms.TextBox MinimizedDFAPath;
        private System.Windows.Forms.Label NFALabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DFALabel;
        private System.Windows.Forms.Button LoadNFA;
        private System.Windows.Forms.Button GenerateDFA;
        private System.Windows.Forms.Button MinimizeDFA;
    }
}

