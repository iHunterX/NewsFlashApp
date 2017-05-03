using System;
using NewsFlashApp.Helpers;
using NewsFlashApp.Models;
using UIKit;

namespace NewsFlashApp.Cells
{
    public partial class DraftNewsCell : UITableViewCell
    {
        public DraftNewsCell (IntPtr handle) : base (handle)
        {
        }

        public void SetUpCell(NewsEntity news)
        {
            titleLabel.Text = news.Title;
            topicLabel.Text = news.Topic;
            weekLabel.Text = "Week " + news.Week.ToIso8601Weeknumber() + " | " + news.Week.Year;
        }
    }
}