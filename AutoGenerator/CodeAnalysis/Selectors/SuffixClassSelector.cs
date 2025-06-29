using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace AutoGenerator.CodeAnalysis.Selectors
{
    /// <summary>
    /// A class selector that selects class declarations based on a specified class name suffix.
    /// </summary>
    public class SuffixClassSelector : IClassSelector
    {
        private readonly string _suffix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SuffixClassSelector"/> class.
        /// </summary>
        /// <param name="suffix">
        /// The suffix to match against class names. 
        /// If <c>null</c>, it will default to an empty string and match all classes.
        /// </param>
        public SuffixClassSelector(string? suffix)
        {
            _suffix = suffix ?? "";
        }

        /// <summary>
        /// Selects class declarations from the given syntax tree root 
        /// whose class names end with the specified suffix.
        /// </summary>
        /// <param name="root">The root of the syntax tree to search within.</param>
        /// <returns>
        /// An enumerable of <see cref="ClassDeclarationSyntax"/> objects that match the suffix condition.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="root"/> is null.</exception>
        public IEnumerable<ClassDeclarationSyntax> SelectClasses(CompilationUnitSyntax root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));

            return root.DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .Where(c => string.IsNullOrWhiteSpace(_suffix) ? true : c.Identifier.Text.EndsWith(_suffix))
                .ToList();
        }
    }

    //public class FileSourceCodeProvider : ISourceCodeProvider
    //{
    //    private readonly string _filePath;

    //    public FileSourceCodeProvider(string filePath)
    //    {
    //        if (string.IsNullOrEmpty(filePath))
    //            throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

    //        _filePath = filePath;
    //    }

    //    public async Task<string> GetSourceCodeAsync()
    //    {
    //        if (!File.Exists(_filePath))
    //            throw new FileNotFoundException("Source file not found.", _filePath);

    //        return await File.ReadAllTextAsync(_filePath);
    //    }



    //    public async Task SaveSourceCodeAsync(string code, string? outputId = null)
    //    {
    //        if (string.IsNullOrWhiteSpace(code))
    //            throw new ArgumentNullException(nameof(code));

    //        string path = !string.IsNullOrWhiteSpace(outputId)
    //            ? outputId
    //            : _filePath ?? throw new ArgumentNullException(nameof(_filePath));

    //        // التحقق من وجود اسم ملف صحيح
    //        if (path.IndexOfAny(Path.GetInvalidPathChars()) >= 0 || Path.GetFileName(path).IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
    //            throw new ArgumentException("The file path contains invalid characters.", nameof(path));

    //        // التأكد من أن المجلد موجود، وإذا لم يكن موجوداً، يتم إنشاؤه
    //        var directory = Path.GetDirectoryName(path);
    //        if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
    //            Directory.CreateDirectory(directory);

    //        // كتابة الكود إلى الملف
    //        await File.WriteAllTextAsync(path, code);
    //    }

    //}
    //public class TextSourceCodeProvider : ISourceCodeProvider
    //{
    //    private readonly string _code;
    //    private readonly string? _outputPath;

    //    public TextSourceCodeProvider(string code, string? outputPath = null)
    //    {
    //        _code = code ?? throw new ArgumentNullException(nameof(code));
    //        _outputPath = outputPath;
    //    }

    //    public Task<string> GetSourceCodeAsync() => Task.FromResult(_code);

    //    public async Task SaveSourceCodeAsync(string code, string? outputPath = null)
    //    {
    //        if (string.IsNullOrWhiteSpace(code))
    //            throw new ArgumentNullException(nameof(code));

    //        var path = outputPath ?? _outputPath;
    //        if (string.IsNullOrWhiteSpace(path))
    //            throw new ArgumentNullException(nameof(path));

    //        await File.WriteAllTextAsync(path, code);
    //    }
    //}
    //public class CompositeClassSelector : IClassSelector
    //{
    //    private readonly List<IClassSelector> _selectors = new();

    //    public CompositeClassSelector AddSelector(IClassSelector selector)
    //    {
    //        if (selector != null)
    //            _selectors.Add(selector);
    //        return this;
    //    }

    //    public IEnumerable<ClassDeclarationSyntax> SelectClasses(CompilationUnitSyntax root)
    //    {
    //        return _selectors.SelectMany(s => s.SelectClasses(root)).Distinct();
    //    }
    //}
    //public class SuffixClassSelector : IClassSelector
    //{
    //    private readonly string _suffix;

    //    public SuffixClassSelector(string? suffix)
    //    {
    //        //if (string.IsNullOrWhiteSpace(suffix))
    //        //    throw new ArgumentException("Suffix cannot be null or empty.", nameof(suffix));

    //        _suffix = suffix ?? "";
    //    }

    //    public IEnumerable<ClassDeclarationSyntax> SelectClasses(CompilationUnitSyntax root)
    //    {
    //        if (root == null)
    //            throw new ArgumentNullException(nameof(root));

    //        return root.DescendantNodes()
    //            .OfType<ClassDeclarationSyntax>()
    //            .Where(c => string.IsNullOrWhiteSpace(_suffix) ? true : c.Identifier.Text.EndsWith(_suffix))
    //            .ToList();
    //    }
    //}
    //public class TypeBasedClassSelector : IClassSelector
    //{
    //    private readonly HashSet<string> _classNames;

    //    public TypeBasedClassSelector(IEnumerable<Type> types)
    //    {
    //        _classNames = types?.Select(t => t.Name).ToHashSet()
    //            ?? throw new ArgumentNullException(nameof(types));
    //    }

    //    public IEnumerable<ClassDeclarationSyntax> SelectClasses(CompilationUnitSyntax root)
    //    {

    //        return root.DescendantNodes()
    //            .OfType<ClassDeclarationSyntax>()
    //            .Where(c => _classNames.Contains(c.Identifier.Text));
    //    }
    //}
    //public class PredicateClassSelector : IClassSelector
    //{
    //    private readonly Func<ClassDeclarationSyntax, bool> _predicate;

    //    public PredicateClassSelector(Func<ClassDeclarationSyntax, bool> predicate)
    //    {
    //        _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
    //    }

    //    public IEnumerable<ClassDeclarationSyntax> SelectClasses(CompilationUnitSyntax root)
    //    {
    //        return root.DescendantNodes()
    //            .OfType<ClassDeclarationSyntax>()
    //            .Where(_predicate);
    //    }
    //}





}
