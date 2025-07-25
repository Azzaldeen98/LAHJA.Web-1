﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace AutoGenerator.Config
{
    // لتوفير كود المصدر (File, Memory, Database, etc.)




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
