namespace RobloxFiles.BinaryFormat
{
    public interface IBinaryFileChunk
    {
        void Load(BinaryRobloxFileReader reader);
        void Save(BinaryRobloxFileWriter writer);
    }
}
