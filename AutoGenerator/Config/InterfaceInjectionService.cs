using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace AutoGenerator.Config
{

    public class InjectInterfaceCommand : ISyntaxTreeCommand
    {
        private readonly IClassSelector _selector;
        private readonly IClassModifier _modifier;
        private readonly string _interfaceNamespace;

        public InjectInterfaceCommand(IClassSelector selector, IClassModifier modifier, string interfaceFullName)
        {
            _selector = selector;
            _modifier = modifier;
            _interfaceNamespace = interfaceFullName.Contains('.') ? interfaceFullName.Substring(0, interfaceFullName.LastIndexOf('.')) : null;
        }

        public CompilationUnitSyntax Execute(CompilationUnitSyntax root)
        {
            bool modified = false;

            if (!string.IsNullOrEmpty(_interfaceNamespace) && !root.Usings.Any(u => u.Name.ToString() == _interfaceNamespace))
            {
                root = root.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(_interfaceNamespace)));
                modified = true;
            }

            var classes = _selector.SelectClasses(root);

            var newRoot = root.ReplaceNodes(classes, (original, _) =>
            {
                var modClass = _modifier.Modify(original);
                if (modClass != original)
                    modified = true;
                return modClass;
            });

            return modified ? newRoot : root;
        }
    }
    public class InterfaceInjector : IClassModifier
    {
        private readonly string _interfaceFullName;
        private readonly string _interfaceSimpleName;
        private readonly SimpleBaseTypeSyntax _interfaceType;

        public InterfaceInjector(string interfaceFullName)
        {
            _interfaceFullName = interfaceFullName;
            _interfaceSimpleName = interfaceFullName.Split('.').Last();
            _interfaceType = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(interfaceFullName));
        }

        public ClassDeclarationSyntax Modify(ClassDeclarationSyntax classDecl)
        {
            var baseList = classDecl.BaseList ?? SyntaxFactory.BaseList();

            // إذا الواجهة غير مضافة مسبقاً
            if (baseList.Types.All(bt => bt.Type.ToString() != _interfaceSimpleName && bt.Type.ToString() != _interfaceFullName))
            {
                baseList = baseList.AddTypes(_interfaceType);
                return classDecl.WithBaseList(baseList);
            }

            return classDecl; // لا تعديل
        }
    }



    public class InterfaceInjectionService : ICodeInjectionService
    {

 
        public async Task<bool> ExecuteAsync(CodeInjectionOptions options)
        {
            ISourceCodeProvider provider = options.IsSourceText
                ? new TextSourceCodeProvider(options.SourceCodeOrFilePath, options.OutputFilePath)
                : new FileSourceCodeProvider(options.SourceCodeOrFilePath);

            IClassModifier modifier = new InterfaceInjector(options.InterfaceFullName);
            var command = new InjectInterfaceCommand(options.Selector, modifier, options.InterfaceFullName);
            var processor = new SyntaxTreeProcessor(provider);
            processor.AddCommand(command);
            return await processor.ProcessAsync(options.OutputFilePath);
        }

        //public async Task<bool> InjectInterfaceToClasses(string sourceFilePath, string interfaceFullName, List<Type> typesClass, string outputFilePath = null)
        //{

        //    IClassSelector selector = new TypeBasedClassSelector(typesClass); // هنا يمكن تعديلها لتناسب احتياجاتك
        //    return await ExecuteInjectInterfaceToClassesAsync(sourceFilePath, interfaceFullName, selector, outputFilePath);
        //}

        //public async Task<bool> InjectInterfaceToClasses(string sourceFilePath, string interfaceFullName, string suffixPattern = null, string outputFilePath = null)
        //{

        //    IClassSelector selector = new SuffixClassSelector(suffixPattern);
        //    return await ExecuteInjectInterfaceToClassesAsync(sourceFilePath, interfaceFullName, selector, outputFilePath);

        //}




        //public CompilationUnitSyntax InjectInterfaceToClasses(
        //                CompilationUnitSyntax root,
        //                List<ClassDeclarationSyntax> classDecls,
        //                string interfaceFullName,
        //                out bool modified)
        //{



        //    //modified = false;

        //    //var interfaceNamespace = interfaceFullName.Contains('.')
        //    //    ? interfaceFullName.Substring(0, interfaceFullName.LastIndexOf('.'))
        //    //    : null;

        //    //if (!string.IsNullOrEmpty(interfaceNamespace) && !root.Usings.Any(u => u.Name.ToString() == interfaceNamespace))
        //    //{
        //    //    root = root.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(interfaceNamespace)));
        //    //    modified = true;
        //    //}

        //    //var interfaceType = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(interfaceFullName));
        //    //var interfaceSimpleName = interfaceFullName.Split('.').Last();

        //    //var newRoot = root.ReplaceNodes(classDecls, (original, _) =>
        //    //{
        //    //    var baseList = original.BaseList ?? SyntaxFactory.BaseList();

        //    //    if (baseList.Types.All(bt => bt.Type.ToString() != interfaceSimpleName && bt.Type.ToString() != interfaceFullName))
        //    //    {
        //    //        baseList = baseList.AddTypes(interfaceType);
        //    //        modified = true;
        //    //        return original.WithBaseList(baseList);
        //    //    }
        //    //    return original;
        //    //});

        //    //return newRoot;
        //}





        //public void InjectInterfaceToClasses(string sourceFilePath, string interfaceFullName, string suffixPattern = null, string outputFilePath = null)
        //{
        //    var code = File.ReadAllText(sourceFilePath);
        //    var tree = CSharpSyntaxTree.ParseText(code);
        //    var root = tree.GetCompilationUnitRoot();

        //    var interfaceNamespace = interfaceFullName.Contains('.') ? interfaceFullName.Substring(0, interfaceFullName.LastIndexOf('.')) : null;
        //    var modified = false;

        //    if (!string.IsNullOrEmpty(interfaceNamespace) && !root.Usings.Any(u => u.Name.ToString() == interfaceNamespace))
        //    {
        //        root = root.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(interfaceNamespace)));
        //        modified = true;
        //    }

        //    var classDecls = root.DescendantNodes()
        //        .OfType<ClassDeclarationSyntax>()
        //        .Where(c => string.IsNullOrEmpty(suffixPattern) || c.Identifier.Text.EndsWith(suffixPattern))
        //        .ToList();

        //   var types=classDecls.Select(x => x.GetType()).ToList();

        //    var interfaceType = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(interfaceFullName));
        //    var interfaceSimpleName = interfaceFullName.Split('.').Last();

        //    var newRoot = root.ReplaceNodes(classDecls, (original, _) =>
        //    {
        //        var baseList = original.BaseList ?? SyntaxFactory.BaseList();

        //        if (baseList.Types.All(bt => bt.Type.ToString() != interfaceSimpleName && bt.Type.ToString() != interfaceFullName))
        //        {
        //            baseList = baseList.AddTypes(interfaceType);
        //            modified = true;
        //            return original.WithBaseList(baseList);
        //        }
        //        return original;
        //    });

        //    if (modified)
        //    {
        //        File.WriteAllText(outputFilePath ?? sourceFilePath, newRoot.NormalizeWhitespace().ToFullString());
        //    }
        //}

        //public void InjectInterfaceToClasses(string sourceFilePath, string interfaceFullName, List<Type> ClassDeclarations, string outputFilePath = null)
        //{
        //    var code = File.ReadAllText(sourceFilePath);
        //    var tree = CSharpSyntaxTree.ParseText(code);
        //    var root = tree.GetCompilationUnitRoot();

        //    var interfaceNamespace = interfaceFullName.Contains('.') ? interfaceFullName.Substring(0, interfaceFullName.LastIndexOf('.')) : null;
        //    var modified = false;

        //    if (!string.IsNullOrEmpty(interfaceNamespace) && !root.Usings.Any(u => u.Name.ToString() == interfaceNamespace))
        //    {
        //        root = root.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(interfaceNamespace)));
        //        modified = true;
        //    }

        //    var validClassNames = new HashSet<string>(
        //                            ClassDeclarations
        //                            .Where(x => x.IsClass)
        //                            .Select(x => x.Name));


        //     var classDecls = root.DescendantNodes()
        //        .OfType<ClassDeclarationSyntax>()
        //        .Where(c => validClassNames.Contains(c.Identifier.Text))
        //        .ToList();

        //    var interfaceType = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(interfaceFullName));
        //    var interfaceSimpleName = interfaceFullName.Split('.').Last();

        //    var newRoot = root.ReplaceNodes(classDecls, (original, _) =>
        //    {
        //        var baseList = original.BaseList ?? SyntaxFactory.BaseList();

        //        if (baseList.Types.All(bt => bt.Type.ToString() != interfaceSimpleName && bt.Type.ToString() != interfaceFullName))
        //        {
        //            baseList = baseList.AddTypes(interfaceType);
        //            modified = true;
        //            return original.WithBaseList(baseList);
        //        }
        //        return original;
        //    });

        //    if (modified)
        //    {
        //        File.WriteAllText(outputFilePath ?? sourceFilePath, newRoot.NormalizeWhitespace().ToFullString());
        //    }
        //}
        //public void AddInterfaceToClass(string filePath, string className, string interfaceName = "ITDto")
        //{
        //    var fileText = File.ReadAllText(filePath);
        //    var pattern = $@"(public\s+partial\s+class\s+{className})(\s*:\s*[\w\s,]+)?";
        //    var regex = new Regex(pattern);
        //    var match = regex.Match(fileText);

        //    if (match.Success)
        //    {
        //        var fullMatch = match.Value;
        //        if (!fullMatch.Contains(interfaceName))
        //        {
        //            string updatedDeclaration = match.Groups[2].Success
        //                ? $"{match.Groups[1].Value}{match.Groups[2].Value}, {interfaceName}"
        //                : $"{match.Groups[1].Value} : {interfaceName}";

        //            var updatedText = regex.Replace(fileText, updatedDeclaration, 1);
        //            File.WriteAllText(filePath, updatedText);
        //        }
        //    }
        //}
    }

    }
