﻿public enum InstructionSet
{
    // Arithmetic Instructions
    ADD,
    ADDI,
    ADDU,
    ADDIU,
    SUB,
    SUBU,
    MUL,
    MULT,
    DIV,
    DIVU,

    // Logical Instructions
    AND,
    ANDI,
    OR,
    ORI,
    XOR,
    XORI,
    NOT,

    // Shift Instructions
    SLL,
    SRL,
    SRA,
    ROL,
    ROR,

    // Comparison Instructions
    SLT,
    SLTI,
    SLE,
    SGE,
    SEQ,
    SNE,

    // Memory Access Instructions
    LW,
    SW,
    LB,
    SB,
    LH,
    SH,
    LBU,
    LHU,
    LWL,
    LWR,
    SWL,
    SWR,
    LD,
    SD,
    ST,

    // Immediate and Address Manipulation
    LI,
    LUI,
    LA,

    // Floating Point Instructions
    ADD_S,
    ADD_D,
    SUB_S,
    SUB_D,
    MUL_S,
    MUL_D,
    DIV_S,
    DIV_D,
    MOV_S,
    MOV_D,
    ABS_S,
    ABS_D,
    CVT_S_W,
    CVT_S_D,
    CVT_D_W,
    CVT_D_S,

    // Jump and Branch Instructions
    J,
    JAL,
    JR,
    JALR,
    BEQ,
    BNE,
    BGEZ,
    BGTZ,
    BLEZ,
    BLTZ,
    BEQZ,
    BNEZ,
    BC1T,
    BC1F,
    BSR,
    BRA,
    GES,
    LES,
    BT,
    LTS,
    GTS,
    NE,
    EQ,


    // System and Exception Instructions
    SYSCALL,
    BREAK,
    NOP,
    RFE,

    // Coprocessor Transfer Instructions
    MFHI,
    MFLO,
    MTHI,
    MTLO,
    MFC0,
    MTC0,
    MFC1,
    MTC1,

    // Pseudoinstructions
    MOVE,
    MOV,
    CLEAR,
    NEG,
    NEGU,
    B,
    BAL,
    LI_S,
    LI_D,
    PRINT_INT,
    PRINT_STRING,
    PRINT_CHAR,
    PRINT_FLOAT,
    PRINT_DOUBLE,
    READ_INT,
    READ_STRING,
    READ_CHAR,
    READ_FLOAT,
    READ_DOUBLE,

    TRAP
}