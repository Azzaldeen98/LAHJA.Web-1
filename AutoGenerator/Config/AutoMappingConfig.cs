using AutoMapper;
using AutoGenerator.Helper.Translation;
using Shared.Interfaces;
using AutoGenerator.AppFolder;
using System.Reflection;
using AutoGenerator.Config.Attributes;
using Microsoft.Extensions.Logging;
using AutoGenerator.Enums;

namespace AutoGenerator.Config
{
    /// <summary>
    /// Represents the configuration class for AutoMapper profile setup.
    /// This class automatically registers bidirectional mappings between DSO models and their corresponding DTO and ViewModel types,
    /// using custom mapping logic and attribute-based configuration.
    /// </summary>
    public class AutoMappingConfig : Profile
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;


        // <summary>
        /// Initializes a new instance of the <see cref="AutoMappingConfig"/> class.
        /// It scans the application assemblies to discover DSO, DTO, and VM types,
        /// and automatically configures two-way mappings between them using custom logic and attributes.
        /// </summary>
        /// <param name="logger">The logger instance used to log mapping-related warnings or errors.</param>
        public AutoMappingConfig(Microsoft.Extensions.Logging.ILogger logger)
        {
            _logger = logger;

            IDataTypeExplorerService dataType = new DataTypeExplorerService();

            var dsoModels = dataType.GetModelsType(ApplicationAssemblies.AssemblyDomain, "", typeof(ITDso));
            var allDtoTypes = dataType.GetModelsType(ApplicationAssemblies.AssemblyInfrastructure, "", typeof(ITDto));
            var allVMTypes = dataType.GetModelsType(ApplicationAssemblies.AssemblyWebApp, "", typeof(ITVM));



            if (dsoModels != null && dsoModels.Any())
            {
                /// From DTO <=> DSO
                if (allDtoTypes != null && allDtoTypes.Any())
                {
                    var dataModelsMap = GetMappedTargetModels(dsoModels, allDtoTypes, LayersModels.DTO);
                    ConfigAutoMapper(dataModelsMap, dsoModels, AutoGeneratorConstant.ModelType.DTO);
                }


                /// From VM <=> DSO
                if (allVMTypes != null && allVMTypes.Any())
                {
                    var dataModelsMap = GetMappedTargetModels(dsoModels, allVMTypes, LayersModels.VM);
                    ConfigAutoMapper(dataModelsMap, dsoModels, AutoGeneratorConstant.ModelType.VM);
                }
            }
        }
        /// <summary>
        /// Retrieves a mapping dictionary between original domain models (DSO)
        /// and their corresponding target models (e.g., DTO or VM),
        /// based on matching naming conventions or custom mapping attributes.
        /// </summary>
        /// <param name="dsoModels">
        /// A list of domain source model types (DSO) that serve as the base models for mapping.
        /// </param>
        /// <param name="dataModelsMap">
        /// A list of target model types (e.g., DTOs or VMs) that may be mapped from or to the DSO models.
        /// </param>
        /// <param name="targetLayerModel">
        /// Specifies the target layer type (e.g., DTO or VM) used to filter the mapping attributes.
        /// </param>
        /// <returns>
        /// A dictionary where the key is the name of a DSO model, and the value is a list of target model types
        /// that are mapped to or from that DSO model.
        /// </returns>
        private Dictionary<string, List<Type>> GetMappedTargetModels(List<Type> dsoModels, List<Type> dataModelsMap, LayersModels targetLayerModel)
        {
            var orderedModels = dsoModels.ToList();
            var dtoMap = dsoModels.ToDictionary(m => m.Name, m => new List<Type>());

            foreach (var dsoModel in dsoModels)
            {
                var attributes = dsoModel.GetCustomAttributes(typeof(AutomateMapperWithAttribute), inherit: false)
                                         .Cast<AutomateMapperWithAttribute>()
                                         .ToList();
                if(attributes!=null && attributes.Count() > 0)
                {
                    var attributesClass = attributes
                                        .Where(model => model.TargetLayerModel == targetLayerModel)
                                        .SelectMany(x => x.TargetTypes)
                                        .ToList(); // Flattened list of strings

                    var matchedModels = dataModelsMap
                                        .Where(model => attributesClass
                                            .Any(att => att != null && att.Contains(model.Name, StringComparison.OrdinalIgnoreCase)))
                                            .ToList();

                    //var matchedModels = attributes.Where(model => model.TargetLayerModel==targetLayerModel && model.TargetTypes.C(dataModel.Name, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (matchedModels != null && matchedModels.Any())
                        dtoMap[dsoModel.Name].AddRange(matchedModels);
                }
                else
                {
                    var matchedModels = dataModelsMap.Where(model => model.Name.Equals(dsoModel.Name, StringComparison.OrdinalIgnoreCase)
                                                || model.Name.StartsWith(dsoModel.Name, StringComparison.OrdinalIgnoreCase)
                                                || model.Name.Contains(dsoModel.Name, StringComparison.OrdinalIgnoreCase)).ToList();
                    if(matchedModels!=null && matchedModels.Any())
                        dtoMap[dsoModel.Name].AddRange(matchedModels);
                }

                
            }

            return dtoMap;
        }
        private Dictionary<string, List<Type>> GetMappedTargetModels2(List<Type> dsoModels, List<Type> dataModelsMap, LayersModels targetLayerModel)
        {
            var orderedModels = dsoModels.ToList();
            var dtoMap = dsoModels.ToDictionary(m => m.Name, m => new List<Type>());

            foreach (var dataModel in dataModelsMap)
            {
                var matchedModel = orderedModels.FirstOrDefault(model =>
                {
                    var attributes = model.GetCustomAttributes(typeof(AutomateMapperWithAttribute), inherit: false)
                                          .Cast<AutomateMapperWithAttribute>()
                                          .ToList();

               
                    bool hasAttributeMatch = attributes.Any(attr => 
                            attr.TargetLayerModel == targetLayerModel
                            && attr.TargetTypes.Any(typeName=>typeName.Equals(dataModel.Name, StringComparison.OrdinalIgnoreCase)));

                    if (!hasAttributeMatch)
                        hasAttributeMatch = dataModel.Name.Equals(model.Name, StringComparison.OrdinalIgnoreCase)
                                            || dataModel.Name.StartsWith(model.Name, StringComparison.OrdinalIgnoreCase)
                                            || dataModel.Name.Contains(model.Name, StringComparison.OrdinalIgnoreCase);

                    return hasAttributeMatch;
                });

                if (matchedModel != null)
                {
                    dtoMap[matchedModel.Name].Add(dataModel);
                }
            }

            return dtoMap;
        }

