// 
// ErrorReport.cs
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

namespace CodeTag
{
    static class ErrorReport
    {
        private static readonly string ApologyMessage =
            "We are deeply sorry, but the following error has occured." + Environment.NewLine +
            "Please, report the error details to petercerno@gmail.com." + Environment.NewLine +
            "Thank you very much!" + Environment.NewLine + Environment.NewLine +
            "ERROR:" + Environment.NewLine;

        public static void Report(Exception exception)
        {
            Report(ApologyMessage + 
                exception.Message + Environment.NewLine +
                exception.StackTrace);
        }

        public static void Report(string message)
        {
            var errorForm = new ErrorForm(message);
            errorForm.ShowDialog();
        }
    }
}
