using MvcBase.GlobalVar;
using MvcBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MvcBase.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<FakeModel> fakeEmplist;

            HttpResponseMessage responseMessage = GlobalVariables.webApiClient.GetAsync("Employee").Result;

            fakeEmplist = responseMessage.Content.ReadAsAsync<IEnumerable<FakeModel>>().Result;

            return View(fakeEmplist);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new FakeModel());
            }
            else
            {
                HttpResponseMessage responseMessage = GlobalVariables.webApiClient.GetAsync("Employee/" + id.ToString()).Result;
                return View(responseMessage.Content.ReadAsAsync<FakeModel>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(FakeModel fakeModel)
        {
            if (fakeModel.EmployeeID == 0)
            {
                HttpResponseMessage responseMessage = GlobalVariables.webApiClient.PostAsJsonAsync("Employee", fakeModel).Result;

                TempData["SuccessMessage"] = "Başarıyla Kaydedildi";
            }
            else
            {
                HttpResponseMessage responseMessage = GlobalVariables.webApiClient.PutAsJsonAsync("Employee/"+fakeModel.EmployeeID, fakeModel).Result;

                TempData["SuccessMessage"] = "Başarıyla Güncellendi";
            }
            return RedirectToAction("index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage responseMessage = GlobalVariables.webApiClient.DeleteAsync("Employee/" + id.ToString()).Result; 

            TempData["SuccessMessage"] = "Başarıyla Silindi";
            return RedirectToAction("index");
        }
    }
}