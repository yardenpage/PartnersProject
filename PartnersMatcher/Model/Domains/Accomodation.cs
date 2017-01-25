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
        bool isSmoking;
        string Animals;
        int NumberOfPartners;

        public Accomodation(string _role, bool _smoke, string _animal, int _num)
        {
            Role = _role;
            isSmoking = _smoke;
            Animals = _animal;
            NumberOfPartners = _num;
        }

        public string GetName()
        {
            return "Accomodation";
        }      
    }
}
