using AutoMapper;
using HotelDb.DataLayer;
using HotelDb.DataLayer.Entities;
using HotelDb.Logic.Entities;
using System;
using System.Collections.Generic;

namespace HotelDb.Logic
{
    public class LogicLL : IDisposable
    {
        private UnitOfWork DataBase { get; }                         
        private readonly IMapper mapper ;        
        
        public LogicLL(IMapper mapper)
        {
            DataBase = new UnitOfWork(); 
            this.mapper = mapper;
        }
       
        public IEnumerable<ClientLL> GetAllClients()
        {
            List<ClientLL> result = new List<ClientLL>();

            foreach (ClientDL cl  in DataBase.Clients.ReadAll())
                result.Add( mapper.Map<ClientLL>(cl));
            return result;
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
