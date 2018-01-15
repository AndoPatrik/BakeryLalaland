using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryLalaland.Model
{
    class Manager
    {
        private string _name;
        private string _id;
        private string _password;

        

        public string Name { get => _name; set => _name = value; }
        public string Id { get => _id; set => _id = value; }
        public string Password { get => _password; set => _password = value; }


        public Manager(string name, string id, string password)
        {
            _name = name;
            _id = id;
            _password = password;
        }

    }
}
