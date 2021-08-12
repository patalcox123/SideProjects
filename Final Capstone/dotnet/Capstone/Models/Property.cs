using System;
using System.Collections.Generic;

namespace Capstone.Models
{
    public class Property
    {
        public int PropertyId { get; set; }
        public int LandlordId { get; set; }
        public string Description { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public decimal Price { get; set; }
        public string DateAvailable { get; set; }
        public bool Available { get; set; }
        public int Beds { get; set; }
        public double Baths { get; set; }
        public string Thumbnail { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
    }
}
