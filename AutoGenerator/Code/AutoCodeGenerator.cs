using AutoGenerator.Helper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AutoGenerator.Code
{
    public class AutoCodeGenerator
    {


        public static bool CheckImportantInfo(GenerationOptions generationOptions)
        {

            if (string.IsNullOrWhiteSpace(generationOptions.SourceBaseInterface)
                || string.IsNullOrWhiteSpace(generationOptions.SourceCategoryName)
                || string.IsNullOrWhiteSpace(generationOptions.DestinationCategoryName))
            {
                Console.WriteLine("يجب تضمين اسم الفئة او الواجهة الاب ");
                return false;
            }




            if (!File.Exists(generationOptions.SourceTemplateFilePath))
            {
                Console.WriteLine("الملف المصدر غير موجود.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(generationOptions.DestinationRoot))//  || Path.GetExtension(generationOptions.DestinationRoot) == string.Empty
            {
                Console.WriteLine("مسار الملف الوجهة غير صالح.");
                return false;
            }

            return true;
        }

        //public bool IsImplementsOrInherits(SyntaxNode declaration,SemanticModel model, string baseTypeOrInterfaceName)
        //{
        //    var symbol = model.GetDeclaredSymbol(declaration) as INamedTypeSymbol;

        //    if (symbol == null)
        //        return false;

        //    // التحقق من الوراثة
        //    var current = symbol;
        //    while (current != null && current.Name != "Object")
        //    {
        //        if (current.Name == baseTypeOrInterfaceName)
        //            return true;

        //        current = current.BaseType;
        //    }

        //    // التحقق من تنفيذ الواجهة (في الكلاس الحالي فقط)
        //    if (symbol.AllInterfaces.Any(i => i.Name == baseTypeOrInterfaceName))
        //        return true;

        //    return false;
        //}
        //public static bool IsImplementsOrInheritsBase(InterfaceDeclarationSyntax classDecl, SemanticModel model, string baseTypeOrInterfaceName)
        //{

        //    return IsImplementsOrInherits(classDecl, model, baseTypeOrInterfaceName);
        //} 
        
        public static bool IsImplementsOrInheritsBase(SyntaxNode declaration, SemanticModel model, string baseTypeOrInterfaceName)
        {

            var symbol = model.GetDeclaredSymbol(declaration) as INamedTypeSymbol;

            if (symbol == null)
                return false;

            // التحقق من الوراثة
            var current = symbol;
            while (current != null && current.Name != "Object")
            {
                if (current.Name == baseTypeOrInterfaceName)
                    return true;

                current = current.BaseType;
            }

            // التحقق من تنفيذ الواجهة (في الكلاس الحالي فقط)
            if (symbol.AllInterfaces.Any(i => i.Name == baseTypeOrInterfaceName))
                return true;

            return false;
        }
        public static async Task GenerateAllClassTemplate(GenerationOptions generationOptions)
        {


            if (!CheckImportantInfo(generationOptions))
                return;

            var sb = new StringBuilder();
         

            var code = File.ReadAllText(generationOptions.SourceTemplateFilePath);
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetCompilationUnitRoot();

            var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

            List<Type> interfaces = new List<Type>();
            if (generationOptions.Interfaces.Any())
                interfaces.AddRange(generationOptions.Interfaces);

            foreach (var classDecl in classDeclarations)
            {
                bool isImplementsInterface = IsImplementsOrInheritsBase(classDecl, 
                                            RoslynUtils.CreateSemanticModel(tree),
                                            generationOptions.SourceBaseInterface);
                //bool implementsInterface = classDecl.BaseList?.Types
                //    .Any(bt => bt.Type.ToString().EndsWith(generationOptions.SourceBaseInterface)) ?? false;

                if (isImplementsInterface)
                {
                    var sourceClassName = classDecl.Identifier.Text;
                    if (!string.IsNullOrWhiteSpace(sourceClassName))
                    {
                      var  className = sourceClassName.Replace(generationOptions.SourceCategoryName, "");
                        
                        //generationOptions.BaseIClassName = baseClassName;
                        var output_directory = "";
                        if (!string.IsNullOrWhiteSpace(className))
                        {
                            generationOptions.ClassName = $"{className}{generationOptions.DestinationCategoryName}";
                            output_directory = $"{generationOptions.DestinationRoot}\\{generationOptions.DestinationDirectory}\\{className}";
                            // Directory.CreateDirectory().FullName;
                            //generationOptions.DestinationDirection = output_directory;
                            var generateCode = "";
                            if (generationOptions.ImplementGenerateInterface)
                            {
                                generationOptions.InterfaceName = $"I{generationOptions.ClassName}";
                                generateCode = GenerateInterface(classDecl, generationOptions,interfaces);
                                await GeneratorManager.SaveToFileAsync($"{output_directory}\\{generationOptions.InterfaceName}.cs", generateCode);
                                generationOptions.BaseInterface = generationOptions.InterfaceName;
                            }


                            generateCode = GenerateClass(classDecl, generationOptions, sourceClassName);
                            await GeneratorManager.SaveToFileAsync($"{output_directory}\\{generationOptions.ClassName}.cs", generateCode);
                            
                        }


                    }
                }
            }

        }
       
        public static string RemoveLastSymbol(string symbolToRemove,string text)
        {
            text = text.TrimEnd();
            if (text.EndsWith(symbolToRemove.ToString()))
            {
                return text.Substring(0, text.Length - 1);
            }
            return text;
            //return Regex.Replace(text, $@"{symbolToRemove}\s*$", "", RegexOptions.Multiline);
        }

        public static IEnumerable<InterfaceDeclarationSyntax>? getInterfacesFromDescendantNodes(CompilationUnitSyntax? root) {
              return root?.DescendantNodes().OfType<InterfaceDeclarationSyntax>();
        }
        public static IEnumerable<ClassDeclarationSyntax>? getClassFromDescendantNodes(CompilationUnitSyntax? root)
        {
            return root?.DescendantNodes().OfType<ClassDeclarationSyntax>();
        }

        public static async Task GenerateUseCaseClassTemplate(GenerationOptions generationOptions)
        {


            if (!CheckImportantInfo(generationOptions))
                return;

            var code = File.ReadAllText(generationOptions.SourceTemplateFilePath);
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetCompilationUnitRoot();

      
            
            var classDeclarations = getInterfacesFromDescendantNodes(root);

            List<Type> interfaces = new List<Type>();
            if (generationOptions.Interfaces.Any())
                interfaces.AddRange(generationOptions.Interfaces);

            foreach (var classDecl in classDeclarations)
            {
                bool isImplementsInterface = IsImplementsOrInheritsBase(classDecl, 
                                            RoslynUtils.CreateSemanticModel(tree),
                                            generationOptions.SourceBaseInterface);
                //bool implementsInterface = classDecl.BaseList?.Types
                //    .Any(bt => bt.Type.ToString().EndsWith(generationOptions.SourceBaseInterface)) ?? false;

                if (isImplementsInterface)
                {
                    var sourceClassName = generationOptions.SourceTypeIsClass? 
                        classDecl.Identifier.Text : classDecl.Identifier.Text.Substring(1);

                    if (!string.IsNullOrWhiteSpace(sourceClassName))
                    {
                        var srcClassName = sourceClassName.Replace(generationOptions.SourceCategoryName, "");
                        //if(!generationOptions.SourceTypeIsClass && srcClassName.StartsWith("I"))
                        //    srcClassName=srcClassName.Substring(1);
              
                        var output_directory = "";
                        if (!string.IsNullOrWhiteSpace(srcClassName))
                        {
                            generationOptions.ClassName = $"{srcClassName}{generationOptions.DestinationCategoryName}";
                            output_directory = $"{generationOptions.DestinationRoot}\\{generationOptions.DestinationDirectory}\\{srcClassName}";

                            var generateCode = "";
                            //if (generationOptions.ImplementGenerateInterface)
                            //{
                            //    generationOptions.InterfaceName = $"I{generationOptions.ClassName}";
                            //    generateCode = GenerateInterface(classDecl, generationOptions, interfaces);
                            //    await GeneratorManager.SaveToFileAsync($"{output_directory}\\{generationOptions.InterfaceName}.cs", generateCode);
                            //    generationOptions.BaseInterface = generationOptions.InterfaceName;
                            //}
                            var methods = classDecl.Members.OfType<MethodDeclarationSyntax>()
                                .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword)); // نفعلها اذا كانت الدوال مصرح عنها  Publick

                            foreach(var method in methods)
                            {
                                var m_name = method.Identifier.Text.Replace("Async", "");
                                m_name = $"{char.ToUpper(m_name[0])}{m_name.Substring(1)}";

                                var sb = new StringBuilder();
                                sb.AppendLine();
                                sb.Append(GeneratorHelpers.GenerateUsingsNamespaces(generationOptions));
                                sb.AppendLine();

                                string singular = srcClassName.EndsWith("s") && srcClassName.Length > 1 ? srcClassName.Substring(0, srcClassName.Length - 1) : srcClassName;

                                var new_class_name = $"{m_name}{( !m_name.Contains(singular) ? srcClassName : "")}{generationOptions.DestinationCategoryName}";

                                sb.Append($"public class {new_class_name}");

                                if (!string.IsNullOrWhiteSpace(generationOptions.BaseInterface))
                                {
                                    sb.Append($" : {generationOptions.BaseInterface} ");
                                }

                                sb.AppendLine("{");
                                var codeA=generationOptions.AdditionalCode.Replace("{ClassName}", new_class_name)
                                    .Replace("{IPropertyType}",$"I{sourceClassName}");
                                sb.AppendLine(codeA);
                                var generateCodeMethod = GenerateMethod(method, generationOptions.MethodContentCode, generationOptions.UnifiedNameForFunctions);

                                sb.AppendLine(generateCodeMethod);
                                sb.AppendLine("}");
                                await GeneratorManager.SaveToFileAsync($"{output_directory}\\{new_class_name}.cs", sb.ToString());
                            }


                            
                        }


                    }
                }
            }

        } 
        
        public static void ImplementationInterfaces(ref StringBuilder sb, List<Type> interfaces)
        {
       
            if (interfaces.Any() && interfaces.Count() > 0)
            {
                if (!sb.ToString().Contains(":"))
                    sb.Append($" : ");
                else
                    sb.Append($" , ");

                foreach (var inter in interfaces)
                {
                    var interfaceName = inter.Name;
                    sb.Append($" {interfaceName} , ");
                }
                sb.Remove(sb.Length - 2, 1); // Remove the last comma
                sb.AppendLine();
            }

           
        }
        
        public static string GenerateInterface(ClassDeclarationSyntax classDeclaration, 
            GenerationOptions generationOptions,
            List<Type>? interfaces,bool includeNamespaces=true)
        {
            var sb = new StringBuilder();

    
            if (string.IsNullOrWhiteSpace(generationOptions.InterfaceName))
            {
                return " ";
            }

            if(includeNamespaces)
                sb.Append(GeneratorHelpers.GenerateUsingsNamespaces(generationOptions));

            sb.AppendLine();
            sb.Append($"public interface {generationOptions.InterfaceName}");



            if(interfaces!=null && interfaces.Any())
                ImplementationInterfaces(ref sb, interfaces);

            else if (!string.IsNullOrWhiteSpace(generationOptions.BaseInterface))
                sb.Append($" : {generationOptions.BaseInterface} ");

            var methods = classDeclaration.Members
                                .OfType<MethodDeclarationSyntax>()
                                .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword)
                                 && m.ParameterList.Parameters.Any(p => p.Type?.ToString().EndsWith("CancellationToken") == true));


            sb.AppendLine("{");
            foreach (var method in methods)
            {
                var generateCode = GenerateDeclarationMethod(method, generationOptions.UnifiedNameForFunctions);
                sb.AppendLine(generateCode);
            }
            sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }     
        public static string GenerateBuilderComponentsProperties(
            ClassDeclarationSyntax classDeclaration,  
            GenerationOptions generationOptions,
            string typeClass= "interface",
            List<Type>? interfaces=null)
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(generationOptions.ClassName))
            {
                return " ";
            }


            sb.AppendLine();
            sb.Append($"public {typeClass} {generationOptions.ClassName}");

            if (interfaces != null && interfaces.Any())
                ImplementationInterfaces(ref sb, interfaces);

            else if (!string.IsNullOrWhiteSpace(generationOptions.BaseInterface))
                sb.Append($" : {generationOptions.BaseInterface} ");

            var methods = classDeclaration.Members
                                .OfType<MethodDeclarationSyntax>()
                                .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));


            sb.AppendLine("{");
            foreach (var method in methods)
            {
                var generateCode = GenerateDeclarationMethod(method, generationOptions.UnifiedNameForFunctions);
                sb.AppendLine(generateCode);
            }
            sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }
        public static string GenerateClass(

            string className,
            string baseInterface,
            GenerationOptions generationOptions,
            string fildsPropertyCode,
            string parametersCode,
            string initializeFieldsCode,
            string contentsCode)
        {
            var sb = new StringBuilder();
            sb.Append(GeneratorHelpers.GenerateUsingsNamespaces(generationOptions));
            sb.AppendLine();

            sb.Append($"public class {className}");

            if (!string.IsNullOrWhiteSpace(baseInterface))
            {
                sb.Append($" : {baseInterface} ");
            }

            sb.AppendLine("{");
            sb.AppendLine();

            var additional_class_Code = generationOptions.AdditionalCode
                .Replace("{PropertyFields}", fildsPropertyCode)
                .Replace("{ClassName}", className)
                .Replace("{Parameters}", RemoveLastSymbol(",", parametersCode))
                .Replace("{InitializeFields}", initializeFieldsCode);

            sb.AppendLine(additional_class_Code);

            sb.AppendLine(contentsCode);

            sb.AppendLine();

            sb.AppendLine("}");
            return sb.ToString();
        }
            
            
    public static string GenerateInterface(
    string interfaceName,
    GenerationOptions generationOptions,
    List<Type>? interfaces,
    string contentsCode,
    bool includeNamespaces = true)
        {
            var sb = new StringBuilder();



            if (includeNamespaces)
                sb.Append(GeneratorHelpers.GenerateUsingsNamespaces(generationOptions));


            sb.AppendLine();
            sb.Append($"public interface {interfaceName}");


            if (interfaces != null && interfaces.Any())
                ImplementationInterfaces(ref sb, interfaces);

            //else if (!string.IsNullOrWhiteSpace(generationOptions.BaseInterface))
            //    sb.Append($" : {generationOptions.BaseInterface} ");
            

            sb.AppendLine("{");

            if (!string.IsNullOrWhiteSpace(contentsCode))
            {
                sb.AppendLine(contentsCode);
                sb.AppendLine();
            }

                sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }

    public static string GenerateClass(
        ClassDeclarationSyntax classDeclaration, 
        GenerationOptions generationOptions,
        string sourceClassName = "", 
        bool includeNamespaces = true,
        string typeModifierClass = "", 
        string typeModifierMethods = "")
        {
            var sb = new StringBuilder();
            
            if (string.IsNullOrWhiteSpace(generationOptions.ClassName))
            {
                return " ";
            }

            if(includeNamespaces)
                sb.Append(GeneratorHelpers.GenerateUsingsNamespaces(generationOptions));
            sb.AppendLine();


            sb.Append($" public {typeModifierClass} class {generationOptions.ClassName}");

            if (!string.IsNullOrWhiteSpace(generationOptions.BaseClass))
            {
                var baseClass = generationOptions.BaseClass;
                if (!string.IsNullOrWhiteSpace(sourceClassName))
                {
                    baseClass = baseClass.Replace("<T>", $"<{sourceClassName}>");
                    //var tclass = generationOptions.ClassName.Replace(generationOptions.DestinationCategoryName, generationOptions.SourceCategoryName);
                     
                }
            
                sb.Append($" : {baseClass} ");
            } 
            
            if (generationOptions.ImplementGenerateInterface && !string.IsNullOrWhiteSpace(generationOptions.BaseInterface))
            {
               var symbole=sb.ToString().Contains(":")? " , ": " : ";
         
                sb.Append($"{symbole}{generationOptions.BaseInterface} ");
            }


            if(generationOptions.ImplementOtherInterfacesInClass)
                ImplementationInterfaces(ref sb, generationOptions.Interfaces);


            var methods = classDeclaration.Members
                            .OfType<MethodDeclarationSyntax>()
                            .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword)
                            && m.ParameterList.Parameters.Any(p => p.Type?.ToString().EndsWith("CancellationToken") == true));


            sb.AppendLine("{");

            if (!string.IsNullOrWhiteSpace(generationOptions.AdditionalCode))
            {
                var code = generationOptions.AdditionalCode.Replace("{ClassName}", Regex.Replace(generationOptions.ClassName, @"<[^<>]*>", ""));
                if(code.Contains("{BaseClass"))
                    code = code.Replace("{BaseClass}", generationOptions.BaseClass);
                if (code.Contains("{IPropertyType"))
                    code = code.Replace("{IPropertyType}", $"I{sourceClassName}");

                sb.AppendLine(code);
                sb.AppendLine();
            }
         

            foreach (var method in methods)
            {

                var generateCode = "";

                if (!string.IsNullOrWhiteSpace(typeModifierMethods))
                {
                    generateCode = GenerateDeclarationMethod(method, generationOptions.UnifiedNameForFunctions);
                    generateCode= generateCode.Replace("public", $" public {typeModifierMethods} ");
                }
                else
                    generateCode = GenerateMethod(method, generationOptions.MethodContentCode, generationOptions.UnifiedNameForFunctions);

                sb.AppendLine(generateCode);
            }
            sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }    
     
    public static string GenerateDeclarationMethod(MethodDeclarationSyntax method,string unifiedNameForFunctions="",string typeModifierMethode="")
    {

        var sb = new StringBuilder();
        var returnType = method.ReturnType.ToString();
        var methodName = (string.IsNullOrWhiteSpace(unifiedNameForFunctions)) ? method.Identifier.Text : unifiedNameForFunctions;
        var parameters = string.Join(", ", method.ParameterList.Parameters
            .Select(p => $"{p.Type} {p.Identifier.Text}"));

        var modifiers = string.Join(" ", method.Modifiers.Select(m => m.Text));

        (returnType, modifiers) = CleanMethodSignature(method);

        sb.AppendLine($"    {modifiers} {returnType} {methodName}({parameters});");

        return CleanGeneratorCode(sb.ToString());
    }    
    public static string GenerateMethod(MethodDeclarationSyntax method,
        string implementationCode,string unifiedNameForFunctions="")
    {
        var sb = new StringBuilder();
        var returnType = method.ReturnType.ToString();
        var methodName = method.Identifier.Text;
        var parameters = string.Join(", ", method.ParameterList.Parameters
            .Select(p => $"{p.Type} {p.Identifier.Text}"));
        var variables = string.Join(", ", method.ParameterList.Parameters
            .Select(p => p.Identifier.Text));

        var modifiers = string.Join(" ", method.Modifiers.Select(m => m.Text));



        (returnType,modifiers) = CleanMethodSignature(method, " async ");

            if (!modifiers.Contains("async"))
                modifiers += $" async ";

            implementationCode = implementationCode.Replace("{InvokeMethodCallback}",$"{methodName}({variables})" );
        implementationCode = implementationCode.Replace("[RETERN]", returnType.Contains("Task<")?" return  ":"");

            if(!string.IsNullOrWhiteSpace(unifiedNameForFunctions))
                methodName =  unifiedNameForFunctions;

           
        // كتابة توقيع الدالة + جسم فارغ
        sb.AppendLine($"    {modifiers} {returnType} {methodName}({parameters})");
        sb.AppendLine("    {");
        sb.AppendLine($"    {implementationCode}");
        sb.AppendLine("    }");
        sb.AppendLine();

        return CleanGeneratorCode(sb.ToString());
    }

    public static string CleanGeneratorCode(string code)
    {
        return code.Replace("System.Threading.Tasks.", "")
                    .Replace("System.Threading.", "")
                    .Replace("System.Collections.Generic.", "");
       
    }
    public static (string ReturnType, string Modifiers) CleanMethodSignature(MethodDeclarationSyntax method,string newText="")
    {
        // استخراج نوع الإرجاع كـ string
        var returnType = method.ReturnType.ToString();

        // إزالة المسار الكامل لنوع Task لتبسيطه
        returnType = returnType.Replace("System.Threading.Tasks.", " ");
        returnType = returnType.Replace("System.Threading.", " ");

        // استخراج المعدّلات (modifiers) كـ string
        var modifiers = string.Join(" ", method.Modifiers.Select(m => m.Text));

        // استبدال virtual بـ async إن كانت الدالة تُعيد Task<> ولم تكن async بالفعل
        if (!string.IsNullOrWhiteSpace(newText) && (returnType.Contains("Task<") || returnType.Contains(" Task ")) && !modifiers.Contains("async"))
        {
            modifiers = modifiers.Replace("virtual", newText);
            if (!modifiers.Contains(newText))
                modifiers += $" {newText}";
        }
        else
        {
            if(modifiers.Contains("async") && string.IsNullOrWhiteSpace(newText))
                modifiers = modifiers.Replace("async", " ");

            modifiers = modifiers.Replace("virtual", " ").Trim();
        }
        

            return (returnType.Trim(), modifiers.Trim());
    }

       
    }
    
}
