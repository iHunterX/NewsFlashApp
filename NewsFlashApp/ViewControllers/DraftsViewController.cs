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
        public List<NewsEntity> NewsList;
        TableSource tableSource;
        public DraftsViewController(IntPtr handle) : base(handle)
        {
            NewsList = new List<NewsEntity>();
            List<AgendaEntity> list = new List<AgendaEntity> {
               new AgendaEntity {Agenda = "COMEX",IsSelected = false},
               new AgendaEntity {Agenda = "CODIR",IsSelected = false},
               new AgendaEntity {Agenda = "IT",IsSelected = false}
               };
            int num = Helper.GetRandomNumber(1, 20);
            for (int i = 1; i <= num; i++)
            {
                NewsList.Add(new NewsEntity("NewFlash", list,
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
            for (int i = 1; i <= num; i++)
            {
                NewsList.Add(new NewsEntity("ABC", list,
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
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            tableSource = new TableSource(this,NewsList);
            // Perform any additional setup after loading the view, typically from a nib.
            tableView.Source = tableSource;

            searchBar = new UISearchBar {Placeholder = "Enter Search Text"};
            searchBar.SizeToFit();
            searchBar.AutocorrectionType = UITextAutocorrectionType.No;
            searchBar.AutocapitalizationType = UITextAutocapitalizationType.None;
            searchBar.TextChanged += (sender, e) =>
            {
                SearchTable();
            };
            searchBar.CancelButtonClicked += (sender, args) =>
            {
                searchBar.BecomeFirstResponder();
            };


            tableView.TableHeaderView = searchBar;

        }
        private void SearchTable()
        { 
            tableSource.PerformSearch(searchBar.Text);
            tableView.ReloadData();
        }
    }
    

    class TableSource : UITableViewSource
    {
        private DraftsViewController parentViewController;
        private List<NewsEntity> newsList = new List<NewsEntity>();
        private List<NewsEntity> searchNewsList = new List<NewsEntity>();


        public TableSource(DraftsViewController parentViewController, List<NewsEntity> listNews)
        {
            this.parentViewController = parentViewController;
            this.newsList = listNews;
            this.searchNewsList = newsList;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return searchNewsList.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            DraftNewsCell cell = (DraftNewsCell)tableView.DequeueReusableCell("DraftNewsCell");

            NewsEntity news = searchNewsList[indexPath.Row];
            cell.SetUpCell(news);
                
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //var vc = new SearchItemViewController() { Item = controller.searchResults[indexPath.Row] };
            //controller.NavigationController.PushViewController(vc, true);
        }

        public void PerformSearch(string searchText)
        {
            searchText = searchText.ToLower();
            this.searchNewsList = newsList.Where(x => x.Title.ToLower().Contains(searchText)).ToList();
        }
    }
}