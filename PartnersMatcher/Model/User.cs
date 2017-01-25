using PartnersMatcher.Model.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartnersMatcher.Model;
using Newtonsoft.Json;

namespace PartnersMatcher
{
    public class User
    {
        string email;//user name
        string full_name;
        double age;
        string phone;
        string city;
        string password;
        public Dictionary<string, IDomain> domains; //domains he filled more data on
        string JsonDomains;
        public Dictionary<int,bool> postsAcco;
        public Dictionary<int, bool> postsTrip;
        public Dictionary<int, bool> postsDate;
        public Dictionary<int, bool> postsSport;
        string JsonPosts;
       public List<string> userSendRequest;
        //List<string> domainsForJson;

        public User(string mail, string pass)
        {
            //domainsForJson = new List<string>();
            domains = new Dictionary<string, IDomain>();
            postsAcco = new Dictionary<int, bool>();
            postsTrip = new Dictionary<int, bool>();
            postsDate = new Dictionary<int, bool>();
            postsSport = new Dictionary<int, bool>();
            email = mail;
            password = pass;
            userSendRequest = new List<string>();
        }
        public void addDetails(string _name, double _age, string _phone, string _city)
        {
            full_name = _name;
            age = _age;
            phone = _phone;
            city = _city;
        }
        public string FullName
        {
            get { return full_name; }
            set
            {
                full_name = value;
            }
        }
        public double Age
        {
            get { return age; }
            set
            {
                age = value;
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                city = value;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }
        public void AddDomain(IDomain domain)
        {
            domains.Add(domain.GetName(), domain);
        }
        public void RemoveDomain(string domain)
        {
            if(domains.ContainsKey(domain))
                domains.Remove(domain);
        }
        public void AddPost(int idPost, bool isOwner, string domain)
        {
            if (domain == "Accomodation")
                postsAcco.Add(idPost, isOwner);
            else if (domain == "Dates")
                postsDate.Add(idPost, isOwner);
            else if (domain == "Trip")
                postsTrip.Add(idPost, isOwner);
            else postsSport.Add(idPost, isOwner);
        }
    }
}
