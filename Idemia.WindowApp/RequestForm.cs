using Idemia.Common.Entities;
using Idemia.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Idemia.WindowApp
{
    public partial class RequestForm : Form
    {
        #region Properties
        public List<Customer> Customers { get; set; }
        public List<RequestType> RequestTypes { get; set; }
        public List<RequestStatus> Statuses { get; set; }
        public int Id { get; set; }
        public Request CurrentRequest { get; set; } 
        #endregion

        #region Constructors
        public RequestForm()
        {
            InitializeComponent();
        }
        public RequestForm(List<Customer> customers, List<RequestStatus> statuses, List<RequestType> types, int? Id)
        {
            InitializeComponent();
            Customers = customers;
            RequestTypes = types;
            Statuses = statuses;
            BindControls(Id);
        }
        
        #endregion

        #region Helper Methods
        private void BindControls(int? id)
        {
            cbCustomer.DisplayMember = cbRequestType.DisplayMember = cbStatus.DisplayMember = "Name";
            cbCustomer.ValueMember = cbRequestType.ValueMember = cbStatus.ValueMember = "Id";
            cbCustomer.DataSource = Customers;
            cbRequestType.DataSource = RequestTypes;
            cbStatus.DataSource = Statuses;
            if (id.HasValue)
            {
                CurrentRequest = new RequestDao().GetRequests(Id: id.Value).First();
                cbCustomer.SelectedValue = CurrentRequest.CustomerId;
                cbRequestType.SelectedValue = CurrentRequest.RequestTypeId;
                cbStatus.SelectedValue = CurrentRequest.StatusId;
                txtOrder.Text = CurrentRequest.Order.ToString();
                cbPriority.SelectedValue = CurrentRequest.Priority;
                this.Id = id.Value;
                cbCustomer.Enabled = cbRequestType.Enabled = cbStatus.Enabled = false;
                btnSave.Visible = CurrentRequest.StatusId == 2;
                btnPause.Visible = CurrentRequest.StatusId > 4 && CurrentRequest.StatusId <8;//Wrong  validaion i know.
            }
            else
            {
                btnPause.Visible = false;
                cbStatus.SelectedIndex = 1;
                cbStatus.Enabled = false;
            }

        }
        
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOrder.Text == "")
            {
                MessageBox.Show("Enter a valid order!");
                return;
            }
            if (Id == 0)//new
            {
                CurrentRequest = new Request();
                CurrentRequest.CustomerId = int.Parse(cbCustomer.SelectedValue.ToString());
                CurrentRequest.StatusId = int.Parse(cbStatus.SelectedValue.ToString());
                CurrentRequest.RequestTypeId = int.Parse(cbRequestType.SelectedValue.ToString());
                CurrentRequest.CustomerId = int.Parse(cbCustomer.SelectedValue.ToString());
                CurrentRequest.Created = DateTime.Now;
                CurrentRequest.CreatedBy = 6;//hard coded 
                CurrentRequest.Modified = DateTime.Now;
                CurrentRequest.ModifiedBy = 6;//manager hadcoded
                CurrentRequest.Order = int.Parse(txtOrder.Text == "" ? "100" : txtOrder.Text);
                CurrentRequest.Priority = cbPriority.SelectedText;
                new RequestDao().SaveRequest(CurrentRequest);
            }
            else
            {
                CurrentRequest.Modified = DateTime.Now;
                CurrentRequest.ModifiedBy = 6;//manager hadcoded
                CurrentRequest.Order = int.Parse(txtOrder.Text == "" ? "100" : txtOrder.Text);
                CurrentRequest.Priority = cbPriority.SelectedText;
                new RequestDao().SaveRequest(CurrentRequest);

            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            CurrentRequest.StatusId = (int)RequestStatusType.Paused;
            new RequestDao().SaveRequest(CurrentRequest);
            this.Close();
        }

        /// <summary>
        /// Allow only numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrder_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtOrder.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtOrder.Text = txtOrder.Text.Remove(txtOrder.Text.Length - 1);
            }
        } 
        #endregion
    }
}
