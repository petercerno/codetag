// 
// CodeSnippet.cs
//  
// Author:
//   Peter Cerno <petercerno@gmail.com>
// 
// Copyright (c) 2014 Peter Cerno
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
    /// Immutable class representing a code snippet with a specific set of tags and context.
    /// </summary>
    internal class CodeSnippet
    {
        internal CodeSnippet(
            string code,
            IEnumerable<string> tags,
            CodeContext context = null)
        {
            if (tags == null)
                throw new ArgumentException("tags");
            Code = code ?? string.Empty;
            SpecificTags = new SortedSet<string>(tags);
            AllTags = context != null
                ? new SortedSet<string>(SpecificTags.Union(context.AllTags))
                : new SortedSet<string>(SpecificTags);
            Authors = context != null ? context.Authors : string.Empty;
            Source = context != null ? context.Source : string.Empty;
            Syntax = context != null ? context.Syntax : string.Empty;
            Path = context != null ? context.Path : string.Empty;
            Context = context;
        }

        /// <summary>
        /// Code of the code snippet.
        /// </summary>
        public string Code { get; protected set; }

        /// <summary>
        /// Authors of the code context.
        /// </summary>
        public string Authors { get; protected set; }

        /// <summary>
        /// Source of the code context.
        /// </summary>
        public string Source { get; protected set; }

        /// <summary>
        /// Syntax of the code snippet.
        /// </summary>
        public string Syntax { get; protected set; }

        /// <summary>
        /// Path of the code snippet.
        /// </summary>
        public string Path { get; protected set; }

        /// <summary>
        /// Set of specific code snippet tags.
        /// </summary>
        public ISet<string> SpecificTags { get; protected set; }

        /// <summary>
        /// Set of specific code snippet tags and all tags of all parent contexts.
        /// </summary>
        public ISet<string> AllTags { get; protected set; }

        /// <summary>
        /// Context of the code snippet.
        /// </summary>
        public CodeContext Context { get; protected set; }

        /// <summary>
        /// Returns the list of all contexts from the outer-most context to the inner-most context.
        /// </summary>
        /// <returns>List of all contexts.</returns>
        public IList<CodeContext> GetContextList()
        {
            var contextStack = new Stack<CodeContext>();
            var context = Context;
            while (context != null)
            {
                contextStack.Push(context);
                context = context.ParentContext;
            }
            return contextStack.ToList();
        }
    }
}
