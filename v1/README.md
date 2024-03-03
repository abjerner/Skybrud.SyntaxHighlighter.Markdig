# Version 1

This package features a small extension for the Markdown processor [**Markdig**](https://github.com/lunet-io/markdig) and our own [**Skybrud.SyntaxHighlighter**](https://packages.limbo.works/skybrud.syntaxHighlighter/) package. With the extension, fenced code blocks will now have support for syntax highligting.

When using Markdig one would usually initialize a new instance of `MarkdownPipelineBuilder`, and then call a number of extension methods to setup how the Markdown should be processed. With this package, you can call the `UseSyntaxHighlighter` extension method to enable syntax highlighting:

```csharp
// Configure the pipeline with all advanced extensions active
var pipeline = new MarkdownPipelineBuilder()
    .UseAdvancedExtensions()
    .UseYamlFrontMatter()
    .UseSyntaxHighlighter()
    .Build();

// Process the Markdown input into HTML
string result = Markdown.ToHtml(md, pipeline);

```