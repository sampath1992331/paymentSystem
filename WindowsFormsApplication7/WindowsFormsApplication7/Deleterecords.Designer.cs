namespace WindowsFormsApplication7
{
    partial class Deleterecords
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.fnamesw = new System.Windows.Forms.Label();
            this.lnamesw = new System.Windows.Forms.Label();
            this.cntactsw = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(147, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(104, 23);
            this.textBox1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(566, 296);
            this.dataGridView1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(26, 38);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(225, 23);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // fnamesw
            // 
            this.fnamesw.AutoSize = true;
            this.fnamesw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fnamesw.Location = new System.Drawing.Point(26, 70);
            this.fnamesw.Name = "fnamesw";
            this.fnamesw.Size = new System.Drawing.Size(43, 17);
            this.fnamesw.TabIndex = 5;
            this.fnamesw.Text = "name";
            // 
            // lnamesw
            // 
            this.lnamesw.AutoSize = true;
            this.lnamesw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnamesw.Location = new System.Drawing.Point(127, 72);
            this.lnamesw.Name = "lnamesw";
            this.lnamesw.Size = new System.Drawing.Size(43, 17);
            this.lnamesw.TabIndex = 6;
            this.lnamesw.Text = "name";
            // 
            // cntactsw
            // 
            this.cntactsw.AutoSize = true;
            this.cntactsw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cntactsw.Location = new System.Drawing.Point(26, 98);
            this.cntactsw.Name = "cntactsw";
            this.cntactsw.Size = new System.Drawing.Size(43, 17);
            this.cntactsw.TabIndex = 7;
            this.cntactsw.Text = "name";
            // 
            // button3
            // 
            this.button3.Image = global::WindowsFormsApplication7.Properties.Resources._1495222562_9;
            this.button3.Location = new System.Drawing.Point(480, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 98);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::WindowsFormsApplication7.Properties.Resources._1495270032_file_delete;
            this.button2.Location = new System.Drawing.Point(376, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 99);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::WindowsFormsApplication7.Properties.Resources._1495151999_edit_find;
            this.button1.Location = new System.Drawing.Point(270, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 99);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Customer ID";
            // 
            // Deleterecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 425);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cntactsw);
            this.Controls.Add(this.lnamesw);
            this.Controls.Add(this.fnamesw);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.Name = "Deleterecords";
            this.Text = "Deleterecords";
            this.Load += new System.EventHandler(this.Deleterecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label fnamesw;
        private System.Windows.Forms.Label lnamesw;
        private System.Windows.Forms.Label cntactsw;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}