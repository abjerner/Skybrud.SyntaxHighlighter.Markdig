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
        /// Gets the options for configuration the syntax highlighter extension.
        /// </summary>
        protected SyntaxHighlighterOptions Options { get; }

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
            Options = new SyntaxHighlighterOptions();
        }

        /// <summary>
        /// Initializes a new code block renderer with default options.
        /// </summary>
        /// <param name="options">The options for configuration the syntax highlighter extension.</param>
        public SyntaxHighlighterCodeBlockRenderer(SyntaxHighlighterOptions options) {
            Fallback = new CodeBlockRenderer();
            Options = options ?? new SyntaxHighlighterOptions();
        }

        /// <summary>
        /// Initializes a new code block renderer with specified <paramref name="fallback"/>.
        /// </summary>
        /// <param name="fallback">A fallback code block renderer.</param>
        public SyntaxHighlighterCodeBlockRenderer(CodeBlockRenderer fallback) {
            Fallback = fallback ?? new CodeBlockRenderer();
            Options = new SyntaxHighlighterOptions();
        }

        /// <summary>
        /// Initializes a new code block renderer with specified <paramref name="fallback"/>.
        /// </summary>
        /// <param name="fallback">A fallback code block renderer.</param>
        /// <param name="options">The options for configuration the syntax highlighter extension.</param>
        public SyntaxHighlighterCodeBlockRenderer(CodeBlockRenderer fallback, SyntaxHighlighterOptions options) {
            Fallback = fallback ?? new CodeBlockRenderer();
            Options = options ?? new SyntaxHighlighterOptions();
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

            // Get the syntax language matching "language"
            Options.TryGetAlias(language, out Language lang);
            
            renderer.Write(Highlighter.Highlight(code, lang));

        }

    }

}