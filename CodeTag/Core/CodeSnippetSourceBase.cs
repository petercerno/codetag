// 
// CodeSnippetSourceBase.cs
//  
// Author:
//       Peter Cerno <petercerno@gmail.com>
// 
// Copyright (c) 2013 Peter Cerno
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTag.Core
{
    /// <summary>
    /// Base class for a source of code snippets.
    /// </summary>
    abstract class CodeSnippetSourceBase : ICodeSnippetSource
    {
        /// <summary>
        /// Search the source with a given set of filtering tags.
        /// </summary>
        /// <param name="tags">Set of filtering tags.</param>
        /// <returns>List of filtered code snippets.</returns>
        public IList<CodeSnippet> Search(ISet<string> tags)
        {
            if (CodeSnippets == null || CodeSnippets.Count == 0)
                return new List<CodeSnippet>();
            if (TagPreprocessor != null)
                tags = TagPreprocessor.Preprocess(tags);
            return
                (TagMatcher != null)
                    ? (from codeSnippet in CodeSnippets
                       let codeSnippetTags =
                           TagPreprocessor != null
                               ? TagPreprocessor.Preprocess(codeSnippet.AllTags)
                               : codeSnippet.AllTags
                       where tags.All(filteringTag => codeSnippetTags.Any(tag => TagMatcher(filteringTag, tag)))
                       select codeSnippet).ToList()
                    : (from codeSnippet in CodeSnippets
                       let codeSnippetTags =
                           TagPreprocessor != null
                               ? TagPreprocessor.Preprocess(codeSnippet.AllTags)
                               : codeSnippet.AllTags
                       where tags.IsSubsetOf(codeSnippetTags)
                       select codeSnippet).ToList();
        }

        /// <summary>
        /// Tag preprocessor.
        /// </summary>
        public ITagPreprocessor TagPreprocessor { get; set; }

        /// <summary>
        /// Predicate for evaluating the match between a filtering tag and a target tag.
        /// </summary>
        public Func<string, string, bool> TagMatcher { get; set; }

        /// <summary>
        /// List of all code snippets.
        /// </summary>
        abstract internal IList<CodeSnippet> CodeSnippets { get; }
    }
}
