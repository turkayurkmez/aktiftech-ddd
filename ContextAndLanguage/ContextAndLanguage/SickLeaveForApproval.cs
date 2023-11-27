namespace ContextAndLanguage
{
    public class SickLeaveForApproval
    {
        public int EmployeeId { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime FirstDayNotAWork { get; set; }
        public bool LeftDuringWorkDay { get; set; }
        public DateTime ComeBackToWork { get; set; }
        public bool ComeBackAfterLunch { get; set; }
    }

    public class SickLeaveApplication
    {
        public void Handle(SickLeaveForApproval sickLeaveForApproval)
        {
            //db'ye kaydet!
        }
    }
}
