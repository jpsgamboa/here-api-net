namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// Reference to the route section defined by the first and last shape point index of the route.
    /// </summary>
    public class RouteShapeReference
    {
        /// <summary>
        /// Index into the global geometry array, pointing to the first shape point of the route section.
        /// </summary>
        public int FirstPoint { get; set; }

        /// <summary>
        /// Index into the global geometry array, pointing to the last shape point of the route section.
        /// </summary>
        public int LastPoint { get; set; }
    }
}