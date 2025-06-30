using System.Reflection;
using AutoGenerator.CodeAnalysis.Specifications;
using Microsoft.CodeAnalysis;


namespace AutoGenerator.Config
{


    /// <summary>
    /// Provides methods to explore and retrieve types from an assembly based on various filtering criteria.
    /// </summary>
    public interface IDataTypeExplorerService
    {
        /// <summary>
        /// Gets all types discovered in the specified assembly that match an optional predicate.
        /// </summary>
        /// <param name="assembly">The assembly to scan for types.</param>
        /// <param name="predicate">An optional filter predicate to apply to types.</param>
        /// <returns>A list of types that satisfy the predicate or all types if no predicate is provided.</returns>
        List<Type> GetDiscoveredTypes(Assembly assembly, Func<Type, bool> predicate = null);

        /// <summary>
        /// Gets types representing data models within the specified assembly, optionally filtered by interface implementation and namespace.
        /// </summary>
        /// <param name="assembly">The assembly to scan for data model types.</param>
        /// <param name="interfaceType">An optional interface type that data models should implement.</param>
        /// <param name="targetNamespace">An optional namespace to restrict the search.</param>
        /// <returns>A list of data model types matching the criteria.</returns>
        List<Type> GetDataModelsType(Assembly assembly, Type interfaceType = null, string targetNamespace = null);

        /// <summary>
        /// Gets types representing repository classes within the specified assembly, filtered by name suffix, optional interface, and namespace.
        /// </summary>
        /// <param name="assembly">The assembly to scan for repository types.</param>
        /// <param name="endText">The suffix that repository class names should end with.</param>
        /// <param name="interfaceType">An optional interface type that repositories should implement.</param>
        /// <param name="targetNamespace">An optional namespace to restrict the search.</param>
        /// <returns>A list of repository types matching the criteria.</returns>
        List<Type> GetRepositoriesType(Assembly assembly, string endText, Type? interfaceType = null, string? targetNamespace = null);

        /// <summary>
        /// Gets data model types in the specified assembly filtered by namespace only.
        /// </summary>
        /// <param name="assembly">The assembly to scan.</param>
        /// <param name="targetNamespace">Optional namespace to filter types.</param>
        /// <returns>A list of data model types in the namespace.</returns>
        List<Type> GetDataModelsType(Assembly assembly, string targetNamespace = null);
  
        /// <summary>
        /// Gets types in the assembly whose names contain a specified keyword, optionally filtered by interface implementation and namespace.
        /// </summary>
        /// <param name="assembly">The assembly to scan.</param>
        /// <param name="keyword">The keyword to match within type names.</param>
        /// <param name="interfaceType">Optional interface type to filter types.</param>
        /// <param name="targetNamespace">Optional namespace filter.</param>
        /// <returns>A list of types with names containing the keyword.</returns>
        List<Type> GetModelsType(Assembly assembly, string keyword, Type? interfaceType = null, string? targetNamespace = null);
    }

    /// <summary>
    /// Implements <see cref="IDataTypeExplorerService"/> to provide filtering and retrieval of types from assemblies
    /// using customizable predicates and filters.
    /// </summary>
    public class DataTypeExplorerService : IDataTypeExplorerService
    {
        /// <inheritdoc/>
        public List<Type> GetDiscoveredTypes(Assembly assembly, Func<Type, bool> predicate = null)
        {
            var types = assembly.GetTypes();

            if (predicate != null)
            {
                types = types.Where(predicate).ToArray();
            }

            return types.ToList();
        }

        /// <inheritdoc/>
        public List<Type> GetDataModelsType(Assembly assembly, Type? interfaceType = null, string? targetNamespace = null)
        {
            var filter = new TypeSpecificationBuilder()
               .InNamespace(targetNamespace)
               .IsClass(true)
               .IsPublic(true)
               .IsImplementInterface(interfaceType, true)
               .IsStaticClass(false)
               .DoesInherit(true)
               .HasMethods(false)
               .HasConstructors(false)
               .HasStaticProperties(false)
               .HasStaticMethods(false)
               .Build();

            return new DataTypeExplorerService().GetDiscoveredTypes(assembly, filter);
        }

        /// <inheritdoc/>
        public List<Type> GetModelsType(Assembly assembly, string keyword, Type? interfaceType = null, string? targetNamespace = null)
        {
            var filter = new TypeSpecificationBuilder()
               .InNamespace(targetNamespace)
               .IsClass(true)
               .IsPublic(true)
               .IsImplementInterface(interfaceType, true)
               .WhereNameContains(keyword)
               .Build();

            return new DataTypeExplorerService().GetDiscoveredTypes(assembly, filter);
        }

