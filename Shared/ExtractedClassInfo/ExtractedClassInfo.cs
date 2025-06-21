using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ExtractedNSwagCode
{
    public class ExtractedClassInfo
    {
        public static void ReadInfoFromFile(string baseClass,string filePath, string outputPath){


            if (string.IsNullOrWhiteSpace(baseClass))
            {
                Console.WriteLine("يجب تضمين اسم الفئة او الواجهة الاب ");
                return;
            }


            var sb = new StringBuilder();
            sb.AppendLine("// هذا الملف تم إنشاؤه تلقائيًا لتحليل الكود\n");
    
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("الملف المصدر غير موجود.");
                return;
            }

            if (string.IsNullOrWhiteSpace(outputPath) || Path.GetExtension(outputPath) == string.Empty)
            {
                Console.WriteLine("مسار الملف الوجهة غير صالح.");
                return;
            }

            try
            {
                // تأكد من وجود المجلد الأب
                var directory = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"حدث خطأ أثناء إنشاء المجلد الوجهة: {ex.Message}");
                return;
            }

            var code = File.ReadAllText(filePath);
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetCompilationUnitRoot();

            var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

            foreach (var classDecl in classDeclarations)
            {
                bool implementsInterface = classDecl.BaseList?.Types
                    .Any(bt => bt.Type.ToString().EndsWith(baseClass)) ?? false;

                if (implementsInterface)
                {
                    var className = classDecl.Identifier.Text;
                    sb.AppendLine($"// Class: {className}");

                    //var methods = classDecl.Members
                    //    .OfType<MethodDeclarationSyntax>()
                    //    .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));
                    var methods = classDecl.Members
                                    .OfType<MethodDeclarationSyntax>()
                                    .Where(m =>
                                        m.Modifiers.Any(SyntaxKind.PublicKeyword) 
                                        //&&
                                        //m.ParameterList.Parameters.Any(p =>p.Type?.ToString().EndsWith("CancellationToken") == true)
                                    );



                    foreach (var method in methods)
                    {
                        //var methodName = method.Identifier.Text;
                        //var returnType = method.ReturnType.ToString();
                        //sb.AppendLine($"//   Method: {methodName}");
                        //sb.AppendLine($"//     Return Type: {returnType}");

                        //foreach (var param in method.ParameterList.Parameters)
                        //{
                        //    sb.AppendLine($"//     Parameter: {param.Identifier.Text} ({param.Type})");
                        //}

                        var returnType = method.ReturnType.ToString();
                        var methodName = method.Identifier.Text;
                        var parameters = string.Join(", ", method.ParameterList.Parameters
                            .Select(p => $"{p.Type} {p.Identifier.Text}"));

                        var modifiers = string.Join(" ", method.Modifiers.Select(m => m.Text));

                        // كتابة توقيع الدالة + جسم فارغ
                        sb.AppendLine($"{modifiers} {returnType} {methodName}({parameters})");
                        sb.AppendLine("{");
                        sb.AppendLine("    // TODO: Add implementation");
                        sb.AppendLine("}");
                        sb.AppendLine();
                    }

                    sb.AppendLine();
                }
            }

            File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
            Console.WriteLine("تم حفظ المعلومات في الملف بنجاح.");
        }

        

        public static void ReadInfo(string folderPath,string outputPath)
        {

                //var folderPath = @"C:\Path\To\Your\Code"; // عدّل المسار هنا
                //var outputPath = @"C:\Path\To\Output\ExtractedInfo.cs";

                var sb = new StringBuilder();
                sb.AppendLine("// هذا الملف تم إنشاؤه تلقائيًا لتحليل الكود\n");

                var csFiles = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories);

                foreach (var file in csFiles)
                {
                    var code = File.ReadAllText(file);
                    var tree = CSharpSyntaxTree.ParseText(code);
                    var root = tree.GetCompilationUnitRoot();

                    var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

                    foreach (var classDecl in classDeclarations)
                    {
                        bool implementsInterface = classDecl.BaseList?.Types
                            .Any(bt => bt.ToString() == "ITApiClient") ?? false;

                        if (implementsInterface)
                        {
                            var className = classDecl.Identifier.Text;
                            sb.AppendLine($"// Class: {className}");

                            var methods = classDecl.Members
                                .OfType<MethodDeclarationSyntax>()
                                .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));

                            foreach (var method in methods)
                            {
                                var methodName = method.Identifier.Text;
                                var returnType = method.ReturnType.ToString();
                                sb.AppendLine($"//   Method: {methodName}");
                                sb.AppendLine($"//     Return Type: {returnType}");

                                foreach (var param in method.ParameterList.Parameters)
                                {
                                    sb.AppendLine($"//     Parameter: {param.Identifier.Text} ({param.Type})");
                                }
                            }

                            sb.AppendLine();
                        }
                    }
                }

                File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
                Console.WriteLine("تم حفظ المعلومات في الملف بنجاح.");
            }
    }
    
}
