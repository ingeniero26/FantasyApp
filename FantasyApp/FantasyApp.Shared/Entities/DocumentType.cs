using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyApp.Shared.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        // Additional properties can be added as needed
    }
}