        /// <inheritdoc/>
        public List<Type> GetRepositoriesType(Assembly assembly, string endText, Type? interfaceType = null, string? targetNamespace = null)
        {
            var filter = new TypeSpecificationBuilder()
               .InNamespace(targetNamespace)
               .IsClass(true)
               .IsPublic(true)
               .IsImplementInterface(interfaceType, true)
               .WhereNameEndWith(endText)
               .Build();

            return new DataTypeExplorerService().GetDiscoveredTypes(assembly, filter);
        }

        /// <inheritdoc/>
        public List<Type> GetDataModelsType(Assembly assembly, string? targetNamespace = null)
        {
            return GetDataModelsType(assembly, null, targetNamespace);
        }
    }


    //public interface IDataTypeExplorerService
    //{
    //    List<Type> GetDiscoveredTypes(Assembly assembly, Func<Type, bool> predicate = null);
    //    List<Type> GetDataModelsType(Assembly assembly, Type interfaceType = null, string targetNamespace = null);
    //     List<Type> GetRepositoriesType(Assembly assembly, string endText, Type? interfaceType = null, string? targetNamespace = null);
    //    List<Type> GetDataModelsType(Assembly assembly, string targetNamespace = null);
    //    List<Type> GetModelsType(Assembly assembly, string keyword, Type? interfaceType = null, string? targetNamespace = null);
    //}



    ///// <summary>
    ///// 
    ///// </summary>
    //public class DataTypeExplorerService : IDataTypeExplorerService
    //{

    //    public List<Type> GetDiscoveredTypes(Assembly assembly, Func<Type, bool> predicate = null)
    //    {
    //        var types = assembly.GetTypes();

    //        if (predicate != null)
    //        {
    //            types = types.Where(predicate).ToArray();
    //        }

    //        return types.ToList();
    //    }


    //    public List<Type> GetDataModelsType(Assembly assembly, 
    //                                        Type? interfaceType=null, 
    //                                        string? targetNamespace = null)
    //    {


    //        var filter = new TypeFilterBuilder()
    //           .InNamespace(targetNamespace)
    //           .IsClass(true)
    //           .IsPublic(true)
    //           .IsImplementInterface(interfaceType, true)
    //           .IsStaticClass(false)
    //           .DoesInherit(true)
    //           .HasMethods(false)
    //           .HasConstructors(false)
    //           .HasStaticProperties(false)
    //           .HasStaticMethods(false)
    //           .Build();


    //       return new DataTypeExplorerService().GetDiscoveredTypes(assembly, filter);
    //    }

    //    public List<Type> GetModelsType(Assembly assembly, string keyword, Type? interfaceType = null, string? targetNamespace = null)
    //    {


    //        var filter = new TypeFilterBuilder()
    //           .InNamespace(targetNamespace)
    //           .IsClass(true)
    //           .IsPublic(true)
    //           .IsImplementInterface(interfaceType, true)
    //           .WhereNameContains(keyword)
    //           .Build();


    //        return new DataTypeExplorerService().GetDiscoveredTypes(assembly, filter);
    //    }

    //    public List<Type> GetRepositoriesType(Assembly assembly, string endText, Type? interfaceType = null, string? targetNamespace = null)
    //    {


    //        var filter = new TypeFilterBuilder()
    //           .InNamespace(targetNamespace)
    //           .IsClass(true)
    //           .IsPublic(true)
    //           .IsImplementInterface(interfaceType, true)
    //           .WhereNameEndWith(endText)
    //           .Build();


    //        return new DataTypeExplorerService().GetDiscoveredTypes(assembly, filter);
    //    }


    //    public List<Type> GetDataModelsType(Assembly assembly, string? targetNamespace = null)
    //    {
    //        return GetDataModelsType(assembly,null,targetNamespace );
    //    }

    //}



    //public static class InterfaceInjector2
    //{

    //    /// <summary>
    //    ///  اعادة حقن واجهة في فئات معينة في ملف C#.
    //    ///  اعادة توريث فئة او كلاس  لمجموعة فئات معينة بشكل الي  واعادة كتابة الملف مره اخرى بعد التعديل
    //    /// </summary>
    //    /// <param name="sourceFilePath"></param>
    //    /// <param name="interfaceFullName"></param>
    //    /// <param name="suffixPattern"></param>
    //    /// <param name="outputFilePath"></param>
    //    public static void InjectInterface(
    //    string sourceFilePath,
    //    string interfaceFullName,
    //    string suffixPattern = null,
    //    string outputFilePath = null)
    //    {
    //        // 1. قراءة الملف وتحليل الشيفرة
    //        var code = File.ReadAllText(sourceFilePath);
    //        var tree = CSharpSyntaxTree.ParseText(code);
    //        var root = tree.GetCompilationUnitRoot();

