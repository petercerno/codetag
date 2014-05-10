﻿// 
// XmlCodeTests.cs
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

using CodeTag.Common;
using CodeTag.Data;
using NUnit.Framework;

namespace CodeTag.Tests.Data
{
    [TestFixture]
    public class XmlCodeTests
    {
        private const string XmlCodeSnippetTestString =
            "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
            "<code tags=\"hello, world\"><![CDATA[<h1>Helo world!</h1>]]></code>";

        private const string XmlCodeSnippetTestTags = "hello, world";
        private const string XmlCodeSnippetTestCode = "<h1>Helo world!</h1>";

        [Test]
        public void XmlCodeSnippetSerializeTest()
        {
            var xmlCodeSnippet = new XmlCode
            {
                Tags = XmlCodeSnippetTestTags,
                Code = XmlCodeSnippetTestCode
            };
            var xmlCodeSnippetString = XmlHelper.SerializeToString(xmlCodeSnippet);
            Assert.AreEqual(xmlCodeSnippetString, XmlCodeSnippetTestString);
        }

        [Test]
        public void XmlCodeSnippetDeserializeTest()
        {
            var xmlCodeSnippet = XmlHelper.DeserializeFromString<XmlCode>(XmlCodeSnippetTestString);
            Assert.AreEqual(xmlCodeSnippet.Tags, XmlCodeSnippetTestTags);
            Assert.AreEqual(xmlCodeSnippet.Code, XmlCodeSnippetTestCode);
        }
    }
}
