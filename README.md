# Opus
The best bytecode in the world

Virtual buffers
Multifunctional buffers :

BF1 - Buffer 1
BF2 - Buffer 2
AC - Accumulator

Function argument buffers :

AR1 - Argument 1 of function
AR2 - Argument 2 of function
AR3 - Argument 3 of function
AR4 - Argument 4 of function
AR5 - Argument 5 of function

O - Output buffer

Instructions list

Ix00000000 - Do nothing
Ix00000001 [v] - Load value v into next function argument buffer
Ix00000002 - Reset numeration of function argument buffer
Ix00000003 [v] - Load value v into next multifunctional buffer


Ix00000006 [v] - Push value v on top of the stack
Ix00000007 - Pop value from stack
Ix00000008 - Pop value from stack into next mulifunctional buffer
Ix00000009 - Pop value from stack into next function argument buffer
Ix00000010 - Load value from multifunctional AC
Ix0000000A - Load value from output buffer into stack 
Ix0000000B - Load value from output buffer into next mulifunctional buffer
Ix0000000C - Set call agreement
Ix0000000D - Load value from output buffer into next function argument buffer
Ix0000000E [n] - Load function argument n on top of the stack
Ix0000000F [n] - Load function argument n into next mulifunctional buffer
Ix00000010 [n] - Load function argument n into next function argument buffer
Ix00000011 [n] - Create 1 or n byte variable into stack 
Ix00000012 [n] [v] - Set value v to variable n
