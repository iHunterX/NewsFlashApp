using System;
using System.Collections.Generic;
using CoreGraphics;
using NewsFlashApp.Models;
using UIKit;

namespace NewsFlashApp.ViewControllers
{
    public partial class NewsDetailsViewController : UIViewController
    {
        public int FirstIndex;
        private UIPageViewController _pageViewController { get; set; }

        public List<NewsEntity> NewsList { get; set; }
        public NewsDetailsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = Title;

            _pageViewController = this.Storyboard.InstantiateViewController("PageViewController") as PageViewController;
            

            if (_pageViewController != null)
            {
                _pageViewController.DataSource = new PageViewControllerDataSource(this, NewsList);

                var startVc = this.ViewControllerAtIndex(FirstIndex) as NewsDetailsPageViewController;
                var viewControllers = new UIViewController[] { startVc };

                _pageViewController.SetViewControllers(viewControllers, UIPageViewControllerNavigationDirection.Forward, false, null);
                _pageViewController.View.Frame = new CGRect(0, 64, View.Frame.Width, View.Frame.Size.Height);
                AddChildViewController(_pageViewController);
                View.AddSubview(_pageViewController.View);
                _pageViewController.DidMoveToParentViewController(this);
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
            var vc = this.Storyboard.InstantiateViewController("NewsDetailsPageViewController") as NewsDetailsPageViewController;
            vc.pageIndex = index;
            vc.News = NewsList[index];
            return vc;
        }

        private class PageViewControllerDataSource : UIPageViewControllerDataSource
        {
            private NewsDetailsViewController _parentViewController;
            private List<NewsEntity> _newsList;



            public PageViewControllerDataSource(NewsDetailsViewController parentViewController, List<NewsEntity> newsList)
            {
                _parentViewController = parentViewController as NewsDetailsViewController;
                _newsList = newsList;
            }

            public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
            {
                var vc = referenceViewController as NewsDetailsPageViewController;
                if (vc != null)
                {
                    var index = vc.pageIndex;
                    if (index == 0)
                    {
                        return null;
                    }
                    else
                    {
                        index--;
                        return _parentViewController.ViewControllerAtIndex(index);
                    }
                }
                else
                {
                    return null;
                }
            }

            public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
            {
                var vc = referenceViewController as NewsDetailsPageViewController;
                var index = vc.pageIndex;

                index++;
                if (index == _newsList.Count)
                {
                    return null;
                }
                else
                {
                    return _parentViewController.ViewControllerAtIndex(index);
                }
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