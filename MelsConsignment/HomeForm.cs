using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MelsConsignment
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }
        
        private void CreateBTN_Click(object sender, EventArgs e)
        {

            EnterForm frm = new EnterForm();
            frm.Show();

        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm();
            frm.Show();
        }
    }
}
