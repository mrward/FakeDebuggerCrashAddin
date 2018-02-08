Simulates a debug session exception whilst debugging.

Adds a Generate Fake Debug Session Crash menu to the Run menu.

To use:

When the Generate Fake Debug Session Crash menu is clicked the active debug session
will be found and then its ExceptionHandler will be called. This should then result
in a dialog being shown by the debugger service.

Simple way to use:

 1. Create a C# console project.
 2. Put a breakpoint in the Main method in Program.cs
 3. Build and then run the application under the debugger.
 4. When the breakpoint is hit select Run - Generate Fake Debug Session Crash
 5. Debugger operation failed dialog should then be displayed.

Note that the debug session will not be terminated.
