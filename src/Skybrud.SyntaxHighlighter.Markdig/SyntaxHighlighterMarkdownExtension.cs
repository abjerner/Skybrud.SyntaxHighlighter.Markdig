﻿using System;
using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;

namespace Skybrud.SyntaxHighlighter.Markdig {

    /// <summary>
    /// Syntax highlighter extension for Markdig.
    /// </summary>
    public class SyntaxHighlighterMarkdownExtension : IMarkdownExtension {

        #region Properties

        /// <summary>
        /// The options for configuration the syntax highlighter extension.
        /// </summary>
        public SyntaxHighlighterOptions Options { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SyntaxHighlighterMarkdownExtension() {
            Options = new SyntaxHighlighterOptions();
        }

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        /// <param name="options">The options for configuration the syntax highlighter extension.</param>
        public SyntaxHighlighterMarkdownExtension(SyntaxHighlighterOptions options) {
            Options = options ?? new SyntaxHighlighterOptions();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Setups this extension for the specified pipeline.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        public void Setup(MarkdownPipelineBuilder pipeline) {}

        /// <summary>
        /// Setups this extension for the specified renderer.
        /// </summary>
        /// <param name="pipeline">The pipeline used to parse the document.</param>
        /// <param name="renderer">The renderer.</param>
        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer) {

            if (renderer == null) throw new ArgumentNullException(nameof(renderer));

            // Make sure "renderer" is an instance of TextRendererBase<HtmlRenderer>
            TextRendererBase<HtmlRenderer> htmlRenderer = renderer as TextRendererBase<HtmlRenderer>;
            if (htmlRenderer == null) return;

            // Make sure we remove the original code block renderer if it's still there
            CodeBlockRenderer originalCodeBlockRenderer = htmlRenderer.ObjectRenderers.FindExact<CodeBlockRenderer>();
            if (originalCodeBlockRenderer != null) htmlRenderer.ObjectRenderers.Remove(originalCodeBlockRenderer);

            // Add our custom code block renderer
            htmlRenderer.ObjectRenderers.AddIfNotAlready(new SyntaxHighlighterCodeBlockRenderer(originalCodeBlockRenderer, Options));

        }

        #endregion

    }

}