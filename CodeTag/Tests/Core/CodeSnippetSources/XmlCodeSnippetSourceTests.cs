// 
// XmlCodeSnippetSourceTests.cs
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
using CodeTag.Core.CodeSnippetSources;
using CodeTag.Data;
using NUnit.Framework;

namespace CodeTag.Tests.Core.CodeSnippetSources
{
    [TestFixture]
    public class XmlCodeSnippetSourceTests
    {
        private const string XmlBlockTestName = "Python for Data Analysis";
        private const string XmlBlockTestSyntax = "python";
        private const string XmlBlockTestTags = "python, pandas";
        private const string XmlBlockTestDescription = "http://pandas.pydata.org/";
        private const string XmlBlockTestPrerequisites = "from pandas import Series, DataFrame";
        private const string XmlBlockPath = "python.xml";

        private const string XmlSubBlockTestName = "Date and Time Data Types and Tools";
        private const string XmlSubBlockTestTags = "datetime";
        private const string XmlSubBlockTestPrerequisites = "from datatime import datetime";

        private const string XmlSubItem1TestTags = "now";
        private const string XmlSubItem1TestCode = "datetime.now()";

        private const string XmlSubItem2TestTags = "constructor";
        private const string XmlSubItem2TestCode = "datetime(2013, 5, 7, 12, 0, 0, 0)";

        [Test]
        public void XmlCodeSnippetSourceTest()
        {
            var xmlBlock = new XmlBlock
                {
                    Name = XmlBlockTestName,
                    Syntax = XmlBlockTestSyntax,
                    Tags = XmlBlockTestTags,
                    Description = XmlBlockTestDescription,
                    Prerequisites = XmlBlockTestPrerequisites,
                    Blocks = new[]
                        {
                            new XmlBlock
                                {
                                    Name = XmlSubBlockTestName,
                                    Tags = XmlSubBlockTestTags,
                                    Prerequisites = XmlSubBlockTestPrerequisites,
                                    CodeSnippets = new[]
                                        {
                                            new XmlCode
                                                {
                                                    Tags = XmlSubItem1TestTags,
                                                    Code = XmlSubItem1TestCode
                                                },
                                            new XmlCode
                                                {
                                                    Tags = XmlSubItem2TestTags,
                                                    Code = XmlSubItem2TestCode
                                                }
                                        }
                                }
                        }
                };

            var xmlCodeSnippetSource = new XmlCodeSnippetSource(xmlBlock, XmlBlockPath);
            var result = xmlCodeSnippetSource.Search(new SortedSet<string>(new[] {"now"}));
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].Code, "datetime.now()");
            Assert.AreEqual(result[0].Syntax, "python");
            Assert.AreEqual(result[0].SpecificTags, new SortedSet<string>(new[] {"now"}));
            Assert.AreEqual(result[0].AllTags, new SortedSet<string>(new[] {"datetime", "now", "pandas", "python"}));
            Assert.AreEqual(result[0].Context.Name, "Date and Time Data Types and Tools");
            Assert.AreEqual(result[0].Context.Prerequisites, "from datatime import datetime");
            Assert.AreEqual(result[0].Context.Description, string.Empty);
            Assert.AreEqual(result[0].Context.Syntax, "python");
            Assert.AreEqual(result[0].Context.SpecificTags, new SortedSet<string>(new[] { "datetime" }));
            Assert.AreEqual(result[0].Context.AllTags, new SortedSet<string>(new[] { "datetime", "pandas", "python" }));
        }
    }
}
