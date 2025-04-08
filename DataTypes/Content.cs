using RobloxFiles.Enums;
using System;

namespace RobloxFiles.DataTypes
{
    public class Content
    {
        public readonly string Uri;
        public readonly ContentSourceType SourceType;
        public static readonly Content None = new Content();

        public RbxObject Object { get; internal set; }
        internal readonly string RefId = "";

        public Content()
        {
            SourceType = ContentSourceType.None;
        }

        public Content(string uri)
        {
            Uri = uri;
            SourceType = ContentSourceType.Uri;
        }

        public Content(RbxObject obj)
        {
            if (obj is Instance)
            {
                SourceType = ContentSourceType.None;
            }
            else
            {
                Object = obj;
                SourceType = ContentSourceType.Object;
            }
        }

        internal Content(RobloxFile file, string refId)
        {
            SourceType = ContentSourceType.Object;
            RefId = refId;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Content content))
                return false;

            if (SourceType != content.SourceType)
                return false;
            else if (SourceType == ContentSourceType.None)
                return true;
            else if (SourceType == ContentSourceType.Uri)
                return Uri?.Equals(content.Uri) ?? false;

            return Object?.Equals(content.Object) ?? false;
        }

        public override int GetHashCode()
        {
            if (SourceType == ContentSourceType.None)
                return 0;
            else if (SourceType == ContentSourceType.Uri)
                return Uri.GetHashCode();

            return Object.GetHashCode();
        }
    }
}
