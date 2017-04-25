// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace NewsFlashApp.Cells
{
    [Register ("MenuCell")]
    partial class MenuCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView titleImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel titleLable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (titleImage != null) {
                titleImage.Dispose ();
                titleImage = null;
            }

            if (titleLable != null) {
                titleLable.Dispose ();
                titleLable = null;
            }
        }
    }
}