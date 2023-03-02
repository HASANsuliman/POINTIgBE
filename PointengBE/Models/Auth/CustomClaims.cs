namespace PointengBE.Models.Auth
{
    public class CustomClaims
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Group { get; set; }

        public string? Type { get; set; }
        public string? Value { get; set; }


        public CustomClaims(string Username, string Group, string Type, string Value)
        {
            this.Username = Username;       
            this.Group = Group; 
            this.Type = Type;   
            this.Value = Value; 
        }
    }
}