        /// <summary>
        /// Configures AutoMapper mappings between DSO model types and their corresponding DTO or VM types.
        /// Configures two-way mappings between DSO models and target types (such as DTO or VM) based on the provided type map.
        /// </summary>
        /// <param name="dtoMap">
        /// A dictionary mapping the DSO model name to the corresponding list of types in the target layer (DTO or VM).
        /// The key is the name of the DSO model, and the value is the list of types to be mapped.
        /// </param>
        /// <param name="dsoModelTypes">
        /// A list of DSO model types to be mapped.
        /// </param>
        /// <param name="targetTypeKey">
        /// A key that identifies the target model type (such as "DTO" or "VM") and is used to customize naming or routing rules.
        /// </param>
        public void ConfigAutoMapper(Dictionary<string, List<Type>> dtoMap, List<Type> dsoModelTypes, string targetTypeKey)
        {

            foreach (var modelType in dsoModelTypes)
            {
                var modelName = modelType.Name;

                if (dtoMap.TryGetValue(modelName, out var dtoTypes))
                {
                    foreach (var dtoType in dtoTypes)
                    {

                        AddTwoWayMap(modelType, dtoType, targetTypeKey);

                    }
                }
            }
        }
        /// <summary>
        /// Adds a two-way mapping between the <paramref name="source"/> and <paramref name="destination"/> types.
        /// It uses the <see cref="MapToAttribute"/> to define custom property mappings based on the specified <paramref name="targetTypeKey"/>.
        /// The method ensures that mappings are created in both directions (source → destination and destination → source).
        /// </summary>
        /// <param name="source">The source type for the mapping.</param>
        /// <param name="destination">The destination type for the mapping.</param>
        /// <param name="targetTypeKey">
        /// A key representing the target layer (e.g., "DTO", "VM") used to filter <see cref="MapToAttribute"/> when defining mappings.
        /// This key is matched against the <c>TargetType</c> property in <see cref="MapToAttribute"/>.
        /// </param>
        /// <remarks>
        /// The method performs the following:
        /// <list type="bullet">
        /// <item>Iterates over source properties and attempts to map them to matching destination properties using attribute configuration or by name.</item>
        /// <item>If a destination property is not found, a warning is logged.</item>
        /// <item>Performs reverse mapping using the same logic, mapping destination properties back to source properties.</item>
        /// <item>Calls a post-mapping method (<see cref="HelperTranslation.MapToProcessAfter"/>) after each mapping.</item>
        /// </list>
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown if mapping configuration fails or incompatible property types are encountered during runtime mapping execution.
        /// </exception>

