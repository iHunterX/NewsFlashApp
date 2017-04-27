using System;
using NewsFlashApp.Models;
using UIKit;

namespace NewsFlashApp.Cells
{
    public partial class AgendaSearchCell : UITableViewCell
    {

        public AgendaSearchCell (IntPtr handle) : base (handle)
        {
            selectedButton.Layer.CornerRadius = selectedButton.Frame.Width/2;
            selectedButton.Layer.BorderWidth = 2;
            selectedButton.Layer.BorderColor = UIColor.Black.CGColor;
        }

        public void SetUpCell(AgendaEntity agd)
        {
            agendaLabel.Text = agd.Agenda;
        }
    }
}