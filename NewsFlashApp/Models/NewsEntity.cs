using System;
using System.Collections.Generic;
using NewsFlashApp.Helpers;


namespace NewsFlashApp.Models
{
    public class NewsEntity
    {

        public string Title { get; private set; }

        public List<AgendaEntity> AudAgendas { get; private set; }

        public DateTime Week { get; private set; }

        public string WebLink { get; private set; }

        public List<string> Officialisations { get; private set; }

        public string Description { get; private set; }

        public Constant.Domain Domain { get; private set; }

        public string Author { get; private set; }

        public bool IsDraft { get; private set; }

        public bool Selected { get; private set; }

        public string Topic { get; private set; }

        public NewsEntity(string title, List<AgendaEntity> audAgendas, DateTime week, List<string> officialisations, string description, string webLink, Constant.Domain domain, string author, string topic, bool selected = false, bool isDraft = false)
        {
            Title = title;
            AudAgendas = audAgendas;
            Week = week;
            Officialisations = officialisations;
            Description = description;
            WebLink = webLink;
            Author = author;
            Topic = topic;
            Selected = selected;
            IsDraft = isDraft;
            Domain = domain;
        }
    }
}