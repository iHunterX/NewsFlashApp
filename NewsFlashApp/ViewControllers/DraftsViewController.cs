using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using NewsFlashApp.Cells;
using NewsFlashApp.Helpers;
using NewsFlashApp.Models;
using UIKit;

namespace NewsFlashApp.ViewControllers
{
    public partial class DraftsViewController : BaseViewController
    {
        UISearchBar searchBar;
        public List<NewsEntity> newList;
        public List<NewsEntity> searchResults;
        public bool IsSearching = false;
        public DraftsViewController(IntPtr handle) : base(handle)
        {
            newList = new List<NewsEntity>();
            List<AgendaEntity> list = new List<AgendaEntity> {
               new AgendaEntity {Agenda = "COMEX",IsSelected = false},
               new AgendaEntity {Agenda = "CODIR",IsSelected = false},
               new AgendaEntity {Agenda = "IT",IsSelected = false}
               };
            int num = Helper.GetRandomNumber(1, 20);
            for (int i = 1; i <= num; i++)
            {
                newList.Add(new NewsEntity("NewFlash", list,
                    Helper.FromIso8601Weeknumber(Helper.GetRandomNumber(14, 18), null,
                        Helper.RandomEnum<DayOfWeek>()),
                    new List<string> { "asdas", "dasdasd" },
                    Helper.RandomString(100),
                    Helper.RandomString(10),
                    Helper.RandomEnum<Constant.Domain>(),
                    Helper.RandomString(10),
                    Helper.RandomEnum<Constant.Domain>().ToFullDomain()
                    ));
            }
            searchResults = new List<NewsEntity>();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            
            // Perform any additional setup after loading the view, typically from a nib.
            tableView.Source = new TableSource(this);

            searchBar = new UISearchBar();
            searchBar.Placeholder = "Enter Search Text";
            searchBar.SizeToFit();
            searchBar.AutocorrectionType = UITextAutocorrectionType.No;
            searchBar.AutocapitalizationType = UITextAutocapitalizationType.None;
            searchBar.SearchButtonClicked += (sender, e) =>
            {
                string text = searchBar.Text.Trim();

                searchResults = (from news in searchResults
                                 where news.Topic.ToUpper().Contains(text.ToUpper()) ||
                                        news.Author.ToUpper().Contains(text.ToUpper())
                                 select news).ToList();
                IsSearching = true;
                tableView.ReloadData();
            };

            tableView.TableHeaderView = searchBar;

        }
    }

    class TableSource : UITableViewSource
    {
        private DraftsViewController parentViewController;
        

        public TableSource(DraftsViewController parentViewController)
        {
            this.parentViewController = parentViewController;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return GetNews().Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            AgendaSearchCell cell = (AgendaSearchCell)tableView.DequeueReusableCell("AgendaSearchCell");

            cell.TextLabel.Text = GetNews()[indexPath.Row].Title;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //var vc = new SearchItemViewController() { Item = controller.searchResults[indexPath.Row] };
            //controller.NavigationController.PushViewController(vc, true);
        }

        private List<NewsEntity> GetNews()
        {
            return parentViewController.IsSearching ? parentViewController.searchResults : parentViewController.newList;
        }
    }
}