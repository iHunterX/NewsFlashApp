using System;
using System.Collections.Generic;
using System.Linq;
using CoreFoundation;
using Foundation;
using NewsFlashApp.Cells;
using NewsFlashApp.Helpers;
using NewsFlashApp.Models;
using UIKit;

namespace NewsFlashApp.ViewControllers
{
    public partial class DetailAgendaViewController : UIViewController
    {
        public List<NewsEntity> NewList { get; set; }
        public List<AgendaEntity> List { get; set; }

        public List<NewsEntity> NewListPerWeek { get; set; }
        private int _todayweek;

        public DetailAgendaViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NewList = new List<NewsEntity>();

            //NewListPerWeek = new List<NewsEntity>();

            CreateData(List);

            _todayweek = DateTime.Today.ToIso8601Weeknumber();
            tableView.Source = new DetailTableSource(NewListPerWeek, this);
            FilterDataByWeek(_todayweek);
            // Perform any additional setup after loading the view, typically from a nib.
        }

        void FilterDataByWeek(int weekInt)
        {

            NewListPerWeek = NewList.Where(x => x.Week.ToIso8601Weeknumber() == weekInt).ToList();
            //UIAlertController okAlertController = UIAlertController.Create("Row count", NewListPerWeek.Count.ToString(), UIAlertControllerStyle.Alert);
            //okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            //PresentViewController(okAlertController,true,null);
            weekLabel.Text = "Week " + _todayweek + " | " + DateTime.Today.Year;
            tableView.Source = new DetailTableSource(NewListPerWeek, this);
            ReloadDataTableView();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

        }

        partial void NextButtonPress(UIButton sender)
        {
            _todayweek ++;
            if (_todayweek > Helper.GetWeeksInYear(DateTime.Today.Year))
            {
                _todayweek = Helper.GetWeeksInYear(DateTime.Today.Year);
            }
            FilterDataByWeek(_todayweek);
            
        }

        partial void PreviousButtonPress(UIButton sender)
        {
            _todayweek--;
            if (_todayweek < 1)
            {
                _todayweek = 1;
            }
            FilterDataByWeek(_todayweek);
        }

        private void ReloadDataTableView()
        {
            DispatchQueue.MainQueue.DispatchAsync(tableView.ReloadData);
        }

        class DetailTableSource : UITableViewSource
        {
            public List<NewsEntity> _datalist;
            private readonly DetailAgendaViewController _parentView;
            string CellIdentifier = "DetailAgendaCell";
            public DetailTableSource(List<NewsEntity> list, DetailAgendaViewController vc)
            {
                _datalist = list;
                _parentView = vc;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                DetailAgendaCell cell = (DetailAgendaCell)(tableView.DequeueReusableCell(CellIdentifier));
                var item = _datalist[indexPath.Row];
                cell.Layer.AnchorPointZ = indexPath.Row;
                cell.SetUpCell(item);
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return _datalist.Count();
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {

            }
        }

        public void CreateData(List<AgendaEntity> loadedList)
        {
            int num = Helper.GetRandomNumber(1, 20);
            for (int i = 1; i <= num; i++)
            {
                NewList.Add(new NewsEntity("NewFlash", loadedList,
                    Helper.FromIso8601Weeknumber(Helper.GetRandomNumber(14, 18), null,
                        Helper.RandomEnum<DayOfWeek>()),
                    new List<string> {"asdas", "dasdasd"},
                    Helper.RandomString(100),
                    Helper.RandomString(10),
                    Helper.RandomEnum<Constant.Domain>(),
                    Helper.RandomString(10)));
            }
           ReloadDataTableView();
            
            
        }

    }
}