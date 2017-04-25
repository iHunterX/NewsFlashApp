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
            CreateData(List);
            tableView.Source = new DetailTableSource(NewList, this);

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

        }

        class DetailTableSource : UITableViewSource
        {
            private readonly List<NewsEntity> _datalist;
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
                    Helper.FromIso8601Weeknumber(Helper.GetRandomNumber(1, Helper.GetWeeksInYear(2016)), null,
                        Helper.RandomEnum<DayOfWeek>()),
                    new List<string> {"asdas", "dasdasd"},
                    Helper.RandomString(100),
                    Helper.RandomString(10),
                    Helper.RandomEnum<Constant.Domain>(),
                    Helper.RandomString(10)));
            }
           
            
            DispatchQueue.MainQueue.DispatchAsync(tableView.ReloadData);
        }

    }
}