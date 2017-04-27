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
    [Register ("AgendaSearchCell")]
    partial class AgendaSearchCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel agendaLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton selectedButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (agendaLabel != null) {
                agendaLabel.Dispose ();
                agendaLabel = null;
            }

            if (selectedButton != null) {
                selectedButton.Dispose ();
                selectedButton = null;
            }
        }
    }
}