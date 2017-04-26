// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace NewsFlashApp.ViewControllers
{
    [Register ("CreateEditNewsViewController")]
    partial class CreateEditNewsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem CancelButton { get; set; }

        [Action ("CancelButtonPressed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CancelButtonPressed (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (CancelButton != null) {
                CancelButton.Dispose ();
                CancelButton = null;
            }
        }
    }
}