using System;
using SidebarNavigation;
using UIKit;

namespace NewsFlashApp.ViewControllers
{
    public partial class RootViewController : UIViewController
    {
        private static UIStoryboard _storyboard;


        // the sidebar controller for the app
        public SidebarController SidebarController { get; private set; }

        // the navigation controller
        public CustomNavigationController NavController { get; private set; }

        // the storyboard
        public override UIStoryboard Storyboard { get; } = _storyboard ?? (_storyboard = UIStoryboard.FromName("Main", null));

        public RootViewController() : base(null, null)
        {


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            var agentdasVc = (AgentdasViewController)Storyboard.InstantiateViewController("AgentdasViewController");
            var menuVc = (MenuViewController)Storyboard.InstantiateViewController("MenuViewController");
            //var draftsVc = (DraftsViewController)Storyboard.InstantiateViewController("DraftsViewController");

            // create a slideout navigation controller with the top navigation controller and the menu view controller
            NavController = new CustomNavigationController();

            NavController.PushViewController(agentdasVc, false);

            SidebarController = new SidebarController(this, NavController, menuVc)
            {
                MenuWidth = 220,
                ReopenOnRotate = false,
                MenuLocation = SidebarController.MenuLocations.Left
            };
        }
    }
}