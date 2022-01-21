
namespace WindowsFormsApp1
{
    partial class InitialForm
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
            this.ChancesAmount_btn = new System.Windows.Forms.Button();
            this.Start_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChancesAmount_btn
            // 
            this.ChancesAmount_btn.Location = new System.Drawing.Point(36, 30);
            this.ChancesAmount_btn.Name = "ChancesAmount_btn";
            this.ChancesAmount_btn.Size = new System.Drawing.Size(264, 43);
            this.ChancesAmount_btn.TabIndex = 0;
            this.ChancesAmount_btn.Text = "Number of chances: 4";
            this.ChancesAmount_btn.UseVisualStyleBackColor = true;
            this.ChancesAmount_btn.Click += new System.EventHandler(this.ChancesAmount_btn_Click);
            // 
            // Start_btn
            // 
            this.Start_btn.Location = new System.Drawing.Point(206, 118);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(94, 34);
            this.Start_btn.TabIndex = 1;
            this.Start_btn.Text = "Start";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 178);
            this.Controls.Add(this.Start_btn);
            this.Controls.Add(this.ChancesAmount_btn);
            this.Name = "InitialForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChancesAmount_btn;
        private System.Windows.Forms.Button Start_btn;
    }
}

