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
    
    public partial class RequestManagerForm : Form
    {
        public List<Customer> Customers { get; set; }
        public List<RequestType> RequestTypes { get; set; }
        public List<RequestStatus> Statuses { get; set; }

        public RequestManagerForm()
        {
            
            InitializeComponent();
            btnGetData.Visible = false;
            LoadData();
            btnGetData.Visible = true;
        }


 

 

        #region Helper Methods
        /// <summary>
        /// Get the lookups for the combo boxes
        /// one form of multi threading is loanching the tasks in parallel
        /// </summary>
        private void LoadData()
        {
            Parallel.Invoke(() => BindCustomers(), () => BindRequestTypes(), () => BindRequestStatus());
        }


        public List<Request> LoadRequests(FormData form)
        {
            int? customerId = form.CustomerId;
            int? requestType = form.RequestTypeId;
            int? statusId = form.StatusId ;
            List<Request> requests = new RequestDao().GetRequests(null, customerId, statusId, 1, 100);
            form.Requests = requests;
            return requests;
        }

        public void BindCustomers()
        {
            List<Customer> customers = new CustomerDao().GetCustomers(null, null, 1, 1000);
            this.Customers = customers;
            cbCustomer.DataSource = customers;
        }

        public void BindRequestTypes()
        {
            List<RequestType> types = new RequestDao().GetRequestTypes(null, null, 1, 1000);
            this.RequestTypes = types;
            cbRequestType.DataSource = types;
        }

        public void BindRequestStatus()
        {
            List<RequestStatus> statuses = new RequestDao().GetRequestStatuses(null, null, 1, 1000);
            this.Statuses = statuses;
            cbStatus.DataSource = statuses;
        }

        private static void GenerateData()
        {
            for (int i = 0; i < 1000; i++)
            {
                Request request = new Request() { CustomerId = 1, Modified = DateTime.Now, Created = DateTime.Now, CreatedBy = 1, Order = i, Priority = "High", RequestDetails = " Details " + i, ModifiedBy = 3, RequestTypeId = 1, StatusId = 1 };
                new RequestDao().SaveRequest(request);

            }
            List<Request> requests = new RequestDao().GetRequests(null, null, null, 1, 1000);
            Console.WriteLine("Number of requests:" + (requests != null ? requests.Count : 0));
            Console.ReadLine();
        }
        #endregion

        /// <summary>
        /// retrieves the list of requests/
        /// uses a background process 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetData_Click(object sender, EventArgs e)
        {
            FormData obj = new FormData();
            obj.CustomerId = int.Parse(cbCustomer.SelectedValue.ToString());
            obj.StatusId = int.Parse(cbStatus.SelectedValue.ToString());
            obj.RequestTypeId = int.Parse(cbRequestType.SelectedValue.ToString());


            if (!refreshDataWorker.IsBusy)
            {
                refreshDataWorker.RunWorkerAsync(obj);
                btnGetData.Enabled = false;
                btnNewRequest.Visible = false;
                btnGetData.Text = "Loading...";
            }
        }

        private void refreshDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FormData obj = (FormData)e.Argument;
            e.Result = LoadRequests(obj);
        }

        private void refreshDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            grdRequests.DataSource = (List<Request>) e.Result;
            grdRequests.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            grdRequests.Columns.Remove("RequestTypeId");
            grdRequests.Columns.Remove("StatusId");
            grdRequests.Columns.Remove("CustomerId");
            grdRequests.Columns.Remove("CreatedBy");
            grdRequests.Columns.Remove("ModifiedBy");
            grdRequests.Columns.Remove("RequestDetails");
            grdRequests.Columns.Remove("Address");
            grdRequests.Columns.Remove("Email");

            btnNewRequest.Visible = true ;
            btnGetData.Text = "Get Data";
            btnGetData.Enabled = true;
        }

        private void refreshDataWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!refreshDataWorker.CancellationPending)
            {
                FormData obj = (FormData)e.UserState;
            }
        }

        private void grdRequests_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show(grdRequests.CurrentRow.Cells[0].Value.ToString());
            int Id = int.Parse(grdRequests.CurrentRow.Cells[0].Value.ToString());
            RequestForm form = new RequestForm( this.Customers, this.Statuses, this.RequestTypes, Id);
            form.ShowDialog();

            
        }

        private void btnNewRequest_Click(object sender, EventArgs e)
        {
            RequestForm form = new RequestForm(this.Customers, this.Statuses, this.RequestTypes, null);
            form.ShowDialog();
        }
    }
    public class FormData
    {
        public List<Request> Requests { get; set; }
        public int Progress { get; set; }
        public int? StatusId { get; set; }
        public int? RequestTypeId { get; set; }
        public int? CustomerId { get; set; }

    }
}
