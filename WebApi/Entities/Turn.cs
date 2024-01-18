namespace WebApi.Entities
{
    public class Turn
    {
        public int TurnNumber { get; set; }
        
        public string Title { get; set; }

        public DateTime DateTurn { get; set; }

        public string TypeOfDoctor { get; set; }
    }
}
