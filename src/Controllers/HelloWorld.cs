using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index() => "This is my default action...";

        public string Welcome(string name, int ID = 1) => HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
    }
}
