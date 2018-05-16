using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    /// <summary>
    /// Representation formats for instruction texts.<para/>
    ///  text: returns the instruction as a plain text string;<para/>
    ///  html: instruction format is based on span tags with different CSS classes to assign semantics to the tagged part of the instruction.<para/>
    /// </summary>
    public enum InstructionFormatType
    {
        [Description("text")] Text,
        [Description("html")] HTML,
    }
}
