using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagazinData.Users
{
    public enum enumvalid
    {
        Stoc,
        NStoc
    }

    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string UserId { get; set; }
        public enumvalid Valid { get; set; }
        //type is or an exctration or deposit 0 or 1
        public DateTime data { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }

    }
}
