using HereAPI.Routing.TypesEnum;

namespace HereAPI.Routing.TypesResponse
{
    /// <summary>
    /// An incident describes a temporary event on a route. It typically refers to a real world
    /// incident (accident, road construction, etc.) spanning on one or several subsequent links.
    /// </summary>
    public class Incident
    {
        /// <summary>
        /// Time period when the incident is relevant
        /// </summary>
        public ValidityPeriod ValidityPeriod { get; set; }

        /// <summary>
        /// A textual description of the event
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Type of the incident, see IncidentTypeType for available options
        /// </summary>
        public IncidentType? Type { get; set; }

        /// <summary>
        /// Criticality on an integer scale
        /// </summary>
        public IncidentCriticailty Criticality { get; set; }

        /// <summary>
        /// Index into the global geometry array, pointing to the first point of the shape subsegment
        /// for the incident
        /// </summary>
        public int FirstPoint { get; set; }

        /// <summary>
        /// Index into the global geometry array, pointing to the last point of the shape subsegment
        /// for the incident
        /// </summary>
        public int LastPoint { get; set; }

        public enum IncidentCriticailty
        {
            Critical = 0,
            Major = 1,
            Minor = 2,
            LowImpact = 3
        }
    }
}