namespace RobloxFiles.BinaryFormat.Chunks
{
    public struct Signature
    {
        public int Version;
        public long Id;

        public int Length;
        public byte[] Data;
    }

    public class SIGN : IBinaryFileChunk
    {
        public Signature[] Signatures;

        public void Load(BinaryRobloxFileReader reader)
        {
            int numSignatures = reader.ReadInt32();
            Signatures = new Signature[numSignatures];

            for (int i = 0; i < numSignatures; i++)
            {
                var signature = new Signature
                {
                    Version = reader.ReadInt32(),
                    Id = reader.ReadInt64(),

                    Length = reader.ReadInt32(),
                };

                signature.Data = reader.ReadBytes(signature.Length);
                Signatures[i] = signature;
            }

            var file = reader.File;
            file.SIGN = this;
        }

        public void Save(BinaryRobloxFileWriter writer)
        {
            writer.Write(Signatures.Length);

            for (int i = 0; i < Signatures.Length; i++)
            {
                var signature = Signatures[i];
                signature.Length = signature.Data.Length;

                writer.Write(signature.Version);
                writer.Write(signature.Id);

                writer.Write(signature.Length);
                writer.Write(signature.Data);
            }
        }
    }
}
