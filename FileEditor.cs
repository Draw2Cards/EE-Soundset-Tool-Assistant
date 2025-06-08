namespace EE_soundset_tool
{
    internal class FileEditor
    {
        public FileEditor()
        {
        }

        private string mainFolderName = "cd_soundsets";
        private string modName = "Bob";
        private string shortName = "bob";
        private string authorName = "bob";

        public bool Edit(List<DataItem> dataItems, string fullName, string authorText)
        {
            bool result = false;
            dataItems.RemoveAll(item => string.IsNullOrWhiteSpace(item.Path));
            if (dataItems.Count == 0)   
                return false;

            if(fullName.Length > 0)
            {
                modName = fullName;
                string cleaned = modName.ToLower().Replace(" ", "");
                shortName = cleaned.Substring(0, Math.Min(6, cleaned.Length));
            }      
            if (authorText.Length > 0) 
                authorName = authorText;

            return EditTp2File(dataItems) && EditTraFile(dataItems) && CopySounds(dataItems) && ReplaceSoundsetsText();
        }

        private bool ReplaceSoundsetsText()
        {
            string originalFile = "setup-cd_soundsets.exe";
            string newFile = $"setup-cd_{shortName}.exe";

            string originalFolder = "cd_soundsets";
            string newFolder = $"cd_{shortName}";

            string originalFile2 = "cd_soundsets\\cd_soundsets.tp2";
            string newFile2 = $"cd_soundsets\\cd_{shortName}.tp2";

            try
            {
                File.Move(originalFile, newFile);
                File.Move(originalFile2, newFile2);
                Directory.Move(originalFolder, newFolder);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool CopySounds(List<DataItem> dataItems)
        {
            try
            {
                foreach (var item in dataItems)
                {
                    var matchingStructure = Program.Structures
                        .FirstOrDefault(structure => structure.Name == item.Key);

                    if (matchingStructure != null)
                    {
                        string sourceSound = item.Path;
                        string destinationSound;
                        if (matchingStructure.Suffix.Length == 1)
                            destinationSound = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mainFolderName + "\\sounds", shortName + matchingStructure.Suffix + ".wav");
                        else
                            destinationSound = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mainFolderName + "\\wav", shortName + matchingStructure.Suffix + ".wav");

                        try
                        {
                            File.Copy(sourceSound, destinationSound, overwrite: true);
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }


        }

        private bool EditTp2File(List<DataItem> dataItems)
        {
            try
            {
                string filePath = mainFolderName + "\\cd_soundsets.tp2";
                var lines = File.ReadAllLines(filePath).ToList(); ;
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].StartsWith("BACKUP ~"))
                    {
                        lines[i] = $"BACKUP ~cd_{shortName}/backup~";
                    }
                    else if (lines[i].StartsWith("AUTHOR ~"))
                    {
                        lines[i] = $"AUTHOR ~{authorName}~";
                    }
                    else if (lines[i].TrimStart().StartsWith("INT_VAR "))
                    {
                        i = AddRefs(dataItems, lines, i);
                    }
                    else if (lines[i].TrimStart().StartsWith("cd_"))
                    {
                        lines.RemoveAt(i--);
                    }
                    else if (lines[i].TrimStart().StartsWith("STR_VAR cd_name"))
                    {
                        lines[i] = $"STR_VAR cd_name = \"{shortName.ToUpper()}\"";
                    }
                }
                File.WriteAllLines(filePath, lines);
                return true;
            }
            catch
            {
                return false;
            }

        }

        private int AddRefs(List<DataItem> dataItems, List<string> lines, int i)
        {
            foreach (var item in dataItems)
            {
                var matchingStructure = Program.Structures
                    .FirstOrDefault(structure => structure.Name == item.Key);

                if (matchingStructure != null)
                    lines.Insert(++i, $"{matchingStructure.Name}=RESOLVE_STR_REF(@{matchingStructure.Id})");
            }
            lines.Insert(++i, $"cd_select_name = RESOLVE_STR_REF(@70)");
            return i;
        }

        private bool EditTraFile(List<DataItem> dataItems)
        {
            try
            {
                string filePath = mainFolderName + "\\english" + "\\setup.tra";
                var lines = File.ReadAllLines(filePath).ToList(); ;
                lines.Clear();
                lines.Add($"@0 = ~{modName} Soundset~");
                foreach (var item in dataItems)
                {
                    var matchingStructure = Program.Structures
                        .FirstOrDefault(structure => structure.Name == item.Key);

                    if (matchingStructure != null)
                        lines.Add($"@{matchingStructure.Id}=~{item.Text}~[{shortName}{matchingStructure.Suffix}]");
                }
                lines.Add($"@70 = ~{modName}~");

                File.WriteAllLines(filePath, lines);
                return true;
            }
            catch
            { 
                return false; 
            }
        }
    }
}