using zarzadzanieTematami.Models;

namespace zarzadzanieTematami.Areas.Promotor.Models.ViewModels
{

    public class TopicsAcceptViewModel
    {
        public TopicsAcceptViewModel() { }

        public TopicsAcceptViewModel(Topics topic)
        {
            this.ID = topic.ID;
            this.Title = topic.Title;
            this.Details = topic.Details;
            this.Commentary = topic.Commentary;
            this.IsAccepted = topic.IsAccepted;
            this.IsRejected = topic.IsRejected;

        }

        public int ID { get; private set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Commentary { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }
    }
}