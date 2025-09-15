# Opus - The best bytecode in the world

### This language was developed as a Ciobanu Stanisalv's course work. Please enjoy coding :)

# Notice 
V2 Opus version is curently in development. You may check V1 by changing branch. It contains main functionality and is ready to run Hello World program

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
❌ Ix0000 - No operation
❌ Ix0001 [v] - Load value v into next function argument buffer
❌ Ix0002 - Reset numeration of function argument buffer
❌ Ix0003 [v] - Load value v into next multifunctional buffer
❌ Ix0006 [v] - Push value v on top of the stack
❌ Ix0007 - Pop value from stack
❌ Ix0008 - Pop value from stack into next mulifunctional buffer
❌ Ix0009 - Pop value from stack into next function argument buffer
❌ Ix0010 - Load value from multifunctional AC
❌ Ix000A - Load value from output buffer into stack 
❌ Ix000B - Load value from output buffer into next mulifunctional buffer
❌ Ix000C - Set call agreement
❌ Ix000D - Load value from output buffer into next function argument buffer
❌ Ix000E [n] - Load function argument n on top of the stack
❌ Ix000F [n] - Load function argument n into next mulifunctional buffer
❌ Ix0010 [n] - Load function argument n into next function argument buffer
❌ Ix0011 [n] - Create 1 or n byte variable into stack 
❌ Ix0012 [n] [v] - Set value v to variable n
```

### Directives

```
❌ call - Call function or procedure
❌ jmp - Jump to line
❌ extern - Define extern function
❌ ret - Return from function or procedure
❌ INT - Interrupt program exection (For simple debug)
```

### Code Sample 1:

```
[<EntryPoint>]

	Ix0001	-11                 - Load -11 in AR1 
	call GetStdHandle           - Call GetStdFunction. Result of operation is in O

	Ix0002                      - Reset AR buffer numeration

	Ix000D                      - Load O value in AR1 
	Ix0001	"Hello, World!"     - Load "Hello, World!" in AR2 
	Ix0001	13                  - Load 13 in AR3 
	
	call WriteConsoleA          - Call WriteConsole
	
	ret                         - Return
```

### Code Sample 2:

```
[<EntryPoint>]

	call Print

	ret

[<Print>]

	Ix0001	-11
	call GetStdHandle

	Ix0002

	Ix000D
	Ix0001	"Print function executed successfully"
	Ix0001	36
	
	call WriteConsoleA
	
	ret
```


# Opus Assembly

### Code Sample 1:

```
[<EntryPoint>]

	LOAD		-11                 	- Load -11 in AR1 
	call 		GetStdHandle            - Call GetStdFunction. Result of operation is in O

	RESET                      			- Reset AR buffer numeration

	LOAD_OUT 	 				    	- Load O value in AR1 
	LOAD 		"Hello, World!" 	    - Load "Hello, World!" in AR2 
	LOAD 		13                 		- Load 13 in AR3 
	
	call 		WriteConsoleA           - Call WriteConsole
	
	ret                             	- Return
```