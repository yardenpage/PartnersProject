using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher
{
    class Post
    {
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Domain { get; set; }

        public Post(string s, string l,string d)
        {
            Subject = s;
            Location = l;
            Domain = d;
        }

        public override string ToString()
        {
            return Domain+ ":   "+ Subject + "   " + Location + "   Watch";
        }
    }
}
