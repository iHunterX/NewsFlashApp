using System;
using System.Collections.Generic;
using NewsFlashApp.Helpers;


namespace NewsFlashApp.Models
{
    public class NewsEntity
    {

        public string Title { get; private set; }

        public List<AgendaEntity> AudAgendas { get; private set; }

        public DateTimeOffset Week { get; private set; }

        public string WebLink { get; private set; }

        public List<string> Officialisations { get; private set; }

        public string Description { get; private set; }

        public Constant.Domain Domain { get; private set; }

        public string Author { get; private set; }


        public NewsEntity(string title, List<AgendaEntity> audAgendas, DateTimeOffset week, List<string> officialisations, string description, string webLink, Constant.Domain domain, string author)
        {
            Title = title;
            AudAgendas = audAgendas;
            Week = week;
            Officialisations = officialisations;
            Description = description;
            WebLink = webLink;
            Author = author;
            Domain = domain;
        }
    }
}