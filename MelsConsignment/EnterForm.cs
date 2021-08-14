using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;


namespace MelsConsignment
{
    public partial class EnterForm : Form
    {

      

        public EnterForm()
        {
            InitializeComponent();
        }



        private void SaveBTN_Click(object sender, EventArgs e)
        {

            MongoClient dbClient = new MongoClient("mongodb+srv://Mels105:MTP1946@cluster0.acccf.mongodb.net/test");

            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("List of databases on the server");

            foreach(var db in dbList)
            {
                Console.WriteLine(db);
            }

            var database = dbClient.GetDatabase("MelsTradingPost");
            var collection = database.GetCollection<BsonDocument>("Consignment");

            var document = new BsonDocument
            {
                {"last_name", LastNameTB.Text },
                {"first_name", FirstNameTB.Text},
                {"type", TypeCMB.Text },
                {"manufacturer", ManfTB.Text },
                {"model", ModelTB.Text },
                {"chambering", CalTB.Text },
                {"page", PageTB.Text },
                {"shelf", ShelfTB.Text },
                {"take", TakeTB.Text }
            };

            collection.InsertOne(document);

        }

        private void EnterForm_Load(object sender, EventArgs e)
        {

        }

        private void TypeCMB_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(TypeCMB.Text == "Shotgun")
            {
                TypeLBL.Text = "Gauge";
            }
            else
            {
                TypeLBL.Text = "Caliber";
            }

        }

        private void ShelfTB_Leave(object sender, EventArgs e)
        {
            double percentage = .85;
            double take = 0;
            double salePrice = Double.Parse(ShelfTB.Text);

            take = salePrice * percentage;

            //round up
            take = Math.Round(take, 2);

            TakeTB.Text = take.ToString();

        }
    }
}