        private void AddTwoWayMap(Type source, Type destination, string targetTypeKey)
        {
            var sourceProps = source.GetProperties();
            var destProps = destination.GetProperties();

            var destPropsDict = destProps.ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);
            var sourcePropsDict = sourceProps.ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);

            var map = CreateMap(source, destination);

            foreach (var srcProp in sourceProps)
            {
                // حاول إيجاد اسم الخاصية في الوجهة بناءً على السمة أو الاسم المباشر
                var mapToAttr = srcProp.GetCustomAttributes<MapToAttribute>()
                                       .FirstOrDefault(a => a.TargetType.Equals(targetTypeKey, StringComparison.OrdinalIgnoreCase));

                var targetPropName = mapToAttr?.TargetProperty ?? srcProp.Name;

                if (destPropsDict.TryGetValue(targetPropName, out var destProp))
                {
                    map.ForMember(targetPropName, opt => opt.MapFrom(src => srcProp.GetValue(src)));
                }
                else
                {
                    _logger?.LogWarning($"[Map] '{destination.Name}' lacks property '{targetPropName}' to map from '{source.Name}.{srcProp.Name}'");
                }
            }

            map.AfterMap((src, dest, context) =>
            {
                HelperTranslation.MapToProcessAfter(src, dest, context);
            });

            // ⇨ الاتجاه العكسي ⇦
            var reverseMap = CreateMap(destination, source);

            foreach (var destProp in destProps)
            {
                var matchingSourceProp = sourceProps.FirstOrDefault(sp =>
                {
                    var attrs = sp.GetCustomAttributes<MapToAttribute>();
                    return attrs.Any(a =>
                               a.TargetType.Equals(targetTypeKey, StringComparison.OrdinalIgnoreCase) &&
                               a.TargetProperty == destProp.Name) ||
                           (!attrs.Any(a => a.TargetType.Equals(targetTypeKey, StringComparison.OrdinalIgnoreCase)) &&
                            sp.Name.Equals(destProp.Name, StringComparison.OrdinalIgnoreCase));
                });

                if (matchingSourceProp != null)
                {
                    reverseMap.ForMember(matchingSourceProp.Name, opt => opt.MapFrom(dest => destProp.GetValue(dest)));
                }
                else
                {
                    _logger?.LogWarning($"[ReverseMap] No matching source property in '{source.Name}' for '{destination.Name}.{destProp.Name}' ({targetTypeKey})");
                }
            }

            reverseMap.AfterMap((src, dest, context) =>
            {
                HelperTranslation.MapToProcessAfter(src, dest, context);
            });
        }



        //private void AddTwoWayMap(Type source, Type destination, string targetTypeKey)
        //{
        //    var sourceProps = source.GetProperties();
        //    var destProps = destination.GetProperties();

        //    var destPropsDict = destProps.ToDictionary(p => p.Name);
        //    var sourcePropsDict = sourceProps.ToDictionary(p => p.Name);

        //    var map = CreateMap(source, destination);

        //    foreach (var srcProp in sourceProps)
        //    {
        //        string targetPropName = null;

        //        var attrs = srcProp.GetCustomAttributes<MapToAttribute>();
        //        var mapToAttr = attrs.FirstOrDefault(a => a.TargetType == targetTypeKey.ToUpperInvariant());

        //        if (mapToAttr != null && !string.IsNullOrWhiteSpace(mapToAttr.TargetProperty))
        //            targetPropName = mapToAttr.TargetProperty;
        //        else
        //            targetPropName = srcProp.Name;

        //        if (destPropsDict.ContainsKey(targetPropName))
        //        {
        //            map.ForMember(targetPropName, opt => opt.MapFrom(src => srcProp.GetValue(src)));
        //        }
        //        else
        //        {
        //            _logger?.LogWarning($"AddTwoWayMap WARNING: '{destination.Name}' does not have property '{targetPropName}' to map from '{source.Name}.{srcProp.Name}'");
        //        }
        //    }

        //    map.AfterMap((src, dest, context) =>
        //    {
        //        HelperTranslation.MapToProcessAfter(src, dest, context);
        //    });

        //    // ⇨ الاتجاه العكسي ⇦
        //    var reverseMap = CreateMap(destination, source);

        //    foreach (var destProp in destProps)
        //    {
        //        string sourcePropName = null;

        //        // ابحث عن خاصية المصدر التي تشير لهذه الخاصية عبر MapToAttribute
        //        var srcProp = sourceProps.FirstOrDefault(sp =>
        //        {
        //            var attrs = sp.GetCustomAttributes<MapToAttribute>();
        //            return attrs.Any(a =>
        //                a.TargetType == targetTypeKey.ToUpperInvariant() &&
        //                a.TargetProperty == destProp.Name)
        //                || (!attrs.Any(a => a.TargetType == targetTypeKey.ToUpperInvariant()) && sp.Name == destProp.Name);
        //        });

        //        if (srcProp != null)
        //        {
        //            reverseMap.ForMember(srcProp.Name, opt => opt.MapFrom(dest => destProp.GetValue(dest)));
        //        }
        //        else
        //        {
        //            _logger?.LogWarning($"AddTwoWayMap Warning: There is no corresponding property in '{source.Name}' for property '{destProp.Name}' in '{destination.Name}' ({targetTypeKey})");
        //        }
        //    }

        //    reverseMap.AfterMap((src, dest, context) =>
        //    {
        //        HelperTranslation.MapToProcessAfter(src, dest, context);
        //    });
        //}

        //private void AddTwoWayMap(Type source, Type destination)
        //{
        //    CreateMap(source, destination).AfterMap((src, dest, context) =>
        //    {
        //        HelperTranslation.MapToProcessAfter(src, dest, context);
        //    });

        //    CreateMap(destination, source).AfterMap((src, dest, context) =>
        //    {
        //        HelperTranslation.MapToProcessAfter(src, dest, context);
        //    });
        //}





        //public void ConfigAutoMapperWithAfterMap(Dictionary<string, List<Type>> dtoMap, List<Type> dsoModelTypes)
        //{
        //    foreach (var modelType in dsoModelTypes)
        //    {
        //        var modelName = modelType.Name;

        //        if (dtoMap.TryGetValue(modelName, out var dtoTypes))
        //        {
        //            foreach (var dtoType in dtoTypes)
        //            {
        //                // إنشاء CreateMap<TSource, TDestination>()
        //                var createMapMethod = typeof(Profile)
        //                    .GetMethods()
        //                    .First(m => m.Name == "CreateMap" && m.IsGenericMethod && m.GetParameters().Length == 0);

        //                var genericCreateMap = createMapMethod.MakeGenericMethod(modelType, dtoType);
        //                var mapExpr1 = genericCreateMap.Invoke(this, null);

        //                // إضافة AfterMap<TSource, TDestination>((src, dest, ctx) => {...})


        //                // إنشاء CreateMap<TDestination, TSource>()
        //                var genericCreateMapReverse = createMapMethod.MakeGenericMethod(dtoType, modelType);
        //                var mapExpr2 = genericCreateMapReverse.Invoke(this, null);

        //                // إضافة AfterMap<TDestination, TSource>((src, dest, ctx) => {...})

        //            }
        //        }
        //    }
        //}


        //private void AddTwoWayMap(Type source, Type destination,MethodInfo createMapMethod)
        //{


        //    // CreateMap<TSource, TDestination>
        //    var genericMap1 = createMapMethod.MakeGenericMethod(source, destination);
        //    var mapExpr1 = genericMap1.Invoke(this, null);
        //    AddAfterMap(mapExpr1, source, destination);

        //    // CreateMap<TDestination, TSource>
        //    var genericMap2 = createMapMethod.MakeGenericMethod(destination, source);
        //    var mapExpr2 = genericMap2.Invoke(this, null);
        //    AddAfterMap(mapExpr2, destination, source);
        //}


        //private void AddAfterMap(object mapExpr, Type srcType, Type destType)
        //{
        //    var afterMapMethod = mapExpr.GetType().GetMethods()
        //        .FirstOrDefault(m => m.Name == "AfterMap" && m.GetParameters().Length == 1);

        //    if (afterMapMethod != null)
        //    {
        //        // بناء تعبير Lambda من النوع المناسب: (src, dest, context) => HelperTranslation.MapToProcessAfter(src, dest, context)
        //        //var srcParam = Expression.Parameter(srcType, "src");
        //        //var destParam = Expression.Parameter(destType, "dest");
        //        //var contextParam = Expression.Parameter(typeof(ResolutionContext), "context");

        //        //var methodCall = Expression.Call(
        //        //    typeof(HelperTranslation).GetMethod(nameof(HelperTranslation.MapToProcessAfter))
        //        //        .MakeGenericMethod(srcType, destType),
        //        //    srcParam, destParam, contextParam
        //        //);

        //        //var lambdaType = typeof(Action<,,>).MakeGenericType(srcType, destType, typeof(ResolutionContext));
        //        //var lambda = Expression.Lambda(lambdaType, methodCall, srcParam, destParam, contextParam).Compile();

        //        //afterMapMethod.Invoke(mapExpr, new object[] { lambda });
        //    }
        //}

    }
   

 

}