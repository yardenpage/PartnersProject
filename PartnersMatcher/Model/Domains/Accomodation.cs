using PartnersMatcher.Model.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher
{
    class Accomodation : IDomain
    {
        string Role;
        string isSmoking;
        string Animals;
        int NumberOfPartners;
        string religion;

        public Accomodation(string _role, string _smoke, string _animal, int _num, string _hob)
        {
            Role = _role;
            isSmoking = _smoke;
            Animals = _animal;
            NumberOfPartners = _num;
            religion = _hob;
        }

        public string ToStringD()
        {
            return Role + "," + isSmoking + "," + Animals + "," + NumberOfPartners + "," + religion;
        }
    }
}
