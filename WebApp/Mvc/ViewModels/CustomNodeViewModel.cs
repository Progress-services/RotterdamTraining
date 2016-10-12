using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models;
using System.Web;

namespace SitefinityWebApp.Mvc.ViewModels
{
    public class CustomNodeViewModel : NodeViewModel
    {
        public CustomNodeViewModel() : base()
        {
            this.rating = this.GetRating();
        }

        public CustomNodeViewModel(SiteMapNode node, string url, string target, bool isCurrentlyOpened, bool hasChildOpen)
            : base(node, url, target, isCurrentlyOpened, hasChildOpen)
        {
            this.rating = this.GetRating();
        }

        public int Rating
        {
            get
            {
                return this.rating;
            }
        }

        private int GetRating()
        {
            var node = this.OriginalSiteMapNode as PageSiteNode;
            var rating = node.GetCustomFieldValue("Rating");

            return (rating != null) ? Decimal.ToInt32((decimal)rating) : 0;
        }

        private readonly int rating;
    }
}