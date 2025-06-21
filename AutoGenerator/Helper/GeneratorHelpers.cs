using AutoGenerator.Code;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using System.Collections.ObjectModel;

namespace AutoGenerator.Helper
{
   public class GeneratorHelpers
    {

        public static Type? FindTypeByClassNameAndNamespace(string className, string namespaceName)
        {
            string fullTypeName = $"{namespaceName}.{className}";
            return GetTypeByName(fullTypeName);
        }

        public static Type? GetTypeByName(string fullTypeName)
        {
            // حاول إيجاد النوع باستخدام Type.GetType مباشرة
            var type = Type.GetType(fullTypeName);
            if (type != null)
                return type;

            // إذا لم يتم إيجاده، ابحث في كل التجميعات المحملة
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = assembly.GetType(fullTypeName);
                if (type != null)
                    return type;
            }

            // لم يتم العثور عليه
            return null;
        }

        public static string RemoveDelBlockIfSurrounded(string code)
        {
            var lines = code.Split('\n').ToList();
            int startIndex = lines.FindIndex(line => line.Contains("{/*{DelBlok}*/"));
            int endIndex = lines.FindIndex(line => line.Contains("/*{DelBlok}*/}"));

            if (startIndex > 0 && endIndex > startIndex)
            {
                // تحقق من وجود { قبل البلوك
                bool hasOpeningBraceBefore = lines.Take(startIndex).Any(line => line.Contains("{"));

                // تحقق من وجود } بعد البلوك
                bool hasClosingBraceAfter = lines.Skip(endIndex + 1).Any(line => line.Contains("}"));

                if (hasOpeningBraceBefore && hasClosingBraceAfter)
                {
                    // حذف الأسطر من startIndex إلى endIndex (شاملة)
                    lines.RemoveRange(startIndex, endIndex - startIndex + 1);
                }
            }

            return string.Join("\n", lines);
        }

        public static string CleanMessyCode(string rawCode)
        {
            try
            {
                var trimmed = rawCode.Trim();

                // ✅ لا تضف أقواس إذا كانت موجودة
                if (!trimmed.StartsWith("{") && !trimmed.EndsWith("}"))
                    trimmed = "{" + trimmed + "}";
       
                var block = SyntaxFactory.ParseStatement(trimmed) as BlockSyntax;
                if (block != null)
                {
                    return block.NormalizeWhitespace().ToString();
                    //var str= DeleteBlooks(code1);
                    //return str;
                }

                // fallback: parse full tree
                var tree = CSharpSyntaxTree.ParseText(trimmed);
                var root = tree.GetRoot().NormalizeWhitespace();

                return root.ToFullString();
                //return DeleteBlooks(code).Trim();

            }
            catch
            {
                return rawCode;
            }
        }


        public static string DeleteBlooks(string code)
        {
            int start = code.IndexOf("{");
            int end = code.LastIndexOf("}");

            if (start >= 0 && end > start)
            {
                return code.Substring(start + 1, end - start - 1).Trim();
            }
            else
            {
               
                return code;
            }
        }
        public static Type? ExtractPaginatedResultType(Type methodReturnType)
        {
            // تحقق إن كان النوع هو Task<T>
            if (methodReturnType.IsGenericType && methodReturnType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                // استخرج T من Task<T>
                var innerType = methodReturnType.GetGenericArguments()[0];

                // تحقق إن كان النوع T هو PaginatedResult<U>
                if (innerType.IsGenericType &&
                    innerType.GetGenericTypeDefinition().Name.StartsWith("PaginatedResult"))
                {
                    var dtoType = innerType.GetGenericArguments()[0]; // Plan
                    var paginatedGeneric = innerType.GetGenericTypeDefinition(); // PaginatedResult<>

                    // أعد بناء النوع بالشكل PaginatedResult<Plan>
                    return paginatedGeneric.MakeGenericType(dtoType);
                }
            }

            return null;
        }

        public static Type? ExtractCollectionTypeFromMethodReturnType(Type returnType)
        {
            // تحقق إذا كان النوع هو Task<T>
            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                var taskInnerType = returnType.GetGenericArguments()[0];

                // تحقق إذا كان taskInnerType هو نوع جنيريك
                if (taskInnerType.IsGenericType)
                {
                    // استخرج نوع التجميع (التعريف العام Generic Type Definition)
                    var genericTypeDef = taskInnerType.GetGenericTypeDefinition();

                    // قائمة أنوع التجميع المعروفة التي نعتبرها كمجموعات
                    var knownCollectionTypes = new[]
                    {
                typeof(IEnumerable<>),
                typeof(ICollection<>),
                typeof(List<>),
                typeof(IReadOnlyCollection<>),
                typeof(IReadOnlyList<>),
                typeof(HashSet<>),
                typeof(ObservableCollection<>),
                // يمكن إضافة أنواع أخرى حسب الحاجة
            };

                    // تحقق هل genericTypeDef موجود في القائمة
                    if (knownCollectionTypes.Contains(genericTypeDef))
                    {
                        return genericTypeDef; // نوع التجميع فقط بدون النوع الداخلي
                    }

                    // في حال كان نوع التجميع غير معروف، لكن هو جنيريك
                    // يمكن إرجاع genericTypeDef كنوع عام
                    // أو null لو تفضل فقط الأنواع المعروفة
                }
            }

