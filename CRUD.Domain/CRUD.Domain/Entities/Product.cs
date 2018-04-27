using CRUD.Domain.Constants;
using System;

namespace CRUD.Domain.Entities
{
    public class Product : ModelBase
    {
        public DateTime DatePurchased { get; set; }
        public byte[] Image { get; set; }
        public decimal Price { get; set; }
        public Origin Origin { get; set; }
    }
}
