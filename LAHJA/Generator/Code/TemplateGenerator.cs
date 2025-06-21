using AutoGenerator.Code;
using Shared.Interfaces;
using Shared.Constants.ArchitecturalLayersRoot;
using Shared.Helpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;


namespace LAHJA.Generator.Code
{


    public  class WebAppGenerator
    {
       
        private static string appRoot = ArchitecturalLayersRoot.ClientAppRoot;

        public static async Task GeneratorCode()
        {

           await   GenerateTemplates();
        }        
        
        public static async Task InjectorCode()
        {
            string templatesPath = Path.Combine($"{appRoot}\\Data\\UI", "Templates");

            if (Directory.Exists(templatesPath))
            {
                string[] folders = Directory.GetDirectories(templatesPath);

                foreach (var folder in folders)
                {
                    await SafeInvokerSourceInjector(folder);
                }
            }
            else
            {
                Console.WriteLine("لم يتم العثور على مجلد Templates.");
            }
            //SafeInvokerSourceInjector($"{appRoot}\\Data\\UI\\Templates\\Payment");
            //SafeInvokerSourceInjector($"{appRoot}\\Data\\UI\\Templates\\Auth\\TemplateAuth.cs", "TemplateAuth");
        }

        public static async Task GenerateTemplates()
        {

            var files = FileScanner.GetAllCsFilePaths($"{ArchitecturalLayersRoot.ApplicationRoot}\\GenerateServices");
            //foreach (var file in files)
            //{
            //    //if(file.Contains("BaseApiClient") || file.Contains("IBuildApiClient"))
            //    //    continue;

            //    GenerateAllTemplates(file);
            //}

           await GenerateAllTemplates(files[0]);

           

        }

        public static List<MemberDeclarationSyntax>  InjectorParameterIntoClass(ClassDeclarationSyntax classNode, List<MemberDeclarationSyntax> updatedMembers,
            string paramType,string paramName)
        {
     

            bool hasSafeInvokerField = classNode.Members
                .OfType<FieldDeclarationSyntax>()
                .Any(f =>
                    f.Declaration.Type.ToString() == paramType &&
                    f.Declaration.Variables.Any(v => v.Identifier.Text == paramName));

            var constructors = classNode.Members
                .OfType<ConstructorDeclarationSyntax>()
                .ToList();

            bool updatedConstructor = false;
            List<MemberDeclarationSyntax> updatedMembersWithConstructor = new();

            foreach (var constructor in constructors)
            {
                bool hasParam = constructor.ParameterList.Parameters
                    .Any(p => p.Type?.ToString() == paramType && p.Identifier.Text == paramName);

                bool hasAssignment = constructor.Body?.Statements
                    .Any(stmt => stmt.ToString().Contains($"this.{paramName} = {paramName}")) == true;

                var newParamList = hasParam
                    ? constructor.ParameterList
                    : constructor.ParameterList.AddParameters(
                        SyntaxFactory.Parameter(SyntaxFactory.Identifier(paramName))
                            .WithType(SyntaxFactory.ParseTypeName(paramType)));

                var assignment = SyntaxFactory.ParseStatement($"this.{paramName} = {paramName};");

                BlockSyntax newBody = hasAssignment
                    ? constructor.Body!
                    : constructor.Body != null
                        ? constructor.Body.AddStatements(assignment)
                        : SyntaxFactory.Block(assignment);

                var updatedConstructorNode = constructor
                    .WithParameterList(newParamList)
                    .WithBody(newBody);

                updatedMembersWithConstructor.Add(updatedConstructorNode);
                updatedConstructor = true;
            }

            if (!hasSafeInvokerField)
            {
                var field = SyntaxFactory.ParseMemberDeclaration($"private readonly {paramType} {paramName};");
                updatedMembers.Insert(0, field!);
            }

            if (updatedConstructor)
            {
                updatedMembers = updatedMembers
                    .Where(m => m is not ConstructorDeclarationSyntax)
                    .ToList();

                updatedMembers.AddRange(updatedMembersWithConstructor);
            }
            else if (constructors.Count == 0)
            {
                var parameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier(paramName))
                    .WithType(SyntaxFactory.ParseTypeName(paramType));

                var assignment = SyntaxFactory.ParseStatement($"this.{paramName} = {paramName};");

                var ctor = SyntaxFactory.ConstructorDeclaration(classNode.Identifier.Text)
                    .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                    .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(new[] { parameter })))
                    .WithBody(SyntaxFactory.Block(assignment));

