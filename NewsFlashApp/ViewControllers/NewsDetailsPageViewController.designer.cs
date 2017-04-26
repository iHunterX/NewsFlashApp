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
    [Register ("NewsDetailsPageViewController")]
    partial class NewsDetailsPageViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel audienceAgendasLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel audienceComLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel authorLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView newDescriptionTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel titlelabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel topicLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel weekLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (audienceAgendasLabel != null) {
                audienceAgendasLabel.Dispose ();
                audienceAgendasLabel = null;
            }

            if (audienceComLabel != null) {
                audienceComLabel.Dispose ();
                audienceComLabel = null;
            }

            if (authorLabel != null) {
                authorLabel.Dispose ();
                authorLabel = null;
            }

            if (newDescriptionTextView != null) {
                newDescriptionTextView.Dispose ();
                newDescriptionTextView = null;
            }

            if (titlelabel != null) {
                titlelabel.Dispose ();
                titlelabel = null;
            }

            if (topicLabel != null) {
                topicLabel.Dispose ();
                topicLabel = null;
            }

            if (weekLabel != null) {
                weekLabel.Dispose ();
                weekLabel = null;
            }
        }
    }
}