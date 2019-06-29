using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace RobloxFiles.DataTypes
{
    public class SharedString
    {
        private static Dictionary<string, byte[]> Records = new Dictionary<string, byte[]>();
        public readonly string MD5_Key;

        public byte[] SharedValue => FindRecord(MD5_Key);
        public override string ToString() => $"MD5 Key: {MD5_Key}";

        internal SharedString(string md5)
        {
            MD5_Key = md5;
        }

        private SharedString(byte[] buffer)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(buffer);
                MD5_Key = Convert.ToBase64String(hash);
            }

            if (Records.ContainsKey(MD5_Key))
                return;

            Records.Add(MD5_Key, buffer);
        }

        public static byte[] FindRecord(string key)
        {
            byte[] result = null;

            if (Records.ContainsKey(key))
                result = Records[key];

            return result;
        }

        public static SharedString FromBuffer(byte[] buffer)
        {
            return new SharedString(buffer);
        }

        public static SharedString FromString(string value)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(value);
            return new SharedString(buffer);
        }

        public static SharedString FromBase64(string base64)
        {
            byte[] buffer = Convert.FromBase64String(base64);
            return new SharedString(buffer);
        }
    }
}
