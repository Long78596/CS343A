﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebDatMonAn.Models;
using WebDatMonAn.Repository;

namespace WebDatMonAn.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _dataContext = context;
            _logger = logger;
        }

        public IActionResult Index()

        {
            var monan = _dataContext.MonAns.Include(c => c.DanhMuc).AsNoTracking().OrderBy(x => x.NgayTao).ToList();
            return View(monan);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}