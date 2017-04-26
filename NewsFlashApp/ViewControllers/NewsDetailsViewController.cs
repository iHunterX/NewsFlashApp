using System;
using System.Collections.Generic;
using NewsFlashApp.Models;
using UIKit;

namespace NewsFlashApp.ViewControllers
{
    public partial class NewsDetailsViewController : UIViewController
    {
        public int FirstIndex;
        private UIPageViewController PageViewController { get; set; }

        public List<NewsEntity> NewsList { get; set; }
        public NewsDetailsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = Title;

            PageViewController = Storyboard.InstantiateViewController("PageViewController") as PageViewController;
            

            if (PageViewController != null)
            {
                PageViewController.DataSource = new PageViewControllerDataSource(this, NewsList);

                var startVc = ViewControllerAtIndex(FirstIndex) as NewsDetailsPageViewController;
                var viewControllers = new UIViewController[] { startVc };

                PageViewController.SetViewControllers(viewControllers, UIPageViewControllerNavigationDirection.Forward, false, null);
                PageViewController.View.Frame = View.Bounds;
                AddChildViewController(PageViewController);
                View.AddSubview(PageViewController.View);
                PageViewController.DidMoveToParentViewController(this);
            }

            NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(UIImage.FromBundle("IconBack"), UIBarButtonItemStyle.Plain, (sender, args) =>
            {
                NavigationController.PopViewController(true);
            }), true);
            NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIImage.FromBundle("Edit"), UIBarButtonItemStyle.Plain, (sender, args) =>
            {
                NavigationController.PopViewController(true);
            }), true);
        }

        public UIViewController ViewControllerAtIndex(int index)
        {
            var vc = Storyboard.InstantiateViewController("NewsDetailsPageViewController") as NewsDetailsPageViewController;
            if (vc != null)
            {
                vc.PageIndex = index;
                vc.News = NewsList[index];
                return vc;
            }
            return null;
        }

        private class PageViewControllerDataSource : UIPageViewControllerDataSource
        {
            private readonly NewsDetailsViewController _parentViewController;
            private List<NewsEntity> _newsList;

            public PageViewControllerDataSource(NewsDetailsViewController parentViewController, List<NewsEntity> newsList)
            {
                _parentViewController = parentViewController;
                _newsList = newsList;
            }

            public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
            {
                var vc = referenceViewController as NewsDetailsPageViewController;
                if (vc != null)
                {
                    var index = vc.PageIndex;
                    if (index == 0)
                    {
                        return null;
                    }
                    index--;
                    return _parentViewController.ViewControllerAtIndex(index);
                }
                return null;
            }

            public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
            {
                var vc = referenceViewController as NewsDetailsPageViewController;
                if (vc != null)
                {
                    var index = vc.PageIndex;

                    index++;
                    if (index == _newsList.Count)
                    {
                        return null;
                    }
                    return _parentViewController.ViewControllerAtIndex(index);
                }
                return null;
            }

            public override nint GetPresentationCount(UIPageViewController pageViewController)
            {
                return _newsList.Count;
            }

            public override nint GetPresentationIndex(UIPageViewController pageViewController)
            {
                return 0;
            }
        }
    }
}