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
            Cursor.Current = Cursors.WaitCursor;

            GunsDGV.Rows.Clear();

            //Best place to have this code?
            //Establish connection and create collection
            MongoClient dbClient = new MongoClient("mongodb+srv://Mels105:MTP1946@cluster0.acccf.mongodb.net/test");
            var database = dbClient.GetDatabase("MelsTradingPost");
            var collection = database.GetCollection<BsonDocument>("Consignment");

            //Construct filter
            string lastName = LastNameTB.Text.ToUpper();
            string firstName = FirstNameTB.Text.ToUpper();

            var filter = Builders<BsonDocument>.Filter.Eq("last_name", lastName);
            var filter1 = Builders<BsonDocument>.Filter.Eq("first_name", firstName);
           
            List<BsonDocument> consignmentDocument = collection.Find(filter).ToList();

            List<FilterDefinition<BsonDocument>> filters = new List<FilterDefinition<BsonDocument>>();

            

            if(consignmentDocument != null)
            {

                List<BsonDocument> docs = new List<BsonDocument>();


                consignmentDocument = Filter(consignmentDocument);

                foreach(BsonDocument doc in consignmentDocument)
                {
                    GunsDGV.Rows.Add(doc.GetValue("_id"), doc.GetValue("type").ToString(), doc.GetValue("manufacturer").ToString(), doc.GetValue("model").ToString()
                            , doc.GetValue("chambering").ToString(), doc.GetValue("shelf").ToString(), doc.GetValue("take").ToString(), doc.GetValue("page").ToString());
                }

                //foreach(BsonDocument doc in consignmentDocument)
                //{


                //    //ObjectId id = doc.GetValue("_id").AsObjectId;
                //    //Console.WriteLine(doc.GetValue("model").ToString());
                //    //GunsDGV.Rows.Add(doc.GetValue("_id"), doc.GetValue("type").ToString(),doc.GetValue("manufacturer").ToString(), doc.GetValue("model").ToString()
                //    //    , doc.GetValue("chambering").ToString(), doc.GetValue("shelf").ToString(), doc.GetValue("take").ToString(), doc.GetValue("page").ToString());
                //}

                //Below code would be used when finding the first matching record.
                //lastName = consignmentDocument.GetValue("last_name").ToString();
                //string firstName = consignmentDocument.GetValue("first_name").ToString();

                //LastTB.Text = lastName;
                //FirstTB.Text = firstName;
                //TypeTB.Text = consignmentDocument.GetValue("type").ToString();
                //ManfTB.Text = consignmentDocument.GetValue("manufacturer").ToString();
                //ModelTB.Text = consignmentDocument.GetValue("model").ToString();
                //CalTB.Text = consignmentDocument.GetValue("chambering").ToString();
                //PageTB.Text = consignmentDocument.GetValue("page").ToString();
            }

            Cursor.Current = Cursors.WaitCursor;

        }

        
        private List<BsonDocument> Filter(List<BsonDocument> list)
        {
            bool add = true;
            List<BsonDocument> returnList = new List<BsonDocument>();

            foreach (BsonDocument doc in list)
            {

                add = true;

                if (FirstNameTB.Text != "" && doc.GetValue("first_name").ToString() != FirstNameTB.Text.ToUpper())
                {
                    add = false;
                }

                if(TypeCMB.Text != "" && doc.GetValue("type").ToString() != TypeCMB.Text.ToUpper())
                {
                    add = false;
                }

                if (add)
                {
                    returnList.Add(doc);
                }
            }



            return returnList;

        }
        private void GunsDGV_DoubleClick(object sender, EventArgs e)
        {
            ViewForm frm = new ViewForm();
            string idStr = GunsDGV.SelectedRows[0].Cells[0].Value.ToString();
            ObjectId id = ObjectId.Parse(idStr);
            frm.SetId(id);
            frm.Show();
        }

        private void GunsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
