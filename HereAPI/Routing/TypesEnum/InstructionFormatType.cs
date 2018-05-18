using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Representation formats for instruction texts.<para/>
    /// </summary>
    public enum InstructionFormatType
    {
        /// <summary>
        /// Returns the instruction as a plain text string
        /// </summary>
        [Description("text")] Text,

        /// <summary>
        /// Instruction format is based on span tags with different CSS classes to assign semantics to the tagged part of the instruction.
        /// </summary>
        [Description("html")] HTML,
    }
}
