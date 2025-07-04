﻿using Microsoft.Extensions.DependencyInjection;
using AutoGenerator.Config;
using AutoGenerator.AppFolder;
using System.Collections;
using System.Reflection;

namespace AutoGenerator
{

    public class AutoBuilderAppCoreOption
    {

        public string? ProjectPath { get; set; }
        public string? ProjectName { get; set; } = "";

        public string NameRootApp { get; set; } = "App";

        //public bool  IsAutoBuild { get; set; } = true;
        public bool IsMapper { get; set; } = true;

        public Type? TypeContext { get; set; }

        public Assembly? Assembly { get; set; }
        public Assembly? AssemblyModels { get; set; }

        public string? DbConnectionString { get; set; }
        public string[]? Arags { get; set; }



    }

    public  interface ITServiceCollection: IServiceCollection
    {

    }

    public class TTServiceCollection : ITServiceCollection
    {
        private readonly List<ServiceDescriptor> _descriptors = new();

        public ServiceDescriptor this[int index]
        {
            get => _descriptors[index];
            set => _descriptors[index] = value;
        }

        public int Count => _descriptors.Count;

        public bool IsReadOnly => false;

        public void Add(ServiceDescriptor item)
        {
            _descriptors.Add(item);
        }

        public void Clear()
        {
            _descriptors.Clear();
        }

        public bool Contains(ServiceDescriptor item)
        {
            return _descriptors.Contains(item);
        }

        public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
        {
            _descriptors.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
            return _descriptors.GetEnumerator();
        }

        public int IndexOf(ServiceDescriptor item)
        {
            return _descriptors.IndexOf(item);
        }

        public void Insert(int index, ServiceDescriptor item)
        {
            _descriptors.Insert(index, item);
        }

        public bool Remove(ServiceDescriptor item)
        {
            return _descriptors.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _descriptors.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class ConfigServices
    {

        public static IServiceCollection AddAutoBuilderAppCore(this IServiceCollection serviceCollection, AutoBuilderAppCoreOption option)
        {
            var args = option.Arags;
            AppFolderInfo.AssemblyShare = option.Assembly;
            AppFolderInfo.AssemblyModels= option.AssemblyModels;

            if ((args.Length > 0 && args[0].Contains("generate")))
            {
                if (args.Length > 1)
                    for (int i = 1; i < args.Length; i++)
                    {
                        option.NameRootApp = args[i];
                        serviceCollection.AddAutoGenerateAppCore(option);
                    }
                else
                    serviceCollection.AddAutoGenerateAppCore(option);
              





            }
            else
                serviceCollection.AddAutoServicesAppCore(option);


            return serviceCollection;
        }


        public static void AddAutoServicesAppCore(this IServiceCollection serviceCollection, AutoBuilderAppCoreOption option)
        {

            if (option.IsMapper)
            {
                
                serviceCollection.AddAutoMapper(typeof(Config.Config));
            }
            if (option.Assembly != null)
            {
                serviceCollection.AddAutoScope(option.Assembly);
                serviceCollection.AddAutoTransient(option.Assembly);
                serviceCollection.AddAutoSingleton(option.Assembly);

                //serviceCollection.AddAutoScheduler(new() {
                //    Assembly=option.Assembly,
                //    DbConnectionString=option.DbConnectionString,
                // } );
            }
        }

        public static void AddAutoGenerateAppCore(this IServiceCollection serviceCollection, AutoBuilderAppCoreOption option)
        {



           
            AppFolderInfo.TypeContext = option.TypeContext;
            AppFolderGenerator.Build(option.ProjectPath, option.NameRootApp);


            //    serviceCollection.AddSingleton<IHostedService, SchedulerJobProvider>(prv =>
            //{

            //    var context = prv.GetService<DataContext>();


            //    var jobOptions = ConfigScheduler.getJobOptions(context, option.Assembly);
            //    var schedulerJobProvider = new SchedulerJobProvider(prv.GetRequiredService<ISchedulerFactory>(), jobOptions);
            //    return schedulerJobProvider;
            //});

            //serviceCollection.AddSingleton<IHostedService, JobScheduler>(prv =>
            //{
            //    var jobScheduler = new JobScheduler(prv.GetRequiredService<ISchedulerFactory>(), option.Assembly);
            //    return jobScheduler;
            //});




        }

    }
}

