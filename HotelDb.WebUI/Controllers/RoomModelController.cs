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
    public class RoomModelController : Controller
    {
        private readonly IMapper mapper;
        public RoomModelController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ActionResult ShowAll()
        {
            List<RoomModel> list = null;

            using (var database = new LogicLL())
                list = mapper.Map<List<RoomModel>>(database.GetAllRooms())
                    .OrderBy(i=>i.RoomNumber)
                    .ToList();

            return View(list);
        }

        public ActionResult ShowAvailable()
        {
            List<RoomModel> list = null;

            using (var database = new LogicLL())
                list = mapper.Map<List<RoomModel>>(database.GetAllRooms())
                    .Where(i => i.Ready == true)
                    .OrderBy(i => i.RoomNumber)
                    .ToList();

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomModel room)
        {          
            try
            {
                using (var database = new LogicLL())
                    database.AddRoom(mapper.Map<RoomLL>(room));

                    return RedirectToAction("ShowAll");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            RoomModel room = new RoomModel();

            using (var database = new LogicLL())
                room = (mapper.Map<List<RoomModel>>(database.GetAllRooms()))
                    .Where(i => i.RoomId == id)
                    .First();

                return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomModel room)
        {
            try
            {
                using (var database = new LogicLL())
                    database.UpdateRoom(mapper.Map<RoomLL>(room));

                    return RedirectToAction("ShowAll");
            }
            catch
            {
                return View();
            }
        }
    }
}