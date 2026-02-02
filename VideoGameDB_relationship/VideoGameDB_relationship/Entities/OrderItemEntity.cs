using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameDB_relationship.Entities
{

    public class OrderItemEntity
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public OrderEntity Order { get; set; } = null!;

        public int GameId { get; set; }
        public GameEntity Game { get; set; } = null!;

        public int Quantity { get; set; }
    }


}
