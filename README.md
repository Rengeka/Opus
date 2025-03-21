# Opus - The best bytecode in the world

### This language was developed as a Ciobanu Stanisalv's course work. Please enjoy coding :)

### Virtual buffers


Multifunctional buffers :

```
BF1 - Buffer 1
BF2 - Buffer 2
AC - Accumulator
```

### Function argument buffers :

```
AR1 - Argument 1 of function
...
ARN - Argument N of function
```

```
O - Output buffer
```

### Instructions list

```
Implemented and ready to use - ✅
Not implemented yet - ❌
Implemented, but didn't pass all the tests - ❔
```

```
✅ Ix00000000 - No operation
✅ Ix00000001 [v] - Load value v into next function argument buffer
✅ Ix00000002 - Reset numeration of function argument buffer
✅ Ix00000003 [v] - Load value v into next multifunctional buffer


❌ Ix00000006 [v] - Push value v on top of the stack
❌ Ix00000007 - Pop value from stack
❌ Ix00000008 - Pop value from stack into next mulifunctional buffer
❌ Ix00000009 - Pop value from stack into next function argument buffer
❌ Ix00000010 - Load value from multifunctional AC
❌ Ix0000000A - Load value from output buffer into stack 
❌ Ix0000000B - Load value from output buffer into next mulifunctional buffer
❌ Ix0000000C - Set call agreement
✅ Ix0000000D - Load value from output buffer into next function argument buffer
❌ Ix0000000E [n] - Load function argument n on top of the stack
❌ Ix0000000F [n] - Load function argument n into next mulifunctional buffer
❌ Ix00000010 [n] - Load function argument n into next function argument buffer
❔  Ix00000011 [n] - Create 1 or n byte variable into stack 
❔  Ix00000012 [n] [v] - Set value v to variable n
```

### Directives

```
✅ call - Call function or procedure
❌ jmp - Jump to line
❌ extern - Define extern function
✅ ret - Return from function or procedure
✅ INT - Interrupt program exection (For simple debug)
```

### Code Sample 1:

```
[<EntryPoint>]

	Ix00000001	-11                 - Load -11 in AR1 
	call GetStdHandle               - Call GetStdFunction. Result of operation is in O

	Ix00000002                      - Reset AR buffer numeration

	Ix0000000D                      - Load O value in AR1 
	Ix00000001	"Hello, World!"     - Load "Hello, World!" in AR2 
	Ix00000001	13                  - Load 13 in AR3 
	
	call WriteConsoleA              - Call WriteConsole
	
	ret                             - Return
```

### Code Sample 2:

```
[<EntryPoint>]

	call Print

	ret

[<Print>]

	Ix00000001	-11
	call GetStdHandle

	Ix00000002

	Ix0000000D
	Ix00000001	"Print function executed successfully"
	Ix00000001	36
	
	call WriteConsoleA
	
	ret
```
