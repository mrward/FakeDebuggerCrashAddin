//
// GenerateFakeDebugSessionCrashHandler.cs
//
// Author:
//       Matt Ward <matt.ward@microsoft.com>
//
// Copyright (c) 2018 Microsoft
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
using MonoDevelop.Components.Commands;
using MonoDevelop.Debugger;
using MonoDevelop.Ide;

namespace FakeDebuggerCrashAddin
{
	class GenerateFakeDebugSessionCrashHandler : CommandHandler
	{
		protected override void Run ()
		{
			try {
				RunInternal ();
			} catch (Exception ex) {
				MessageService.ShowError ("Error trying to fake debug session crash.", ex);
			}
		}

		void RunInternal ()
		{
			var currentSession = DebuggingService.DebuggerSession;
			if (currentSession == null) {
				MessageService.ShowMessage ("No active debugger session to crash.");
				return;
			}

			var sessions = DebuggingService.GetSessions ();
			if (sessions.Length > 1) {
				for (int i = 0; i < sessions.Length; ++i) {
					var session = sessions [i];
					var exception = new ApplicationException (string.Format ("Fake debug session crash {0}", i));
					session.ExceptionHandler (exception);
				}
			} else {
				var exception = new ApplicationException ("Fake debug session crash");
				currentSession.ExceptionHandler (exception);
			}
		}
	}
}
