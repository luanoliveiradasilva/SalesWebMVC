using app.Models.Enums;
using System;
namespace app.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public double amount { get; set; }
        public SalesStatus status { get; set; }

        public Seller seller { get; set; }
   
        public SalesRecord() { }

        public SalesRecord(int id, DateTime date, double amount, SalesStatus status, Seller seller)
        {
            Id = id;
            this.date = date;
            this.amount = amount;
            this.status = status;
            this.seller = seller;
        }
    }
}
