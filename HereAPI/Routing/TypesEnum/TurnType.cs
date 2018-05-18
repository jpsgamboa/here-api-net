using System.ComponentModel;

namespace HereAPI.Routing.TypesEnum
{
    public partial class EnumTypes
    {
        /// <summary>
        /// Type of the turn.
        /// </summary>
        public enum TurnType
        {
            /// <summary>
            /// A potentially difficult sharp turn of turning radius that might be too short for
            /// certain vehicles.
            /// </summary>
            [Description("difficult")] Difficult,
        }
    }
}