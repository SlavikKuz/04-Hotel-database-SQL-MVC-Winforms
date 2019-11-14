using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HotelDb.Logic;
using HotelDb.Logic.Entities;
using HotelDb.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelDb.WebUI.Controllers
{
    public class ClientModelController : Controller
    {
        private readonly IMapper mapper;
        public ClientModelController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ActionResult CreatePage()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClient(ClientModel client)
        {
            try
            {
                using (var database = new LogicLL())
                    database.AddClient(mapper.Map<ClientLL>(client));

                return RedirectToAction("ShowAllPage");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchPage()
        {
            return View(new List<ClientModel>());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchPage(string searchString)
        {
            if (String.IsNullOrWhiteSpace(searchString))
                return RedirectToAction("SearchPage");

            List<ClientModel> output;

            using (var database = new LogicLL())
                output = mapper.Map<List<ClientModel>>(database.GetAllClients());

                output.Where(x => JsonConvert.SerializeObject(x).Contains(searchString));
                      
            return View(output);
        }

        public ActionResult ShowAllPage()
        {
            List<ClientModel> list;
            
            using (var database = new LogicLL())
                list = mapper.Map<List<ClientModel>>(database.GetAllClients());
            
            return View(list);
        }

        public ActionResult EditPage(Guid id)
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
        public ActionResult SaveClient(ClientModel client)
        {
            try
            {
                using (var database = new LogicLL())
                    database.UpdateClient(mapper.Map<ClientLL>(client));

                return RedirectToAction("ShowAllPage");
            }
            catch
            {
                return View();
            }
        }

        //TODO:
        public ActionResult HistoryClient(Guid id) 
        {
            List<BookingModel> bookingHistory = new List<BookingModel>();

            using (var database = new LogicLL())
            {
                bookingHistory = (mapper.Map<List<BookingModel>>(database.GetAllBookings()))
                    .Where(x => x.Client.Id == id).ToList();
            }

            return View(bookingHistory);
        }
        
        //TODO:
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