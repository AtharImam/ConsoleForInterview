namespace TestWebApi
{
    // [JsonConverter(typeof(PersonTypeConverter))]
    public class Person
    {
        public string  FirstName { get; set; }

        public string  LastName { get; set; }
    }

    public class Doctor : Person
    {
        public string HospitalName { get; set; }
    }

    public class Student: Person
    {
        public string SchoolName { get; set; }
    }
}
