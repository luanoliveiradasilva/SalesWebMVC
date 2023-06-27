using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Models
{
    public class Seller
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime birthDate { get; set; }
        public double baseSalary { get; set; }

        public Department department { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.birthDate = birthDate;
            this.baseSalary = baseSalary;
            this.department = department;
        }


        public void addSale(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }

        public void removeSale(SalesRecord salesRecord) { Sales.Remove(salesRecord); }

        public double totalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(salesRecord => salesRecord.date >= initial && salesRecord.date <= final).Sum(SalesRecord => SalesRecord.amount);
        }

    }
}
