using System;
using NewsFlashApp.Helpers;
using NewsFlashApp.Models;
using SWTableViewCells;
using UIKit;

namespace NewsFlashApp.Cells
{
    public partial class DetailAgendaCell : SWTableViewCell
    {
        public DetailAgendaCell(IntPtr handle) : base(handle)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            //var pan = new UISwipeGestureRecognizer { CancelsTouchesInView = false,Direction = UISwipeGestureRecognizerDirection.Left,Delegate = this};
            //AddGestureRecognizer(pan);
        }

        public void SetUpCell(NewsEntity news)
        {
            headLeftView.BackgroundColor = news.Domain.ToDescription().ToUiColor();
            authorNews.Text = news.Author;
            titleNews.Text = news.Title;
            
        }
    }
}
