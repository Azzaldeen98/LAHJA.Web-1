using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using AutoGenerator.Helper.Translation;
using Shared.Interfaces;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Castle.Core.Logging;
using AutoGenerator.Code;
using AutoGenerator.Attributes;

namespace AutoGenerator.Config
{

     
    public static class AutoConfigAll
    {
       



        public static void AddAutoScope(this IServiceCollection serviceCollection, Assembly? assembly)
        {

            var scopes = assembly.GetTypes().Where(t => typeof(ITScope).IsAssignableFrom(t) ).AsParallel().ToList();
            var Iscopeshare = scopes.Where(t => typeof(ITBaseShareRepository).IsAssignableFrom(t) && t.IsInterface).AsParallel().ToList();
            var cscopeshare = scopes.Where(t => typeof(ITBaseShareRepository).IsAssignableFrom(t) && t.IsClass).AsParallel().ToList();
              foreach (var Iscope in Iscopeshare)
            {

                var cscope= cscopeshare.Where(t => Iscope.IsAssignableFrom(t)).FirstOrDefault();
                if(cscope != null)
                {
                    serviceCollection.AddScoped(Iscope, cscope);
                }
                else
                {

                }
               
            }

            var Iscopeservis = scopes.Where(t => typeof(ITBaseService).IsAssignableFrom(t) && t.IsInterface).AsParallel().ToList();
            var cscopeservis = scopes.Where(t => typeof(ITBaseService).IsAssignableFrom(t) && t.IsClass).AsParallel().ToList();
            foreach (var Iscope in Iscopeservis)
            {
                if(!Iscope.Name.Contains("IUse"))
                {
                    continue;
                }
                var cscope = cscopeservis.Where(t => Iscope.IsAssignableFrom(t)).FirstOrDefault();
                if (cscope != null)
                {
                    serviceCollection.AddScoped(Iscope, cscope);
                }
            }






            //serviceCollection.AddHttpContextAccessor();

            //var  usercliems= assembly.GetTypes().Where(t => typeof(ITClaimsHelper).IsAssignableFrom(t)).AsParallel().ToList();












        }

        public static void AddAutoSingleton(this IServiceCollection serviceCollection, Assembly? assembly)
        {
          
            var singletons = assembly.GetTypes().Where(t => typeof(ITSingleton).IsAssignableFrom(t) && t.IsClass).ToList();
            foreach (var singleton in singletons)
            {
                serviceCollection.AddSingleton(singleton);
            }



           
        }

        public static void AddAutoTransient(this IServiceCollection serviceCollection, Assembly? assembly)
        {
         
            var transients = assembly.GetTypes().Where(t => typeof(ITTransient).IsAssignableFrom(t) && t.IsClass).ToList();
            foreach (var transient in transients)
            {
                serviceCollection.AddTransient(transient);
            }
        }

    }

    public class Config : Profile
    {
        public static bool CheckIgnoreAutomateMapper(Type type)
        {
            var attribute = type.GetCustomAttribute<AutoMapperIgnoreAttribute>();
            return attribute != null && attribute.IgnoreMapping;
        }

        public Config()
        {


            //var assemblyModels = AppFolderInfo.AssemblyModels;
            //var assembly = AppFolderInfo.AssemblyShare;

            //var models = assemblyModels.GetTypes().Where(t => typeof(ITModel).IsAssignableFrom(t) && t.IsClass).ToList();
            //var dtos = assembly.GetTypes().Where(t => typeof(ITDto).IsAssignableFrom(t) && t.IsClass).ToList();
            //var dtosShare = assembly.GetTypes().Where(t => typeof(ITShareDto).IsAssignableFrom(t) && t.IsClass).ToList();
            //var vms = assembly.GetTypes().Where(t => typeof(ITVM).IsAssignableFrom(t) && t.IsClass).ToList();
            //var dsos = assembly.GetTypes().Where(t => typeof(ITDso).IsAssignableFrom(t) && t.IsClass).ToList();

            //// 1. Map Models <-> DTOs
            //foreach (var model in models.Where(m => !CheckIgnoreAutomateMapper(m)))
            //{
            //    foreach (var dto in dtos.Where(d => d.Name.Contains(model.Name, StringComparison.OrdinalIgnoreCase)))
            //    {
            //        AddTwoWayMap(model, dto);

            //        if (!CheckIgnoreAutomateMapper(dto))
            //        {
            //            foreach (var share in dtosShare.Where(s => s.Name.Contains(model.Name, StringComparison.OrdinalIgnoreCase)))
            //            {
            //                CreateMap(dto, share);

            //                foreach (var dso in dsos.Where(d => d.Name.Contains(model.Name, StringComparison.OrdinalIgnoreCase)))
            //                {
            //                    CreateMap(share, dso);
            //                }
            //            }
            //        }
            //    }
            //}

            //// 2. Map DSO <-> VM
            //foreach (var dso in dsos.Where(d => !CheckIgnoreAutomateMapper(d)))
            //{
            //    foreach (var vm in vms.Where(v => !CheckIgnoreAutomateMapper(v)))
            //    {
            //        AddTwoWayMap(dso, vm);
            //    }
            //}

            //// 3. Map DTO <-> VM
            //foreach (var dto in dtos.Where(d => !CheckIgnoreAutomateMapper(d)))
            //{
            //    foreach (var vm in vms.Where(v => !CheckIgnoreAutomateMapper(v)))
            //    {
            //        AddTwoWayMap(dto, vm);
            //    }
            //}

            //// 4. Map Share <-> VM
            //foreach (var share in dtosShare.Where(s => !CheckIgnoreAutomateMapper(s)))
            //{
            //    foreach (var vm in vms.Where(v => !CheckIgnoreAutomateMapper(v)))
            //    {
            //        AddTwoWayMap(share, vm);
            //    }
            //}




        }




        private void AddTwoWayMap(Type source, Type destination)
        {
            CreateMap(source, destination).AfterMap((src, dest, context) =>
            {
                HelperTranslation.MapToProcessAfter(src, dest, context);
            });

            CreateMap(destination, source).AfterMap((src, dest, context) =>
            {
                HelperTranslation.MapToProcessAfter(src, dest, context);
            });
        }
    }
}