using System;
using System.Text;

namespace RobloxFiles.BinaryFormat.Chunks
{
    public enum RbxSignatureType
    {
        Ed25519
    }

    public struct RbxSignature
    {
        public RbxSignatureType SignatureType;
        public long PublicKeyId;
        public byte[] Value;
    }

    public class SIGN : IBinaryFileChunk
    {
        public RbxSignature[] Signatures;

        public void Load(BinaryRobloxFileReader reader)
        {
            int numSignatures = reader.ReadInt32();
            Signatures = new RbxSignature[numSignatures];

            for (int i = 0; i < numSignatures; i++)
            {
                var signature = new RbxSignature
                {
                    SignatureType = (RbxSignatureType)reader.ReadInt32(),
                    PublicKeyId = reader.ReadInt64(),
                };

                var length = reader.ReadInt32();
                signature.Value = reader.ReadBytes(length);
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

                writer.Write((int)signature.SignatureType);
                writer.Write(signature.PublicKeyId);

                writer.Write(signature.Value.Length);
                writer.Write(signature.Value);
            }
        }

        public void WriteInfo(StringBuilder builder)
        {
            int numSignatures = Signatures.Length;
            builder.AppendLine($"NumSignatures: {numSignatures}");

            for (int i = 0; i < numSignatures; i++)
            {
                var signature = Signatures[i];
                builder.AppendLine($"## Signature {i}");

                var version = Enum.GetName(typeof(RbxSignatureType), signature.SignatureType);
                builder.AppendLine($"- SignatureType: {version}");

                var publicKeyId = signature.PublicKeyId;
                builder.AppendLine($"- PublicKeyId: {publicKeyId}");

                var value = Convert.ToBase64String(signature.Value);
                builder.AppendLine($"- Value: {value}");
            }
        }
    }
}
