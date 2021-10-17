namespace DefaultValueInjection.Model
{
    public class UserProfile
    {
        public string FirstName {  get; set; }
        public string LastName {  get; set; }

        public Preference Preference { get; set; }
    }

    public class Preference
    {
        public string Language { get; set; }
        public string Theme { get; set; }
    }
}
