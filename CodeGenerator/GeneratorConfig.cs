using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class GeneratorConfig
    {
        public string Path { 
            get => _path ?? throw new ArgumentNullException("Path is not set"); 
            set => _path = value;
        }
        private string? _path { get; set; }

    }
}
