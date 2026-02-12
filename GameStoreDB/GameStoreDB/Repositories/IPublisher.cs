using System;
using System.Collections.Generic;
using System.Text;
using GameStoreDB.Entities;

namespace GameStoreDB.Repositories
{
    public interface IPublisher
    {
        void Add(Publisher publisher);
        Publisher? Get(int id);
        IEnumerable<Publisher> GetAll();
        void Update(Publisher updatedPublisher);
        void Remove(int id);
    }
}
