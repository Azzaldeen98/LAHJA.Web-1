using Shared.Interfaces;
using System.Reflection;
using System.Text.RegularExpressions;
using AutoGenerator.Code;
using AutoGenerator.Helper;

namespace AutoGenerator.Config
{
    using AutoGenerator.Config.Attributes;
    using Microsoft.CodeAnalysis;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class RepositoryAnalyzer
    {
        public Dictionary<string, string> ProcessRepository(Type repositoryType)
        {
            var chunksCode = new Dictionary<string, string>();

            var mapperField = GetField(repositoryType, "_mapper");
            var apiClientField = GetField(repositoryType, "_apiClient");

            if (mapperField == null || apiClientField == null)
            {
                Console.WriteLine($"❌ الحقول المطلوبة (_mapper و _apiClient) غير موجودة في الكلاس {repositoryType.Name}");
                return null;
            }

            var apiClientType = apiClientField.FieldType;
            var methods = repositoryType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                Console.WriteLine($"\n📌 تحليل الدالة: {method.Name}");

          

                var methodSyntax = GeneratorHelpers.ConvertToSyntax(method);
                var parameters = method.GetParameters();
                var (returnTypeStr, modifiers) = AutoCodeGenerator.CleanMethodSignature(methodSyntax);

                var dsoParam = parameters.FirstOrDefault(p => typeof(ITDso).IsAssignableFrom(p.ParameterType));
                var noDsoParamNames = parameters.Select(p => p.Name).ToList();

                var returnType = GeneratorHelpers.ExtractInnerTypeFromMethodReturnType(method.ReturnType);
                var returnCollectionType = GeneratorHelpers.ExtractCollectionTypeFromMethodReturnType(method.ReturnType);

                ///TODO :  Read RouteToAttribute

                var routeToAttribute = method.GetCustomAttribute<RouteToAttribute>();

                var keywords = new List<string>();
                if (routeToAttribute != null && routeToAttribute is RouteToAttribute)
                {
                    keywords.Add(routeToAttribute.Name);
                }
                else
                {
                    keywords.Add(method.Name);

                    //keywords = ExtractKeywords(method.Name);
                }
                if (method.Name.Contains("ForgotPassword"))
                {

                }
                if (dsoParam == null)
                {
                    var bodyCode = GenerateBodyWithoutDso(apiClientType, keywords, noDsoParamNames, returnType, returnTypeStr, returnCollectionType);
                    var cleanedBodyCode = GeneratorHelpers.CleanMessyCode(bodyCode);
                    chunksCode.Add(method.Name, cleanedBodyCode);

                }
                else
                {
                    var bodyCode = GenerateBodyWithDso(apiClientType, keywords, dsoParam, returnType, returnCollectionType);
                    var cleanedBodyCode = GeneratorHelpers.CleanMessyCode(bodyCode);
                    chunksCode.Add(method.Name, cleanedBodyCode);

                }
            }

            return chunksCode;
        }

