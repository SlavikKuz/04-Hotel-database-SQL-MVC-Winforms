using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelDb.DataLayer.Context;
using HotelDb.Logic;
using HotelDb.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelDb.WebUI.Controllers
{
    public class ClientModelController : Controller
    {
        //private HotelDbContext database;
        private readonly IMapper mapper;

        public ClientModelController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: ClientModel
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ShowAll()
        {
            List<ClientModel> list = null;

            using (var database = new LogicLL())
                list = mapper.Map<List<ClientModel>>(database.GetAllClients());

                return View(list);
        }

        // GET: ClientModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientModel/Edit/5
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

        // GET: ClientModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientModel/Delete/5
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