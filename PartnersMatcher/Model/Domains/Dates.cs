using PartnersMatcher.Model.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher
{
    public partial class Dates : IDomain
    {
        string _gender;
        double _age;
        string _intention;
        public Dates(string gender, double age, string intention)
        {
            _gender = gender;
            _age = age;
            _intention = intention;
        }
        public string GetName()
        {
            return "Dates";
        }
    }
}