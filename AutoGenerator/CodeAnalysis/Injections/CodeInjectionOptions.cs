using AutoGenerator.CodeAnalysis.Selectors;

namespace AutoGenerator.CodeAnalysis.Injections
{
    /// <summary>
    /// Represents configuration options used to control the code injection process.
    /// </summary>
    public class CodeInjectionOptions
    {
        /// <summary>
        /// The type of code injection to apply (e.g., interface, method, or property).
        /// </summary>
        public InjectionType InjectionType { get; set; }

        /// <summary>
        /// Indicates whether the source input is a raw code string (true)
        /// or a path to a source file (false).
        /// </summary>
        public bool IsSourceText { get; set; } = false;

        /// <summary>
        /// Contains either the raw source code or the file path to the source,
        /// depending on <see cref="IsSourceText"/>.
        /// </summary>
        public string SourceCodeOrFilePath { get; set; }

        /// <summary>
        /// The file path where the modified or injected code should be saved.
        /// </summary>
        public string OutputFilePath { get; set; }

        /// <summary>
        /// The full name (namespace + name) of the interface to target for injection.
        /// </summary>
        public string InterfaceFullName { get; set; }

        /// <summary>
        /// The class selection strategy used to identify which classes in the source
        /// should be injected with code.
        /// </summary>
        public IClassSelector Selector { get; set; }
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
