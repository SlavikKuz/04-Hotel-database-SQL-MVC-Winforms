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
                    Booking = b
                    //Client = clients.Where(x => x.ClientId == b.ClientId).First()
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
                bookingView.SelectClient = (mapper.Map<List<ClientModel>>(database.GetAllClients()))
                    .Select(x => new SelectListItem { Text = x.ClientFullName, Value = x.ClientId.ToString() })
                    .ToList();

                bookingView.SelectRoom = (mapper.Map<List<RoomModel>>
                    (
                        database.GetAllRooms()).Where(x => x.Ready == true)
                    )
                    .Select(x => new SelectListItem { Text = x.RoomNumber, Value = x.RoomId.ToString() })
                    .ToList();

                bookingView.SelectGuest = (mapper.Map<List<ClientModel>>(database.GetAllClients()))
                    .Select(x => new SelectListItem { Text = x.ClientFullName, Value = x.ClientId.ToString() })
                    .ToList();
            }
            return View(bookingView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string bookingButton, BookingViewModel bookingPost)
        {

            List<ClientModel> allClients;
            List<RoomModel> allRooms;
            List<ClientModel> allGuests;
            List<HolidayModel> allHolidays;
            List<RoomPriceModel> allRoomPrices;
            List<InvoiceModel> allInvoices;

            using (var database = new LogicLL())
            {
                allClients = mapper.Map<List<ClientModel>>(database.GetAllClients());

                allRooms = (mapper.Map<List<RoomModel>>(database.GetAllRooms()))
                    .Where(x => x.Ready == true).ToList();

                allGuests = mapper.Map<List<ClientModel>>(database.GetAllClients());

                allHolidays = mapper.Map<List<HolidayModel>>(database.GetAllHolidays());

                allRoomPrices = mapper.Map<List<RoomPriceModel>>(database.GetAllRoomPrices());

                allInvoices = mapper.Map<List<InvoiceModel>>(database.GetAllInvoices());
            }

            bookingPost.SelectClient = allClients
                    .Select(x => new SelectListItem { Text = x.ClientFullName, Value = x.ClientId.ToString() })
                    .ToList();

            bookingPost.SelectRoom = allRooms
                    .Select(x => new SelectListItem { Text = x.RoomNumber, Value = x.RoomId.ToString() })
                    .ToList();

            bookingPost.SelectGuest = allGuests
                    .Select(x => new SelectListItem { Text = x.ClientFullName, Value = x.ClientId.ToString() })
                    .ToList();

            switch (bookingButton)
            {
                case "AddRoom":
                    bookingPost.Booking.BookedRoomsId.Add(bookingPost.RoomId);
                    break;

                case "AddGuest":
                    bookingPost.Booking.GuestListId.Add(bookingPost.GuestId);
                    break;

                case "AddInvoice":
                    decimal totalPrice = 0;

                    //fix for list of rooms
                    RoomPriceModel roomPrice = allRoomPrices.Where(x => x.RoomId == bookingPost.RoomId).First();

                    for (DateTime day = bookingPost.Booking.DayFrom; day <= bookingPost.Booking.DayTill; day = day.AddDays(1))
                    {
                        if ((allHolidays.Select(x => x.HolidayDay))
                            .Where(x => x == day).Count() > 0)
                        {
                            totalPrice += roomPrice.HolidayPrice;
                        }
                        else if ((day.DayOfWeek == DayOfWeek.Friday) || 
                                 (day.DayOfWeek == DayOfWeek.Saturday) || 
                                 (day.DayOfWeek == DayOfWeek.Sunday ))
                        {
                            totalPrice += roomPrice.WeekendPrice;
                        }
                        else
                        {
                            totalPrice += roomPrice.AveragePrice;
                        }
                    }

                    bookingPost.Invoice.TotalPrice = totalPrice;
                    break;

                case "Save":
                    {
                        try
                        {
                            //save roomList, return Id
                            //save guestList,return Id
                            //save booking                           
                            InvoiceModel invoice = new InvoiceModel()
                            {
                                BookingId = 404,
                                ClientId = bookingPost.Booking.ClientId,
                                TotalPrice = bookingPost.Invoice.TotalPrice
                            };

                            using (var database = new LogicLL())
                            {
                                database.AddInvoice(mapper.Map<InvoiceLL>(invoice));
                                invoice = (mapper.Map<List<InvoiceModel>>(database.GetAllInvoices())).Last();
                            }

                            InvoiceModel nesw = invoice;

                            return RedirectToAction(nameof(ShowAll));
                        }
                        catch (Exception ex)
                        {
                            return View();
                        }
                    }
            }

            foreach (var room in bookingPost.Booking.BookedRoomsId)
                bookingPost.SelectedRooms.Add(
                   allRooms.Where(x => x.RoomId == room)
                    .Select(x => x.RoomNumber)
                    .First()
                    .ToString());

            foreach (var guest in bookingPost.Booking.GuestListId)
                bookingPost.SelectedGuests.Add(
                   allGuests.Where(x => x.ClientId == guest)
                    .Select(x => x.ClientFullName)
                    .First()
                    .ToString());

            return View(bookingPost);
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