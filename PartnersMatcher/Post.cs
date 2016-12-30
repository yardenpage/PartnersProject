using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher
{
    class Post
    {
        public string name { get; set; }
        public string ID { get; set; }
        public string user { get; set; }

        public Post(string n, string i, string u)
        {
            name = n;
            ID = i;
            user = u;
        }

        public override string ToString()
        {
            return ID + ". " + user + ": " + name;
        }
    }
}
}
