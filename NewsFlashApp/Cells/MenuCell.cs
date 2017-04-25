using System;
using System.Runtime.InteropServices;
using UIKit;

namespace NewsFlashApp.Cells
{
    public partial class MenuCell : UITableViewCell
    {
        public MenuCell(IntPtr handle) : base(handle)
        {
        }

        public void SetUpCell([Optional]string strImg, string label)
        {
            titleImage.Image = UIImage.FromBundle(strImg);
            titleLable.Text = label;
        }
    }
}
