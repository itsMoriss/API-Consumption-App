namespace APIConsumptionApp
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public Address Address { get; set; } = new Address();
        public string Phone { get; set; } = "";
        public string Website { get; set; } = "";
        public Company Company { get; set; } = new Company();
    }

    public class Address
    {
        public string Street { get; set; } = "";
        public string Suite { get; set; } = "";
        public string City { get; set; } = "";
        public string Zipcode { get; set; } = "";
        public Geo Geo { get; set; } = new Geo();
    }

    public class Geo
    {
        public string Lat { get; set; } = "";
        public string Lng { get; set; } = "";
    }

    public class Company
    {
        public string Name { get; set; } = "";
        public string CatchPhrase { get; set; } = "";
        public string Bs { get; set; } = "";    
    }
}
