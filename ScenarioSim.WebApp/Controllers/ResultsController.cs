using System.Collections.Generic;
using System.Web.Mvc;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.WebApp.Controllers
{
    public class ResultsController : Controller
    {
        private readonly IScenarioResultRepository resultRepository;

        public ResultsController(IScenarioResultRepository resultRepository)
        {
            this.resultRepository = resultRepository;
        }

        // GET: Results
        public ActionResult Index()
        {
            IEnumerable<ScenarioResult> results = resultRepository.GetAllResults();
            return View(results);
        }

        // GET: Results/Details/5
        public ActionResult Details(int id)
        {
            ScenarioResult result = resultRepository.GetResult(id);
            return View(result);
        }

        // GET: Results/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Results/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ScenarioResult result = new ScenarioResult();
                resultRepository.UpdateResult(id, result);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Results/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Results/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                resultRepository.RemoveResult(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