    //        bool modified = false; // 🔹 لتتبع ما إذا كان هناك تعديل

    //        // 1. التأكد من وجود using للـ namespace الخاص بالواجهة
    //        var interfaceNamespace = interfaceFullName.Contains('.')
    //            ? interfaceFullName.Substring(0, interfaceFullName.LastIndexOf('.'))
    //            : null;

    //        if (!string.IsNullOrEmpty(interfaceNamespace))
    //        {
    //            var hasUsing = root.Usings.Any(u => u.Name.ToString() == interfaceNamespace);
    //            if (!hasUsing)
    //            {
    //                var usingDirective = SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(interfaceNamespace))
    //                                                  .WithTrailingTrivia(SyntaxFactory.ElasticCarriageReturnLineFeed);
    //                root = root.AddUsings(usingDirective);
    //                modified = true; // 📌 تم التعديل
    //            }
    //        }

    //        // 2. تحديد الفئات الهدف
    //        var classDecls = root.DescendantNodes()
    //            .OfType<ClassDeclarationSyntax>()
    //            .Where(c => string.IsNullOrEmpty(suffixPattern) || c.Identifier.Text.EndsWith(suffixPattern))
    //            .ToList();

    //        // 3. استبدال العقد لكل فئة هدف
    //        var newRoot = root.ReplaceNodes(
    //            classDecls,
    //            (original, _) =>
    //            {
    //                var baseList = original.BaseList ?? SyntaxFactory.BaseList();
    //                var interfaceType = SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(interfaceFullName));
    //                var interfaceSimpleName = interfaceFullName.Split('.').Last();

    //                // 🔍 التحقق من وجود الواجهة بالفعل
    //                var hasInterface = baseList.Types.Any(bt =>
    //                    bt.Type.ToString() == interfaceSimpleName ||
    //                    bt.Type.ToString() == interfaceFullName);

    //                if (!hasInterface)
    //                {
    //                    modified = true; // 📌 تم التعديل
    //                    baseList = baseList.AddTypes(interfaceType);
    //                    return original.WithBaseList(baseList);
    //                }

    //                return original;
    //            });

    //        // 4. حفظ الملف فقط إذا كان هناك تعديل
    //        if (modified)
    //        {
    //            File.WriteAllText(outputFilePath ?? sourceFilePath,
    //                newRoot.NormalizeWhitespace().ToFullString());
    //        }
    //    }


    //    public static void AddInterfaceToDataModel(string filePath, string className, string interfaceName = "ITDto")
    //    {
    //        var fileText = File.ReadAllText(filePath);

    //        // نبحث عن تعريف الكلاس
    //        var pattern = $@"(public\s+partial\s+class\s+{className})(\s*:\s*[\w\s,]+)?";
    //        var regex = new Regex(pattern);

    //        var match = regex.Match(fileText);
    //        if (match.Success)
    //        {
    //            var fullMatch = match.Value;

    //            // تحقق إذا كانت الواجهة مضافة مسبقًا
    //            if (!fullMatch.Contains(interfaceName))
    //            {
    //                string updatedDeclaration;
    //                if (match.Groups[2].Success)
    //                {
    //                    // الكلاس يرث شيئًا مسبقًا، نضيف الواجهة
    //                    updatedDeclaration = $"{match.Groups[1].Value}{match.Groups[2].Value}, {interfaceName}";
    //                }
    //                else
    //                {
    //                    // لا يوجد وراثة، نضيف : واجهة
    //                    updatedDeclaration = $"{match.Groups[1].Value} : {interfaceName}";
    //                }

    //                var updatedText = regex.Replace(fileText, updatedDeclaration, 1);
    //                File.WriteAllText(filePath, updatedText);
    //                Console.WriteLine($"✅ تمت إضافة {interfaceName} إلى الكلاس {className} في الملف.");
    //            }
    //            else
    //            {
    //                Console.WriteLine($"ℹ️ الكلاس {className} يحتوي مسبقًا على {interfaceName}.");
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine($"❌ لم يتم العثور على تعريف الكلاس {className} في الملف.");
    //        }
    //    }

    //}

}
