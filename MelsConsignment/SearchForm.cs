using MongoDB.Bson;
using MongoDB.Driver;
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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            //Establish connection and create collection
            MongoClient dbClient = new MongoClient("mongodb+srv://Mels105:MTP1946@cluster0.acccf.mongodb.net/test");
            var database = dbClient.GetDatabase("MelsTradingPost");
            var collection = database.GetCollection<BsonDocument>("Consignment");

            //Construct filter
            string lastName = LastNameTB.Text;
            var filter = Builders<BsonDocument>.Filter.Eq("last_name", lastName);



            var consignmentDocument = collection.Find(filter).FirstOrDefault();

            if(consignmentDocument != null)
            {
                lastName = consignmentDocument.GetValue("last_name").ToString();

                LastNameLBL.Text = lastName;
            }


        }
    }
}
