
using System;

namespace PalTracker
{
    public class TimeEntryController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ITimeEntryRepository _repo;
        public TimeEntryController(ITimeEntryRepository repo)
        {
            this._repo = repo;
        }

        public object Create(TimeEntry toCreate)
        {
            throw new NotImplementedException();
        }

        public object List()
        {
            throw new NotImplementedException();
        }

        public object Update(int v, TimeEntry theUpdate)
        {
            throw new NotImplementedException();
        }

        public object Delete(int v)
        {
            throw new NotImplementedException();
        }

        public object Read(int v)
        {
            throw new NotImplementedException();
        }
    }
}
