using ImageSaveIntoDB.IService;
using ImageSaveIntoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSaveIntoDB.Controllers
{
    public class HomeController : Controller
    {
        IStudentService _studentService = null;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string SaveFile(FileUpload fileObj)
        {
            Student ostudent = JsonConvert.DeserializeObject<Student>(fileObj.Student);

            if (fileObj.file.Length > 0)
            {
                using (var ms=new MemoryStream())
                {
                    fileObj.file.CopyTo(ms);
                    var fileBytes=ms.ToArray();
                    ostudent.Photo=fileBytes;

                    ostudent = _studentService.Save(ostudent);
                    if (ostudent.StudentID > 0)
                    {
                        return "Saved";
                    }
                }
            }
            return "Failed"; 
        }

        [HttpGet]
        public JsonResult GetSavedStudent()
        {
            var student=_studentService.GetSavedStudent();
            student.Photo = this.GetImage(Convert.ToBase64String(student.Photo));
            return Json(student);
        }

        public byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
        }
    }
}
