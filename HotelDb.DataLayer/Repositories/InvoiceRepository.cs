using HotelDb.DataLayer.Context;
using HotelDb.DataLayer.Entities;
using HotelDb.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.DataLayer.Repositories
{
    public class InvoiceRepository:IRepository<InvoiceDL>
    {
        private HotelDbContext database;

        public InvoiceRepository(HotelDbContext context)
        {
            database = context;
        }

        public void Create(InvoiceDL invoice)
        {
            database.Invoices.Add(invoice);
        }

        public void Delete(long id)
        {
            InvoiceDL invoice = database.Invoices.Find(id);
            if (invoice != null)
            {
                database.Invoices.Remove(invoice);
            }
        }

        public InvoiceDL Read(int id)
        {
            return database.Invoices.Find(id);
        }

        public IEnumerable<InvoiceDL> ReadAll()
        {
            return database.Invoices;
        }

        public void Update(InvoiceDL invoice)
        {
            database.Invoices.Update(invoice);
        }
    }
}
