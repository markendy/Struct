namespace saod7
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewBut = new System.Windows.Forms.Button();
            this.OpenBut = new System.Windows.Forms.Button();
            this.SaveBut = new System.Windows.Forms.Button();
            this.AddType1 = new System.Windows.Forms.Button();
            this.AddType2 = new System.Windows.Forms.Button();
            this.AddTextBox = new System.Windows.Forms.TextBox();
            this.Logs = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ParentTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DelBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewBut
            // 
            this.NewBut.Location = new System.Drawing.Point(3, 2);
            this.NewBut.Name = "NewBut";
            this.NewBut.Size = new System.Drawing.Size(45, 23);
            this.NewBut.TabIndex = 1;
            this.NewBut.Text = "New";
            this.NewBut.UseVisualStyleBackColor = true;
            // 
            // OpenBut
            // 
            this.OpenBut.Location = new System.Drawing.Point(54, 2);
            this.OpenBut.Name = "OpenBut";
            this.OpenBut.Size = new System.Drawing.Size(45, 23);
            this.OpenBut.TabIndex = 2;
            this.OpenBut.Text = "Open";
            this.OpenBut.UseVisualStyleBackColor = true;
            // 
            // SaveBut
            // 
            this.SaveBut.Location = new System.Drawing.Point(105, 2);
            this.SaveBut.Name = "SaveBut";
            this.SaveBut.Size = new System.Drawing.Size(45, 23);
            this.SaveBut.TabIndex = 3;
            this.SaveBut.Text = "Save";
            this.SaveBut.UseVisualStyleBackColor = true;
            // 
            // AddType1
            // 
            this.AddType1.Location = new System.Drawing.Point(12, 72);
            this.AddType1.Name = "AddType1";
            this.AddType1.Size = new System.Drawing.Size(87, 23);
            this.AddType1.TabIndex = 4;
            this.AddType1.Text = "Add Type ->";
            this.AddType1.UseVisualStyleBackColor = true;
            this.AddType1.Click += new System.EventHandler(this.AddType1_Click);
            // 
            // AddType2
            // 
            this.AddType2.Location = new System.Drawing.Point(12, 101);
            this.AddType2.Name = "AddType2";
            this.AddType2.Size = new System.Drawing.Size(87, 23);
            this.AddType2.TabIndex = 5;
            this.AddType2.Text = "Add Type <->";
            this.AddType2.UseVisualStyleBackColor = true;
            this.AddType2.Click += new System.EventHandler(this.AddType2_Click);
            // 
            // AddTextBox
            // 
            this.AddTextBox.Location = new System.Drawing.Point(12, 46);
            this.AddTextBox.Name = "AddTextBox";
            this.AddTextBox.Size = new System.Drawing.Size(36, 20);
            this.AddTextBox.TabIndex = 6;
            // 
            // Logs
            // 
            this.Logs.Location = new System.Drawing.Point(12, 146);
            this.Logs.Name = "Logs";
            this.Logs.ReadOnly = true;
            this.Logs.Size = new System.Drawing.Size(87, 20);
            this.Logs.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Obxod";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Logs:";
            // 
            // ParentTextBox
            // 
            this.ParentTextBox.Location = new System.Drawing.Point(63, 46);
            this.ParentTextBox.Name = "ParentTextBox";
            this.ParentTextBox.Size = new System.Drawing.Size(36, 20);
            this.ParentTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Parent:";
            // 
            // InTextBox
            // 
            this.InTextBox.Location = new System.Drawing.Point(114, 46);
            this.InTextBox.Name = "InTextBox";
            this.InTextBox.Size = new System.Drawing.Size(36, 20);
            this.InTextBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Vxoj?:";
            // 
            // DelBut
            // 
            this.DelBut.Location = new System.Drawing.Point(114, 72);
            this.DelBut.Name = "DelBut";
            this.DelBut.Size = new System.Drawing.Size(87, 23);
            this.DelBut.TabIndex = 15;
            this.DelBut.Text = "Delete";
            this.DelBut.UseVisualStyleBackColor = true;
            this.DelBut.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 188);
            this.Controls.Add(this.DelBut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.InTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ParentTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Logs);
            this.Controls.Add(this.AddTextBox);
            this.Controls.Add(this.AddType2);
            this.Controls.Add(this.AddType1);
            this.Controls.Add(this.SaveBut);
            this.Controls.Add(this.OpenBut);
            this.Controls.Add(this.NewBut);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewBut;
        private System.Windows.Forms.Button OpenBut;
        private System.Windows.Forms.Button SaveBut;
        private System.Windows.Forms.Button AddType1;
        private System.Windows.Forms.Button AddType2;
        private System.Windows.Forms.TextBox AddTextBox;
        private System.Windows.Forms.TextBox Logs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ParentTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DelBut;
    }
}

