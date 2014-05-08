// 
// XmlCodeSnippetSource.cs
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
using System.Collections.ObjectModel;
using CodeTag.Common;
using CodeTag.Data;

namespace CodeTag.Core.CodeSnippetSources
{
    /// <summary>
    /// Xml source of code snippets.
    /// </summary>
    internal class XmlCodeSnippetSource : CodeSnippetSourceBase
    {
        /// <summary>
        /// Creates a code snippet source from an xml block.
        /// </summary>
        /// <param name="xmlBlock">Xml representation of a block of code snippets.</param>
        /// <param name="path">Path corresponding to the xml block.</param>
        public XmlCodeSnippetSource(XmlBlock xmlBlock, string path)
        {
            _codeSnippets = new List<CodeSnippet>();
            if (xmlBlock != null)
                ProcessXmlBlock(xmlBlock, null, path);
        }

        private static readonly char[] SplitCharacters = {',', ';', ' ', '\t', '\r', '\n'};

        private static IEnumerable<string> Split(string str)
        {
            return string.IsNullOrWhiteSpace(str)
                ? new string[0]
                : str.Split(SplitCharacters, StringSplitOptions.RemoveEmptyEntries);
        }

        private void ProcessXmlBlock(XmlBlock xmlBlock, CodeContext parentContext, string path)
        {
            var context =
                new CodeContext(
                    xmlBlock.Name.Strip(),
                    Split(xmlBlock.Tags),
                    xmlBlock.Authors.Strip(),
                    xmlBlock.Source.Strip(),
                    xmlBlock.Syntax.Strip(),
                    xmlBlock.Description.Strip(),
                    xmlBlock.Prerequisites.Strip(),
                    path.Strip(),
                    parentContext);
            if (xmlBlock.CodeSnippets != null && xmlBlock.CodeSnippets.Length > 0)
                foreach (var xmlChildCode in xmlBlock.CodeSnippets)
                    ProcessXmlCode(xmlChildCode, context);
            if (xmlBlock.Blocks != null && xmlBlock.Blocks.Length > 0)
                foreach (var xmlChildBlock in xmlBlock.Blocks)
                    ProcessXmlBlock(xmlChildBlock, context, path);
        }

        private void ProcessXmlCode(XmlCode xmlCode, CodeContext parentContext)
        {
            _codeSnippets.Add(
                new CodeSnippet(
                    xmlCode.Code.Strip(),
                    Split(xmlCode.Tags),
                    parentContext));
        }

        private readonly List<CodeSnippet> _codeSnippets;

        internal override IList<CodeSnippet> CodeSnippets
        {
            get { return new ReadOnlyCollection<CodeSnippet>(_codeSnippets); }
        }
    }
}
