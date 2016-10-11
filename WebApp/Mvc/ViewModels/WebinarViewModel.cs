using System;

namespace SitefinityWebApp.Mvc.ViewModels
{
    public class WebinarViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}