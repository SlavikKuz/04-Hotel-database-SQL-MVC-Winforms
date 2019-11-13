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

        public ActionResult Create() //CreatePage
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientModel client) //CreateClient
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

        public ActionResult Search() //SearchPage
        {
            return View(new List<ClientModel>());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string searchString) //SearchClient
        {
            if (String.IsNullOrWhiteSpace(searchString))
                return RedirectToAction("Search");

            List<ClientModel> output;

            using (var database = new LogicLL())
                output = mapper.Map<List<ClientModel>>(database.GetAllClients());

                output.Where(x =>
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

        public ActionResult ShowAll() //ShowAllPage
        {
            List<ClientModel> list;
            
            using (var database = new LogicLL())
                list = mapper.Map<List<ClientModel>>(database.GetAllClients());
            
            return View(list);
        }

        public ActionResult Edit(Guid id) //EditPage
        {
            ClientModel client;

            using (var database = new LogicLL())
                client = (mapper.Map<List<ClientModel>>(database.GetAllClients()))
                    .Where(x => x.Id == id)
                    .First();

            return View(client);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientModel client) //SaveClient
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

        public ActionResult History(Guid id) //HistoryClient
        {
            List<BookingModel> bookingHistory = new List<BookingModel>();

            using (var database = new LogicLL())
            {
                bookingHistory = (mapper.Map<List<BookingModel>>(database.GetAllBookings()))
                    .Where(x => x.Client.Id == id).ToList();
            }

            return View(bookingHistory);
        }

        public ActionResult Invoice(Guid id)//InvoiceClient
        {
            InvoiceModel invoice;

            using (var database = new LogicLL())
                invoice = (mapper.Map<List<BookingModel>>(database.GetAllBookings()))
                    .Where(x => x.Id == id)
                    .Select(x => x.Invoice)
                    .First();

            return View(invoice);
        }
    }
}