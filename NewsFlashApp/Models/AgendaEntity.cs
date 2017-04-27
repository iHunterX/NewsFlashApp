using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFlashApp.Models
{
    public class AgendaEntity
    {
        public string Agenda { get; set; }

        public string Type { get; set; }

        public string Group { get; set; }

        public bool IsSelected { get; set; }

        public AgendaEntity()
        {
            
        }
    }
}
