using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ProductRequirementsDto
    {
        public Guid Id { get; set; }

        public string OsMin { get; set; }

        public string OsMax { get; set; }

        public string ProcessorMin { get; set; }

        public string ProcessorMax { get; set; }

        public string MemoryMin { get; set; }
        
        public string MemoryMax { get; set; }

        public string StorageMin { get; set; }
        
        public string StorageMax { get; set; }
                
        public string DirectXMin { get; set; }
                
        public string DirectXMax { get; set; }

        public string GraphicsMin { get; set; }
                
        public string GraphicsMax { get; set; }

        public string LanguagesSupported { get; set; }

        public string PrivacyPolicy { get; set; }
    }
}
