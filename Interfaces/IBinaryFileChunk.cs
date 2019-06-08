namespace RobloxFiles.BinaryFormat
{
    public interface IBinaryFileChunk
    {
        void LoadFromReader(BinaryRobloxFileReader reader);
        BinaryRobloxFileChunk SaveAsChunk(BinaryRobloxFileWriter writer);
    }
}
