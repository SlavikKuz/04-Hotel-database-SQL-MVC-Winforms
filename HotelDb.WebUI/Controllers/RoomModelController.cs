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

        public ActionResult CreatePage()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoom(RoomModel room)
        {          
            try
            {
                using (var database = new LogicLL())
                {
                    database.AddRoom(mapper.Map<RoomLL>(room));
                    room = mapper.Map<List<RoomModel>>(database.GetAllRooms())
                        .ToList().Last();
                    room.RoomPrice.RoomId = room.Id;
                }
                return RedirectToAction("PricePage", room.RoomPrice); //PricePage
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult PricePage(RoomPriceModel roomPrice)
        {
            return View(roomPrice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePrice(RoomPriceModel roomPrice)
        {
            try
            {
                using (var database = new LogicLL())
                    database.UpdateRoomPrice(mapper.Map<RoomPriceLL>(roomPrice));

                return RedirectToAction("ShowAvailablePage");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult ShowAllPage()
        {
            List<RoomModel> list;

            using (var database = new LogicLL())
                list = mapper.Map<List<RoomModel>>(database.GetAllRooms())
                    .OrderBy(i=>i.RoomNumber)
                    .ToList();

            return View(list);
        }
        public ActionResult ShowAvailablePage()
        {
            List<RoomModel> list;

            using (var database = new LogicLL())
                list = mapper.Map<List<RoomModel>>(database.GetAllRooms())
                    .Where(i => i.Ready == true)
                    .OrderBy(i => i.RoomNumber)
                    .ToList();

            return View(list);
        }

        public ActionResult EditPage(Guid id)
        {
            RoomModel room;

            using (var database = new LogicLL())
                room = (mapper.Map<List<RoomModel>>(database.GetAllRooms()))
                    .Where(i => i.Id == id)
                    .First();

                return View(room);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRoom(RoomModel room)
        {
            try
            {
                using (var database = new LogicLL())
                {
                    database.UpdateRoom(mapper.Map<RoomLL>(room));
                    room = mapper.Map<List<RoomModel>>(database.GetAllRooms())
                        .ToList().Last();
                    room.RoomPrice.RoomId = room.Id;
                }
                return RedirectToAction("PricePage", room.RoomPrice); //PricePage
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult ShowPricePage(Guid id)
        {
            RoomPriceModel roomPrice;

            using (var database = new LogicLL())
                roomPrice = (mapper.Map<List<RoomPriceModel>>(database.GetAllRoomPrice()))
                            .Where(x => x.Id == id).Single();

                return View(roomPrice);
        }

        public ActionResult EditPrice(Guid id)
        {
            RoomPriceModel roomPrice;

            using (var database = new LogicLL())
                roomPrice = (mapper.Map<List<RoomPriceModel>>(database.GetAllRoomPrice()))
                            .Where(x => x.Id == id).Single();

            return View(roomPrice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPrice(RoomPriceModel roomPrice)
        {
            try
            {
                using (var database = new LogicLL())
                    database.UpdateRoomPrice(mapper.Map<RoomPriceLL>(roomPrice));

                return RedirectToAction("ShowAvailablePage");
            }
            catch
            {
                return View();
            }
        }    
    }
}