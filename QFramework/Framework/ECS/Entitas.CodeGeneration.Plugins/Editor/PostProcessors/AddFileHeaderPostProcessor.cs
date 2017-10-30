using QFramework;

namespace Entitas.CodeGeneration.Plugins {

    public class AddFileHeaderPostProcessor : ICodeGenFilePostProcessor {

        public string Name { get { return "Add file header"; } }
        public int Priority { get { return 0; } }
        public bool IsEnabledByDefault { get { return true; } }
        public bool RunInDryMode { get { return true; } }

        public const string AUTO_GENERATED_HEADER_FORMAT =
@"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by {0}.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
";

        public CodeGenFile[] PostProcess(CodeGenFile[] files) {
            foreach (var file in files) {
                file.FileContent = string.Format(AUTO_GENERATED_HEADER_FORMAT, file.GeneratorName) + file.FileContent;
            }

            return files;
        }
    }
}
