namespace AutoGenerator.CodeAnalysis;

using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Linq;
using System.Reflection;
using AutoGenerator.CodeAnalysis.Descriptors;
using AutoGenerator.Enums;

/// <summary>
/// أداة لتحليل الكود من ملفات C# أو من النوع (Type) باستخدام Roslyn أو الانعكاس.
/// </summary>
public class CodeAnalyzer
{

    private List<string> attributes { get; set; } = new();
    private  string _code;
    private  CompilationUnitSyntax _root;

    public CodeAnalyzer() { 
    
    
    }

    /// <summary>
    /// يُنشئ مثيلًا جديدًا من <see cref="CodeAnalyzer"/> ويقرأ شجرة بناء الكود من الملف المحدد.
    /// </summary>
    /// <param name="filePath">المسار الكامل إلى ملف الكود.</param>
    /// <exception cref="FileNotFoundException">يُرمى إذا لم يكن الملف موجودًا.</exception>
    public void BuildFileCodeAnalyzer(string filePath)
    {
        if ( string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath) || !filePath.Trim().EndsWith(".cs") )
            throw new FileNotFoundException("File not found", filePath);

        _code = File.ReadAllText(filePath);
         var tree = CSharpSyntaxTree.ParseText(_code);
        _root = tree.GetCompilationUnitRoot();

    }
    //public bool HasAttribute(string attributeToCheck)
    //{

    //    if (!string.IsNullOrWhiteSpace(attributeToCheck))
    //    {
    //        attributeToCheck = attributeToCheck.Replace("Attribute", "");
    //    }

    //    if (attributes != null && attributes.Count()>0)
    //    {
    //      return  attributes.Contains(attributeToCheck);
    //    }

    //    return false;
    //}

    /// <summary>
    /// يُحلل الكلاس بناءً على نوعه (Type) ويُعيد معلومات حول الدوال والخصائص والسمات.
    /// </summary>
    /// <param name="type">نوع الكلاس المطلوب تحليله (typeof(MyClass)).</param>
    /// <param name="attributeToCheck">اسم السمة التي يتم التحقق منها لتصفية النتائج (اختياري).</param>
    /// <returns>كائن ClassDescriptor يحتوي على معلومات الكلاس.</returns>
    public ClassDescriptor ExtractClassDescriptor(Type type, ClassTypes? classType = ClassTypes.Class, string? attributeToCheck = null)
    {
        if (!string.IsNullOrWhiteSpace(attributeToCheck))
            attributeToCheck = attributeToCheck.Replace("Attribute", "");

        // استرجاع سمات الكلاس نفسه
        var classAttributes = type.GetCustomAttributes()
                                  .Select(a => a.GetType().Name.Replace("Attribute", ""))
                                  .ToList();

        var classDescriptor = new ClassDescriptor
        {
            Name = type.Name,
            Attributes = classAttributes
        };

        // استخراج الخصائص
        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
        {
            var attrs = prop.GetCustomAttributes()
                            .Select(a => a.GetType().Name.Replace("Attribute", ""))
                            .ToList();

            if (attributeToCheck != null && !attrs.Contains(attributeToCheck))
                continue;

            classDescriptor.Properties.Add(new PropertyDescriptor
            {
                Name = prop.Name,
                Attributes = attrs,
             
            });
        }

        // استخراج الدوال
        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
        {
            if (method.IsSpecialName) continue; // تجاهل set/get والتوابع الخاصة

            var attrs = method.GetCustomAttributes()
                              .Select(a => a.GetType().Name.Replace("Attribute", ""))
                              .ToList();

            if (attributeToCheck != null && !attrs.Contains(attributeToCheck))
                continue;

            classDescriptor.Methods.Add(new MethodDescriptor
            {
                Name = method.Name,
                Attributes = attrs
            });
        }

        // استخراج الحقول (اختياري – أضف إن كنت تستخدم FieldDescriptor)
        foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
        {
            var attrs = field.GetCustomAttributes()
                             .Select(a => a.GetType().Name.Replace("Attribute", ""))
                             .ToList();

            if (attributeToCheck != null && !attrs.Contains(attributeToCheck))
                continue;

            classDescriptor.Fields.Add(new FieldDescriptor
            {
                Name = field.Name,
                Attributes = attrs
            });
        }

        return classDescriptor;
    }

    /// <summary>
    /// يستخرج معلومات عن كلاس معين من الملف المحلل.
    /// يمكنك تحديد اسم الكلاس أو ترتيبه أو نوعه (class، interface، record).
    /// </summary>
    /// <param name="className">اسم الكلاس المطلوب (اختياري).</param>
    /// <param name="index">ترتيب الكلاس داخل الملف (اختياري).</param>
    /// <param name="classType">نوع الكلاس المطلوب: "class" أو "interface" أو "record". القيمة الافتراضية "class".</param>
    /// <param name="attributeToCheck">اسم السمة (Attribute) المطلوبة للتحقق منها في الدوال والخصائص (اختياري).</param>
    /// <returns>كائن <see cref="ClassDescriptor"/> يحتوي على تفاصيل الكلاس، أو null إذا لم يُعثر عليه.</returns>
    public ClassDescriptor ExtractClassDescriptor(string filePath , string? className = null, int? index = null, ClassTypes? classType = ClassTypes.Class, string? attributeToCheck = null)
    {

        BuildFileCodeAnalyzer(filePath);

        if (!string.IsNullOrWhiteSpace(attributeToCheck))
        {
            attributeToCheck = attributeToCheck.Replace("Attribute", "");
        }

        // البحث عن جميع أنواع الكلاسات
        IEnumerable<MemberDeclarationSyntax> classNodes = _root.DescendantNodes()
            .Where(n => n is ClassDeclarationSyntax || n is InterfaceDeclarationSyntax || n is RecordDeclarationSyntax)
            .Cast<MemberDeclarationSyntax>();

        // فلترة حسب نوع الكلاس

        classNodes = classNodes.Where(n =>
            (classType == ClassTypes.Class && n is ClassDeclarationSyntax) ||
            (classType == ClassTypes.Interface && n is InterfaceDeclarationSyntax) ||
            (classType == ClassTypes.Record && n is RecordDeclarationSyntax));
        

        // فلترة حسب الاسم
        if (!string.IsNullOrWhiteSpace(className))
        {
            classNodes = classNodes.Where(n => GetIdentifier(n).Text == className);
        }

        // فلترة حسب الترتيب داخل الملف
        if (index.HasValue)
        {
            classNodes = classNodes.Skip(index.Value).Take(1);
        }

        var classNode = classNodes.FirstOrDefault();
        if (classNode == null) return null;

        attributes = GetAttributes(((TypeDeclarationSyntax)classNode).AttributeLists);

        var classDescriptor = new ClassDescriptor
        {
            Name = GetIdentifier(classNode).Text,
            Attributes = attributes,
            Code = classNode.NormalizeWhitespace().ToFullString()
        };

    


        var members = (classNode as TypeDeclarationSyntax)?.Members;
        if (members == null) return classDescriptor;

        foreach (var member in members)
        {
            if (member is MethodDeclarationSyntax method)
            {
                var attrs = GetAttributes(method.AttributeLists);
                if (attributeToCheck != null && !attrs.Contains(attributeToCheck))
                    continue;

                classDescriptor.Methods.Add(new MethodDescriptor
                {
                    Name = method.Identifier.Text,
                    Attributes = attrs,
                    Code = method.NormalizeWhitespace().ToFullString()
                });
            }
            else if (member is PropertyDeclarationSyntax prop)
            {
                var attrs = GetAttributes(prop.AttributeLists);
                if (attributeToCheck != null && !attrs.Contains(attributeToCheck))
                    continue;

                classDescriptor.Properties.Add(new PropertyDescriptor
                {
                    Name = prop.Identifier.Text,
                    Attributes = attrs,
                    Code = prop.NormalizeWhitespace().ToFullString()
                });
            }
            else if (member is FieldDeclarationSyntax field)
            {
                var attrs = GetAttributes(field.AttributeLists);
                if (attributeToCheck != null && !attrs.Contains(attributeToCheck))
                    continue;

                foreach (var variable in field.Declaration.Variables)
                {
                    classDescriptor.Fields.Add(new FieldDescriptor
                    {
                        Name = variable.Identifier.Text,
                        Attributes = attrs,
                        Code = variable.NormalizeWhitespace().ToFullString()
                    });
                }
            }
        }

        return classDescriptor;
    }

    /// <summary>
    /// يستخرج اسم الكلاس أو الواجهة أو السجل من العقدة.
    /// </summary>
    /// <param name="node">العقدة النحوية للكلاس أو الواجهة أو السجل.</param>
    /// <returns>اسم الكيان المحدد (class/interface/record).</returns>
    private static SyntaxToken GetIdentifier(MemberDeclarationSyntax node)
    {
        return node switch
        {
            ClassDeclarationSyntax cls => cls.Identifier,
            InterfaceDeclarationSyntax iface => iface.Identifier,
            RecordDeclarationSyntax rec => rec.Identifier,
            _ => default
        };
    }

    /// <summary>
    /// يستخرج أسماء السمات (Attributes) من القوائم النحوية الخاصة بها.
    /// </summary>
    /// <param name="attributeLists">قائمة السمات (AttributeListSyntax).</param>
    /// <returns>قائمة بأسماء السمات كنصوص.</returns>
    private static List<string> GetAttributes(SyntaxList<AttributeListSyntax> attributeLists)
    {
        return attributeLists
            .SelectMany(al => al.Attributes)
            .Select(attr => attr.Name.ToString())
            .ToList();
    }
}

