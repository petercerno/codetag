// 
// XmlBlockTests.cs
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

using CodeTag.Common;
using CodeTag.Data;
using NUnit.Framework;

namespace CodeTag.Tests.Data
{
    [TestFixture]
    public class XmlBlockTests
    {
        private const string XmlBlockTestName = "Python for Data Analysis";
        private const string XmlBlockTestSyntax = "python";
        private const string XmlBlockTestTags = "python, pandas";
        private const string XmlBlockTestDescription = "http://pandas.pydata.org/";
        private const string XmlBlockTestPrerequisites = "from pandas import Series, DataFrame";

        private const string XmlSubBlockTestName = "Date and Time Data Types and Tools";
        private const string XmlSubBlockTestTags = "datetime";
        private const string XmlSubBlockTestPrerequisites = "from datatime import datetime";

        private const string XmlSubItem1TestTags = "now";
        private const string XmlSubItem1TestCode = "datetime.now()";

        private const string XmlSubItem2TestTags = "constructor";
        private const string XmlSubItem2TestCode = "datetime(2013, 5, 7, 12, 0, 0, 0)";

        private const string XmlBlockTestString =
            "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            "<block name=\"Python for Data Analysis\" syntax=\"python\" tags=\"python, pandas\">" +
            "<description>http://pandas.pydata.org/</description>" +
            "<prerequisites><![CDATA[from pandas import Series, DataFrame]]></prerequisites>" +
            "<block name=\"Date and Time Data Types and Tools\" tags=\"datetime\">" +
            "<prerequisites><![CDATA[from datatime import datetime]]></prerequisites>" +
            "<code tags=\"now\"><![CDATA[datetime.now()]]></code>" +
            "<code tags=\"constructor\"><![CDATA[datetime(2013, 5, 7, 12, 0, 0, 0)]]></code>" +
            "</block>" +
            "</block>";

        [Test]
        public void XmlBlockSerializeTest()
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

            var xmlBlockString = XmlHelper.SerializeToString(xmlBlock);
            Assert.AreEqual(xmlBlockString, XmlBlockTestString);
        }

        [Test]
        public void XmlBockDeserializeTest()
        {
            var xmlBlock = XmlHelper.DeserializeFromString<XmlBlock>(XmlBlockTestString);
            Assert.AreEqual(xmlBlock.Name, XmlBlockTestName);
            Assert.AreEqual(xmlBlock.Syntax, XmlBlockTestSyntax);
            Assert.AreEqual(xmlBlock.Tags, XmlBlockTestTags);
            Assert.AreEqual(xmlBlock.Description, XmlBlockTestDescription);
            Assert.AreEqual(xmlBlock.Prerequisites, XmlBlockTestPrerequisites);
            Assert.AreEqual(xmlBlock.Blocks.Length, 1);
            Assert.AreEqual(xmlBlock.Blocks[0].Name, XmlSubBlockTestName);
            Assert.AreEqual(xmlBlock.Blocks[0].Tags, XmlSubBlockTestTags);
            Assert.AreEqual(xmlBlock.Blocks[0].Prerequisites, XmlSubBlockTestPrerequisites);
            Assert.AreEqual(xmlBlock.Blocks[0].CodeSnippets.Length, 2);
            Assert.AreEqual(xmlBlock.Blocks[0].CodeSnippets[0].Tags, XmlSubItem1TestTags);
            Assert.AreEqual(xmlBlock.Blocks[0].CodeSnippets[0].Code, XmlSubItem1TestCode);
            Assert.AreEqual(xmlBlock.Blocks[0].CodeSnippets[1].Tags, XmlSubItem2TestTags);
            Assert.AreEqual(xmlBlock.Blocks[0].CodeSnippets[1].Code, XmlSubItem2TestCode);
        }
    }
}
