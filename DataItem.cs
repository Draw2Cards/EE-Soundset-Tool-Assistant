namespace EE_soundset_tool
{
    public class DataItem
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Path { get; set; }
        public string Key { get; set; }
        public DataItem() { }
        public DataItem(string name, string text, string path, string key)
        {
            Name = name;
            Text = text;
            Path = path;
            Key = key;
        }
    }
}