        private FieldInfo GetField(Type type, string fieldName)
            => type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);

        private string GenerateBodyWithoutDso(Type apiClientType, List<string> keywords, List<string> paramNames,
            Type returnType, string returnTypeStr, Type? returnCollectionType=null)
        {
            if (paramNames == null) paramNames = new List<string>();

            string paramText = paramNames.Any() ? string.Join(",", paramNames) : string.Empty;

            Console.WriteLine("⚠️ الدالة لا تحتوي على معاملات ITDso، سيتم استخدام دالة ApiClient بدون تحويل.");

            var apiMethod = FindTargetMethod(apiClientType, keywords);


            if (apiClientType.Name.Contains("ForgotPassword"))
            {
        
             
            }


            if (apiMethod == null )
            {
                Console.WriteLine("❌ لم يتم العثور على دالة مطابقة داخل _apiClient");
                return string.Empty;
            }

            var apiReturnType = GeneratorHelpers.ExtractInnerTypeFromMethodReturnType(apiMethod.ReturnType);
            var (apiReturnTypeStr, _) = AutoCodeGenerator.CleanMethodSignature(GeneratorHelpers.ConvertToSyntax(apiMethod));

            bool returnsValue = IsReturnTypeWithValue(apiReturnType);

            var body = new StringBuilder();

            if (returnsValue)
            {
                body.AppendLine($"\n\tvar result = await _apiClient.{apiMethod.Name}({paramText});");

                if (typeof(ITDso).IsAssignableFrom(returnType))
                {
                    if (apiReturnTypeStr.Contains("Paged"))
                    {
                        body.AppendLine(generatePaginatedResult(returnType.Name, true));
                    }
                    else
                    {
                        
                        var _type= (returnCollectionType != null && !string.IsNullOrWhiteSpace(returnCollectionType.Name)) 
                            ? $"{GeneratorHelpers.GetSimpleTypeName(returnCollectionType)}<{returnType.Name}>" : returnType.Name;  
                        body.AppendLine($"\n\treturn _mapper.Map<{_type}>(result);");
                    }
                }
                else
                {
                    if (apiReturnTypeStr.Contains("Paged"))
                    {
                        body.AppendLine(generatePaginatedResult(returnType.Name, false));
        
                    }
                    else
                    {
                        body.AppendLine("\n\treturn result;");
                    }
                }
            }
            else
            {
                body.AppendLine($"\n\tawait _apiClient.{apiMethod.Name}({paramText});");
            }

            return body.ToString();
        }

        private string GenerateBodyWithDso(Type apiClientType, List<string> keywords, ParameterInfo dsoParam, Type returnType, Type? returnCollectionType = null)
        {
            var apiMethod = FindTargetMethod(apiClientType, keywords);
            if (apiMethod == null)
            {
                Console.WriteLine("❌ لم يتم العثور على دالة مطابقة داخل _apiClient");
                return string.Empty;
            }

            var apiParams = apiMethod.GetParameters();
            var dtoParam = apiParams.FirstOrDefault(p => typeof(ITDto).IsAssignableFrom(p.ParameterType));
            if (dtoParam == null)
            {
                Console.WriteLine("⚠️ دالة ApiClient لا تحتوي على معامل من نوع ITDto");
                return string.Empty;
            }

            var apiReturnType = GeneratorHelpers.ExtractInnerTypeFromMethodReturnType(apiMethod.ReturnType);
            var (apiReturnTypeStr, _) = AutoCodeGenerator.CleanMethodSignature(GeneratorHelpers.ConvertToSyntax(apiMethod));
            var paramNames = apiParams.Select(p => p.Name).ToArray();
            var paramsText = string.Join(",", paramNames);

            var body = new StringBuilder();

            // تحويل DSO إلى DTO
            body.AppendLine($"\n\tvar _{dtoParam.Name} = _mapper.Map<{dtoParam.ParameterType.Name}>({dsoParam.Name});");
            paramsText = paramsText.Replace(dtoParam.Name, $"_{dtoParam.Name}");

            if (IsReturnTypeWithValue(apiReturnType))
            {
                body.AppendLine($"\n\tvar result = await _apiClient.{apiMethod.Name}({paramsText});");

                if (typeof(ITDto).IsAssignableFrom(apiReturnType))
                {
                    if (apiReturnTypeStr.Contains("Paged"))
                    {
                        body.AppendLine(generatePaginatedResult(returnType.Name, true));
                    }
                    else
                    {
                        var _type = (returnCollectionType != null && !string.IsNullOrWhiteSpace(returnCollectionType.Name))
                           ? $"{GeneratorHelpers.GetSimpleTypeName(returnCollectionType)}<{returnType.Name}>" : returnType.Name;

                        body.AppendLine($"\n\treturn _mapper.Map<{_type}>(result);");
                     
                    }
                }
                else
                {
                    if (apiReturnTypeStr.Contains("Paged"))
                    {
                        body.AppendLine(generatePaginatedResult(returnType.Name,false));
                    }
                    else
                    {
                        body.AppendLine("\n\treturn result;");
                    }
                }
            }
            else
            {
                body.AppendLine($"\n\tawait _apiClient.{apiMethod.Name}({paramsText});");
            }

            return body.ToString();
        }

        private string generatePaginatedResult(string typeName,bool hasMapped=true)
        {
            var data =  hasMapped ? $"_mapper.Map<List<{typeName}>>(result.Data.ToList())":"result.Data.ToList()";
            return "\n"+$@"
                return PaginatedResult<{typeName}>.Success(
                    {data},
                    result.TotalRecords,
                    result.PageNumber,
                    result.PageSize,
                    result.SortBy,
                    result.SortDirection);";
        }
        private bool IsReturnTypeWithValue(Type returnType)
        {
            if (returnType == null || returnType == typeof(void) || returnType == typeof(Task))
                return false;

            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
                return true;

            return true;
        }

        private List<string> ExtractKeywords(string methodName)
        {
            return Regex.Matches(methodName, "[A-Z][a-z]*")
                .Cast<Match>()
                .Select(m => m.Value.ToLower())
                .ToList();
        }

        private MethodInfo FindTargetMethod(Type apiClientType, List<string> keywords)
        {
            var methods = apiClientType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            // 1. تطابق تام مع أحد الكلمات
            var exactMatch = methods.FirstOrDefault(m => keywords.Contains(m.Name));
            if (exactMatch != null)
                return exactMatch;

            // 2. استخراج كلمات مفتاحية جديدة من أول كلمة (إن وجدت)
            if (keywords != null && keywords.Any())
                keywords = ExtractKeywords(keywords.First());

            // 3. تحقق من صلاحية الكلمات بعد الاستخراج
            if (keywords == null || !keywords.Any())
                return null;

            // 4. تطابق جزئي (كل كلمة موجودة في اسم الدالة)
            return methods.FirstOrDefault(m =>
            {
                var name = m.Name.ToLowerInvariant();
                return keywords.All(k => name.Contains(k.ToLowerInvariant()));
            });
        }

    }

    //public class RepositoryAnalyzer2
    //{


    //    public Dictionary<string, string> ProcessRepository(Type repositoryType)
    //    {
    //        Dictionary<string, string>  chunksCode = new Dictionary<string, string>();
    //        var mapperField = repositoryType.GetField("_mapper", BindingFlags.Instance | BindingFlags.NonPublic);
    //        var apiClientField = repositoryType.GetField("_apiClient", BindingFlags.Instance | BindingFlags.NonPublic);

    //        if (mapperField == null || apiClientField == null)
    //        {
    //            Console.WriteLine($"❌ لم يتم العثور على الحقول المطلوبة داخل الكلاس {repositoryType.Name}");
    //            return null;
    //        }

    //        var apiClientType = apiClientField.FieldType;

    //        var methods = repositoryType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

    //        foreach (var method in methods)
    //        {
    //            Console.WriteLine($"\n📌 تحليل الدالة: {method.Name}");

    //            var methodSyntax = GeneratorHelpers.ConvertToSyntax(method);


    //            var parameters = method.GetParameters();


    //            (var returnTypeStr, var Modifiers) = AutoCodeGenerator.CleanMethodSignature(methodSyntax);
    //            var dsoParam = parameters.FirstOrDefault(p => typeof(ITDso).IsAssignableFrom(p.ParameterType));
    //            var noDsoParams = parameters.Select(p => p.Name);
    //            var returnType = GeneratorHelpers.ExtractInnerTypeFromMethodReturnType(method.ReturnType); 

    //            var mytype = GeneratorHelpers.ConvertToSyntax(method).ReturnType.ToString();

    //            var keywords = ExtractKeywords(method.Name);


    //            if (dsoParam == null)
    //            {
    //                var paramNamesText = "";
    //                if (dsoParam == null && noDsoParams.Any())
    //                {
    //                    paramNamesText = string.Join(",", noDsoParams);
    //                }

    //                Console.WriteLine("⚠️ لا تحتوي الدالة على معاملات من نوع ITDso، سيتم محاولة البحث بدون تحويل معامل.");

    //                var apiMethodWithoutParam = FindApiClientMethod(apiClientType, keywords);
    //                if (apiMethodWithoutParam == null)
    //                {
    //                    Console.WriteLine("❌ لم يتم العثور على دالة مطابقة داخل _apiClient");
    //                    continue;
    //                }

    //                (var returnApiTypeStr, var Mod) = AutoCodeGenerator.CleanMethodSignature(GeneratorHelpers.ConvertToSyntax(apiMethodWithoutParam));
    //                var apiReturnType = GeneratorHelpers.ExtractInnerTypeFromMethodReturnType(apiMethodWithoutParam.ReturnType);
    //                string bodyCodeNoParam = "";


    //                // التحقق مما إذا كانت ترجع قيمة
    //                bool returnsValue = IsReturnTypeWithValue(apiReturnType);

    //                if (returnsValue)
    //                {
    //                    bodyCodeNoParam += $"\tvar result = await _apiClient.{apiMethodWithoutParam.Name}({paramNamesText});\n";
    //                    if (typeof(ITDso).IsAssignableFrom(returnType))
    //                    {
    //                        if (returnApiTypeStr.Contains("Paged"))
    //                        {
    //                            bodyCodeNoParam += $@"
    //                            return  PaginatedResult<{returnType.Name}>.Success(
    //                            _mapper.Map<List<{returnType.Name}>>(result.Data.ToList()), 
    //                            result.TotalRecords, 
    //                            result.PageNumber, 
    //                            result.PageSize,
    //                            result.SortBy,
    //                            result.SortDirection);";

    //                        }
    //                        else {
    //                            bodyCodeNoParam += $"\treturn _mapper.Map<{returnType.Name}>(result);";
    //                        }

    //                    }
    //                    else
    //                    {
    //                        if (returnApiTypeStr.Contains("Paged"))
    //                        {
    //                            bodyCodeNoParam += @$"
    //                            return  PaginatedResult<{{returnType.Name}}>.Success(
    //                            result.Data.ToList(), 
    //                            result.TotalRecords, 
    //                            result.PageNumber, 
    //                            result.PageSize,
    //                            result.SortBy,
    //                            result.SortDirection);";

    //                        }
    //                        else
    //                        {
    //                            bodyCodeNoParam += "\treturn result;";
    //                        }


    //                    }
    //                }
    //                else
    //                {
    //                    bodyCodeNoParam += $"\t await _apiClient.{apiMethodWithoutParam.Name}({paramNamesText});\n";
    //                }

    //                //if (returnType == typeof(void))
    //                //{
    //                //    bodyCodeNoParam += "\treturn;";
    //                //}

    //                //else if (IsListOfITDto(apiReturnType, out var dtoItemType))
    //                //{
    //                //    //var dsoItemType = GetMappedDsoType(dtoItemType);
    //                //    bodyCodeNoParam += $"\treturn  _mapper.Map<ICollection<{returnType.Name}>>(result);";
    //                //    //bodyCodeNoParam += $"\treturn result.Select(x => _mapper.Map<{dsoItemType.Name}>(x)).ToList();";
    //                //}
    //                //else if (apiReturnType.Name.Contains("WithPage"))
    //                //{
    //                //    var innerDtoType = GetGenericTypeInside(apiReturnType);
    //                //    var dsoItemType = GetMappedDsoType(innerDtoType);
    //                //    bodyCodeNoParam += $"\treturn new {returnType.Name} {{ Items = result.Items.Select(x => _mapper.Map<{dsoItemType.Name}>(x)).ToList() }};";
    //                //}

    //                chunksCode.Add(method.Name, bodyCodeNoParam);
    //            }
    //            else
    //            {



    //                var apiMethod = FindApiClientMethod(apiClientType, keywords);
    //                if (apiMethod == null)
    //                {
    //                    Console.WriteLine("❌ لم يتم العثور على دالة مطابقة داخل _apiClient");
    //                    continue;
    //                }
    //                //var apiMethodSyntax = GeneratorHelpers.ConvertToSyntax(apiMethod);
    //                var apiParams = apiMethod.GetParameters();
    //                var dtoParam = apiParams.FirstOrDefault(p => typeof(ITDto).IsAssignableFrom(p.ParameterType));
    //                if (dtoParam == null)
    //                {
    //                    Console.WriteLine("⚠️ لا تحتوي دالة ApiClient على معامل من نوع ITDto");
    //                    continue;
    //                }

    //                int dtoParamIndex = Array.IndexOf(apiParams, dtoParam);
    //                string[] parameterNames = apiParams.Select(p => p.Name).ToArray();
    //                string paramsNameText = string.Join(",", parameterNames);
    //                var apiReturnType2 = GeneratorHelpers.ExtractInnerTypeFromMethodReturnType(apiMethod.ReturnType);
    //                (var apiReturnType2Str, var Mod) = AutoCodeGenerator.CleanMethodSignature(GeneratorHelpers.ConvertToSyntax(apiMethod));
    //                string bodyCode = "";

    //                if (dtoParam != null)
    //                {
    //                    // توليد التحويل من DSO إلى DTO
    //                    bodyCode += $"\tvar {parameterNames[dtoParamIndex]} = _mapper.Map<{dtoParam.ParameterType.Name}>({dsoParam.Name});\n";
    //                }


    //                // التحقق مما إذا كانت الدالة ترجع قيمة
    //                bool returnsValue2 = IsReturnTypeWithValue(apiReturnType2);

    //                if (returnsValue2)
    //                {
    //                    bodyCode += $"\tvar result =await _apiClient.{apiMethod.Name}({paramsNameText});\n";
    //                    if (typeof(ITDto).IsAssignableFrom(apiReturnType2))
    //                    {
    //                        if (apiReturnType2Str.Contains("Paged"))
    //                        {
    //                            apiReturnType2Str += $@"
    //                             return  PaginatedResult<{returnType.Name}>.Success(
    //                            _mapper.Map<List<{returnType.Name}>>(result.Data.ToList()), 
    //                            result.TotalRecords, 
    //                            result.PageNumber, 
    //                            result.PageSize,
    //                            result.SortBy,
    //                            result.SortDirection);";

    //                        }
    //                        else
    //                            bodyCode += $"\treturn _mapper.Map<{returnType.Name}>(result);";
    //                    }
    //                    else
    //                    {
    //                        if (apiReturnType2Str.Contains("Paged"))
    //                        {
    //                            apiReturnType2Str += @$"
    //                            return  PaginatedResult<{{returnType.Name}}>.Success(
    //                            result.Data.ToList(), 
    //                            result.TotalRecords, 
    //                            result.PageNumber, 
    //                            result.PageSize,
    //                            result.SortBy,
    //                            result.SortDirection);";

    //                        }
    //                        else
    //                            bodyCode += "\treturn result;";
    //                    }
    //                }
    //                else
    //                {
    //                    bodyCode += $"\t await _apiClient.{apiMethod.Name}({paramsNameText});\n";
    //                }


    //                //else if (IsListOfITDto(apiReturnType2, out var dtoItemType2))
    //                //{
    //                //    var dsoItemType2 = GetMappedDsoType(dtoItemType2);
    //                //    bodyCode += $"\treturn result.Select(x => _mapper.Map<{dsoItemType2.Name}>(x)).ToList();";
    //                //}
    //                //else if (apiReturnType2.Name.Contains("WithPage"))
    //                //{
    //                //    var innerDtoType = GetGenericTypeInside(apiReturnType2);
    //                //    var dsoItemType = GetMappedDsoType(innerDtoType);
    //                //    bodyCode += $"\treturn new {returnType.Name} {{ Items = result.Items.Select(x => _mapper.Map<{dsoItemType.Name}>(x)).ToList() }};";
    //                //}
    //                //else if (apiReturnType2 == typeof(void))
    //                //{
    //                //    bodyCode += "\treturn;";
    //                //}
    //                chunksCode.Add(method.Name, bodyCode);



    //            }
    //        }

    //        return chunksCode;
    //    }

    //    private bool IsReturnTypeWithValue(string returnType)
    //    {
    //      return  returnType.Contains("Task<");
    //    }
    //    private bool IsReturnTypeWithValue(Type returnType)
    //    {
    //        if (returnType==null || returnType == typeof(void) || returnType == typeof(Task))
    //            return false;

    //        if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
    //            return true;

    //        return true;
    //    }

    //    private List<string> ExtractKeywords(string methodName)
    //    {
    //        return Regex.Matches(methodName, "[A-Z][a-z]*").Cast<Match>().Select(m => m.Value.ToLower()).ToList();
    //    }

    //    private MethodInfo? FindApiClientMethod(Type apiClientType, List<string> keywords)
    //    {
    //        return apiClientType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
    //            .FirstOrDefault(m =>
    //            {
    //                var name = m.Name.ToLower();
    //                return keywords.All(k => name.Contains(k));
    //            });
    //    }

    //    private bool IsListOfITDto(Type type, out Type itemType)
    //    {
    //        itemType = null!;
    //        if (!type.IsGenericType) return false;

    //        var def = type.GetGenericTypeDefinition();
    //        if (def == typeof(IEnumerable<>) || def == typeof(List<>))
    //        {
    //            itemType = type.GetGenericArguments()[0];
    //            return typeof(ITDto).IsAssignableFrom(itemType);
    //        }

    //        return false;
    //    }

    //    private Type GetMappedDsoType(Type dtoType)
    //    {
    //        var name = dtoType.Name.Replace("Dto", "Dso");
    //        return AppDomain.CurrentDomain.GetAssemblies()
    //            .SelectMany(a => a.GetTypes())
    //            .FirstOrDefault(t => t.Name == name && typeof(ITDso).IsAssignableFrom(t)) ?? dtoType;
    //    }

    //    private Type GetMappedDtoType(Type dsoType)
    //    {
    //        var name = dsoType.Name.Replace("Dso", "Dto");
    //        return AppDomain.CurrentDomain.GetAssemblies()
    //            .SelectMany(a => a.GetTypes())
    //            .FirstOrDefault(t => t.Name == name && typeof(ITDto).IsAssignableFrom(t)) ?? dsoType;
    //    }

    //    private Type GetGenericTypeInside(Type wrapperType)
    //    {
    //        return wrapperType.IsGenericType ? wrapperType.GetGenericArguments()[0] : wrapperType;
    //    }
    //}





}
