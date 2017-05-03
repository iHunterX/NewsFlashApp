using System;
using UIKit;

namespace NewsFlashApp.ViewControllers
{
    public partial class BaseViewController : UIViewController
    {
        protected SidebarNavigation.SidebarController SidebarController => (UIApplication.SharedApplication.Delegate as AppDelegate)?.RootViewController.SidebarController;

        // provide access to the navigation controller to all inheriting controllers
        protected CustomNavigationController NavController => (UIApplication.SharedApplication.Delegate as AppDelegate)?.RootViewController.NavController;

        // provide access to the storyboard to all inheriting controllers
        public override UIStoryboard Storyboard => (UIApplication.SharedApplication.Delegate as AppDelegate)?.RootViewController.Storyboard;

        public BaseViewController(IntPtr handle) : base(handle)
        {

        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = Title;
            NavigationItem.SetLeftBarButtonItem(
                new UIBarButtonItem(UIImage.FromBundle("Masternav")
                    , UIBarButtonItemStyle.Plain
                    , (sender, args) => {
                        SidebarController.ToggleMenu();
                    }), true);

            NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIImage.FromBundle("Add"), UIBarButtonItemStyle.Plain, (sender, args) =>
            {
                var editVc = Storyboard.InstantiateViewController("CreateEditNewsViewController") as CreateEditNewsViewController;
                if (editVc == null) return;
                var createEditNavigationController = new UINavigationController(editVc);
                NavController.PresentViewController(createEditNavigationController, true, null);
            }), true);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

        }
    }
}