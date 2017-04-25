using System;
using System.Collections.Generic;
using System.Linq;
using CoreFoundation;
using Foundation;
using NewsFlashApp.Cells;
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


            NewList.Add(new NewsEntity("asdasd",
                new List<AgendaEntity> { loadedList[0] },
                Helper.FromIso8601Weeknumber(20, null, DayOfWeek.Sunday),
                new List<string> { "asdas", "dasdasd" },
                "asdasdasdasdasdasdasd",
                "",
                Constant.Domain.Board
            ));
            NewList.Add(new NewsEntity("asdasd", new List<AgendaEntity> { loadedList[0], loadedList[1] }, Helper.FromIso8601Weeknumber(21, null, DayOfWeek.Sunday),
                new List<string> { "asdas", "dasdasd" }, "asdasdasdasdasdasdasd", "", Constant.Domain.Board));
            NewList.Add(new NewsEntity("asdasd", new List<AgendaEntity> { loadedList[1], loadedList[0] }, Helper.FromIso8601Weeknumber(22, null, DayOfWeek.Sunday),
                new List<string> { "asdas", "dasdasd" }, "asdasdasdasdasdasdasd", "", Constant.Domain.CorDev));
            NewList.Add(new NewsEntity("asdasd", new List<AgendaEntity> { loadedList[1], loadedList[0] }, Helper.FromIso8601Weeknumber(23, null, DayOfWeek.Sunday),
                new List<string> { "asdas", "dasdasd" }, "asdasdasdasdasdasdasd", "", Constant.Domain.GenSer));
            NewList.Add(new NewsEntity("asdasd", new List<AgendaEntity> { loadedList[0] }, Helper.FromIso8601Weeknumber(24, null, DayOfWeek.Sunday),
                new List<string> { "asdas", "dasdasd" }, "asdasdasdasdasdasdasd", "", Constant.Domain.It));
            NewList.Add(new NewsEntity("asdasd", new List<AgendaEntity> { loadedList[1], loadedList[0] }, Helper.FromIso8601Weeknumber(25, null, DayOfWeek.Sunday),
                new List<string> { "asdas", "dasdasd" }, "asdasdasdasdasdasdasd", "", Constant.Domain.Business));
            NewList.Add(new NewsEntity("asdasd", new List<AgendaEntity> { loadedList[1] }, Helper.FromIso8601Weeknumber(10, null, DayOfWeek.Sunday),
                new List<string> { "asdas", "dasdasd" }, "asdasdasdasdasdasdasd", "", Constant.Domain.AdminFine));
            DispatchQueue.MainQueue.DispatchAsync(tableView.ReloadData);
        }

    }
}