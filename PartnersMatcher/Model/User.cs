using PartnersMatcher.Model.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher
{
    public class User
    {
        string email;//user name
        string full_name;
        string age;
        string phone;
        string city;
        public HashSet<IDomain> domains; //domains he filled more data on
        public HashSet<string> domain_name; //domains he just choosed
        List<string> domainsForJson;

        public User(string mail, string name, string _age, string _phone, string _city)
        {
            domainsForJson = new List<string>();
            domains = new HashSet<IDomain>();
            domain_name = new HashSet<string>();
            email = mail;
            full_name = name;
            age = _age;
            phone = _phone;
            city = _city;
        }

        public void ToStringAllDomains()
        {
            foreach(IDomain d in domains)
            {
                d.ToStringD();
                domains.Add(d);
            }
        }
    }
}
