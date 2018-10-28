namespace Idemia.WindowApp
{
    partial class RequestManagerForm
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
            this.grdRequests = new System.Windows.Forms.DataGridView();
            this.btnGetData = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cbRequestType = new System.Windows.Forms.ComboBox();
            this.lblRequestType = new System.Windows.Forms.Label();
            this.refreshDataWorker = new System.ComponentModel.BackgroundWorker();
            this.btnNewRequest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRequests
            // 
            this.grdRequests.AllowUserToAddRows = false;
            this.grdRequests.AllowUserToDeleteRows = false;
            this.grdRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRequests.Location = new System.Drawing.Point(16, 55);
            this.grdRequests.Name = "grdRequests";
            this.grdRequests.ReadOnly = true;
            this.grdRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRequests.Size = new System.Drawing.Size(655, 261);
            this.grdRequests.TabIndex = 0;
            this.grdRequests.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdRequests_CellMouseDoubleClick);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(444, 4);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(115, 45);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.DisplayMember = "Name";
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(12, 28);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 2;
            this.cbStatus.ValueMember = "Id";
            // 
            // cbCustomer
            // 
            this.cbCustomer.DisplayMember = "Name";
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(139, 28);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(109, 21);
            this.cbCustomer.TabIndex = 3;
            this.cbCustomer.ValueMember = "Id";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(136, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 5;
            this.lblCustomer.Text = "Customer";
            // 
            // cbRequestType
            // 
            this.cbRequestType.DisplayMember = "Name";
            this.cbRequestType.FormattingEnabled = true;
            this.cbRequestType.Location = new System.Drawing.Point(256, 28);
            this.cbRequestType.Name = "cbRequestType";
            this.cbRequestType.Size = new System.Drawing.Size(182, 21);
            this.cbRequestType.TabIndex = 6;
            this.cbRequestType.ValueMember = "Id";
            // 
            // lblRequestType
            // 
            this.lblRequestType.AutoSize = true;
            this.lblRequestType.Location = new System.Drawing.Point(253, 9);
            this.lblRequestType.Name = "lblRequestType";
            this.lblRequestType.Size = new System.Drawing.Size(74, 13);
            this.lblRequestType.TabIndex = 7;
            this.lblRequestType.Text = "Request Type";
            // 
            // refreshDataWorker
            // 
            this.refreshDataWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.refreshDataWorker_DoWork);
            this.refreshDataWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.refreshDataWorker_ProgressChanged);
            this.refreshDataWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.refreshDataWorker_RunWorkerCompleted);
            // 
            // btnNewRequest
            // 
            this.btnNewRequest.Location = new System.Drawing.Point(565, 4);
            this.btnNewRequest.Name = "btnNewRequest";
            this.btnNewRequest.Size = new System.Drawing.Size(90, 45);
            this.btnNewRequest.TabIndex = 9;
            this.btnNewRequest.Text = "New Request";
            this.btnNewRequest.UseVisualStyleBackColor = true;
            this.btnNewRequest.Click += new System.EventHandler(this.btnNewRequest_Click);
            // 
            // RequestManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 302);
            this.Controls.Add(this.btnNewRequest);
            this.Controls.Add(this.lblRequestType);
            this.Controls.Add(this.cbRequestType);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.grdRequests);
            this.Name = "RequestManagerForm";
            this.Text = "RequestManagerForm";
            ((System.ComponentModel.ISupportInitialize)(this.grdRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdRequests;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cbRequestType;
        private System.Windows.Forms.Label lblRequestType;
        private System.ComponentModel.BackgroundWorker refreshDataWorker;
        private System.Windows.Forms.Button btnNewRequest;
    }
}