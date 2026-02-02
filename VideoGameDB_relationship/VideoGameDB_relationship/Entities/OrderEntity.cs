using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameDB_relationship.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public ICollection<OrderItemEntity> Items { get; set; } = new List<OrderItemEntity>();
    }

}
