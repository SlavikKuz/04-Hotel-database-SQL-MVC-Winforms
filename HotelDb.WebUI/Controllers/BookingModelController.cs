using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelDb.Logic;
using HotelDb.Logic.Entities;
using HotelDb.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelDb.WebUI.Controllers
{
    public class BookingModelController : Controller
    {
        private readonly IMapper mapper;
        public BookingModelController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        
        public ActionResult ShowAll()
        {
            List<BookingViewModel> bookingsView = new List<BookingViewModel>();
            List<BookingModel> bookings = new List<BookingModel>();
            List<ClientModel> clients = new List<ClientModel>();
            List<GuestModel> guests = new List<GuestModel>();

            using (var database = new LogicLL())
            {
                bookings = mapper.Map<List<BookingModel>>(database.GetAllBookings());
                clients = mapper.Map<List<ClientModel>>(database.GetAllClients());
                guests = mapper.Map<List<GuestModel>>(database.GetAllGuest());
            }

            foreach (var b in bookings)
            {
                bookingsView.Add(new BookingViewModel
                {
                    Booking = b,
                    Client = clients.Where(x => x.ClientId == b.ClientId).First()
                    //Guests = guests.Where(x => x.BookingId == b.BookingId).ToList()
                });
            }
            
            return View(bookingsView);
        }

        public ActionResult Create()
        {
            BookingViewModel bookingView = new BookingViewModel();

            using (var database = new LogicLL())
            {
                bookingView.Clients = (mapper.Map<List<ClientModel>>(database.GetAllClients()))
                    .Select(x => new SelectListItem { Text = x.ClientFullName, Value = x.ClientId.ToString() })
                    .ToList();
            }
            return View(bookingView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingViewModel bookingPost)
        {
            BookingModel bookingFull = new BookingModel();
            bookingFull = bookingPost.Booking;
            bookingFull.ClientId = bookingPost.ClientId;
            bookingFull.OrderDate = DateTime.Now;
            
            try
            {
                using (var database = new LogicLL())
                    database.AddBooking(mapper.Map<BookingLL>(bookingPost));

                    return RedirectToAction(nameof(ShowAll));
            }
            catch
            {
                return View();
            }
        }













        // GET: BookingModel
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookingModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: BookingModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingModel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}