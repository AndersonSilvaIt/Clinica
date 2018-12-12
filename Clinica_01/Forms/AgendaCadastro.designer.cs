namespace Clinica_01.Forms
{
    partial class AgendaCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgendaCadastro));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ddlTipo = new System.Windows.Forms.ComboBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTipo = new System.Windows.Forms.Button();
            this.btnPaciente = new System.Windows.Forms.Button();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlSituacao = new System.Windows.Forms.ComboBox();
            this.txtHora = new System.Windows.Forms.MaskedTextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(23, 81);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data";
            // 
            // txtPaciente
            // 
            this.txtPaciente.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.txtPaciente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPaciente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPaciente.CausesValidation = false;
            this.txtPaciente.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaciente.Location = new System.Drawing.Point(23, 33);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ShortcutsEnabled = false;
            this.txtPaciente.Size = new System.Drawing.Size(333, 22);
            this.txtPaciente.TabIndex = 1;
            this.txtPaciente.WordWrap = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Paciente";
            // 
            // btnAgendar
            // 
            this.btnAgendar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgendar.BackgroundImage")));
            this.btnAgendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgendar.Location = new System.Drawing.Point(23, 322);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(50, 50);
            this.btnAgendar.TabIndex = 8;
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(237, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Valor R$";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label10.Location = new System.Drawing.Point(253, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = "Serviço";
            // 
            // ddlTipo
            // 
            this.ddlTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ddlTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTipo.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.ddlTipo.FormattingEnabled = true;
            this.ddlTipo.Location = new System.Drawing.Point(256, 83);
            this.ddlTipo.Name = "ddlTipo";
            this.ddlTipo.Size = new System.Drawing.Size(100, 23);
            this.ddlTipo.TabIndex = 4;
            // 
            // txtObs
            // 
            this.txtObs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtObs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtObs.CausesValidation = false;
            this.txtObs.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObs.Location = new System.Drawing.Point(23, 138);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.ShortcutsEnabled = false;
            this.txtObs.Size = new System.Drawing.Size(333, 109);
            this.txtObs.TabIndex = 5;
            this.txtObs.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Observações";
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(133, 322);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 50);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Location = new System.Drawing.Point(189, 322);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(50, 50);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtValor
            // 
            this.txtValor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtValor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtValor.CausesValidation = false;
            this.txtValor.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(240, 281);
            this.txtValor.Name = "txtValor";
            this.txtValor.ShortcutsEnabled = false;
            this.txtValor.Size = new System.Drawing.Size(116, 22);
            this.txtValor.TabIndex = 7;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(185, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "Hrs";
            // 
            // btnTipo
            // 
            this.btnTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTipo.Location = new System.Drawing.Point(362, 83);
            this.btnTipo.Name = "btnTipo";
            this.btnTipo.Size = new System.Drawing.Size(30, 23);
            this.btnTipo.TabIndex = 31;
            this.btnTipo.Text = "+";
            this.btnTipo.UseVisualStyleBackColor = true;
            this.btnTipo.Click += new System.EventHandler(this.btnTipo_Click);
            // 
            // btnPaciente
            // 
            this.btnPaciente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaciente.Location = new System.Drawing.Point(362, 33);
            this.btnPaciente.Name = "btnPaciente";
            this.btnPaciente.Size = new System.Drawing.Size(30, 23);
            this.btnPaciente.TabIndex = 40;
            this.btnPaciente.Text = "+";
            this.btnPaciente.UseVisualStyleBackColor = true;
            this.btnPaciente.Click += new System.EventHandler(this.btnPaciente_Click);
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveUpdate.BackgroundImage")));
            this.btnSaveUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveUpdate.Location = new System.Drawing.Point(79, 322);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(50, 50);
            this.btnSaveUpdate.TabIndex = 9;
            this.btnSaveUpdate.UseVisualStyleBackColor = true;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label5.Location = new System.Drawing.Point(20, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 35;
            this.label5.Text = "Situação";
            // 
            // ddlSituacao
            // 
            this.ddlSituacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ddlSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSituacao.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.ddlSituacao.FormattingEnabled = true;
            this.ddlSituacao.Items.AddRange(new object[] {
            "",
            "Agendado",
            "Remarcou",
            "Cancelou",
            "Não Compareceu",
            "OK"});
            this.ddlSituacao.Location = new System.Drawing.Point(23, 280);
            this.ddlSituacao.Name = "ddlSituacao";
            this.ddlSituacao.Size = new System.Drawing.Size(126, 23);
            this.ddlSituacao.TabIndex = 6;
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(142, 81);
            this.txtHora.Mask = "90:00";
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(41, 20);
            this.txtHora.TabIndex = 3;
            this.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHora.ValidatingType = typeof(System.DateTime);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Location = new System.Drawing.Point(306, 325);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(50, 50);
            this.btnPrint.TabIndex = 41;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // AgendaCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(404, 387);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ddlSituacao);
            this.Controls.Add(this.btnSaveUpdate);
            this.Controls.Add(this.btnPaciente);
            this.Controls.Add(this.btnTipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ddlTipo);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgendar);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtHora);
            this.Name = "AgendaCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBR Sistemas - Clínica";
            this.Load += new System.EventHandler(this.AgendaCadastro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ddlTipo;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTipo;
        private System.Windows.Forms.Button btnPaciente;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlSituacao;
        private System.Windows.Forms.MaskedTextBox txtHora;
        private System.Windows.Forms.Button btnPrint;
    }
}