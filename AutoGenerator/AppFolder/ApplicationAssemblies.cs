using System.Reflection;

namespace AutoGenerator.AppFolder
{
    public class ApplicationAssemblies
    {

        public static Assembly? AssemblyWebApp{ get; set; }
        public static Assembly? AssemblyShared { get; set; }
        public static Assembly? AssemblyClientShared { get; set; }
        public static Assembly? AssemblyAutoGenerator { get; set; }
        public static Assembly? AssemblyDomain { get; set; }
        public static Assembly? AssemblyApplication { get; set; }
        public static Assembly? AssemblyInfrastructure { get; set; }

    }
}
