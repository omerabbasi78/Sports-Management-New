﻿using Repository.Pattern;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class SportsController : BaseController
    {

        Result<int> saveResult = new Result<int>();
        ISportsService _sportsService;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public SportsController(ISportsService sportsService, IUnitOfWorkAsync unitOfWork)
        {
            _sportsService = sportsService;
            _unitOfWork = unitOfWork;
        }
        // GET: Sports
        public ActionResult Index()
        {
            IEnumerable<Sports> model = new List<Sports>();
            model = _sportsService.Queryable().data;
            return View(model);
        }

        public ActionResult Detail(int id = 0)
        {
            Result<Sports> model = new Result<Sports>();
            if (id > 0)
            {
                model = _sportsService.Find(id);
                return View(model.data);
            }

            return View(model.data);
        }

        [HttpPost]
        public ActionResult Detail(Sports model)
        {
            model.ObjectState = model.SportId > 0 ? ObjectState.Modified : ObjectState.Added;
            _sportsService.InsertOrUpdateGraph(model);
            saveResult = _unitOfWork.SaveChanges();
            if (saveResult.success)
            {
                TempData["successmessage"] = "Saved Successfully.";
            }
            else
            {
                AddErrors(saveResult.errors, saveResult.ErrorMessage);
                return View(model);
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var result = _sportsService.Delete(id);
            saveResult = _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}