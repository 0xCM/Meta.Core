namespace Meta.Code
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Text;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Task = System.Threading.Tasks.Task;

    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideObject(typeof(MetaGen))]
    [ComVisible(true)]
    [CodeGeneratorRegistration(typeof(MetaGen), nameof(MetaGen), CsProjectGuid, GeneratesDesignTimeSource =true)]
    public sealed class MetaGen : AsyncPackage, IVsSingleFileGenerator
    {
        /// <summary>
        /// MetaGen GUID string.
        /// </summary>
        public const string PackageGuidString = "e2a8b9a0-25b4-463f-82b3-da46bec34e0b";
        public const string CsProjectGuid = "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}";

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaGen"/> class.
        /// </summary>
        public MetaGen()
        {
            // Inside this method you can place any initialization code that does not require
            // any Visual Studio service because at this point the package object is created but
            // not sited yet inside Visual Studio environment. The place to do all the other
            // initialization is the Initialize method.
        }

       
        int IVsSingleFileGenerator.DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".inst.cs";
            return VSConstants.S_OK;
        }

        int IVsSingleFileGenerator.Generate(string wszInputFilePath, string bstrInputFileContents,
            string wszDefaultNamespace,
            IntPtr[] rgbOutputFileContents,
            out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            var ctx = new CodeGenContext(wszInputFilePath, bstrInputFileContents, wszDefaultNamespace);

            var sb = new StringBuilder();
            sb.AppendLine("/*");
            sb.AppendLine(bstrInputFileContents);
            sb.AppendLine("*/");

            var code = sb.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes(code);
            rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(bytes.Length);
            Marshal.Copy(bytes, 0, rgbOutputFileContents[0], bytes.Length);
            pcbOutput = (uint)bytes.Length;
            return VSConstants.S_OK;
        }

        public static string GenerateCode(CodeGenContext ctx)
        {
            var sb = new StringBuilder();
            sb.AppendLine("/*");
            sb.AppendLine(ctx.InputContent);
            sb.AppendLine("*/");
            var code = sb.ToString();
            return code;


        }

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        }

        #endregion
    }

    public class CodeGenContext
    {
        public CodeGenContext(string InputPath, string InputContent, string DefaultNamespace)
        {
            this.InputPath = InputPath;
            this.InputContent = InputContent;
            this.DefaultNamespace = DefaultNamespace;
        }

        public string InputPath { get; }

        public string InputContent { get; }

        public string DefaultNamespace { get; }

    }
}
