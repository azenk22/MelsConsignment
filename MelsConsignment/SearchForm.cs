﻿using MongoDB.Bson;
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

            //Best place to have this code?
            //Establish connection and create collection
            MongoClient dbClient = new MongoClient("mongodb+srv://Mels105:MTP1946@cluster0.acccf.mongodb.net/test");
            var database = dbClient.GetDatabase("MelsTradingPost");
            var collection = database.GetCollection<BsonDocument>("Consignment");

            //Construct filter
            string lastName = LastNameTB.Text;
            string firstName = FirstNameTB.Text;

            var filter = Builders<BsonDocument>.Filter.Eq("last_name", lastName);
            var filter1 = Builders<BsonDocument>.Filter.Eq("first_name", firstName);


            var consignmentDocument = collection.Find(filter & filter1).ToList();
            

            if(consignmentDocument != null)
            {
                int rowIndex = 0;

                foreach(BsonDocument doc in consignmentDocument)
                {
                    Console.WriteLine(doc.GetValue("model").ToString());
                    GunsDGV.Rows.Add(doc.GetValue("manufacturer").ToString(), doc.GetValue("model").ToString());
                    rowIndex++;
                }
                
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


    }
}
