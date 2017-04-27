// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;

namespace NewsFlashApp.ViewControllers
{
    [Register ("AgendaSearchViewController")]
    partial class AgendaSearchViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        internal UIKit.UISearchDisplayController searchDisplayController { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        internal UIKit.UITableView tableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (searchDisplayController != null) {
                searchDisplayController.Dispose ();
                searchDisplayController = null;
            }

            if (tableView != null) {
                tableView.Dispose ();
                tableView = null;
            }
        }
    }
}