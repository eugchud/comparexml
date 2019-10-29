namespace CompareCFGs
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFile1Address = new System.Windows.Forms.TextBox();
            this.buttonFile1Open = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonFile1Read = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDebug1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.buttonDebug2 = new System.Windows.Forms.Button();
            this.buttonFile2Read = new System.Windows.Forms.Button();
            this.buttonFile2Open = new System.Windows.Forms.Button();
            this.textBoxFile2Address = new System.Windows.Forms.TextBox();
            this.buttonSearchWithAlg = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxFile1Address
            // 
            this.textBoxFile1Address.Location = new System.Drawing.Point(6, 20);
            this.textBoxFile1Address.Name = "textBoxFile1Address";
            this.textBoxFile1Address.Size = new System.Drawing.Size(364, 20);
            this.textBoxFile1Address.TabIndex = 0;
            // 
            // buttonFile1Open
            // 
            this.buttonFile1Open.Location = new System.Drawing.Point(226, 52);
            this.buttonFile1Open.Name = "buttonFile1Open";
            this.buttonFile1Open.Size = new System.Drawing.Size(144, 23);
            this.buttonFile1Open.TabIndex = 1;
            this.buttonFile1Open.Text = "Открыть";
            this.buttonFile1Open.UseVisualStyleBackColor = true;
            this.buttonFile1Open.Click += new System.EventHandler(this.buttonFile1Open_Click);
            // 
            // buttonFile1Read
            // 
            this.buttonFile1Read.Enabled = false;
            this.buttonFile1Read.Location = new System.Drawing.Point(226, 81);
            this.buttonFile1Read.Name = "buttonFile1Read";
            this.buttonFile1Read.Size = new System.Drawing.Size(144, 23);
            this.buttonFile1Read.TabIndex = 2;
            this.buttonFile1Read.Text = "Перезагрузить";
            this.buttonFile1Read.UseVisualStyleBackColor = true;
            this.buttonFile1Read.Click += new System.EventHandler(this.buttonFile1Read_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.buttonDebug1);
            this.groupBox1.Controls.Add(this.buttonFile1Read);
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Controls.Add(this.textBoxFile1Address);
            this.groupBox1.Controls.Add(this.buttonFile1Open);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 521);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл 1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 361);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(364, 150);
            this.dataGridView1.TabIndex = 9;
            // 
            // buttonDebug1
            // 
            this.buttonDebug1.Enabled = false;
            this.buttonDebug1.Location = new System.Drawing.Point(226, 300);
            this.buttonDebug1.Name = "buttonDebug1";
            this.buttonDebug1.Size = new System.Drawing.Size(144, 32);
            this.buttonDebug1.TabIndex = 8;
            this.buttonDebug1.Text = "Отладочная информация";
            this.buttonDebug1.UseVisualStyleBackColor = true;
            this.buttonDebug1.Click += new System.EventHandler(this.buttonDebug1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 52);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(214, 280);
            this.treeView1.TabIndex = 7;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.treeView2);
            this.groupBox2.Controls.Add(this.buttonDebug2);
            this.groupBox2.Controls.Add(this.buttonFile2Read);
            this.groupBox2.Controls.Add(this.buttonFile2Open);
            this.groupBox2.Controls.Add(this.textBoxFile2Address);
            this.groupBox2.Location = new System.Drawing.Point(394, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 521);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Файл 2";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 361);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(364, 150);
            this.dataGridView2.TabIndex = 11;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(6, 52);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(214, 280);
            this.treeView2.TabIndex = 10;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // buttonDebug2
            // 
            this.buttonDebug2.Enabled = false;
            this.buttonDebug2.Location = new System.Drawing.Point(226, 300);
            this.buttonDebug2.Name = "buttonDebug2";
            this.buttonDebug2.Size = new System.Drawing.Size(144, 32);
            this.buttonDebug2.TabIndex = 4;
            this.buttonDebug2.Text = "Отладочная информация";
            this.buttonDebug2.UseVisualStyleBackColor = true;
            this.buttonDebug2.Click += new System.EventHandler(this.buttonDebug2_Click);
            // 
            // buttonFile2Read
            // 
            this.buttonFile2Read.Enabled = false;
            this.buttonFile2Read.Location = new System.Drawing.Point(226, 81);
            this.buttonFile2Read.Name = "buttonFile2Read";
            this.buttonFile2Read.Size = new System.Drawing.Size(144, 23);
            this.buttonFile2Read.TabIndex = 2;
            this.buttonFile2Read.Text = "Перезагрузить";
            this.buttonFile2Read.UseVisualStyleBackColor = true;
            this.buttonFile2Read.Click += new System.EventHandler(this.buttonFile2Read_Click);
            // 
            // buttonFile2Open
            // 
            this.buttonFile2Open.Location = new System.Drawing.Point(226, 52);
            this.buttonFile2Open.Name = "buttonFile2Open";
            this.buttonFile2Open.Size = new System.Drawing.Size(144, 23);
            this.buttonFile2Open.TabIndex = 1;
            this.buttonFile2Open.Text = "Открыть";
            this.buttonFile2Open.UseVisualStyleBackColor = true;
            this.buttonFile2Open.Click += new System.EventHandler(this.buttonFile2Open_Click);
            // 
            // textBoxFile2Address
            // 
            this.textBoxFile2Address.Location = new System.Drawing.Point(6, 19);
            this.textBoxFile2Address.Name = "textBoxFile2Address";
            this.textBoxFile2Address.Size = new System.Drawing.Size(364, 20);
            this.textBoxFile2Address.TabIndex = 0;
            // 
            // buttonSearchWithAlg
            // 
            this.buttonSearchWithAlg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearchWithAlg.Location = new System.Drawing.Point(279, 554);
            this.buttonSearchWithAlg.Name = "buttonSearchWithAlg";
            this.buttonSearchWithAlg.Size = new System.Drawing.Size(226, 40);
            this.buttonSearchWithAlg.TabIndex = 8;
            this.buttonSearchWithAlg.Text = " Поиск различий";
            this.buttonSearchWithAlg.UseVisualStyleBackColor = true;
            this.buttonSearchWithAlg.Click += new System.EventHandler(this.buttonSearchWithAlg_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(265, 551);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 43);
            this.label1.TabIndex = 10;
            this.label1.Text = "Пожалуйста, подождите....";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 597);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSearchWithAlg);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(797, 636);
            this.MinimumSize = new System.Drawing.Size(797, 636);
            this.Name = "FormMain";
            this.Text = "Сравнение XML-файлов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFile1Address;
        private System.Windows.Forms.Button buttonFile1Open;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonFile1Read;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxFile2Address;
        private System.Windows.Forms.Button buttonFile2Open;
        private System.Windows.Forms.Button buttonFile2Read;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonSearchWithAlg;
        private System.Windows.Forms.Button buttonDebug1;
        private System.Windows.Forms.Button buttonDebug2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

