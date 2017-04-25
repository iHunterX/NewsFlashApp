using System;
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
            headLeftView.BackgroundColor = news.Domain.ToDescription().ToUIColor();
        }
    }
}
