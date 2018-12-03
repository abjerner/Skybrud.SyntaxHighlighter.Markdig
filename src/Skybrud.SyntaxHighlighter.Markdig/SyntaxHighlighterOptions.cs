using System;
using System.Collections.Generic;

namespace Skybrud.SyntaxHighlighter.Markdig {

    /// <summary>
    /// Class with options for configuration the syntax highlighter extension.
    /// </summary>
    public class SyntaxHighlighterOptions {
        
        #region Properties

        /// <summary>
        /// Gets a dictionary with the aliases.
        /// </summary>
        public Dictionary<string, Language> Aliases { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SyntaxHighlighterOptions() {
            Aliases = new Dictionary<string, Language> {
                {"c#", Language.CSharp },
                {"csharp", Language.CSharp },
                {"json", Language.Json },
                {"js", Language.JavaScript },
                {"javascript", Language.JavaScript },
                {"html", Language.Html },
                {"xml", Language.Xml }
            };

        }

        #endregion

        #region Member methods

        /// <summary>
        /// Attempts to get the <paramref name="language"/> for <paramref name="alias"/>. 
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <param name="language">The language that should be used for <paramref name="alias"/>, or <see cref="Language.None"/> if not found.</param>
        /// <returns><c>true</c> if <paramref name="alias"/> is found; otherwise <c>false</c>.</returns>
        public bool TryGetAlias(string alias, out Language language) {
            return Aliases.TryGetValue(alias ?? "", out language);
        }

        /// <summary>
        /// Adds a new <paramref name="alias"/> for <paramref name="language"/>.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <param name="language">The language to be used for <paramref name="alias"/>.</param>
        /// <returns></returns>
        public SyntaxHighlighterOptions AddAlias(string alias, Language language) {
            if (String.IsNullOrWhiteSpace(alias)) throw new ArgumentNullException(nameof(alias));
            Aliases[alias] = language;
            return this;
        }

        /// <summary>
        /// Removes the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns></returns>
        public SyntaxHighlighterOptions RemoveAlias(string alias) {
            if (String.IsNullOrWhiteSpace(alias)) throw new ArgumentNullException(nameof(alias));
            Aliases.Remove(alias);
            return this;
        }

        #endregion

    }

}