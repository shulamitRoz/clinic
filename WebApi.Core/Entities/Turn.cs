namespace WebApi.Entities
{
    public class Turn
    {
        public int Id { get; set; }
        public int TurnNumber { get; set; }
        
        public string Title { get; set; }

        public DateTime DateTurn { get; set; }

        public string TypeOfDoctor { get; set; }
        public int DoctorID { get; set; }   
        public Doctors Doctor { get; set; }
        public Patients Patient { get; set; }
    }
}
