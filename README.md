
CodeTag
=======

CodeTag is a small and easy-to-use productivity tool used for organizing and searching the code snippets based on the (filtering) tags. You can easily organize all your code snippets in a hierarchy, where each internal node of the hierarchy can also have its own (filtering) tags (and many other properties), which are then inherited by all of its children. We support a simple xml format for storing the (hierarchies of) code snippets. This enables other developers to easily import and use the stored code snippets.

CodeTag is a .NET System Tray Application, i.e., when you launch the CodeTag application a small tray icon will show up in your taskbar. At most one instance of this application is allowed to run at any given time. Currently, only Windows operating system is supported.

The CodeTag application consists of the following three dialogs:

 1. **Search** - Dialog for searching the code snippets by their tags. (Global hotkey: `Alt+A`). 
 2. **Configure** - Configuration dialog, setting the source xml files containing the code snippets.
 3. **Editor** - Code snippet editor. (Hotkey: `F4` from the Search dialog).

Each of these dialogs is accessible via the context menu of the CodeTag tray icon.

Search
------

To save you time you can access the Search dialog via a global shortcut (`Alt+A`). Then you can search the code snippets by entering the filtering tags. Use the `Up` and `Down` keys to navigate the resulting list of filtered code snippets. In case you want to edit a selected code snippet, just press the `F4` key and the Editor dialog will show up with the selected code snippet. If you press the `Enter` key, the web browser will be launched and the code snippet will be searched on the web. The Search dialog can be hidden by pressing the `Escape` key.

Configure
---------

In the Configure dialog you can define the code snippet sources, i.e., a list of xml files containing the tagged code snippets. In addition, you can also define the tag preprocessors and the tag matching algorithm. You can also set the CodeTag application to launch at startup.

Editor
------

In the Editor dialog you can easily open / edit / save the xml files representing the (hierarchies of) code snippets.

Layout
======

    CodeSnippets/
        Sample code snippets.

    CodeTag/
        C# source code of the CodeTag project.

    CodeTag/Tests/
        NUnit tests for the CodeTag project.

    packages/
        NuGet packages <http://www.nuget.org/>.

Donate
======

Bitcoin Address: `1DCE7HeEepXuMo4mytCqKGbxQZ6KQysqrU`

LICENSE
=======

The CodeTag project is licensed to you under MIT.X11:

Copyright (c) 2014 Peter Cerno.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.