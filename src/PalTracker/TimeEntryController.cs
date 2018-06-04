
namespace PalTracker
{
    public class TimeEntryController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ITimeEntryRepository _repo;
        public TimeEntryController(ITimeEntryRepository repo)
        {
            this._repo = repo;
        }

    }
}
