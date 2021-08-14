using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelsConsignment
{
    class Consignment
    {
        public int id;
        public string type;
        public string lastName;
        public string firstName;
        public string make;
        public string model;
        public string chamber;
        public int page;

        public Consignment(int id, string type, string lastName, string firstName, string make,
            string model, string chamber, int page)
        {
            this.id = id;
            this.type = type;
            this.lastName = lastName;
            this.firstName = firstName;
            this.make = make;
            this.model = model;
            this.chamber = chamber;
            this.page = page;
        }

        public Consignment()
        {

        }

    }   
}
