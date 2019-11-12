using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HotelDb.Logic;
using HotelDb.Logic.Entities;
using HotelDb.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelDb.WebUI.Controllers
{
    public class ClientModelController : Controller
    {
        private readonly IMapper mapper;
        public ClientModelController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ActionResult ShowAll()
        {
            List<ClientModel> list = null;
            using (var database = new LogicLL())
                list = mapper.Map<List<ClientModel>>(database.GetAllClients());
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientModel client)
        {
            try
            {
                using (var database = new LogicLL())
                    database.AddClient(mapper.Map<ClientLL>(client));

                return RedirectToAction("ShowAll");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search()
        {
            return View(new List<ClientModel>());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string searchString)
        {
            if (String.IsNullOrWhiteSpace(searchString))
                return RedirectToAction("Search");

            List<ClientModel> input = null;
            List<ClientModel> output = null;

            using (var database = new LogicLL())
                input = mapper.Map<List<ClientModel>>(database.GetAllClients());

            foreach (ClientModel client in input)
                output = input.Where(x =>
                                   (x.FirstName.Contains(searchString)) ||
                                   (x.LastName.Contains(searchString)) ||
                                   (x.Address.Contains(searchString)) ||
                                   (x.City.Contains(searchString)) ||
                                   (x.Country.Contains(searchString)) ||
                                   (x.Email.Contains(searchString)) ||
                                   (x.Tel.Contains(searchString)) ||
                                   (x.ClientInfo.Contains(searchString))).ToList();

            return View(output);
        }

        public ActionResult Edit(int id)
        {
            ClientModel client = new ClientModel();

            using (var database = new LogicLL())
                client = (mapper.Map<List<ClientModel>>(database.GetAllClients()))
                    .Where(x => x.ClientId == id)
                    .First();

            return View(client);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientModel client)
        {
            try
            {
                using (var database = new LogicLL())
                    database.UpdateClient(mapper.Map<ClientLL>(client));

                return RedirectToAction("ShowAll");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult History(int id)
        {
            ClientViewModel clientView = new ClientViewModel();

            using (var database = new LogicLL())
            {
                clientView.Client = (mapper.Map<List<ClientModel>>(database.GetAllClients()))
                    .Where(x => x.ClientId == id)
                    .First();

                clientView.Bookings = (mapper.Map<List<BookingModel>>(database.GetAllBookings()))
                    .Where(x => x.ClientId == id).ToList();

                clientView.Invoices = (mapper.Map<List<InvoiceModel>>(database.GetAllInvoices()))
                    .Where(x => x.ClientId == id).ToList();
            }

            return View(clientView);
        }

        public ActionResult Invoice(int id)
        {
            InvoiceModel invoice = new InvoiceModel();

            using (var database = new LogicLL())
                invoice = (mapper.Map<List<InvoiceModel>>(database.GetAllInvoices()))
                    .Where(x => x.BookingId == id)
                    .First();

            return View(invoice);
        }
    }
}