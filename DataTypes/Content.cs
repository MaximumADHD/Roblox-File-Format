namespace RobloxFiles.DataTypes
{
    /// <summary>
    /// Content is a type used by most url-based XML properties.
    /// Here, it only exists as a wrapper class for strings.
    /// </summary>
    public class Content
    {
        // TODO: Maybe introduce constraints to the value?
        public readonly string Data;

        public override string ToString()
        {
            return Data;
        }

        public Content(string data)
        {
            Data = data;
        }

        public static implicit operator string(Content content)
        {
            return content.Data;
        }

        public static implicit operator Content(string data)
        {
            return new Content(data);
        }
    }
}
