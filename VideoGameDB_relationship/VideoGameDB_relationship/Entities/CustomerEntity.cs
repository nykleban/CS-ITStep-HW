using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameDB_relationship.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
