using System;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;

namespace Nez.Tiled
{
    public class TmxBase64Data
    {
        public Stream Data { get; private set; }

        public TmxBase64Data(XElement xData)
        {
            if ((string)xData.Attribute("encoding") != "base64")
                throw new Exception("TmxBase64Data: Only Base64-encoded data is supported.");

            var rawData = Convert.FromBase64String((string)xData.Value);
            Data = new MemoryStream(rawData, false);

            var compression = (string)xData.Attribute("compression");
            if (compression == "gzip")
            {
                Data = new GZipStream(Data, CompressionMode.Decompress);
            }
            else if (compression == "zlib")
            {
                // Strip 2-byte header and 4-byte checksum
                // TODO: Validate header here
                var bodyLength = rawData.Length - 6;
                var bodyData = new byte[bodyLength];
                Array.Copy(rawData, 2, bodyData, 0, bodyLength);

                var bodyStream = new MemoryStream(bodyData, false);
                Data = new DeflateStream(bodyStream, CompressionMode.Decompress);

                // TODO: Validate checksum?
            }
            else if (compression != null)
            {
                throw new Exception("TmxBase64Data: Unknown compression.");
            }
        }
    }
}