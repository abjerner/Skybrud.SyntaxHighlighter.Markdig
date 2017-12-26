using Markdig;

namespace Skybrud.SyntaxHighlighter.Markdig {

    public static class MarkdigExtensions {

        public static MarkdownPipelineBuilder UseSyntaxHighlighter(this MarkdownPipelineBuilder pipeline) {
            pipeline.Extensions.Add(new SyntaxHighlighterMarkdownExtension());
            return pipeline;
        }

    }

}