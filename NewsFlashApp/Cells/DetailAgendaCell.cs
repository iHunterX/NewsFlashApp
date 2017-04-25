using System;
using NewsFlashApp.Helpers;
using NewsFlashApp.Models;
using UIKit;

namespace NewsFlashApp.Cells
{
    public partial class DetailAgendaCell : UITableViewCell
    {
        public DetailAgendaCell(IntPtr handle) : base(handle)
        {
        }

        public void SetUpCell(NewsEntity news)
        {
            headLeftView.BackgroundColor = news.Domain.ToDescription().ToUiColor();
            authorNews.Text = news.Author;
            titleNews.Text = news.Title;
        }
    }
}
