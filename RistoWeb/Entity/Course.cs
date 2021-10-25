using System;
using System.ComponentModel.DataAnnotations;

namespace RistoWeb.Entity
{
    public class Course
    {
        [Key]
        public int C_ID { get; set; }
        public string C_Name { get; set; }
        public double Price { get; set; }
        public DateTime C_Date { get; set; }
        public int C_Type { get; set; }
    }
}
