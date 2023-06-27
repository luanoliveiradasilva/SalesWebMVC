using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace app.Models
{
    public class Seller
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} Requerid")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string name { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Enter a valid E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Requerid")]
        public string email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} Requerid")]
        public DateTime birthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} Requerid")]
        public double baseSalary { get; set; }

        [Display(Name = "Department")]
        public Department department { get; set; }

        [Display(Name = "Department")]
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
