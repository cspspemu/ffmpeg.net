GUIDELINESS & TIPS:

- Keep the original source, to be able, when upgrading, to see all the original changes.
- When implementing a module, create a .cs file with all the commented C code.
	- Remove C code while you are implementing it.
- Pointers can be replaced to arrays or to classes (a class is something like a pointer to an struct).
- Handle tabular data with shortcuts. Visual Studio supports ALT + left drag to select a text region. SHIFT + ALT + keys to select with keyboard.
- To be able to create compilable types, replace an undefined type with the "Unimplemented" class, and put the original declaration above in a comment. This will allow to update it later and will avoid errors.
- If a name is a reserved keyword on C#, put an underscore before: "base" -> "_base"