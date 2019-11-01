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
        //TODO: methods to save and retrieve data;     
        List<ClientModel> GetClientsAll();
        List<ClientModel> GetClientsAll(string clientSearch);
    }
}
