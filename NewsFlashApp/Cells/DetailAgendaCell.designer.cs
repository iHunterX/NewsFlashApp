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
    [Register ("DetailAgendaCell")]
    partial class DetailAgendaCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel authorNews { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView headLeftView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel titleNews { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (authorNews != null) {
                authorNews.Dispose ();
                authorNews = null;
            }

            if (headLeftView != null) {
                headLeftView.Dispose ();
                headLeftView = null;
            }

            if (titleNews != null) {
                titleNews.Dispose ();
                titleNews = null;
            }
        }
    }
}