using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE_soundset_tool
{
    internal class Validator
    {
        private readonly List<string> RequiredFiles = ["setup-cd_soundsets.exe", "cd_soundsets\\cd_soundsets.tp2", "cd_soundsets\\english\\setup.tra"];
        private readonly List<DataItem> DataItems;
       
        public Validator(List<DataItem> dataItems)
        {
            DataItems = dataItems;
        }

        public bool Validate(out string errorMessage)
        {
            errorMessage = "";
            foreach (var file in RequiredFiles)
            {
                if (!File.Exists(file))
                {
                    errorMessage = "Required files not found. Make sure the \"cd_soundsets\" folder is in the correct location.";
                    return false;
                }
            }

            foreach (var item in DataItems)
            {
                if (item.Path.Length > 0 && !File.Exists(item.Path))
                {
                    errorMessage = $"Couldn't find file:\n\n{item.Path}\n\nMake sure all paths are still valid.";
                    return false;
                }
            }

            return true;
        }

    }
}
