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
    public class DayModelController : Controller
    {
        private IMapper mapper;
        public DayModelController(IMapper mapper)
        { this.mapper = mapper; }

        public ActionResult ShowAll()
        {
            List<HolidayModel> holidays = new List<HolidayModel>();

            using (var database = new LogicLL())
                holidays = mapper.Map<List<HolidayModel>>(database.GetAllHolidays());
           
            return View(holidays);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HolidayModel dayHoliday)
        {
            try
            {
                using (var database = new LogicLL())
                    database.AddHoliday(mapper.Map<HolidaysListLL>(dayHoliday));

                return RedirectToAction(nameof(ShowAll));
            }
            catch
            {
                return View();
            }
        }





        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: DayModel/Delete/5
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