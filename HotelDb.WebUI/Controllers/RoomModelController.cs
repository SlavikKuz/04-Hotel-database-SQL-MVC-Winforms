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

                    return RedirectToAction("Price", new { @roomNumber = room.RoomNumber });
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

        public ActionResult Price(string roomNumber)
        {
            RoomPriceModel roomPrice = new RoomPriceModel()
            { RoomNumber = roomNumber };

            return View(roomPrice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PriceSave(RoomPriceModel roomPrice)
        {
            try
            {
                using (var database = new LogicLL())
                    database.AddRoomPrice(mapper.Map<RoomPriceLL>(roomPrice));

                return RedirectToAction("ShowAvailable");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult ShowPrice(string roomNumber)
        {
            RoomPriceModel roomPrice;

            using (var database = new LogicLL())
                roomPrice = (mapper.Map<List<RoomPriceModel>>(database.GetAllRoomPrice()))
                            .Where(x => x.RoomNumber.Contains(roomNumber))
                            .First();      

            return View(roomPrice);
        }


        public ActionResult EditPrice(int id)
        {
            RoomPriceModel roomPrice;

            using (var database = new LogicLL())
                roomPrice = (mapper.Map<List<RoomPriceModel>>(database.GetAllRoomPrice()))
                            .Where(x => x.RoomPriceId == id)
                            .First();

            return View(roomPrice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPrice(RoomPriceModel roomList)
        {
            try
            {
                using (var database = new LogicLL())
                    database.UpdateRoomList(mapper.Map<RoomPriceLL>(roomList));

                return RedirectToAction("ShowAll");
            }
            catch
            {
                return View();
            }
        }
        

    }
}