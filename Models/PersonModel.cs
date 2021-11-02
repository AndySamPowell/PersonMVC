using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonApp.Models
{
    public class PersonModel
    {
        public PersonModel()
        {
            Accounts = new HashSet<AccountModel>();
        }

        public int Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }

        public virtual ICollection<AccountModel> Accounts { get; set; }
    }
}
