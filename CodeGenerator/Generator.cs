using System.Linq.Expressions;

namespace CodeGenerator
{
    public class Generator
    {
        private GeneratorConfig _config;
        public Generator(GeneratorConfig config)
        { 
            _config = config;
        }

        public async Task<bool> Generate(IEnumerable<ObjectDef>)

    }
}
