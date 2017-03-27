namespace Mailer
{
    partial class ClientForm
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.richTextBoxMailView = new System.Windows.Forms.RichTextBox();
            this.listBoxEmailList = new System.Windows.Forms.ListBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.dataGridViewEmailList = new System.Windows.Forms.DataGridView();
            this.Sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmailList)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "buttonBack";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // richTextBoxMailView
            // 
            this.richTextBoxMailView.Location = new System.Drawing.Point(184, 274);
            this.richTextBoxMailView.Name = "richTextBoxMailView";
            this.richTextBoxMailView.Size = new System.Drawing.Size(655, 306);
            this.richTextBoxMailView.TabIndex = 1;
            this.richTextBoxMailView.Text = "";
            // 
            // listBoxEmailList
            // 
            this.listBoxEmailList.FormattingEnabled = true;
            this.listBoxEmailList.Location = new System.Drawing.Point(12, 107);
            this.listBoxEmailList.Name = "listBoxEmailList";
            this.listBoxEmailList.Size = new System.Drawing.Size(152, 394);
            this.listBoxEmailList.TabIndex = 2;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelUsername.Location = new System.Drawing.Point(129, 12);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(0, 20);
            this.labelUsername.TabIndex = 3;
            // 
            // dataGridViewEmailList
            // 
            this.dataGridViewEmailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sender,
            this.Subject});
            this.dataGridViewEmailList.Location = new System.Drawing.Point(196, 97);
            this.dataGridViewEmailList.Name = "dataGridViewEmailList";
            this.dataGridViewEmailList.ReadOnly = true;
            this.dataGridViewEmailList.Size = new System.Drawing.Size(747, 150);
            this.dataGridViewEmailList.TabIndex = 4;
            // 
            // Sender
            // 
            this.Sender.HeaderText = "Sender";
            this.Sender.Name = "Sender";
            this.Sender.ReadOnly = true;
            this.Sender.Width = 200;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            this.Subject.Width = 500;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 634);
            this.Controls.Add(this.dataGridViewEmailList);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.listBoxEmailList);
            this.Controls.Add(this.richTextBoxMailView);
            this.Controls.Add(this.buttonBack);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmailList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.RichTextBox richTextBoxMailView;
        private System.Windows.Forms.ListBox listBoxEmailList;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.DataGridView dataGridViewEmailList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
    }
}