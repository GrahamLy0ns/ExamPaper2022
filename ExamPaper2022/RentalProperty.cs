using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPaper2022
{
    public enum RentalType
    {
        House,
        Flat,
        Share
    }
    public class RentalProperty
    {
        public int ID { get; set; }
        public RentalType RentalType { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        public void IncreaseRentByPerchentageAmount(decimal amount, decimal Price)
        {
            Price *= amount;
        }
        public override string ToString()
        {
            return Location + " " + Price;
        }


    }

    public class PropertyData : DbContext
    {
        public PropertyData() : base("PropertyData") { }
        public DbSet<RentalProperty> Properties { get; set; }
    }
}
