// 
// CompositeCodeSnippetSource.cs
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

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodeTag.Core.CodeSnippetSources
{
    /// <summary>
    /// Composite source of code snippets.
    /// </summary>
    class CompositeCodeSnippetSource : CodeSnippetSourceBase
    {
        /// <summary>
        /// Creates composite source of code snippets.
        /// </summary>
        /// <param name="codeSnippetSources">Enumeration of code snippet sources.</param>
        public CompositeCodeSnippetSource(IEnumerable<CodeSnippetSourceBase> codeSnippetSources)
        {
            _codeSnippets = new List<CodeSnippet>();
            if (codeSnippetSources != null)
                foreach (var codeSnippetSource in codeSnippetSources)
                    _codeSnippets.AddRange(codeSnippetSource.CodeSnippets);
        }

        private readonly List<CodeSnippet> _codeSnippets;

        internal override IList<CodeSnippet> CodeSnippets
        {
            get { return new ReadOnlyCollection<CodeSnippet>(_codeSnippets); }
        }
    }
}
