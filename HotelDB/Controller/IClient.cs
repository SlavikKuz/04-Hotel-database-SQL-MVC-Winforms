using System.Data;

namespace HotelDB.Controller
{
    public interface IClient
    {
        void SetController(ClientController controller);

        //methods from Client model
        //void InsertClient();
        //DataTable SelectClients();
        //DataTable SelectClients(string find);
        //bool SelectClient(int client_id);
        //bool UpdateClient();

        void SetClient(string client_name);
        void SetEmail(string email);
        void SetTel(string tel);
        void SetAddress(string address);
        void SetNotes(string notes);
    }
}
