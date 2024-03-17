namespace WebApi.Entities
{
    public class Doctors
    {
        public int Id { get; set; } 
        public string NameDoctor { get; set; }  
        
        public string SpecializationDoctor { get; set; }

        public List <Turn> turnes { get; set; }
        public List<Patients> patients { get; set; }

    }
}