            // غير مجموعة أو غير متطابق مع النوع المطلوب
            return null;
        }
        public static string GetSimpleTypeName(Type type)
        {
            var name = type.Name; // مثلا "ICollection`1"
            var backtickIndex = name.IndexOf('`');
            if (backtickIndex > 0)
                return name.Substring(0, backtickIndex); // "ICollection"
            return name; // لو ما فيه ` ترجع الاسم كما هو
        }

        public static Type? ExtractInnerTypeFromMethodReturnType(Type returnType, string genericDataType = "PaginatedResult")
        {
            // تحقق إن كان النوع هو Task<T>
            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                // استخرج T من Task<T>
                var taskInnerType = returnType.GetGenericArguments()[0];

                // تحقق إن كان T نوع جنيريك
                if (taskInnerType.IsGenericType)
                {
                    var genericTypeDef = taskInnerType.GetGenericTypeDefinition();
                    var genericTypeName = genericTypeDef.Name;

                    // حالة PaginatedResult<U> (أو حسب اسم genericDataType المرسل)
                    if (!string.IsNullOrWhiteSpace(genericDataType) && genericTypeName.StartsWith(genericDataType))
                    {
                        // استخرج U من PaginatedResult<U>
                        return taskInnerType.GetGenericArguments()[0];
                    }

                    // حالة ICollection<U> أو List<U> أو أنواع جنيريك أخرى
                    // نتحقق من بعض الأنواع الشائعة أو يمكن قبول جميع الأنواع الجنيريك مع استرجاع أول نوع جنيريك
                    var innerTypes = taskInnerType.GetGenericArguments();
                    if (innerTypes.Length == 1)
                    {
                        return innerTypes[0];
                    }
                }
                else
                {
                    // إذا لم يكن جنيريك، نعيد النوع كما هو
                    return taskInnerType;
                }
            }

            // في حال لم يكن النوع من النوع المطلوب
            return null;
        }

        public static Type? ExtractInnerTypeFromMethodReturnType2(Type returnType,string genericDataType= "PaginatedResult")
        {
            // تحقق إن كان النوع هو Task<T>
            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                // استخرج T من Task<T>
                var taskInnerType = returnType.GetGenericArguments()[0];

                // تحقق إن كان النوع الداخلي هو PaginatedResult<U>
                if (taskInnerType.IsGenericType && !string.IsNullOrWhiteSpace(genericDataType) &&
                    taskInnerType.GetGenericTypeDefinition().Name.StartsWith(genericDataType))
                {
                    // استخرج U من PaginatedResult<U>
                    var finalInnerType = taskInnerType.GetGenericArguments()[0];
                    return finalInnerType;
                }

                return taskInnerType;
            }

            // في حال لم يكن النوع من النوع المطلوب
            return null;
        }
        public static string GenerateUsingsNamespaces(GenerationOptions generationOptions)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            //sb.AppendLine($"using  System;");
            if (generationOptions.Usings.Any())
            {
                foreach (var library in generationOptions.Usings)
                {
                    sb.AppendLine($"using {library};");
                }
            }


            sb.AppendLine($"namespace {generationOptions.NamespaceName};");

            sb.AppendLine();

            return sb.ToString();
        }
        public static string GetFullReturnTypeWithNamespaces(MethodDeclarationSyntax methodSyntax, SemanticModel semanticModel)
        {
            if (methodSyntax == null || semanticModel == null)
                throw new ArgumentNullException();

            // استخراج نوع الإرجاع من الـ Syntax
            var returnTypeSyntax = methodSyntax.ReturnType;

            // الحصول على المعلومات النوعية باستخدام SemanticModel
            var typeInfo = semanticModel.GetTypeInfo(returnTypeSyntax);
            var returnTypeSymbol = typeInfo.Type;

            // إعادة النوع الكامل مع كل الـ namespaces
            return returnTypeSymbol?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) ?? string.Empty;
        }
        public static MethodDeclarationSyntax ConvertToSyntax(MethodInfo method)
        {
            // اسم الدالة
            var methodName = method.Name;

            // نوع الإرجاع
            var returnType = SyntaxFactory.ParseTypeName(GetFriendlyTypeName(method.ReturnType));

            // المعاملات
            var parameters = SyntaxFactory.ParameterList(
                SyntaxFactory.SeparatedList(
                    method.GetParameters().Select(p =>
                        SyntaxFactory.Parameter(SyntaxFactory.Identifier(p.Name))
                            .WithType(SyntaxFactory.ParseTypeName(GetFriendlyTypeName(p.ParameterType)))
                    )
                )
            );

            // جسم الدالة: رمية استثناء
            var body = SyntaxFactory.Block(
                SyntaxFactory.SingletonList<StatementSyntax>(
                    SyntaxFactory.ThrowStatement(
                        SyntaxFactory.ObjectCreationExpression(
                            SyntaxFactory.IdentifierName("NotImplementedException")
                        )
                        .WithArgumentList(SyntaxFactory.ArgumentList())
                    )
                )
            );

            // توليد MethodDeclarationSyntax
            return SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithModifiers(SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithParameterList(parameters)
                .WithBody(body);
        }

        private static string GetFriendlyTypeName(Type type)
        {
            if (type == typeof(void)) return "void";
            if (type == typeof(int)) return "int";
            if (type == typeof(string)) return "string";
            if (type == typeof(bool)) return "bool";
            if (type == typeof(object)) return "object";
            if (type == typeof(Task)) return "Task";

            if (type.IsGenericType)
            {
                var genericTypeName = type.Name.Substring(0, type.Name.IndexOf('`'));
                var genericArgs = string.Join(", ", type.GetGenericArguments().Select(GetFriendlyTypeName));
                return $"{genericTypeName}<{genericArgs}>";
            }

            return type.Name;
        }
    }
}
