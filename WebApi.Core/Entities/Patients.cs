namespace WebApi.Entities
{
    public class Patients
    {
        public int Id { get; set; }
        public string PatienName { get; set; }
  
        public string Status { get; set; }
         public List<Turn> Turns { get; set; }
        public List<Doctors> Doctors { get; set; }
    }
}
