namespace ControlVar2AB
{
    partial class Form1
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
            dataGridViewResult = new DataGridView();
            button1 = new Button();
            cmbGroupBy = new ComboBox();
            label3 = new Label();
            buttonDelet = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewResult
            // 
            dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResult.Location = new Point(41, 48);
            dataGridViewResult.Name = "dataGridViewResult";
            dataGridViewResult.RowHeadersWidth = 51;
            dataGridViewResult.RowTemplate.Height = 29;
            dataGridViewResult.Size = new Size(432, 188);
            dataGridViewResult.TabIndex = 0;
            dataGridViewResult.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(547, 159);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 2;
            button1.Text = "Объединение";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cmbGroupBy
            // 
            cmbGroupBy.FormattingEnabled = true;
            cmbGroupBy.Location = new Point(531, 95);
            cmbGroupBy.Name = "cmbGroupBy";
            cmbGroupBy.Size = new Size(151, 28);
            cmbGroupBy.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(540, 62);
            label3.Name = "label3";
            label3.Size = new Size(142, 20);
            label3.TabIndex = 8;
            label3.Text = "Выбор сортировки";
            label3.Click += label3_Click;
            // 
            // buttonDelet
            // 
            buttonDelet.Location = new Point(340, 333);
            buttonDelet.Name = "buttonDelet";
            buttonDelet.Size = new Size(94, 29);
            buttonDelet.TabIndex = 9;
            buttonDelet.Text = "button2";
            buttonDelet.UseVisualStyleBackColor = true;
            buttonDelet.Click += buttonDelet_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(buttonDelet);
            Controls.Add(label3);
            Controls.Add(cmbGroupBy);
            Controls.Add(button1);
            Controls.Add(dataGridViewResult);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewResult;
        private Button button1;
        private ComboBox cmbGroupBy;
        private Label label3;
        private Button buttonDelet;
    }
}