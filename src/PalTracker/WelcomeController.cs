using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/")]
    public class WelcomeController : Controller
    {
        private readonly WelcomeMessage _message;
        private readonly CloudFoundryInfo _info;
        [HttpGet]
        public string SayHello() => _message.Message ;//+ " params = " /*+ _info.Port + " memory " + _info.MemoryLimit*/;

        public WelcomeController(WelcomeMessage message /*, CloudFoundryInfo info*/)
        {
            _message = message;
           // _info = info;
        }
    }
}