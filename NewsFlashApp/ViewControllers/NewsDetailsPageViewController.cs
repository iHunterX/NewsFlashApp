using System;
using NewsFlashApp.Helpers;
using NewsFlashApp.Models;
using UIKit;

namespace NewsFlashApp.ViewControllers
{
    public partial class NewsDetailsPageViewController : UIViewController
    {
        public int pageIndex = 0;
        public NewsEntity News { get; set; }
        public NewsDetailsPageViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = News.Domain.ToDescription().ToUiColor();
        }
    }
}