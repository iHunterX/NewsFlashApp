using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using NewsFlashApp.Models;
using Newtonsoft.Json;
using UIKit;

namespace NewsFlashApp.ViewControllers
{
    public partial class AgentdasViewController : BaseViewController
    {
        private static IEnumerable<IGrouping<string, AgendaEntity>> AgdList { get; set; }


        protected static List<string> Query { get; private set; }



        public AgentdasViewController(IntPtr handle) : base(handle)
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

            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.SetRightBarButtonItem(
                new UIBarButtonItem(UIImage.FromBundle("Add")
                    , UIBarButtonItemStyle.Plain
                    , (sender, args) => {
                        SidebarController.ToggleMenu();
                    }), true);

            AgdList = JsonConvert.DeserializeObject<List<AgendaEntity>>(Resources.Resources.AgendaList).ToArray().GroupBy(x => x.Agenda);
            Query = new List<string>();
            AgdList.ToList().ForEach(x => Query.Add(x.Key));
            tableView.Source = new AgendaTableSource(Query, this);

        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }



        class AgendaTableSource : UITableViewSource
        {
            private readonly List<string> _datalist;
            private readonly AgentdasViewController _parentView;
            string CellIdentifier = "AgentdasCellIdentifier";
            public AgendaTableSource(List<string> list, AgentdasViewController vc)
            {
                _datalist = list;
                _parentView = vc;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier) ?? new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
                string item = _datalist[indexPath.Row];
                cell.TextLabel.Text = item;
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return _datalist.Count();
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                tableView.DeselectRow(indexPath, true);
                var detailAgendaVc = (DetailAgendaViewController)_parentView.Storyboard.InstantiateViewController("DetailAgendaViewController");
                List<AgendaEntity> list =
                    JsonConvert.DeserializeObject<List<AgendaEntity>>(NewsFlashApp.Resources.Resources.AgendaList);
                List<AgendaEntity> groupedCustomerList = list.Where(u => u.Agenda == _datalist[indexPath.Row]).ToList();
                detailAgendaVc.List = groupedCustomerList;
                detailAgendaVc.NavigationItem.Title = _datalist[indexPath.Row];
                _parentView.NavController.PushViewController(detailAgendaVc, true);

            }
        }
    }
}