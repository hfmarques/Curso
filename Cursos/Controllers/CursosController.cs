using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Cursos.Models;

namespace Cursos.Controllers
{
    public class CursosController : Controller
    {
        public Models.Cursos Cursos;

        public CursosController()
        {
            var xml = XElement.Load(@"C:\Desenvolvimentos\Cursos\Arquivo Combo.xml");

            var serializer = new XmlSerializer(typeof(Models.Cursos));

            using (var stream = new StringReader(xml.ToString()))
            using (var reader = XmlReader.Create(stream))
            {
                Cursos = (Models.Cursos)serializer.Deserialize(reader);
            }
        }
        // GET: Cursos
        public ActionResult Index()
        {
            return View(Cursos);
        }

        // POST: Cursos/Create
        [HttpPost]
        public ActionResult Create(string nome)
        {
            try
            {
                Cursos.Materias.Add(new Materias()
                {
                    Codigo = Cursos.Materias.Max(x => x.Codigo) + 1,
                    Nome = nome
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
