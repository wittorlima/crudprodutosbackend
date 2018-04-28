using CRUD.Domain.Constants;
using System;

namespace CRUD.Application.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public DateTime DatePurchased { get; set; }
        public byte[] Image { get; set; }
        public decimal Price { get; set; }
        public Origin Origin { get; set; }
    }
}