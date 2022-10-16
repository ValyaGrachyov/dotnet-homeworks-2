.class public abstract sealed auto ansi beforefieldinit
  Hw2.Parser
{
.method public hidebysig static void
    ParseCalcArguments(
      string[] args,
      [out] float64& val1,
      [out] valuetype Hw2.CalculatorOperation operation,
      [out] float64& val2
    ) cil managed
  {
    .custom instance void System.Runtime.CompilerServices.NullableContextAttribute::.ctor([in] unsigned int8)
      = (01 00 01 00 00 ) 
      
    .maxstack 2
    .locals init (
      [0] bool V_0,
      [1] bool V_1,
      [2] bool V_2,
      [3] bool V_3,
      [4] bool V_4,
      [5] bool V_5,
      [6] bool V_6
    )

    
    IL_0000: nop

    
    IL_0001: ldarg.0      // args
    IL_0002: ldc.i4.0
    IL_0003: ldelem.ref
    IL_0004: ldarg.1      // val1
    IL_0005: call         bool [System.Runtime]System.Double::TryParse(string, float64&)
    IL_000a: ldc.i4.0
    IL_000b: ceq
    IL_000d: stloc.0      

    IL_000e: ldloc.0      
    IL_000f: brfalse.s    IL_0018

    
    IL_0011: nop

    
    IL_0012: newobj       instance void [System.Runtime]System.ArgumentException::.ctor()
    IL_0017: throw

    
    IL_0018: ldarg.0      // args
    IL_0019: ldc.i4.2
    IL_001a: ldelem.ref
    IL_001b: ldarg.3      // val2
    IL_001c: call         bool [System.Runtime]System.Double::TryParse(string, float64&)
    IL_0021: ldc.i4.0
    IL_0022: ceq
    IL_0024: stloc.1      

    IL_0025: ldloc.1      
    IL_0026: brfalse.s    IL_002f

    
    IL_0028: nop

    
    IL_0029: newobj       instance void [System.Runtime]System.ArgumentException::.ctor()
    IL_002e: throw

    
    IL_002f: ldarg.0      // args
    IL_0030: ldlen
    IL_0031: conv.i4
    IL_0032: ldc.i4.3
    IL_0033: cgt
    IL_0035: stloc.2      

    IL_0036: ldloc.2      
    IL_0037: brfalse.s    IL_0040

    
    IL_0039: nop

    
    IL_003a: newobj       instance void [System.Runtime]System.ArgumentException::.ctor()
    IL_003f: throw

    
    IL_0040: ldarg.0      // args
    IL_0041: ldc.i4.1
    IL_0042: ldelem.ref
    IL_0043: ldstr        "+"
    IL_0048: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_004d: stloc.3      

    IL_004e: ldloc.3      
    IL_004f: brfalse.s    IL_0058

    
    IL_0051: nop

    
    IL_0052: ldarg.2      // operation
    IL_0053: ldc.i4.0
    IL_0054: stind.i4

    
    IL_0055: nop

    IL_0056: br.s         IL_00b0

    
    IL_0058: ldarg.0      // args
    IL_0059: ldc.i4.1
    IL_005a: ldelem.ref
    IL_005b: ldstr        "-"
    IL_0060: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0065: stloc.s      V_4

    IL_0067: ldloc.s      V_4
    IL_0069: brfalse.s    IL_0072

    
    IL_006b: nop

    
    IL_006c: ldarg.2      // operation
    IL_006d: ldc.i4.1
    IL_006e: stind.i4

    
    IL_006f: nop

    IL_0070: br.s         IL_00b0

    
    IL_0072: ldarg.0      // args
    IL_0073: ldc.i4.1
    IL_0074: ldelem.ref
    IL_0075: ldstr        "*"
    IL_007a: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_007f: stloc.s      V_5

    IL_0081: ldloc.s      V_5
    IL_0083: brfalse.s    IL_008c

    
    IL_0085: nop

    
    IL_0086: ldarg.2      // operation
    IL_0087: ldc.i4.2
    IL_0088: stind.i4

    
    IL_0089: nop

    IL_008a: br.s         IL_00b0

    
    IL_008c: ldarg.0      // args
    IL_008d: ldc.i4.1
    IL_008e: ldelem.ref
    IL_008f: ldstr        "/"
    IL_0094: call         bool [System.Runtime]System.String::op_Equality(string, string)
    IL_0099: stloc.s      V_6

    IL_009b: ldloc.s      V_6
    IL_009d: brfalse.s    IL_00a6

    
    IL_009f: nop

    
    IL_00a0: ldarg.2      // operation
    IL_00a1: ldc.i4.3
    IL_00a2: stind.i4

    
    IL_00a3: nop

    IL_00a4: br.s         IL_00b0

    
    IL_00a6: nop

    
    IL_00a7: ldarg.2      // operation
    IL_00a8: ldc.i4.4
    IL_00a9: stind.i4

    
    IL_00aa: newobj       instance void [System.Runtime]System.InvalidOperationException::.ctor()
    IL_00af: throw

    
    IL_00b0: ret
}
}


