using System;
using NewsFlashApp.Models;
using UIKit;

namespace NewsFlashApp.ViewControllers
{
    public partial class CreateEditNewsViewController : UITableViewController
    {
        public NewsEntity News { get; set; }
        public bool IsEdit = false; 

        public CreateEditNewsViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(UIImage.FromBundle("IconBack"), UIBarButtonItemStyle.Plain, (sender, args) =>
            {
                NavigationController.PopViewController(true);
            }), true);

        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return section == 3 && !IsEdit ? (nfloat) 0.1 : base.GetHeightForHeader(tableView, section);
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            if (section != 3) return base.RowsInSection(tableView, section);
            return IsEdit ? 1 : 0;
        }

        public override nfloat GetHeightForFooter(UITableView tableView, nint section)
        {
            return section == 3 && !IsEdit ? (nfloat) 0.1 : base.GetHeightForFooter(tableView, section);
        }
    }
}