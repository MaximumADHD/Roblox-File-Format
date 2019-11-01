namespace RobloxFiles.DataTypes
{
    /// <summary>
    /// Content is a type used by most url-based XML properties.
    /// Here, it only exists as a wrapper class for strings.
    /// </summary>
    public class Content
    {
        public readonly string Url;
        public override string ToString() => Url;

        public Content(string url)
        {
            Url = url;
        }

        public static implicit operator string(Content content)
        {
            return content.Url;
        }

        public static implicit operator Content(string url)
        {
            return new Content(url);
        }
    }
}
