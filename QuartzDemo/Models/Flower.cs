using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuartzDemo.Models
{
    public class Flower
    {
        [Key]
        public int FlowerId { get; set; }
        public string FlowerName { get; set; }
        public DateTime WhenAdded { get; set; }
    }
}
