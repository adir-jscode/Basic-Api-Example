namespace BasicApiExample.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public string PatientType { get; set; }

        public string Bedum { get; set;}
        public string Diagnosis { get; set; }
    }
}
