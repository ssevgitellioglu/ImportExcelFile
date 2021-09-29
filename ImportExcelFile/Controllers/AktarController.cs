using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImportExcelFile.Controllers
{
    public class AktarController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VarlikAktar()
        {
            try
            {
                //  Get all files from Request object  
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                    HttpPostedFileBase file = files[i];
                    string fname;
                    fname = file.FileName;
                    fname = Path.Combine(Server.MapPath("~/Aktarim/"), fname);
                    file.SaveAs(fname);
                    //ExcelOku(fname);
                }


                return Json("File Uploaded Successfully!");

            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }

        }
    }
}