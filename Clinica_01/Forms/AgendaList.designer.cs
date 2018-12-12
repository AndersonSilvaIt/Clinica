namespace Clinica_01.Forms
{
    partial class AgendaList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgendaList));
            this.grdAgenda = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataToString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataNascimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorasToString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FoneResidencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ddlSituacao = new System.Windows.Forms.ComboBox();
            this.txtHoraFim = new System.Windows.Forms.MaskedTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ddlTipo = new System.Windows.Forms.ComboBox();
            this.txtHoraInicial = new System.Windows.Forms.MaskedTextBox();
            this.txtDataFim = new System.Windows.Forms.MaskedTextBox();
            this.txtDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresg = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status01 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status02 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenda)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdAgenda
            // 
            this.grdAgenda.AllowUserToAddRows = false;
            this.grdAgenda.AllowUserToDeleteRows = false;
            this.grdAgenda.AllowUserToResizeColumns = false;
            this.grdAgenda.AllowUserToResizeRows = false;
            this.grdAgenda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdAgenda.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAgenda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdAgenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nome,
            this.CPF,
            this.DataToString,
            this.RG,
            this.DataNascimento,
            this.HorasToString,
            this.FoneResidencial,
            this.Celular,
            this.Email,
            this.Situacao});
            this.grdAgenda.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAgenda.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdAgenda.Location = new System.Drawing.Point(12, 228);
            this.grdAgenda.MultiSelect = false;
            this.grdAgenda.Name = "grdAgenda";
            this.grdAgenda.ReadOnly = true;
            this.grdAgenda.RowHeadersVisible = false;
            this.grdAgenda.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdAgenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAgenda.ShowCellErrors = false;
            this.grdAgenda.ShowCellToolTips = false;
            this.grdAgenda.ShowEditingIcon = false;
            this.grdAgenda.ShowRowErrors = false;
            this.grdAgenda.Size = new System.Drawing.Size(666, 257);
            this.grdAgenda.TabIndex = 6;
            this.grdAgenda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAgenda_CellDoubleClick);
            this.grdAgenda.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdAgenda_ColumnHeaderMouseClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.FillWeight = 80F;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "IdPaciente";
            this.Nome.FillWeight = 306F;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Visible = false;
            // 
            // CPF
            // 
            this.CPF.DataPropertyName = "PacienteNome";
            this.CPF.FillWeight = 211.446F;
            this.CPF.HeaderText = "Paciente";
            this.CPF.Name = "CPF";
            this.CPF.ReadOnly = true;
            // 
            // DataToString
            // 
            this.DataToString.DataPropertyName = "DataToString";
            this.DataToString.FillWeight = 66.09406F;
            this.DataToString.HeaderText = "Data";
            this.DataToString.Name = "DataToString";
            this.DataToString.ReadOnly = true;
            // 
            // RG
            // 
            this.RG.DataPropertyName = "Data";
            this.RG.FillWeight = 70F;
            this.RG.HeaderText = "Data";
            this.RG.Name = "RG";
            this.RG.ReadOnly = true;
            this.RG.Visible = false;
            // 
            // DataNascimento
            // 
            this.DataNascimento.DataPropertyName = "Horas";
            this.DataNascimento.HeaderText = "Horas";
            this.DataNascimento.Name = "DataNascimento";
            this.DataNascimento.ReadOnly = true;
            // 
            // HorasToString
            // 
            this.HorasToString.DataPropertyName = "HorasToString";
            this.HorasToString.FillWeight = 27.64001F;
            this.HorasToString.HeaderText = "Horas";
            this.HorasToString.Name = "HorasToString";
            this.HorasToString.ReadOnly = true;
            this.HorasToString.Visible = false;
            // 
            // FoneResidencial
            // 
            this.FoneResidencial.DataPropertyName = "Tipo";
            this.FoneResidencial.FillWeight = 103.65F;
            this.FoneResidencial.HeaderText = "Tipo";
            this.FoneResidencial.Name = "FoneResidencial";
            this.FoneResidencial.ReadOnly = true;
            // 
            // Celular
            // 
            this.Celular.DataPropertyName = "Observacao";
            this.Celular.HeaderText = "Celular";
            this.Celular.Name = "Celular";
            this.Celular.ReadOnly = true;
            this.Celular.Visible = false;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Valor";
            this.Email.FillWeight = 200F;
            this.Email.HeaderText = "Valor";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Visible = false;
            // 
            // Situacao
            // 
            this.Situacao.DataPropertyName = "Situation";
            this.Situacao.FillWeight = 104.1605F;
            this.Situacao.HeaderText = "Situação";
            this.Situacao.Name = "Situacao";
            this.Situacao.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.ddlSituacao);
            this.groupBox1.Controls.Add(this.txtHoraFim);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.ddlTipo);
            this.groupBox1.Controls.Add(this.txtHoraInicial);
            this.groupBox1.Controls.Add(this.txtDataFim);
            this.groupBox1.Controls.Add(this.txtDataInicial);
            this.groupBox1.Controls.Add(this.txtPaciente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 178);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar Dados";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label5.Location = new System.Drawing.Point(186, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 37;
            this.label5.Text = "Situação";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.label10.Location = new System.Drawing.Point(186, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 27;
            this.label10.Text = "Serviço";
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
            this.ddlSituacao.Location = new System.Drawing.Point(189, 146);
            this.ddlSituacao.Name = "ddlSituacao";
            this.ddlSituacao.Size = new System.Drawing.Size(126, 23);
            this.ddlSituacao.TabIndex = 36;
            // 
            // txtHoraFim
            // 
            this.txtHoraFim.Location = new System.Drawing.Point(78, 147);
            this.txtHoraFim.Mask = "90:00";
            this.txtHoraFim.Name = "txtHoraFim";
            this.txtHoraFim.Size = new System.Drawing.Size(41, 22);
            this.txtHoraFim.TabIndex = 5;
            this.txtHoraFim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHoraFim.ValidatingType = typeof(System.DateTime);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(334, 139);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ddlTipo
            // 
            this.ddlTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ddlTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTipo.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.ddlTipo.FormattingEnabled = true;
            this.ddlTipo.Location = new System.Drawing.Point(189, 95);
            this.ddlTipo.Name = "ddlTipo";
            this.ddlTipo.Size = new System.Drawing.Size(100, 23);
            this.ddlTipo.TabIndex = 26;
            // 
            // txtHoraInicial
            // 
            this.txtHoraInicial.Location = new System.Drawing.Point(19, 147);
            this.txtHoraInicial.Mask = "90:00";
            this.txtHoraInicial.Name = "txtHoraInicial";
            this.txtHoraInicial.Size = new System.Drawing.Size(41, 22);
            this.txtHoraInicial.TabIndex = 4;
            this.txtHoraInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHoraInicial.ValidatingType = typeof(System.DateTime);
            // 
            // txtDataFim
            // 
            this.txtDataFim.Location = new System.Drawing.Point(97, 95);
            this.txtDataFim.Mask = "00/00/0000";
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(61, 22);
            this.txtDataFim.TabIndex = 3;
            this.txtDataFim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataFim.ValidatingType = typeof(System.DateTime);
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.Location = new System.Drawing.Point(19, 95);
            this.txtDataInicial.Mask = "00/00/0000";
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(61, 22);
            this.txtDataInicial.TabIndex = 2;
            this.txtDataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataInicial.ValidatingType = typeof(System.DateTime);
            // 
            // txtPaciente
            // 
            this.txtPaciente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPaciente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPaciente.CausesValidation = false;
            this.txtPaciente.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaciente.Location = new System.Drawing.Point(19, 43);
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
            this.label7.Location = new System.Drawing.Point(16, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Paciente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Até";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hora";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(94, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Até";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNew.BackgroundImage")));
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Location = new System.Drawing.Point(388, 192);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(30, 30);
            this.btnNew.TabIndex = 7;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnRefresg
            // 
            this.btnRefresg.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresg.BackgroundImage")));
            this.btnRefresg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresg.Location = new System.Drawing.Point(388, 19);
            this.btnRefresg.Name = "btnRefresg";
            this.btnRefresg.Size = new System.Drawing.Size(30, 30);
            this.btnRefresg.TabIndex = 8;
            this.btnRefresg.UseVisualStyleBackColor = false;
            this.btnRefresg.Click += new System.EventHandler(this.btnRefresg_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Algerian", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label3.Location = new System.Drawing.Point(477, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 32);
            this.label3.TabIndex = 21;
            this.label3.Text = "Agenda";
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.ForeColor = System.Drawing.Color.Black;
            this.lblResults.Location = new System.Drawing.Point(16, 203);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(54, 19);
            this.lblResults.TabIndex = 22;
            this.lblResults.Text = "results";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status01,
            this.status02});
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(690, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status01
            // 
            this.status01.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status01.Name = "status01";
            this.status01.Size = new System.Drawing.Size(221, 17);
            this.status01.Text = "DBR Sistemas - Clinica Compania do Corpo";
            // 
            // status02
            // 
            this.status02.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status02.Name = "status02";
            this.status02.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.status02.Size = new System.Drawing.Size(36, 17);
            this.status02.Text = "Horas";
            this.status02.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Location = new System.Drawing.Point(648, 192);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(30, 30);
            this.btnPrint.TabIndex = 24;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // AgendaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(690, 541);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRefresg);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdAgenda);
            this.Name = "AgendaList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBR Sistemas - Clínica";
            this.Load += new System.EventHandler(this.AgendaList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenda)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAgenda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MaskedTextBox txtDataInicial;
        private System.Windows.Forms.MaskedTextBox txtDataFim;
        private System.Windows.Forms.MaskedTextBox txtHoraFim;
        private System.Windows.Forms.MaskedTextBox txtHoraInicial;
        private System.Windows.Forms.Button btnRefresg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status01;
        private System.Windows.Forms.ToolStripStatusLabel status02;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ddlTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlSituacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataToString;
        private System.Windows.Forms.DataGridViewTextBoxColumn RG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataNascimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorasToString;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoneResidencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Situacao;
    }
}