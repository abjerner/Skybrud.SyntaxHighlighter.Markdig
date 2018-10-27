using Markdig;

namespace Skybrud.SyntaxHighlighter.Markdig {

    /// <summary>
    /// Class with extension methods for the Markdown package.
    /// </summary>
    public static class MarkdigExtensions {

        /// <summary>
        /// Adds a new <see cref="SyntaxHighlighterMarkdownExtension"/> to the specified Markdig <paramref name="pipeline"/>.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The pipeline.</returns>
        public static MarkdownPipelineBuilder UseSyntaxHighlighter(this MarkdownPipelineBuilder pipeline) {
            pipeline.Extensions.Add(new SyntaxHighlighterMarkdownExtension());
            return pipeline;
        }

    }

}