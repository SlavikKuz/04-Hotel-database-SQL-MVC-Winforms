using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using HotelDb.DataLayer.Context;
using System.Collections.Generic;
using System;

namespace HotelDb.DataLayer.Repositories
{
    public class ClientsRepository : IRepository<ClientDL>
    {
        private HotelDbContext database;

        public ClientsRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(ClientDL client)
        {
            database.Clients.Add(client);
        }

        public ClientDL Read(int id)
        {
            return database.Clients.Find(id);
        }

        public IEnumerable<ClientDL> ReadAll()
        {
            return database.Clients;
        }

        public void Update(ClientDL client)
        {
            database.Clients.Update(client);
        }

        public void Delete(Guid id)
        {
            ClientDL client = database.Clients.Find(id);
            if (client != null)
            {
                database.Clients.Remove(client);
            }
        }
    }
}
