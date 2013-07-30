// 
// CompositeTagPreprocessorTests.cs
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
using CodeTag.Core;
using CodeTag.Core.TagPreprocessors;
using NUnit.Framework;

namespace CodeTag.Tests.Core.TagPreprocessors
{
    [TestFixture]
    public class CompositeTagPreprocessorTests
    {
        [Test]
        public void CompositeTagPreprocessorTest()
        {
            var tagPreprocessor = new CompositeTagPreprocessor(
                new List<ITagPreprocessor>
                    {
                        new LowerCaseTagPreprocessor(),
                        new SpecialCharsTagPreprocessor(),
                    });

            var inputTags = new SortedSet<string>(new[]
                {
                    "test1_XYZ1",
                    "test2.XYZ2",
                    "test3-XYZ3",
                    "test4+XYZ4",
                    "test5,XYZ5",
                    "test6;XYZ6",
                    "test7 XYZ7",
                    "test8\tXYZ8"
                });

            var outputTags = new SortedSet<string>(new[]
                {
                    "test1xyz1",
                    "test2xyz2",
                    "test3xyz3",
                    "test4xyz4",
                    "test5", "xyz5",
                    "test6", "xyz6",
                    "test7", "xyz7",
                    "test8", "xyz8"
                });

            var resultTags = tagPreprocessor.Preprocess(inputTags);
            Assert.AreEqual(outputTags, resultTags);
        }
    }
}
