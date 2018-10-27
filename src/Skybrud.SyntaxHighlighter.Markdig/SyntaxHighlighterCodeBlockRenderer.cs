using System;
using Markdig.Parsers;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;

namespace Skybrud.SyntaxHighlighter.Markdig {

    /// <summary>
    /// Our custom code block renderer.
    /// </summary>
    public class SyntaxHighlighterCodeBlockRenderer : HtmlObjectRenderer<CodeBlock> {

        #region Properties

        /// <summary>
        /// Gets the fallback code block renderer.
        /// </summary>
        protected CodeBlockRenderer Fallback { get; }

        #endregion

        #region Constructors
        
        /// <summary>
        /// Initializes a new code block renderer with default options.
        /// </summary>
        public SyntaxHighlighterCodeBlockRenderer() {
            Fallback = new CodeBlockRenderer();
        }

        /// <summary>
        /// Initializes a new code block renderer with specified <paramref name="fallback"/>.
        /// </summary>
        /// <param name="fallback">A fallback code block renderer.</param>
        public SyntaxHighlighterCodeBlockRenderer(CodeBlockRenderer fallback) {
            Fallback = fallback ?? new CodeBlockRenderer();
        }

        #endregion

        /// <summary>
        /// Writes the specified <paramref name="block"/> to the <paramref name="renderer"/>.
        /// </summary>
        /// <param name="renderer">The renderer.</param>
        /// <param name="block">The object to render.</param>
        protected override void Write(HtmlRenderer renderer, CodeBlock block) {

            // Make sure "obj" is an instance of "FencedCodeBlock"
            FencedCodeBlock fenced = block as FencedCodeBlock;

            // Make sure "obj" is an instance of "FencedCodeBlockParser"
            FencedCodeBlockParser parser = block.Parser as FencedCodeBlockParser;
            
            // Use the fallback code block renderer
            if (fenced == null || parser == null) {
                Fallback.Write(renderer, block);
                return;
            }

            // Get the language from the fenced block
            string language = fenced.Info.ToLowerInvariant();

            // Get the actual contents of the fenced block
            string code = String.Join(Environment.NewLine, block.Lines.Lines);

            // TODO: is this really a good idea?
            code = code.TrimEnd();
            
            switch (language) {

                case "c#":
                case "csharp":
                    renderer.Write(Highlighter.HighlightCSharp(code));
                    break;

                case "json":
                    renderer.Write(Highlighter.HighlightJson(code));
                    break;

                case "javascript":
                    renderer.Write(Highlighter.HighlightJavaScript(code));
                    break;

                case "html":
                    renderer.Write(Highlighter.HighlightHtml(code));
                    break;

                case "xml":
                    renderer.Write(Highlighter.HighlightXml(code));
                    break;

                default:
                    Fallback.Write(renderer, block);
                    break;

            }

        }

    }

}