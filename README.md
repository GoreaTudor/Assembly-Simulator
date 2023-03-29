# Assembly-Simulator

## Language rules:

General line format:
```
    label: instruction operand_1, operand_2 # comment
```
where the label refers to the instruction labels (used to jump to instructions), not to be confused by data labels.

Operand Types:
```
    * reg  --  Register (General registers: A, B, C, D) (Special registers (cannot be used): Stack Pointer (SP), Instruction Pointer (IP))
    * nr   --  Number (12, 23, 0x2f, -43, 0b1101, nr1, nr2, 'A', 'b') ( where "nr1" and "nr2" are data labels, even characters are considered numbers by their ASCII code )
    * adr --  adress (\[123\], \[0x6f\], \[0b10010\], \[nr1\], \[nr2\], ~~ \['A'\] ~~) (Characters are not allowed here)
    * ptr  --  Pointer (adresses using general registers: \[A\], \[B\], \[C\], \[D\])
    * lbl  --  Label, can be an instruction label, or a data label
```

## Instruction Set:

0. Important Instructions:
    * HLT  --  Stopps the process. Has no parameters

1.  Memory Instructions:
    * MOV dest, src  --  Moves the data from src to dest.
        - MOV reg, nr
        - MOV reg, reg
        - MOV reg, ptr
        - MOV reg, adr
        - MOV ptr, nr
        - MOV ptr, reg
        - MOV adr, nr
        - MOV adr, reg

    * DB/DEF data, lbl*  --  Defines the initial data that will be used in the Runtime phase. The label is optional, and it creates a refference to the beginning of the data, also called data label. (A data label MUST be defined before it is used, unlike instruction labels that can be defined anywhere throughout the code)
        - DEF str, lbl
        - DEF str
        - DEF nr, lbl
        - DEF nr
        - DB str, lbl
        - DB str
        - DB nr, lbl
        - DB nr


2. Arithmetic Instructions:
    * ADD dest, src  --  Adds to src the value of the dest
        - ADD reg, nr
        - ADD reg, reg
        - ADD reg, ptr
        - ADD reg, adr
    
    * SUB dest, src  --  Subtracts from src the value of the dest
        - SUB reg, nr
        - SUB reg, reg
        - SUB reg, ptr
        - SUB reg, adr
    
    * MULT dest, src  --  Multiplies the src the value of the dest
        - MULT reg, nr
        - MULT reg, reg
        - MULT reg, ptr
        - MULT reg, adr
    
    * DIV dest, src  --  Divides the src with value of the dest and saves the quotient into src
        - DIV reg, nr
        - DIV reg, reg
        - DIV reg, ptr
        - DIV reg, adr
    
    * MOD dest, src  --  Divides the src the value of the dest and saves the remainder into src
        - MOD reg, nr
        - MOD reg, reg
        - MOD reg, ptr
        - MOD reg, adr
    
    * INC dest  --  Increments the value of dest with 1
        - INC reg
 
    * DEC dest  --  Decrements the value of dest with 1
        - DEC reg

    * NEG dest  --  Changes the sign of dest
        - NEG reg


3. Logic Instructions:
    * AND dest, src  --  And operation to src with dest
        - AND reg, nr
        - AND reg, reg
        - AND reg, ptr
        - AND reg, adr
    
    * OR dest, src  --  Or operation to src with dest
        - OR reg, nr
        - OR reg, reg
        - OR reg, ptr
        - OR reg, adr
    
    * XOR dest, src  --  Xor operation to src with dest
        - XOR reg, nr
        - XOR reg, reg
        - XOR reg, ptr
        - XOR reg, adr
    
    * NOT dest  --  Inverses the bits of the dest
        - NOT reg


4. Branch Instructions (The labels here represent instruction labels):
    * JMP dest  --  Jumps to a specific instruction label
        - JMP lbl

    * JZ/BZ src, dest  --  Jumps to dest, if src is zero
        - JZ reg, lbl
        - BZ reg, lbl

    * JNZ/BNZ src, dest  --  Jumps to dest, if src is not zero
        - JNZ reg, lbl
        - BNZ reg, lbl

    * JLZ/BLZ src, dest  --  Jumps to dest, if src is less than zero
        - JLZ reg, lbl
        - BLZ reg, lbl

    * JLEZ/BLEZ src, dest  --  Jumps to dest, if src is less than or equal to zero
        - JLEZ reg, lbl
        - BLEZ reg, lbl

    * JGZ/BGZ src, dest  --  Jumps to dest, if src is greater than zero
        - JGZ reg, lbl
        - BGZ reg, lbl

    * JGEZ/BGEZ src, dest  --  Jumps to dest, if src is greater than or equal to zero
        - JGEZ reg, lbl
        - BGEZ reg, lbl

    
5. Set Instructions:
    * SZ src, dest  --  Sets dest to 1, if src is zero, otherwise sets dest to 0
        - SZ reg, reg

    * SNZ src, dest  --  Sets dest to 1, if src is not zero, otherwise sets dest to 0
        - SNZ reg, reg

    * SLZ src, dest  --  Sets dest to 1, if src is less than zero, otherwise sets dest to 0
        - SLZ reg, reg

    * SLEZ src, dest  --  Sets dest to 1, if src is less than or equal to zero, otherwise sets dest to 0
        - SLEZ reg, reg

    * SGZ src, dest  --  Sets dest to 1, if src is greater than zero, otherwise sets dest to 0
        - SGZ reg, reg

    * SGEZ src, dest  --  Sets dest to 1, if src is greater than or equal to zero, otherwise sets dest to 0
        - SGEZ reg, reg


6. Shift Instructions:
    * SHL dest  --  Shifts with 1 position to the left the contents of the dest
        - SHL reg

    * SHR dest  --  Shifts with 1 position to the right the contents of the dest
        - SHR reg


7. Stack & Function Instructions:
    * PUSH src  --  Pushes the value of the src to the stack
        - PUSH nr
        - PUSH reg
        - PUSH ptr
        - PUSH adr

    * POP dest/src  --  Pops the last value(s) from the stack
        - POP reg  --  pops the stack into the reg (dest)
        - POP nr  --  pops the stack **n** times

    * STR dest, src  --  Reads into dest the value from the stack at position \[SP-src\]
        - STR reg, nr
        - STR reg, reg

    * STW dest, src  --  Writes from dest the value into the stack at position \[SP-src\]
        - STW reg, nr
        - STW reg, reg

    * CALL lbl  --  Pushes into the stack the next instruction adress, then jumps to the label
        - CALL lbl

    * RET  --  Pops the stack and returns to the adress given by the poped value. Has no parameters
        - RET

8. IO Instructions:
    * INP dest  --  Reads the next character from the input and saves it's ASCII value into dest
        - INP reg

    * OUTD src  --  Prints the decimal value of the src 
        - OUTD nr
        - OUTD reg

    * OUTC src  --  Prints the character with the ASCII code of src 
        - OUTC nr
        - OUTC reg

    * OUTB src  --  Prints the binary value of the src 
        - OUTB nr
        - OUTB reg

    * OUTH src  --  Prints the hexadecimal value of the src 
        - OUTH nr
        - OUTH reg
