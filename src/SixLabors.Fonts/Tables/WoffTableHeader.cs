// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using System.IO;

namespace SixLabors.Fonts.Tables
{
    internal sealed class WoffTableHeader : TableHeader
    {
        public WoffTableHeader(string tag, uint offset, uint compressedLength, uint origLength, uint checkSum)
            : base(tag, checkSum, offset, origLength)
            => this.CompressedLength = compressedLength;

        public uint CompressedLength { get; }

        public override BigEndianBinaryReader CreateReader(Stream stream)
        {
            // not compressed use uncompress
            if (this.Length == this.CompressedLength)
            {
                return base.CreateReader(stream);
            }
            else
            {
                stream.Seek(this.Offset, SeekOrigin.Begin);
                var compressedStream = new IO.ZlibInflateStream(stream);
                return new BigEndianBinaryReader(compressedStream, false);
            }
        }

        // WOFF TableDirectoryEntry
        // UInt32 | tag          | 4-byte sfnt table identifier.
        // UInt32 | offset       | Offset to the data, from beginning of WOFF file.
        // UInt32 | compLength   | Length of the compressed data, excluding padding.
        // UInt32 | origLength   | Length of the uncompressed table, excluding padding.
        // UInt32 | origChecksum | Checksum of the uncompressed table.
        public static new WoffTableHeader Read(BigEndianBinaryReader reader) =>
            new WoffTableHeader(
                reader.ReadTag(),
                reader.ReadUInt32(),
                reader.ReadUInt32(),
                reader.ReadUInt32(),
                reader.ReadUInt32());
    }
}
