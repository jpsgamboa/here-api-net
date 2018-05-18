namespace HereAPI.Shared.Structure
{
    /// <summary>
    /// Requires attributes whose name is part of the request URL to have a method to return that name
    /// </summary>
    public interface IRequestAttribute : IAttribute
    {
        string GetAttributeName();
    }
}