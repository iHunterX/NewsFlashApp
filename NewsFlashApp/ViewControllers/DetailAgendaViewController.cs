using System;
using System.Collections.Generic;
using System.Linq;
using CoreFoundation;
using Foundation;
using NewsFlashApp.Cells;
using NewsFlashApp.Helpers;
using NewsFlashApp.Models;
using UIKit;
using SWTableViewCells;

namespace NewsFlashApp.ViewControllers
{
    public partial class DetailAgendaViewController : UIViewController
    {
        public List<NewsEntity> NewList { get; set; }
        public List<AgendaEntity> List { get; set; }


        public List<NewsEntity> NewListPerWeek { get; set; }
        private int _todayweek;

        private static CellDelegate _cellDelegate;

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
            _cellDelegate = new CellDelegate(NewListPerWeek, tableView,this);
            FilterDataByWeek(_todayweek);
            NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(UIImage.FromBundle("IconBack"), UIBarButtonItemStyle.Plain, (sender, args) =>
            {
                NavigationController.PopViewController(true);
            }), true);
            NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIImage.FromBundle("Add"), UIBarButtonItemStyle.Plain, (sender, args) =>
            {
                var editVc = Storyboard.InstantiateViewController("CreateEditNewsViewController") as CreateEditNewsViewController;
                if (editVc == null) return;
                var createEditNavigationController = new UINavigationController(editVc);
                NavigationController.PresentViewController(createEditNavigationController, true, null);
            }), true);

        }

        void FilterDataByWeek(int weekInt)
        {
            NewListPerWeek = NewList.Where(x => x.Week.ToIso8601Weeknumber() == weekInt).ToList();
            weekLabel.Text = "Week " + _todayweek + " | " + DateTime.Today.Year;
            tableView.Source = new DetailTableSource(NewListPerWeek, this);
            _cellDelegate = new CellDelegate(NewListPerWeek, tableView,this);
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

        partial void MeetingDoneSwitchToggle(UISwitch sender)
        {
            throw new NotImplementedException();
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
            
            private List<NewsEntity> _datalist;
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
                if (cell.Delegate == null)
                {
                    cell.Delegate = _cellDelegate;
                    cell.SetRightUtilityButtons(RightButtons(), 58.0f);
                }
                var item = _datalist[indexPath.Row];
                cell.SetUpCell(item);
                cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return _datalist.Count();
            }


            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                var newsDetailVc = (NewsDetailsViewController)_parentView.Storyboard.InstantiateViewController("NewsDetailsViewController");
                newsDetailVc.FirstIndex = indexPath.Row;
                newsDetailVc.NewsList = _datalist;
                _parentView.NavigationController.PushViewController(newsDetailVc,true);
                tableView.DeselectRow(indexPath,false);
            }


            private static UIButton[] RightButtons()
            {
                NSMutableArray rightUtilityButtons = new NSMutableArray();
                rightUtilityButtons.AddUtilityButton(UIColor.FromRGBA(0.78f, 0.78f, 0.8f, 1.0f), "Edit");
                rightUtilityButtons.AddUtilityButton(UIColor.FromRGBA(1.0f, 0.231f, 0.188f, 1.0f), "Delete");
                return NSArray.FromArray<UIButton>(rightUtilityButtons);
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
                    Helper.RandomString(10),
                    Helper.RandomEnum<Constant.Domain>().ToFullDomain()
                    ));
            }
           ReloadDataTableView();
        }
    }

    class CellDelegate : SWTableViewCellDelegate
    {
        private List<NewsEntity> _datalist;
        private readonly UITableView tableView;
        private DetailAgendaViewController ParentView;

        public CellDelegate(List<NewsEntity> dataList, UITableView tableView,DetailAgendaViewController parentView)
        {

            this._datalist = dataList;
            this.tableView = tableView;
            this.ParentView = parentView;
        }

        public override void ScrollingToState(SWTableViewCell cell, SWCellState state)
        {
            switch (state)
            {
                case SWCellState.Center:
                    Console.WriteLine("utility buttons closed");
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;
                case SWCellState.Left:
                    Console.WriteLine("left utility buttons open");
                    break;
                case SWCellState.Right:
                    Console.WriteLine("right utility buttons open");
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
            }
        }


        public override void DidTriggerRightUtilityButton(SWTableViewCell cell, nint index)
        {
            NSIndexPath cellIndexPath = tableView.IndexPathForCell(cell);
            switch (index)
            {
                case 0:
                    // More button was pressed
                    cell.HideUtilityButtons(true);
                    var editVc = ParentView.Storyboard.InstantiateViewController("CreateEditNewsViewController") as CreateEditNewsViewController;
                    if (editVc == null) return;
                    var createEditNavigationController = new UINavigationController(editVc);
                    editVc.News = _datalist[cellIndexPath.Row];
                    ParentView.NavigationController.PresentViewController(createEditNavigationController, true, null);
                    break;
                case 1:
                    // Delete button was pressed
                    
                    _datalist.RemoveAt(cellIndexPath.Row);
                    tableView.DeleteRows(new[] { cellIndexPath }, UITableViewRowAnimation.Left);
                    break;
            }
        }

        public override bool ShouldHideUtilityButtonsOnSwipe(SWTableViewCell cell)
        {
            // allow just one cell's utility button to be open at once
            return true;
        }

        public override bool CanSwipeToState(SWTableViewCell cell, SWCellState state)
        {
            switch (state)
            {
                case SWCellState.Left:
                    // set to false to disable all left utility buttons appearing
                    return false;
                case SWCellState.Right:
                    // set to false to disable all right utility buttons appearing
                    return true;
            }
            return true;
        }
    }
}