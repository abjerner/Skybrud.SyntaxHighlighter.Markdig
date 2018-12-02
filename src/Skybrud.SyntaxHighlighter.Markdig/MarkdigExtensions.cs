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

        /// <summary>
        /// Adds a new <see cref="SyntaxHighlighterMarkdownExtension"/> to the specified Markdig <paramref name="pipeline"/>.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options for configuration the syntax highlighter extension.</param>
        /// <returns>The pipeline.</returns>
        public static MarkdownPipelineBuilder UseSyntaxHighlighter(this MarkdownPipelineBuilder pipeline, SyntaxHighlighterOptions options) {
            pipeline.Extensions.Add(new SyntaxHighlighterMarkdownExtension(options));
            return pipeline;
        }

        /// <summary>
        /// Adds a new <see cref="SyntaxHighlighterMarkdownExtension"/> to the specified Markdig <paramref name="pipeline"/>.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options for configuration the syntax highlighter extension.</param>
        /// <returns>The pipeline.</returns>
        public static MarkdownPipelineBuilder UseSyntaxHighlighter(this MarkdownPipelineBuilder pipeline, out SyntaxHighlighterOptions options) {
            options = new SyntaxHighlighterOptions();
            pipeline.Extensions.Add(new SyntaxHighlighterMarkdownExtension(options));
            return pipeline;
        }

    }

}