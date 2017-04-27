using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using NewsFlashApp.Cells;
using NewsFlashApp.Models;
using UIKit;

namespace NewsFlashApp.ViewControllers
{
    public partial class AgendaSearchViewController : UIViewController
    {
        internal List<AgendaEntity> AgendaList;
        internal List<AgendaEntity> FilteredagendaList;
        public AgendaSearchViewController(IntPtr handle) : base(handle)
        {
           AgendaList = new List<AgendaEntity> {
               new AgendaEntity {Agenda = "COMEX",IsSelected = false},
               new AgendaEntity {Agenda = "CODIR",IsSelected = false},
               new AgendaEntity {Agenda = "IT",IsSelected = false}
               };
            FilteredagendaList = new List<AgendaEntity>();
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var searchSource = new AgendaSearchSource(this);
            tableView.Source = searchSource;

            var sdc = searchDisplayController;
            sdc.SearchResultsSource = searchSource;
            sdc.SearchBar.TextChanged += (sender, e) =>
            {
                string text = e.SearchText.Trim();
                FilteredagendaList = (from agenda in AgendaList
                                       where agenda.Agenda.ToUpper().Contains(text.ToUpper())
                                       select agenda).ToList();
            };
        }



    }
    class AgendaSearchSource : UITableViewSource
    {
        public static readonly NSString CellId = new NSString("AgendaSearchCell");

        private AgendaSearchViewController searchViewController;
        private UISearchDisplayController _search;

        public AgendaSearchSource(AgendaSearchViewController searchViewController)
        {
            this.searchViewController = searchViewController;
            _search = searchViewController.searchDisplayController;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return GetAgenda().Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            AgendaSearchCell cell = (AgendaSearchCell)tableView.DequeueReusableCell(CellId);
            AgendaEntity agd = GetAgenda()[indexPath.Row];
            cell.SetUpCell(agd);

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //detailController.Title = GetFruit()[indexPath.Row].Name;
            //fruitController.NavigationController.PushViewController(detailController, true);
            AgendaEntity agd = GetAgenda()[indexPath.Row];
            agd.IsSelected = !agd.IsSelected;
        }

        private List<AgendaEntity> GetAgenda()
        {
            return _search.Active ? searchViewController.FilteredagendaList : searchViewController.AgendaList;
        }
    }
}
