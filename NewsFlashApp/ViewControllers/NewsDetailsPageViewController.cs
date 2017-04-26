using System;
using System.Linq;
using AssetsLibrary;
using Foundation;
using NewsFlashApp.Helpers;
using NewsFlashApp.Models;
using UIKit;

namespace NewsFlashApp.ViewControllers
{
    public partial class NewsDetailsPageViewController : UIViewController
    {
        public int PageIndex = 0;
        public NewsEntity News { get; set; }
        public NewsDetailsPageViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            SetUpUi();
            SetData(News);
        }

        void SetData(NewsEntity news)
        {
            topicLabel.BackgroundColor = news.Domain.ToDescription().ToUiColor();
            news.AudAgendas.ForEach(entity => audienceAgendasLabel.Text += string.Join(", ",entity.Agenda).ToString());
            topicLabel.Text = news.Domain.ToFullDomain();
            titlelabel.Text = news.Title;
            weekLabel.Text =  "Week " + news.Week.ToIso8601Weeknumber() + " | " + news.Week.Year;
            newDescriptionTextView.Text = news.Description;
            authorLabel.Text = "By " + news.Author;
            news.AudAgendas.ForEach(entity => audienceComLabel.Text += string.Join(", ", entity.Agenda).ToString());

        }


        void SetUpUi()
        {
            topicLabel.Layer.BorderColor = UIColor.LightGray.CGColor;
            topicLabel.TextColor = UIColor.White;
            audienceAgendasLabel.TextColor = UIColor.LightGray;
            weekLabel.TextColor = UIColor.LightGray;
            newDescriptionTextView.Editable = false;
            audienceAgendasLabel.Text = "Audience Agenda: ";
            audienceComLabel.Text = "Audience Communicaiton: ";

        }
    }
}