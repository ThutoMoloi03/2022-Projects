using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelProject1
{
    public class Person
    {

        #region data members
        private string Id, name, Phone;
        #endregion

        #region Properties
        public string ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Telephone
        {
            get { return Phone; }
            set { Phone = value; }
        }
        #endregion

        #region Construtor
        public Person()
        {
            Id = "";
            name = "";
            Phone = "";
        }

        public Person(string pID, string pName, string pPhone)
        {
            Id = pID;
            name = pName;
            Phone = pPhone;
        }
        #endregion

        
    }
}
