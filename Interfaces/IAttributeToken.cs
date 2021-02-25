namespace RobloxFiles
{
    public interface IAttributeToken<T>
    {
        AttributeType AttributeType { get; }

        T ReadAttribute(Attribute attribute);
        void WriteAttribute(Attribute attribute, T value);
    }
}
