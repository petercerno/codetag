// 
// CodeContext.cs
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
    /// Immutable class representing a code context (or block).
    /// </summary>
    internal class CodeContext
    {
        internal CodeContext(
            string name,
            IEnumerable<string> tags,
            string authors = null,
            string source = null,
            string syntax = null,
            string description = null,
            string prerequisites = null,
            string path = null,
            CodeContext parentContext = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name");
            if (tags == null)
                throw new ArgumentException("tags");
            Name = name;
            SpecificTags = new SortedSet<string>(tags);
            AllTags = parentContext != null
                ? new SortedSet<string>(SpecificTags.Union(parentContext.AllTags))
                : new SortedSet<string>(SpecificTags);
            Authors = authors ?? (parentContext != null ? parentContext.Authors : string.Empty);
            Source = source ?? (parentContext != null ? parentContext.Source : string.Empty);
            Syntax = syntax ?? (parentContext != null ? parentContext.Syntax : string.Empty);
            Description = description ?? string.Empty;
            Prerequisites = prerequisites ?? string.Empty;
            Path = path ?? (parentContext != null ? parentContext.Path : string.Empty);
            ParentContext = parentContext;
        }

        /// <summary>
        /// Name of the code context.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Authors of the code context.
        /// </summary>
        public string Authors { get; protected set; }

        /// <summary>
        /// Source of the code context.
        /// </summary>
        public string Source { get; protected set; }

        /// <summary>
        /// Syntax of the code context.
        /// </summary>
        public string Syntax { get; protected set; }

        /// <summary>
        /// Set of specific code context tags.
        /// </summary>
        public ISet<string> SpecificTags { get; protected set; }

        /// <summary>
        /// Set of specific code context tags and all tags of all parent contexts.
        /// </summary>
        public ISet<string> AllTags { get; protected set; }

        /// <summary>
        /// Description of the code context.
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// Prerequisites of the code context.
        /// </summary>
        public string Prerequisites { get; protected set; }

        /// <summary>
        /// Path to the code context.
        /// </summary>
        public string Path { get; protected set; }

        /// <summary>
        /// Parent code context.
        /// </summary>
        public CodeContext ParentContext { get; protected set; }
    }
}
