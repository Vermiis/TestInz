public class PromotrAddTopicViewModel
{
    public string Title { get; set; }
    public string Descripton { get; set; }
    public string TypeOf { get; set; }
    public string PromotorName { get; set; }
    public string PromotorID { get; set; }

}

public class PromotorListTopicsViewModel
{
    public string Title { get; set; }
    public string Descripton { get; set; }
    public string TypeOf { get; set; }
    public string TakenByID { get; set; }

}

public class PromotorEditTopicViewModel
{
    public string Title { get; set; }
    public string Descripton { get; set; }
    public string TypeOf { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsProposed { get; set; }

}