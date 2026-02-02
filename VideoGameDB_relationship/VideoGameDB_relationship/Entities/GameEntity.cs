using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameDB_relationship.Entities
{
    public class GameEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public int ReleaseYear { get; set; }

        public int DeveloperId { get; set; }
        public DeveloperEntity Developer { get; set; } = null!;

        public ICollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
    }

}
