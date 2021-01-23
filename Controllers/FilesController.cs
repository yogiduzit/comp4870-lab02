using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using Lab2.Models;

namespace Lab2.Controllers
{
    public class FilesController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly string PATH;

        public FilesController(IWebHostEnvironment env)
        {
            _env = env;
            PATH = Path.GetFullPath(Path.Combine(_env.WebRootPath, "..", "TextFiles")).ToString();
            Console.WriteLine(PATH);
        }
        // GET: Files
        public ActionResult Index()
        {
            FileViewModel[] files = Directory.GetFiles(PATH).Select(fileName => {
                string[] separated = fileName.Split(Path.DirectorySeparatorChar);
                string name = separated[separated.Length - 1];
                return new FileViewModel (
                    name[4] - '0',
                    name 
                );
            }).ToArray();
            return View(files);
        }

        public ActionResult Content(int id)
        {
            string text = System.IO.File.ReadAllText(Path.Combine(PATH, $"File{id}.txt"));
            ViewBag.Content = text;
            return View();
        }
    }
}