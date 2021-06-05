namespace RobloxFiles
{
    public interface IAttributeToken<T>
    {
        AttributeType AttributeType { get; }

        T ReadAttribute(RbxAttribute attribute);
        void WriteAttribute(RbxAttribute attribute, T value);
    }
}
