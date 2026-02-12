using GameStoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStoreDB.Repositories
{
    public class PublisherRepository
    {
        public readonly AppDbContext context;
        public PublisherRepository(AppDbContext context)
        {
            this.context = context;
        }

        private void save()
        {
          context.SaveChanges();

        }

        public void Add(Publisher publisher)
        {
            context.Publishers.Add(publisher);
            save();
        }

        public Publisher? Get(int id)
        {
            return context.Publishers.FirstOrDefault(p => p.Id == id);
        }
        public void Remove(int id)
        {
            var publisher = Get(id);
            if (publisher != null)
            {
                context.Publishers.Remove(publisher);
                save();
            }
        }
       
        public void Update(Publisher updatedPublisher)
        {
            var publisher = Get(updatedPublisher.Id);
            if (publisher != null)
            {
                publisher.Name = updatedPublisher.Name;
                publisher.Age = updatedPublisher.Age;
                publisher.Country = updatedPublisher.Country;
                publisher.Email = updatedPublisher.Email;
                save();
            }

        }
        
    }
}
