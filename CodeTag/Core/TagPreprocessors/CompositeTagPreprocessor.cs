﻿// 
// CompositeTagPreprocessor.cs
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

using System.Collections.Generic;
using System.Linq;

namespace CodeTag.Core.TagPreprocessors
{
    /// <summary>
    /// Composite tag preprocessor.
    /// </summary>
    internal class CompositeTagPreprocessor : ITagPreprocessor
    {
        /// <summary>
        /// Creates composite tag preprocessors.
        /// </summary>
        /// <param name="tagPreprocessors">Enumeration of tag preprocessors.</param>
        public CompositeTagPreprocessor(IEnumerable<ITagPreprocessor> tagPreprocessors)
        {
            _tagPreprocessors = tagPreprocessors.ToList();
        }

        private readonly IList<ITagPreprocessor> _tagPreprocessors;

        public ISet<string> Preprocess(ISet<string> tags)
        {
            if (_tagPreprocessors == null || _tagPreprocessors.Count == 0) return tags;
            return _tagPreprocessors.Aggregate(
                tags, (current, tagPreprocessor) => tagPreprocessor.Preprocess(current));
        }
    }
}
