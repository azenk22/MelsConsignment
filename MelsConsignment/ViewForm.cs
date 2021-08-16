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
    public partial class ViewForm : Form
    {
        private ObjectId id;

        public void SetId(ObjectId id)
        {
            this.id = id;
        }

        private ObjectId GetId()
        {
            return this.id;
        }

        public ViewForm()
        {
            InitializeComponent();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {

            MongoClient dbClient = new MongoClient("mongodb+srv://Mels105:MTP1946@cluster0.acccf.mongodb.net/test");
            var database = dbClient.GetDatabase("MelsTradingPost");
            var collection = database.GetCollection<BsonDocument>("Consignment");
            ObjectId id = GetId();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var document = collection.Find(filter).FirstOrDefault();

            PopulateBoxes(document);

            //var update = Builders<BsonDocument>.Update.Set("last_name", "TEST");
            //collection.UpdateOne(filter, update);

        }

        private void PopulateBoxes(BsonDocument document)
        {
            LastNameTB.Text = document.GetValue("last_name").ToString();
            FirstNameTB.Text = document.GetValue("first_name").ToString();
            TypeCMB.Text = document.GetValue("type").ToString();
            ManfTB.Text = document.GetValue("manufacturer").ToString();
            ModelTB.Text = document.GetValue("model").ToString();
            CalTB.Text = document.GetValue("chambering").ToString();
            PageTB.Text = document.GetValue("page").ToString();
            ShelfTB.Text = document.GetValue("shelf").ToString();
            TakeTB.Text = document.GetValue("take").ToString();
        }

        private void UpdateBTN_Click(object sender, EventArgs e)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://Mels105:MTP1946@cluster0.acccf.mongodb.net/test");
            var database = dbClient.GetDatabase("MelsTradingPost");
            var collection = database.GetCollection<BsonDocument>("Consignment");
            ObjectId id = GetId();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("last_name", LastNameTB.Text).Set("first_name", FirstNameTB.Text)
                .Set("type", TypeCMB.Text).Set("manufacturer", ManfTB.Text).Set("model", ModelTB.Text).Set("chambering", CalTB.Text)
                .Set("page", PageTB.Text).Set("shelf", ShelfTB.Text).Set("take", TakeTB.Text);
            collection.UpdateOne(filter, update);
        }
    }
}
