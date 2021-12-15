using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplication1.DataContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        static HttpClient client = new HttpClient();
        public JsonResult treatments;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {

            using (StreamReader r = new StreamReader(System.IO.File.OpenRead(@"c:\json\file.json")))
            {
                string json = r.ReadToEnd();

                List<Consulta> consulta = JsonConvert.DeserializeObject<List<Consulta>>(json);
                int con = consulta.Count;

                for (int i = 0; i < con; i++)
                {

                    Patient patient = (Patient)consulta[i].patient;
                    HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:31034/api/Patients", patient);

                    List<Answers> answers = (List<Answers>)consulta[i].answers;
                    int ans = consulta[i].answers.Count;

                    for (int a = 0; a < ans; a++)
                    {
                        HttpResponseMessage response1 = await client.PostAsJsonAsync("http://localhost:31034/api/Answers", answers[a]);
                    }

                    CheckList checkList = (CheckList)consulta[i].checkList;
                    HttpResponseMessage response2 = await client.PostAsJsonAsync("http://localhost:31034/api/CheckLists", checkList);

                    List<AnswerTypes> answerTypes = (List<AnswerTypes>)consulta[i].checkList.AnswerTypes;
                    int ansT = consulta[i].checkList.AnswerTypes.Count;

                    for (int l = 0; l < ansT; l++)
                    {
                        HttpResponseMessage response3 = await client.PostAsJsonAsync("http://localhost:31034/api/AnswerTypes", answerTypes[l]);
                    }

                    List<Levels> levels = (List<Levels>)consulta[i].checkList.Levels;
                    int lev = consulta[i].checkList.Levels.Count;

                    for (int l = 0; l < lev; l++)
                    {
                        HttpResponseMessage response4 = await client.PostAsJsonAsync("http://localhost:31034/api/Levels", levels[l]);

                        List<Sections> sections = (List<Sections>)consulta[i].checkList.Levels[l].Sections;
                        int sec = consulta[i].checkList.Levels[l].Sections.Count;

                        for (int s = 0;s < sec; s++)
                        {
                            HttpResponseMessage response5 = await client.PostAsJsonAsync("http://localhost:31034/api/Sections", sections[s]);

                            List<Questions> questions = (List<Questions>)consulta[i].checkList.Levels[l].Sections[s].Questions;
                            int que = consulta[i].checkList.Levels[l].Sections[s].Questions.Count;

                            for (int q = 0; q < que; q++)
                            {
                                HttpResponseMessage response6 = await client.PostAsJsonAsync("http://localhost:31034/api/Questions", questions[q]);
                            }
                        }
                    }
                }
            }
            return View();
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
