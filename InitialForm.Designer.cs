namespace WindowsFormsApp1
{
    public partial class InitialForm
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
            ChancesAmount = new System.Windows.Forms.Button();
            Start_btn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // ChancesAmount_btn
            // 
            ChancesAmount.Location = new System.Drawing.Point(36, 30);
            ChancesAmount.Name = "ChancesAmount_btn";
            ChancesAmount.Size = new System.Drawing.Size(264, 43);
            ChancesAmount.TabIndex = 0;
            ChancesAmount.Text = "Number of chances: 4";
            ChancesAmount.UseVisualStyleBackColor = true;
            ChancesAmount.Click += new System.EventHandler(ChangesGuessAmount_Click);
            // 
            // Start_btn
            // 
            Start_btn.Location = new System.Drawing.Point(206, 118);
            Start_btn.Name = "Start_btn";
            Start_btn.Size = new System.Drawing.Size(94, 34);
            Start_btn.TabIndex = 1;
            Start_btn.Text = "Start";
            Start_btn.UseVisualStyleBackColor = true;
            Start_btn.Click += new System.EventHandler(Start_Click);
            // 
            // InitialForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(336, 178);
            Controls.Add(Start_btn);
            Controls.Add(ChancesAmount);
            Name = "InitialForm";
            Text = "Bool Pgia";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button ChancesAmount;
        private System.Windows.Forms.Button Start_btn;
    }
}