                updatedMembers.Add(ctor);
            }

            return updatedMembers;

        }

        public static async Task SafeInvokerSourceInjector(string folderPath)
        {


            var csFiles = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories)
                .Where(path => !Path.GetFileName(path).Contains(".g."))
                .ToList();

            foreach (var file in csFiles)
            {
                var sourceCode = File.ReadAllText(file);
                var tree = CSharpSyntaxTree.ParseText(sourceCode);
                var root = tree.GetCompilationUnitRoot();

                var targetClasses = root.DescendantNodes()
                    .OfType<ClassDeclarationSyntax>()
                    .Where(c =>
                        c.AttributeLists
                            .SelectMany(attrList => attrList.Attributes)
                            .Any(attr => attr.Name.ToString() == "AutoSafeInvoke"))
                    .ToList();

                if (!targetClasses.Any())
                    continue;
                var newRoot = root;

          

                if (newRoot != null)
                {
                    if (!newRoot.Usings.Any(u => u.ToString() == "using Client.Shared.Execution;"))
                    {
                        var newUsing = SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Client.Shared.Execution"));
                        newRoot = newRoot.AddUsings(newUsing);
                    }

                    // تابع التعديل على root
                }


                foreach (var classNode in targetClasses)
                {
                    var updatedMembers = new List<MemberDeclarationSyntax>();

                    foreach (var member in classNode.Members)
                    {
                        if (member is MethodDeclarationSyntax method)
                        {
                            var hasIgnoreAttr = method.AttributeLists
                                .SelectMany(attrList => attrList.Attributes)
                                .Any(attr => attr.Name.ToString() == "IgnoreSafeInvoke");

                            if (hasIgnoreAttr)
                            {
                                updatedMembers.Add(method);
                                continue;
                            }

                            if (method.Body != null && method.Body.Statements.Any(stmt => stmt.ToString().Contains("safeInvoker.InvokeAsync")) ||
                                method.ExpressionBody != null && method.ExpressionBody.Expression.ToString().Contains("safeInvoker.InvokeAsync"))
                            {
                                updatedMembers.Add(method);
                                continue;
                            }

                            var returnType = method.ReturnType.ToString();
                            //var isReturnTask = returnType == "Task" && returnType.StartsWith("Task<");
                            var isReturnTask = returnType != "Task" && returnType.StartsWith("Task<");
                            var innerCode = method.ExpressionBody != null
                                ? method.ExpressionBody.Expression.ToString()
                                : method.Body != null
                                    ? string.Join(Environment.NewLine, method.Body.Statements.Select(s => s.ToString()))
                                    : "// original body";

                            string wrappedCode = isReturnTask
                                ? $@"return await safeInvoker.InvokeAsync(async () => {{ {innerCode} }});"
                                : $@"await safeInvoker.InvokeAsync(async () => {{ {innerCode} }});";

                            var newBody = SyntaxFactory.Block(SyntaxFactory.ParseStatement(wrappedCode));

                            var newMethod = method
                                .WithBody(newBody)
                                .WithExpressionBody(null)
                                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None));

                            updatedMembers.Add(newMethod);
                        }
                        else
                        {
                            updatedMembers.Add(member);
                        }
                    }


                    updatedMembers= InjectorParameterIntoClass(classNode, updatedMembers, "ISafeInvoker", "safeInvoker");

                    // ✨ إعادة ترتيب: الحقول → البناة → الباقي
                    var fields = updatedMembers.OfType<FieldDeclarationSyntax>().Cast<MemberDeclarationSyntax>().ToList();
                    var constructorsFinal = updatedMembers.OfType<ConstructorDeclarationSyntax>().Cast<MemberDeclarationSyntax>().ToList();
                    var others = updatedMembers.Where(m => m is not FieldDeclarationSyntax and not ConstructorDeclarationSyntax).ToList();

                    var reorderedMembers = new List<MemberDeclarationSyntax>();
                    reorderedMembers.AddRange(fields);
                    reorderedMembers.AddRange(constructorsFinal);
                    reorderedMembers.AddRange(others);

                    var newClass = classNode.WithMembers(SyntaxFactory.List(reorderedMembers));
                    newRoot = newRoot.ReplaceNode(classNode, newClass);
                }

                string directory = Path.GetDirectoryName(file)!;
                string newFilePath = Path.Combine(directory, Path.GetFileName(file));

                string result = newRoot.NormalizeWhitespace().ToFullString();
              await  File.WriteAllTextAsync(newFilePath, result);
                Console.WriteLine($"✅ تم إنشاء الملف: {Path.GetFileName(newFilePath)}");
            }
        }


        public static void SafeInvokerSourceInjector2(string folderPath)
        {
   
            var csFiles = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories)
                       .Where(path => !Path.GetFileName(path).Contains(".g."))
                       .ToList();

            foreach (var file in csFiles)
            {
              
                var sourceCode = File.ReadAllText(file);
                var tree = CSharpSyntaxTree.ParseText(sourceCode);
                var root = tree.GetCompilationUnitRoot();

                // 🔍 ابحث عن كل الفئات التي تحمل الوسم [AutoSafeInvoke]
                var targetClasses = root.DescendantNodes()
                    .OfType<ClassDeclarationSyntax>()
                    .Where(c =>
                        c.AttributeLists
                            .SelectMany(attrList => attrList.Attributes)
                            .Any(attr => attr.Name.ToString() == "AutoSafeInvoke"))
                    .ToList();

                // لو لم توجد فئات مستهدفة، تخطى الملف
                if (!targetClasses.Any())
                    continue;

                var newRoot = root;

                foreach (var classNode in targetClasses)
                {
                    var updatedMembers = new List<MemberDeclarationSyntax>();

                    foreach (var member in classNode.Members)
                    {
                        // ✅ إذا كان الدالة وتحمل IgnoreSafeInvoke → تجاهل التعديل
                        if (member is MethodDeclarationSyntax method)
                        {
                            var hasIgnoreAttr = method.AttributeLists
                                .SelectMany(attrList => attrList.Attributes)
                                .Any(attr => attr.Name.ToString() == "IgnoreSafeInvoke");

                            if (hasIgnoreAttr)
                            {
                                updatedMembers.Add(method); // أضفها كما هي
                                continue;
                            }

                            if (method.Body != null && method.Body.Statements.Any(stmt => stmt.ToString().Contains("safeInvoker.InvokeAsync"))
                            || method.ExpressionBody != null && method.ExpressionBody.Expression.ToString().Contains("safeInvoker.InvokeAsync"))
                            {
                                updatedMembers.Add(method);
                                continue;
                            }



                            var returnType = method.ReturnType.ToString();
                            var isReturnTask = returnType != "Task";

                            var parameters = method.ParameterList.Parameters;
                            var paramNames = string.Join(", ", parameters.Select(p => p.Identifier.Text));

                            string innerCode;
                            if (method.ExpressionBody != null)
                            {
                                innerCode = method.ExpressionBody.Expression.ToString();
                            }
                            else if (method.Body != null)
                            {
                                var statements = method.Body.Statements;
                                innerCode = string.Join(Environment.NewLine, statements.Select(s => s.ToString()));
                            }
                            else
                            {
                                innerCode = "// original body";
                            }

                            string wrappedCode = isReturnTask
                                ? $@"return await safeInvoker.InvokeAsync(async () => {{ {innerCode} }});"
                                : $@"await safeInvoker.InvokeAsync(async () => {{ {innerCode} }});";

                            var newBody = SyntaxFactory.Block(SyntaxFactory.ParseStatement(wrappedCode));

                            var newMethod = method
                                .WithBody(newBody)
                                .WithExpressionBody(null)
                                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None));

                            updatedMembers.Add(newMethod);
                        }
                        else
                        {
                            
                            // ✅ احتفظ بجميع الأعضاء الآخرين كما هي (مثل constructors, properties, fields...)
                            updatedMembers.Add(member);
                        }
                    }



                    const string paramType = "ISafeInvoker";
                    const string paramName = "safeInvoker";

                    // التحقق من وجود الحقل مسبقًا
                    bool hasSafeInvokerField = classNode.Members
                        .OfType<FieldDeclarationSyntax>()
                        .Any(f =>
                            f.Declaration.Type.ToString() == paramType &&
                            f.Declaration.Variables.Any(v => v.Identifier.Text == paramName));

                    // إذا لم يوجد، نضيف الحقل في أعلى الكلاس
                    if (!hasSafeInvokerField)
                    {
                        var field = SyntaxFactory.ParseMemberDeclaration($"private readonly {paramType} {paramName};");
                        updatedMembers.Insert(0, field!);
                    }

                    var constructors = classNode.Members.OfType<ConstructorDeclarationSyntax>().ToList();

                    if (constructors.Count == 0)
                    {
                        // لا يوجد أي باني، ننشئ واحد جديد
                        var parameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier(paramName))
                            .WithType(SyntaxFactory.ParseTypeName(paramType));

                        var assignment = SyntaxFactory.ParseStatement($"this.{paramName} = {paramName};");

                        var ctor = SyntaxFactory.ConstructorDeclaration(classNode.Identifier.Text)
                            .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                            .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SingletonSeparatedList(parameter)))
                            .WithBody(SyntaxFactory.Block(assignment));

                        updatedMembers.Add(ctor);
                    }
                    else
                    {
                        // هناك بانٍ أو أكثر، نتحقق من وجود المتغير داخله ونضيفه إن لزم
                        var updatedConstructors = new List<ConstructorDeclarationSyntax>();

                        foreach (var constructor in constructors)
                        {
                            bool hasParam = constructor.ParameterList.Parameters
                                .Any(p => p.Type?.ToString() == paramType && p.Identifier.Text == paramName);

                            var paramList = hasParam
                                ? constructor.ParameterList
                                : constructor.ParameterList.AddParameters(
                                    SyntaxFactory.Parameter(SyntaxFactory.Identifier(paramName))
                                        .WithType(SyntaxFactory.ParseTypeName(paramType)));

                            bool hasAssignment = constructor.Body?.Statements
                                .Any(stmt => stmt.ToString().Contains($"this.{paramName} = {paramName}")) == true;

                            var newBody = hasAssignment
                                ? constructor.Body!
                                : constructor.Body != null
                                    ? constructor.Body.AddStatements(SyntaxFactory.ParseStatement($"this.{paramName} = {paramName};"))
                                    : SyntaxFactory.Block(SyntaxFactory.ParseStatement($"this.{paramName} = {paramName};"));

                            var updatedConstructor = constructor
                                .WithParameterList(paramList)
                                .WithBody(newBody);

                            updatedConstructors.Add(updatedConstructor);
                        }

                        // نحذف البانين القدامى ونضيف المحدثين
                        updatedMembers = updatedMembers
                            .Where(m => m is not ConstructorDeclarationSyntax)
                            .ToList();

                        updatedMembers.AddRange(updatedConstructors);
                    }






                    // أعد بناء الفئة بكل الأعضاء المعدلة وغير المعدلة
                    var newClass = classNode.WithMembers(SyntaxFactory.List(updatedMembers));
                    newRoot = newRoot.ReplaceNode(classNode, newClass);

                }

                // استخراج اسم الملف وتوليد اسم جديد
                string directory = Path.GetDirectoryName(file)!;
                string oldFileName = Path.GetFileName(file);
                string newFileName = $"{oldFileName}";
                string newFilePath = Path.Combine(directory, newFileName);

                // حفظ الملف الجديد
                string result = newRoot.NormalizeWhitespace().ToFullString();
                File.WriteAllText(newFilePath, result);
                Console.WriteLine($"✅ تم إنشاء الملف: {newFileName}");
            }
        }

        public static void SafeInvokerSourceInjector(string sourceTemplateFilePath, string targetClassName)
        {

            

   

            // 👇 اقرأ كود الملف
            var sourceCode = File.ReadAllText(sourceTemplateFilePath);

            // 👇 حلل الكود باستخدام Roslyn
            var tree = CSharpSyntaxTree.ParseText(sourceCode);
            var root = tree.GetCompilationUnitRoot();

            // 👇 ابحث عن الفئة المستهدفة
            var classNode = root.DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .FirstOrDefault(c => c.Identifier.Text == targetClassName);

            if (classNode == null)
            {
                Console.WriteLine("❌ الفئة المطلوبة غير موجودة");
                return;
            }

            // 👇 أنشئ نسخة جديدة من الدوال بعد التغليف بـ safeInvoker
            var newMethods = new List<MemberDeclarationSyntax>();

            foreach (var method in classNode.Members.OfType<MethodDeclarationSyntax>())
            {
                var returnType = method.ReturnType.ToString();
                var isReturnTask = returnType != "Task";

                // المعاملات
                var parameters = method.ParameterList.Parameters;
                var paramList = string.Join(", ", parameters.Select(p => p.ToString()));
                var paramNames = string.Join(", ", parameters.Select(p => p.Identifier.Text));

                // الكود الداخلي
                var innerCall = method.ExpressionBody != null
                    ? method.ExpressionBody.Expression.ToString()
                    : method.Body?.Statements.ToString() ?? "// original body";

                string wrappedCode = isReturnTask
                    ? $@"return await safeInvoker.InvokeAsync(() =>{{ {innerCall} }});"
                    : $@"await safeInvoker.InvokeAsync(() => {{ {innerCall} }});";

                // body الجديد
                var newBody = SyntaxFactory.Block(SyntaxFactory.ParseStatement(wrappedCode));

                // دالة جديدة بنفس التوقيع
                var newMethod = method
                    .WithBody(newBody)
                    .WithExpressionBody(null)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.None));

                newMethods.Add(newMethod);
            }

            // 👇 أعد بناء الفئة بنفس الاسم والدوال المعدلة فقط
            var newClass = classNode.WithMembers(SyntaxFactory.List(newMethods));

            // 👇 استبدل الفئة القديمة بالجديدة داخل الشجرة الأصلية
            var newRoot = root.ReplaceNode(classNode, newClass);

            // 👇 الناتج النهائي
            string result = newRoot.NormalizeWhitespace().ToFullString();



            // استخراج المجلد واسم الملف
            string directory = Path.GetDirectoryName(sourceTemplateFilePath)!;
            string oldFileName = Path.GetFileName(sourceTemplateFilePath);

            // تعديل اسم الملف (مثلاً نضيف "Modified_" قبل الاسم)
            string newFileName = $"Generate{oldFileName}";

            // دمج المسار الجديد
            string newFilePath = Path.Combine(directory, newFileName);
            // 👇 اكتب إلى ملف جديد (أو اطبعه)
            File.WriteAllText(newFilePath, result);
            Console.WriteLine("✅ تم توليد الملف بنجاح.");

        }
        public static async Task GenerateAllTemplates(string sourceTemplateFilePath)
        {
          await  AutoGenerateUITemplateGenerator.GenerateAllUITemplatesClass(new GenerationOptions
            {
                SourceTemplateFilePath = $"{sourceTemplateFilePath}",
                DestinationRoot = $"{appRoot}\\Data\\UI",
                DestinationDirectory = "GenerateTemplates",
                SourceBaseInterface = "ITBaseShareService",
                SourceCategoryName = "Service",
                ImplementGenerateInterface = true,
                //BaseClass = "BuilderApi<T,E>",
                ImplementOtherInterfacesInClass = false,
                DestinationCategoryName = "Template",
                NamespaceName = "LAHJA.Data.UI.GenerateTemplates.{ServiceName}",
                Interfaces = new List<Type>
                {
                    //typeof(ITBaseRepository),
                    //typeof(ITScope),
                },
                Usings = new List<string>
                {

                    "AutoMapper",
                    "System.Threading.Tasks",
                    "Infrastructure.Nswag",
                    "Shared.Interfaces",
                     "Microsoft.Extensions.Configuration",
                     "Application.Services",
                     "LAHJA.Data.UI.Templates.Base",
                     "LAHJA.Providers",
                     "LAHJA.Data.UI.Components.Base"
            },
                AdditionalCode = @"    
    public {ClassName}(IMapper mapper, T service) : base(mapper,service){
                              
    }",
                MethodContentCode = "",

            });
        }
    
    }
}
