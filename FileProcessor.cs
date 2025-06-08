using System.Text.RegularExpressions;

namespace EE_soundset_tool
{
    public class FileProcessor
    {
        public List<string> ProcessFile(string fileName)
        {
            string exeDirectory = Application.StartupPath;
            string filePath = Path.Combine(exeDirectory, fileName);

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found.", filePath);

            string fileContent = File.ReadAllText(filePath);

            string pattern = @"    (cd_\w+) +=";
            Regex regex = new(pattern);
            MatchCollection matches = regex.Matches(fileContent);

            List<string> foundItems = new List<string>();
            foreach (Match match in matches)
                foundItems.Add(match.Groups[1].Value);

            return foundItems;
        }
    }
}
