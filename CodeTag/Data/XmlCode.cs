// 
// XmlCode.cs
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
using System.Xml;
using System.Xml.Serialization;

namespace CodeTag.Data
{
    /// <summary>
    /// Xml representation of a code snippet.
    /// </summary>
    [XmlRoot("code")]
    public class XmlCode
    {
        internal XmlCode()
        {
            
        }

        [XmlAttribute("syntax")]
        public string Syntax { get; set; }

        [XmlAttribute("tags")]
        public string Tags { get; set; }

        [XmlIgnore]
        public string Code { get; set; }

        /// <summary>
        /// Source: http://stackoverflow.com/questions/1379888/how-do-you-serialize-a-string-as-cdata-using-xmlserializer
        /// </summary>
        [XmlText]
        public XmlNode[] CDataCode
        {
            get
            {
                return Code != null
                           ? new XmlNode[] {new XmlDocument().CreateCDataSection(Code)}
                           : null;
            }
            set
            {
                if (value == null)
                {
                    Code = null;
                    return;
                }

                if (value.Length != 1)
                    throw new InvalidOperationException(
                        String.Format("Invalid array length {0}", value.Length));

                Code = value[0].Value;
            }
        }
    }
}
