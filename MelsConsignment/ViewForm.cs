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
    public partial class ViewForm : Form
    {
        private string id;

        public void SetId(string id)
        {
            this.id = id;
        }

        private string GetId()
        {
            return this.id;
        }

        public ViewForm()
        {
            InitializeComponent();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
        }
    }
}
