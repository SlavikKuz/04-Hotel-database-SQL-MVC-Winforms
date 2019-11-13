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
        { 
            this.mapper = mapper; 
        }

        public ActionResult Create() //CreatePage
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HolidayListModel holiday) //CreateHoliday
        {
            try
            {
                using (var database = new LogicLL())
                    database.AddHoliday(mapper.Map<HolidayListLL>(holiday));

                return RedirectToAction(nameof(ShowAll));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult ShowAll()
        {
            List<HolidayListModel> holidays;

            using (var database = new LogicLL())
                holidays = mapper.Map<List<HolidayListModel>>(database.GetAllHolidayList());
           
            return View(holidays);
        }

        public ActionResult Delete(Guid id) //DeletePage
        {
            HolidayListModel holiday;

            using (var database = new LogicLL())
                holiday = (mapper.Map<List<HolidayListModel>>(database.GetAllHolidayList()))
                    .Where(x => x.Id == id)
                    .First();

            return View(holiday);
        }       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(HolidayListModel holiday) //DeletePage
        {
            try
            {
                using (var database = new LogicLL())
                    database.RemoveHoliday(holiday.Id);

                    return RedirectToAction(nameof(ShowAll));
            }
            catch
            {
                return View();
            }
        }
    }
}