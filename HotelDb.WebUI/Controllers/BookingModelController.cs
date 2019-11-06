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
            List<BookingModel> list = new List<BookingModel>();

            using (var database = new LogicLL())
                list = mapper.Map<List<BookingModel>>(database.GetAllBookings());

                return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingModel booking)
        {
            try
            {
                using (var database = new LogicLL())
                    database.AddBooking(mapper.Map<BookingLL>(booking));

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