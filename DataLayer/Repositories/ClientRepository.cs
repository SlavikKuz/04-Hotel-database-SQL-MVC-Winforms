using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using HotelDb.DataLayer.Context;
using System.Collections.Generic;

namespace HotelDb.DataLayer.Repositories
{
    public class ClientRepository : IRepository<ClientModel>
    {
        private HotelDbContext database;

        public ClientRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(ClientModel client)
        {
            database.Clients.Add(client);
        }

        public void Delete(int id)
        {
            ClientModel client = database.Clients.Find(id);
            if (client != null)
            {
                database.Clients.Remove(client);
            }
        }

        public ClientModel Read(int id)
        {
            return database.Clients.Find(id);
        }

        public IEnumerable<ClientModel> ReadAll()
        {
            return database.Clients;
        }

        public void Update(ClientModel client)
        {
            database.Clients.Update(client);
        }
    }
}
