using BellInterviewClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BellInterviewClient
{
    public partial class Form1 : Form
    {
        private RestClientService restService;
        public Form1()
        {
            InitializeComponent();
            restService = new RestClientService();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            var client = new Client() 
            {
                firstName = tb_FN.Text,
                lastName = tb_LN.Text,
                DOB = dtp_DOB.Value,
                address = tb_Address.Text,
                email = tb_Email.Text,
                phone = tb_Phone.Text
        };

            var status = restService.CreateClientAsync(client).Result;
            if (status)
            {
                MessageBox.Show("Success!");
            }
            else
            {
                MessageBox.Show("Failure");
            }
        }
        private void btn_Show_Click(object sender, EventArgs e)
        {

        }
    }
}
