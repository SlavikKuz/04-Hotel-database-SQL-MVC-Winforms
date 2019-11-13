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

        public ActionResult Create()//CreatePage
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomModel room)//CreateRoom
        {          
            try
            {
                RoomPriceModel roomPrice = new RoomPriceModel();

                using (var database = new LogicLL())
                {
                    database.AddRoom(mapper.Map<RoomLL>(room));
                    database.AddRoomPrice(mapper.Map<RoomPriceLL>(roomPrice));
                    
                    roomPrice = mapper.Map<List<RoomPriceModel>>(database.GetAllRoomPrice())
                        .ToList().Last();
                }
                return RedirectToAction("Price", roomPrice); //PricePage
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Price(RoomPriceModel roomPrice) //PricePage
        {
            return View(roomPrice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PriceSave(RoomPriceModel roomPrice) //SavePrice
        {
            try
            {
                using (var database = new LogicLL())
                    database.UpdateRoomPrice(mapper.Map<RoomPriceLL>(roomPrice));

                return RedirectToAction("ShowAvailable");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult ShowAll() //ShowAllPage
        {
            List<RoomModel> list;

            using (var database = new LogicLL())
                list = mapper.Map<List<RoomModel>>(database.GetAllRooms())
                    .OrderBy(i=>i.RoomNumber)
                    .ToList();

            return View(list);
        }
        public ActionResult ShowAvailable() //ShowAvailablePage
        {
            List<RoomModel> list;

            using (var database = new LogicLL())
                list = mapper.Map<List<RoomModel>>(database.GetAllRooms())
                    .Where(i => i.Ready == true)
                    .OrderBy(i => i.RoomNumber)
                    .ToList();

            return View(list);
        }

        public ActionResult Edit(Guid id) //EditPage
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
        public ActionResult Edit(RoomModel room) //EditRoom
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

        
        // ????
        public ActionResult ShowPrice(Guid id) //ShowPricePage
        {
            RoomPriceModel roomPrice;

            using (var database = new LogicLL())
                roomPrice = (mapper.Map<List<RoomPriceModel>>(database.GetAllRoomPrice()))
                            .Where(x => x.Id == id)
                            .First();

            return View(roomPrice);
        }
        // ????
        public ActionResult EditPrice(Guid id)
        {
            RoomPriceModel roomPrice;

            using (var database = new LogicLL())
                roomPrice = (mapper.Map<List<RoomPriceModel>>(database.GetAllRoomPrice()))
                            .Where(x => x.Id == id)
                            .First();

            return View(roomPrice);
        } //EditPricePage
        // ????
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPrice(RoomPriceModel roomPrice)
        {
            try
            {
                using (var database = new LogicLL())
                    database.UpdateRoomList(mapper.Map<RoomPriceLL>(roomPrice));

                return RedirectToAction("ShowAll");
            }
            catch
            {
                return View();
            }
        }    
    }
}