using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using AutoGenerator.CodeAnalysis.Providers;

namespace AutoGenerator.CodeAnalysis.Syntaxs
{
    /// <summary>
    /// Processes a syntax tree by applying a sequence of syntax tree commands.
    /// </summary>
    public class SyntaxTreeProcessor : ISyntaxTreeProcessor
    {
        private readonly ISourceCodeProvider _sourceProvider;
        private readonly List<ISyntaxTreeCommand> _commands = new();

        /// <summary>
        /// Initializes a new instance of <see cref="SyntaxTreeProcessor"/> with a source code provider.
        /// </summary>
        /// <param name="sourceProvider">The source code provider (e.g., from file or text).</param>
        public SyntaxTreeProcessor(ISourceCodeProvider sourceProvider)
        {
            _sourceProvider = sourceProvider;
        }

        /// <summary>
        /// Adds a syntax tree command to the processing queue.
        /// </summary>
        /// <param name="command">The command to apply to the syntax tree.</param>
        public void AddCommand(ISyntaxTreeCommand command)
        {
            _commands.Add(command);
        }
        /// <summary>
        /// Processes the syntax tree by executing all added commands.
        /// If changes were made, saves the modified code to the output path.
        /// </summary>
        /// <param name="outputId">Optional output file path to save the result.</param>
        /// <returns>True if the code was modified and saved; otherwise, false.</returns>
        public async Task<bool> ProcessAsync(string? outputId = null)
        {
            var code = await _sourceProvider.GetSourceCodeAsync();
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetCompilationUnitRoot();

            var originalRoot = root;

            foreach (var command in _commands)
            {
                root = command.Execute(root);
            }

            if (root != originalRoot)
            {
                await _sourceProvider.SaveSourceCodeAsync(root.NormalizeWhitespace().ToFullString(), outputId);
                return true;
            }
            return false;
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
