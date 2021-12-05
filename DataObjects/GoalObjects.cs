namespace LifeGoals
{
    public class GoalObjects
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public bool Important { get; set; }

        public string Titles { get; set; }
        
        public string User { get; set; }

        public bool IsDonate { get; set; }

        public string PrivateKey { get; set; }

     
        public string PublicAddress{ get; set; }

        public string DonateValue{ get; set; }

        public bool IsPrivateDonateGoal { get; set; }

        public string MaxDonateValue{ get; set; }
        
        public EGoalStageImplementation StageImplementation { get; set; }
    }

    public enum EGoalStageImplementation
    {
        created,
        startedDoing,
        isDone

    } 
    
    
}