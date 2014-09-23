using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFileFinder
{
    public class DuplicateFileEntity
    {
        public int Id { get; set; }

        public string File { get; set; }

        public string SearchTerm { get; set; }

        public int Total { get; set; }
    }
}
