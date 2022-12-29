using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeAnThucTap
{
    internal class SHA1_Demo
    {
        public static uint LeftRotate(uint x, int c)
        {
            return (x << c) | (x >> (32 - c));
        }

        public static string Hash_SHA1(string message)
        {
            //process message
            byte[] bytes = ProcMessage(message);
            //padding message
            byte[] processedMessage = PadMessage(bytes);
            //hashing message
            string digestmessage = HashMessage(processedMessage);
            return digestmessage;
        }

        // process message
        public static byte[] ProcMessage(string message)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            //foreach(byte b in bytes) { Console.WriteLine(b); }
            return bytes;
        }

        // padding message
        public static byte[] PadMessage(byte[] bytes)
        {
            var processedMessageBuilder = new List<byte>(bytes) { 0x80 };
            while (processedMessageBuilder.Count % 64 != 56) processedMessageBuilder.Add(0x0);
            processedMessageBuilder.AddRange(BitConverter.GetBytes((long)bytes.Length * 8)); // bit converter returns little-endian
            var processedMessage = processedMessageBuilder.ToArray();

            byte[] length = BitConverter.GetBytes(bytes.Length * 8); // bit converter returns little-endian
            Array.Copy(length, 0, processedMessage, processedMessage.Length - 8, 4); // add length in bits



            //foreach(byte x in processedMessage) { Console.WriteLine(GetByteString(x)); }
            return processedMessage;
        }

        // Hashing message
        public static string HashMessage(byte[] processedMessage)
        {
            uint h0 = 0x67452301;   //A
            uint h1 = 0xEFCDAB89;   //B
            uint h2 = 0x98BADCFE;   //C
            uint h3 = 0x10325476;   //D
            uint h4 = 0xC3D2E1F0;   //E

            for (int i = 0; i < processedMessage.Length / 64; ++i)
            {
                // copy the input to W
                uint[] W = new uint[80];
                for (int j = 0; j < 16; ++j)
                    W[j] = BitConverter.ToUInt32(processedMessage, (i * 64) + (j * 4));
                for (int j = 16; j < 79; ++j)
                    W[j] = LeftRotate((W[j - 3] ^ W[j - 8] ^ W[j - 14] ^ W[j - 16]), 1);
                //foreach(uint x in W) { DebugString(x); }
                // initialize round variables
                uint A = h0, B = h1, C = h2, D = h3, E = h4, F = 0, g = 0;
                // primary loop
                for (uint k = 0; k < 79; ++k)
                {
                    if (k <= 19)
                    {
                        F = (B & C) ^ (~B & D);
                        g = 0x5A827999;
                    }
                    else if (k >= 20 && k <= 39)
                    {
                        F = B ^ C ^ D;
                        g = 0x6ED9EBA1;
                    }
                    else if (k >= 40 && k <= 59)
                    {
                        F = (B & C) ^ (B & D) ^ (C & D);
                        g = 0x8F1BBCDC;
                    }
                    else if (k >= 60)
                    {
                        F = B ^ C ^ D;
                        g = 0xCA62C1D6;
                    }
                    var temp = LeftRotate(A, 5) + F + E + g + W[i];
                    E = D;
                    D = C;
                    C = LeftRotate(B, 30);
                    B = A;
                    A = temp;
                }
                h0 += A;
                h1 += B;
                h2 += C;
                h3 += D;
                h4 += E;
            }

            //var hh = LeftRotate(h0, 128) | LeftRotate(h1, 96) | LeftRotate(h2, 64) | LeftRotate(h3, 32) | h4;
            
            //return GetByteString(a0) + GetByteString(b0) + GetByteString(c0) + GetByteString(d0);
            //return GetByteString(hh);

            //return GetByteString(h4) + GetByteString(h3) + GetByteString(h2) + GetByteString(h1) + GetByteString(h0);
            return GetByteString(h0) + GetByteString(h1) + GetByteString(h2) + GetByteString(h3) + GetByteString(h4);
        }

        private static string GetByteString(uint x)
        {
            return String.Join("", BitConverter.GetBytes(x).Select(y => y.ToString("x2")));
        }
        private static void DebugString(uint x)
        {
            string s = String.Join("", BitConverter.GetBytes(x).Select(y => y.ToString("x2")));
            Console.WriteLine(s);
        }

    }
}
