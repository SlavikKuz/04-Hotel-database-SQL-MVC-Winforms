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
    public class HolidayModelController : Controller
    {
        private IMapper mapper;
        public HolidayModelController(IMapper mapper)
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
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Delete(long holidayId)
        {
            HolidayModel holiday = new HolidayModel();

            using (var database = new LogicLL())
                holiday = (mapper.Map<List<HolidayModel>>(database.GetAllHolidays()))
                    .Where(x => x.HolidayId == holidayId)
                    .First();

            return View(holiday);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(HolidayModel holiday)
        {
            try
            {
                using (var database = new LogicLL())
                    database.RemoveHoliday(holiday.HolidayId);

                    return RedirectToAction(nameof(ShowAll));
            }
            catch
            {
                return View();
            }
        }
    }
}