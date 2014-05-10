// 
// SpecialCharsTagPreprocessor.cs
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
using System.Text.RegularExpressions;

namespace CodeTag.Core.TagPreprocessors
{
    /// <summary>
    /// Removes special chars from tags.
    /// </summary>
    internal class SpecialCharsTagPreprocessor : ITagPreprocessor
    {
        /// <summary>
        /// These characters are removed from tags.
        /// </summary>
        public static readonly Regex SkipPattern = new Regex(@"[_\.\-+]");

        /// <summary>
        /// These characters split a tag into multiple tags.
        /// </summary>
        public static readonly char[] SplitChars = {',', ';', ' ', '\t', '\r', '\n'};

        public ISet<string> Preprocess(ISet<string> tags)
        {
            var resultTags = new SortedSet<string>();
            foreach (var tag in tags.Select(t => SkipPattern.Replace(t, "")))
                resultTags.UnionWith(tag.Split(SplitChars, StringSplitOptions.RemoveEmptyEntries));
            return resultTags;
        }
    }
}
