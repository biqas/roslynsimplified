using System;

namespace BITS.Compilers.CSharp.Syntax
{
    /// <summary>
    /// Enum for all modifers
    /// </summary>
    [Flags]
    public enum MODIFIER
    {
        /// <summary>
        /// 
        /// </summary>
        NONE = 0x00000000,

        /// <summary>
        /// 
        /// </summary>
        PRIVATE = 0x00000001,

        /// <summary>
        /// 
        /// </summary>
        PROTECTED = 0x00000002,

        /// <summary>
        /// 
        /// </summary>
        INTERNAL = 0x0004,

        /// <summary>
        /// 
        /// </summary>
        PUBLIC = 0x00000008,

        /// <summary>
        /// 
        /// </summary>
        PARTIAL = 0x00000010,

        /// <summary>
        /// 
        /// </summary>
        SEALED = 0x00000020,

        /// <summary>
        /// 
        /// </summary>
        VIRTUAL = 0x00000040,

        /// <summary>
        /// 
        /// </summary>
        ABSTRACT = 0x0000080,

        /// <summary>
        /// 
        /// </summary>
        STATIC = 0x00000100,

        /// <summary>
        /// 
        /// </summary>
        READ_ONLY = 0x00000200,

        /// <summary>
        /// 
        /// </summary>
        CONST = 0x00000400,

        /// <summary>
        /// 
        /// </summary>
        FIXED = 0x00000800,

        /// <summary>
        /// 
        /// </summary>
        PARAMS = 0x00001000,

        /// <summary>
        /// 
        /// </summary>
        VOLATILE = 0x00002000,

        /// <summary>
        /// 
        /// </summary>
        IN = 0x00004000,

        /// <summary>
        /// 
        /// </summary>
        OUT = 0x00008000,

        /// <summary>
        /// 
        /// </summary>
        REF = 0x00010000,

        /// <summary>
        /// 
        /// </summary>
        EXTERN = 0x00020000,

        /// <summary>
        /// 
        /// </summary>
        OVERRIDE = 0x00040000,

        /// <summary>
        /// 
        /// </summary>
        NEW = 0x00080000,

        /// <summary>
        /// 
        /// </summary>
        PROTECTED_VIRTUAL = PROTECTED | VIRTUAL,

        /// <summary>
        /// 
        /// </summary>
        PUBLIC_STATIC = PUBLIC | STATIC,

        /// <summary>
        /// 
        /// </summary>
        PUBLIC_ABSTRACT = PUBLIC | ABSTRACT,

        /// <summary>
        /// 
        /// </summary>
        PUBLIC_CONST = PUBLIC | CONST,

        /// <summary>
        /// 
        /// </summary>
        PUBLIC_READ_ONLY = PUBLIC | READ_ONLY,

        /// <summary>
        /// 
        /// </summary>
        PUBLIC_READ_ONLY_STATIC = PUBLIC | READ_ONLY | STATIC,
    }
}
