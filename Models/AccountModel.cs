using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonApp.Models
{
    public class AccountModel
    {
        public AccountModel()
        {
            Transactions = new HashSet<TransactionModel>();
        }

        public int Code { get; set; }
        public int PersonCode { get; set; }
        public string AccountNumber { get; set; }
        public decimal OutstandingBalance { get; set; }

        public virtual PersonModel PersonCodeNavigation { get; set; }
        public virtual ICollection<TransactionModel> Transactions { get; set; }
    }
}
