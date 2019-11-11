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
                bookingView.SelectListClient = (mapper.Map<List<ClientModel>>(database.GetAllClients()))
                    .Select(x => new SelectListItem { Text = x.ClientFullName, Value = x.ClientId.ToString() })
                    .ToList();

                bookingView.SelectListRoom = (mapper.Map<List<RoomModel>>
                    (
                        database.GetAllRooms()).Where(x => x.Ready == true)
                    )
                    .Select(x => new SelectListItem { Text = x.RoomNumber, Value = x.RoomId.ToString() })
                    .ToList();

                bookingView.SelectListGuest = (mapper.Map<List<ClientModel>>(database.GetAllClients()))
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

            bookingPost.SelectListClient = allClients
                    .Select(x => new SelectListItem { Text = x.ClientFullName, Value = x.ClientId.ToString() })
                    .ToList();

            bookingPost.SelectListRoom = allRooms
                    .Select(x => new SelectListItem { Text = x.RoomNumber, Value = x.RoomId.ToString() })
                    .ToList();

            bookingPost.SelectListGuest = allGuests
                    .Select(x => new SelectListItem { Text = x.ClientFullName, Value = x.ClientId.ToString() })
                    .ToList();

            switch (bookingButton)
            {
                case "AddRoom":
                    bookingPost.RoomList.Add( new RoomListModel()
                    { RoomId = bookingPost.RoomId });
                    break;

                case "AddGuest":
                    bookingPost.GuestList.Add( new GuestListModel() 
                    { ClientId = bookingPost.GuestId });
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

                            BookingModel booking = new BookingModel()
                            {
                                //bookingId =
                                ClientId = bookingPost.Booking.ClientId,
                                OrderDate = bookingPost.Booking.OrderDate,
                                DayFrom = bookingPost.Booking.DayFrom,
                                DayTill = bookingPost.Booking.DayTill,
                                WithKids = bookingPost.Booking.WithKids,
                                //List<long> GuestListId
                                Status = bookingPost.Booking.Status,
                                Info = bookingPost.Booking.Info
                                //List<long> BookedRoomsId
                                //InvoiceId
                            };

                            InvoiceModel invoice = new InvoiceModel()
                            {
                                BookingId = 404,
                                ClientId = bookingPost.Booking.ClientId,
                                TotalPrice = bookingPost.Invoice.TotalPrice
                            };
                            
                            using (var database = new LogicLL())
                            {
                                //save booking
                                //get bookingId
                                //save others
                                //updade booking record

                                database.AddBooking(mapper.Map<BookingLL>(booking));
                                bookingPost.Booking.BookingId = 
                                    (mapper.Map<List<BookingModel>>(database.GetAllBookings())).Last().BookingId;


                                database.AddInvoice(mapper.Map<InvoiceLL>(invoice));
                                bookingPost.Invoice.InvoiceId = 
                                    (mapper.Map<List<InvoiceModel>>(database.GetAllInvoices())).Last().InvoiceId;

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

            foreach (var room in bookingPost.RoomList)
                bookingPost.ShowSelectedRooms.Add(
                   allRooms.Where(x => x.RoomId == room.RoomId)
                    .Select(x => x.RoomNumber)
                    .First()
                    .ToString());

            foreach (var guest in bookingPost.GuestList)
                bookingPost.ShowSelectedGuests.Add(
                   allGuests.Where(x => x.ClientId == guest.ClientId)
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