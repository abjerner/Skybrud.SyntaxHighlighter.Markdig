using System;
using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace Skybrud.SyntaxHighlighter.Markdig {

    public class SyntaxHighlighterMarkdownExtension : IMarkdownExtension {
        
        public void Setup(MarkdownPipelineBuilder pipeline) {}

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer) {

            if (renderer == null) throw new ArgumentNullException(nameof(renderer));

            // Make sure "renderer" is an instance of TextRendererBase<HtmlRenderer>
            TextRendererBase<HtmlRenderer> htmlRenderer = renderer as TextRendererBase<HtmlRenderer>;
            if (htmlRenderer == null) return;

            // Make sure we remove the original code block renderer if it's still there
            CodeBlockRenderer originalCodeBlockRenderer = htmlRenderer.ObjectRenderers.FindExact<CodeBlockRenderer>();
            if (originalCodeBlockRenderer != null) htmlRenderer.ObjectRenderers.Remove(originalCodeBlockRenderer);

            // Add our custom code block renderer
            htmlRenderer.ObjectRenderers.AddIfNotAlready(new SyntaxHighlighterCodeBlockRenderer(originalCodeBlockRenderer));

        }

    }

}