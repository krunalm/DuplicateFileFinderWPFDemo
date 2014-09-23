using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFileFinder
{
    public static class Helpers
    {
        public static void ShowMessage(string msg)
        {
            System.Windows.MessageBox.Show(msg, "Duplicate File Finder");
        }

        public static int GetMaxCharLimit()
        {
            return string.IsNullOrEmpty(ConfigurationManager.AppSettings["MaxCharLimit"]) ? 10 : Convert.ToInt32(ConfigurationManager.AppSettings["MaxCharLimit"]);
        }
    }
}
