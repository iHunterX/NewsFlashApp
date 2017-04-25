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
    [Register ("DetailAgendaViewController")]
    partial class DetailAgendaViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView bottomView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton nextButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton preButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView topView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel weekLabel { get; set; }

        [Action ("MeetingDoneSwitchToggle:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void MeetingDoneSwitchToggle (UIKit.UISwitch sender);

        [Action ("NextButtonPress:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NextButtonPress (UIKit.UIButton sender);

        [Action ("PreviousButtonPress:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PreviousButtonPress (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (bottomView != null) {
                bottomView.Dispose ();
                bottomView = null;
            }

            if (nextButton != null) {
                nextButton.Dispose ();
                nextButton = null;
            }

            if (preButton != null) {
                preButton.Dispose ();
                preButton = null;
            }

            if (tableView != null) {
                tableView.Dispose ();
                tableView = null;
            }

            if (topView != null) {
                topView.Dispose ();
                topView = null;
            }

            if (weekLabel != null) {
                weekLabel.Dispose ();
                weekLabel = null;
            }
        }
    }
}