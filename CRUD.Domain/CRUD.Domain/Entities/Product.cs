using CRUD.Domain.Constants;
using System;

namespace CRUD.Domain.Entities
{
    public class Product : ModelBase
    {
        public virtual DateTime DatePurchased { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Origin Origin { get; set; }
    }
}
