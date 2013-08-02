// 
// XmlHelper.cs
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

using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CodeTag.Common
{
    /// <summary>
    /// Xml helper class based on:
    /// http://stackoverflow.com/questions/1564718/using-stringwriter-for-xml-serialization
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Serializes a given object to an xml string.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="value">Object to be serialized.</param>
        /// <param name="indent">Value indicating whether to indent elements. The default is false.</param>
        /// <param name="omitXmlDeclaration">Value indicating whether to omit an XML declaration. The default is false.</param>
        /// <returns>Xml representation of the object.</returns>
        public static string SerializeToString<T>(T value, bool indent = false, bool omitXmlDeclaration = false) where T : class
        {
            if (value == null)
                return null;

            var settings = new XmlWriterSettings
                {
                    Encoding = new UnicodeEncoding(false, false),
                    Indent = indent,
                    OmitXmlDeclaration = omitXmlDeclaration                    
                };

            using (var textWriter = new StringWriter())
            using (var xmlWriter = XmlWriter.Create(textWriter, settings))
            {
                SerializeToStream(xmlWriter, value);
                return textWriter.ToString();
            }
        }

        /// <summary>
        /// Deserializes a given xml string to an object.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="xml">Xml representation of the object.</param>
        /// <returns>Deserialized object.</returns>
        public static T DeserializeFromString<T>(string xml) where T : class
        {
            if (string.IsNullOrEmpty(xml))
                return default(T);

            var settings = new XmlReaderSettings();

            using (var textReader = new StringReader(xml))
            using (var xmlReader = XmlReader.Create(textReader, settings))
                return DeserializeFromStream<T>(xmlReader);
        }

        /// <summary>
        /// Serializes a given object to a file.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="fileName">File path.</param>
        /// <param name="xml">Object to be serialized.</param>
        public static void SerializeToFile<T>(string fileName, T xml) where T : class
        {
            using (var saveStream = File.Open(fileName, FileMode.Create))
                SerializeToStream(saveStream, xml);
        }

        /// <summary>
        /// Deserializes a given file to an object.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="fileName">File path.</param>
        /// <returns>Deserialized object.</returns>
        public static T DeserializeFromFile<T>(string fileName) where T : class
        {
            using (var streamReader = File.OpenText(fileName))
            using (var xmlReader = XmlReader.Create(streamReader, new XmlReaderSettings()))
                return DeserializeFromStream<T>(xmlReader);
        }

        /// <summary>
        /// Serializes a given object to a stream.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="stream">Stream.</param>
        /// <param name="xml">Object to be serialized.</param>
        public static void SerializeToStream<T>(dynamic stream, T xml) where T : class
        {
            if (xml == null) return;
            var serializer = new XmlSerializer(typeof(T), string.Empty);
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            serializer.Serialize(stream, xml, ns);
        }

        /// <summary>
        /// Deserializes a given stream to an object.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="stream">Stream.</param>
        /// <returns>Deserialized object.</returns>
        public static T DeserializeFromStream<T>(dynamic stream) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T), string.Empty);
            return xmlSerializer.Deserialize(stream) as T;
        }
    }
}
