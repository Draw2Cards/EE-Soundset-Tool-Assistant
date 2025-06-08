namespace EE_soundset_tool
{
    public class Structure
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Suffix { get; set; }
        public string Description { get; set; }
        public string Tip { get; set; }

        public Structure(string name, int id, string suffix, string description, string tip = "")
        {
            Name = name;
            Id = id;
            Suffix = suffix;
            Description = description;
            Tip = tip;
        }
    }
}
