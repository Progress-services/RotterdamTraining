using SitefinityWebApp.Mvc.ViewModels;
using System.ComponentModel;

namespace SitefinityWebApp.Mvc.Models
{
    public class WebinarModel
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public WebinarViewModel FirstWebinar
        {
            get
            {
                return this.firstWebinar ?? (this.firstWebinar = new WebinarViewModel());
            }
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public WebinarViewModel SecondWebinar
        {
            get
            {
                return this.secondWebinar ?? (this.secondWebinar = new WebinarViewModel());
            }
        }


        private WebinarViewModel firstWebinar;
        private WebinarViewModel secondWebinar;
    }
}