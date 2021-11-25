namespace LifeGoals
{
    public class GoalObjects
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public bool Important { get; set; }

        public string Titles { get; set; }
        
        public string User { get; set; }

        public EStageImplementation StageImplementation { get; set; }
    }

    public enum EStageImplementation
    {
        created,
        startedDoing,
        isDone

    } 
    
    
}