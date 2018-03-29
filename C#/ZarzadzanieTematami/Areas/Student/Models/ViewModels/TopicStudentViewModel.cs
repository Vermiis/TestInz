public class TopicReservationStudentViewModel
{
    public string TakenByID { get; set; }
    public bool IsTaken { get; set; }
}

public class TopicCreateStudentViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string PromotorName { get; set; }
    public string TypeOf { get; set; }
    public string TakenBy { get; set; }
    public bool IsProposed { get; set; }
    public bool IsTaken { get; set; }
}

public class TopicShowStudentViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string PromotorName { get; set; }
    public string TypeOf { get; set; }
    public bool IsTaken { get; set; }
}