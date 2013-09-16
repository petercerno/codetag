// 
// Configuration.cs
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
using System.Collections.Specialized;
using System.Linq;
using CodeTag.Properties;

namespace CodeTag
{
    /// <summary>
    /// Configuration of the application.
    /// </summary>
    static class Configuration
    {
        /// <summary>
        /// Tag preprocessing enumeration.
        /// </summary>
        [Flags]
        public enum TagPreprocess
        {
            LowerCase = 1,
            RemoveSpecialChars = 2
        }

        /// <summary>
        /// Tag matching enumeration.
        /// </summary>
        public enum TagMatch
        {
            Exact,
            Prefix,
            Substring
        }

        public static readonly TagPreprocess DefaultTagPreprocess = TagPreprocess.LowerCase | TagPreprocess.RemoveSpecialChars;
        public static readonly TagMatch DefaultTagMatch = TagMatch.Prefix;
        public static readonly Tuple<string, bool>[] DefaultCodeSnippetSources = new Tuple<string, bool>[0];
        public static readonly bool DefaultStartup = false;

        /// <summary>
        /// Get or set the enumeration of tag preprocessors.
        /// </summary>
        public static TagPreprocess TagPreprocessing
        {
            get
            {
                try
                {
                    if (Settings.Default.TagPreprocessing == null) return DefaultTagPreprocess;
                    var tagPreprocessingCollection = Settings.Default.TagPreprocessing.Cast<string>();
                    return tagPreprocessingCollection.Aggregate(
                        (TagPreprocess)0,
                        (current, tagPreprocessing) =>
                        (current | (TagPreprocess)Enum.Parse(typeof(TagPreprocess), tagPreprocessing)));
                }
                catch (Exception exception)
                {
                    ErrorReport.Report(exception);
                    return DefaultTagPreprocess;
                }
            }
            set
            {
                try
                {
                    var tagPreprocessingCollection = new StringCollection();
                    tagPreprocessingCollection.AddRange(
                        (from TagPreprocess tagPreprocess in Enum.GetValues(typeof(TagPreprocess))
                         where (value & tagPreprocess) == tagPreprocess
                         select tagPreprocess.ToString()).ToArray());
                    Settings.Default.TagPreprocessing = tagPreprocessingCollection;
                }
                catch (Exception exception)
                {
                    ErrorReport.Report(exception);
                }
            }
        }

        /// <summary>
        /// Get or set the tag matching.
        /// </summary>
        public static TagMatch TagMatching
        {
            get
            {
                try
                {
                    var tagMatching = Settings.Default.TagMatching;
                    if (tagMatching == null) return DefaultTagMatch;
                    return (TagMatch)Enum.Parse(typeof(TagMatch), tagMatching);
                }
                catch (Exception exception)
                {
                    ErrorReport.Report(exception);
                    return DefaultTagMatch;
                }
            }
            set
            {
                try
                {
                    Settings.Default.TagMatching = value.ToString();
                }
                catch (Exception exception)
                {
                    ErrorReport.Report(exception);
                }
            }
        }

        /// <summary>
        /// Get or set the checked code snippet sources.
        /// </summary>
        public static Tuple<string, bool>[] CheckedCodeSnippetSources
        {
            get
            {
                try
                {
                    if (Settings.Default.CodeSnippetSources == null) return DefaultCodeSnippetSources;
                    if (Settings.Default.CodeSnippetSourcesChecked == null) return DefaultCodeSnippetSources;
                    var codeSnippetSourceArray = Settings.Default.CodeSnippetSources.Cast<string>().ToArray();
                    var codeSnippetSourceCheck = Settings.Default.CodeSnippetSourcesChecked;
                    if (codeSnippetSourceArray.Length != codeSnippetSourceCheck.Length) return null;
                    return Enumerable.Range(0, codeSnippetSourceArray.Length).Select(
                        i => Tuple.Create(codeSnippetSourceArray[i], codeSnippetSourceCheck[i] == '1')).ToArray();
                }
                catch (Exception exception)
                {
                    ErrorReport.Report(exception);
                    return DefaultCodeSnippetSources;
                }
            }
            set
            {
                try
                {
                    var codeSnippetSourceCollection = new StringCollection();
                    codeSnippetSourceCollection.AddRange(value.Select(t => t.Item1).ToArray());
                    Settings.Default.CodeSnippetSources = codeSnippetSourceCollection;
                    Settings.Default.CodeSnippetSourcesChecked = string.Concat(value.Select(t => t.Item2 ? "1" : "0"));
                }
                catch (Exception exception)
                {
                    ErrorReport.Report(exception);
                }
            }
        }

        /// <summary>
        /// Get or set the launch at the startup.
        /// </summary>
        public static bool Startup
        {
            get
            {
                try
                {
                    return Settings.Default.Startup;
                }
                catch (Exception exception)
                {
                    ErrorReport.Report(exception);
                    return DefaultStartup;
                }
            }
            set
            {
                try
                {
                    Settings.Default.Startup = value;
                }
                catch (Exception exception)
                {
                    ErrorReport.Report(exception);
                }
            }
        }

        /// <summary>
        /// Save the configuration.
        /// </summary>
        public static void Save()
        {
            try
            {
                Settings.Default.Save();
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }
    }
}
