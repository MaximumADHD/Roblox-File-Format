namespace RobloxFiles.DataTypes
{
    // ContentId represents legacy Content properties which don't support object bindings.
    public class ContentId
    {
        public readonly string Url;

        public ContentId(string url)
        {
            Url = url;
        }

        public override int GetHashCode()
        {
            return Url.GetHashCode();
        }

        public override string ToString()
        {
            return Url;
        }

        public static implicit operator string(ContentId id)
        {
            return id.Url;
        }

        public static implicit operator ContentId(string url)
        {
            return new ContentId(url);
        }

        public static implicit operator Content(ContentId id)
        {
            return new Content(id.Url);
        }

        public static implicit operator ContentId(Content content)
        {
            if (content.SourceType == Enums.ContentSourceType.Uri)
                return content.Uri;

            return "";
        }
    }
}
