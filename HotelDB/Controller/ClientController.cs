using System.Data;
using System.Windows.Forms;
using HotelDB.Model;

namespace HotelDB.Controller
{
    public class ClientController
    {
        IClient _view;
        SQL _sql;
        ClientModel _mClient;
        DataTable _clientTable;

        //constructor
        public ClientController(IClient view, SQL sql, 
            ClientModel mClient, DataTable clientTable)
        {
            _view = view;
            _sql = sql;
            _mClient = mClient;
            _clientTable = clientTable;
            view.SetController(this);
        }

        public DataTable SelectClients(string filter)
        {
            DataTable clientTable;
            clientTable = _mClient.SelectClients(filter);
            return clientTable;
        }
    }
}
