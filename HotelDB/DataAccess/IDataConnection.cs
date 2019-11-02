using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDB.Model;

namespace HotelDB.DataAccess
{
    public interface IDataConnection
    { 
        List<ClientModel> GetClientsAll();
        List<ClientModel> GetClientsAll(string clientSearch);
        ClientModel GetClientsAll(int clientPosition);
        void CreateClient(ClientModel client);
        void UpdateClient(ClientModel client);
    }
}
