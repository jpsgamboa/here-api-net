namespace HereAPI.Shared.TypeObjects
{
    public class KeyValuePair
    {
        public string Key { get; set; }
        public string Pair { get; set; }

        public KeyValuePair(string key, string pair)
        {
            Key = key;
            Pair = pair;
        }
    }
}