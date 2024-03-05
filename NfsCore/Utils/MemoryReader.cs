using System;
using System.IO;
using System.Runtime.InteropServices;



namespace NfsCore.Utils
{
	public unsafe class MemoryReader
	{
		private byte[] stream;
		public int Position { get; set; }
		public int Length { get => stream.Length; }

		public MemoryReader() { }
		public MemoryReader(byte[] array)
		{
			SetStream(array);
		}
		public MemoryReader(byte* byteptr_t, int count)
		{
			SetStream(byteptr_t, count);
		}
		public MemoryReader(byte* byteptr_t, int offset, int count)
		{
			SetStream(byteptr_t, offset, count);
		}
		public MemoryReader(string filename)
		{
			SetStream(filename);
		}
		public MemoryReader(IntPtr dataptr_t, int count)
		{
			SetStream(dataptr_t, count);
		}
		public MemoryReader(IntPtr dataptr_t, int offset, int count)
		{
			SetStream(dataptr_t, offset, count);
		}

		/// <summary>
		/// Sets memory array to be read from.
		/// </summary>
		/// <param name="array">Byte array to be read.</param>
		public void SetStream(byte[] array)
		{
			stream = array;
			Position = 0;
		}
		/// <summary>
		/// Sets memory array to be read from.
		/// </summary>
		/// <param name="byteptr_t">Pointer to the block of memory.</param>
		/// <param name="count">Length of the memory to be read.</param>
		public void SetStream(byte* byteptr_t, int count)
		{
			stream = new byte[count];
			fixed (byte* dataptr_t = &stream[0])
			{
				for (int a1 = 0; a1 < count; ++a1)
					*(dataptr_t + a1) = *(byteptr_t + a1);
			}
			Position = 0;
		}
		/// <summary>
		/// Sets memory array to be read from.
		/// </summary>
		/// <param name="byteptr_t">Pointer to the block of memory.</param>
		/// <param name="offset">Offset in memory from pointer provided.</param>
		/// <param name="count">Length of the memory to be read.</param>
		public void SetStream(byte* byteptr_t, int offset, int count)
		{
			stream = new byte[count];
			fixed (byte* dataptr_t = &stream[0])
			{
				for (int a1 = 0; a1 < count; ++a1)
					*(dataptr_t + a1) = *(byteptr_t + offset + a1);
			}
			Position = 0;
		}
		/// <summary>
		/// Sets memory array to be read from.
		/// </summary>
		/// <param name="filename">Filename from which read the data through.</param>
		public void SetStream(string filename)
		{
			stream = File.ReadAllBytes(filename);
			Position = 0;
		}
		/// <summary>
		/// Sets memory array to be read from.
		/// </summary>
		/// <param name="dataptr_t">Pointer to the block of memory.</param>
		/// <param name="count">Length of the memory to be read.</param>
		public void SetStream(IntPtr dataptr_t, int count)
		{
			SetStream((byte*)dataptr_t, count);
		}
		/// <summary>
		/// Sets memory array to be read from.
		/// </summary>
		/// <param name="dataptr_t">Pointer to the block of memory.</param>
		/// <param name="offset">Offset in memory from pointer provided.</param>
		/// <param name="count">Length of the memory to be read.</param>
		public void SetStream(IntPtr dataptr_t, int offset, int count)
		{
			SetStream((byte*)dataptr_t, offset, count);
		}

		/// <summary>
		/// Reads a Boolean value from the current stream and advances the current position 
		/// of the stream by one byte.
		/// </summary>
		/// <returns>True if the byte is nonzero; otherwise, false.</returns>
		public bool ReadBoolean()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				bool result = *dataptr_t == 0 ? false : true;
				Position += sizeof(bool);
				return result;
			}
		}
		/// <summary>
		/// Reads the next byte from the current stream and advances the current position 
		/// of the stream by one byte.
		/// </summary>
		/// <returns>The next byte read from the current stream.</returns>
		public byte ReadByte()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				byte result = *dataptr_t;
				Position += sizeof(byte);
				return result;
			}
		}
		/// <summary>
		/// Reads the specified number of bytes from the current stream into a byte array 
		/// and advances the current position by that number of bytes.
		/// </summary>
		/// <param name="count">The number of bytes to read.</param>
		/// <returns>A byte array containing data read from the underlying stream. This might be less 
		/// than the number of bytes requested if the end of the stream is reached.</returns>
		public byte[] ReadBytes(int count)
		{
			if (count <= 0) return null;
			byte[] result = new byte[count];
			fixed (byte* dataptr_t = &stream[Position], resptr_t = &result[0])
			{
				for (int a1 = 0; a1 < count; ++a1)
					*(resptr_t + a1) = *(dataptr_t + a1);
				Position += sizeof(byte) * count;
				return result;
			}
		}
		/// <summary>
		/// Reads the next character from the current stream and advances the current position 
		/// of the stream in accordance with the Encoding used and the specific character 
		/// being read from the stream.
		/// </summary>
		/// <returns>A character read from the current stream.</returns>
		public char ReadChar()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				char result = *(char*)dataptr_t;
				Position += sizeof(char);
				return result;
			}
		}
		/// <summary>
		/// Reads the specified number of characters from the current stream, returns the 
		/// data in a character array, and advances the current position in accordance with 
		/// the Encoding used and the specific character being read from the stream.
		/// </summary>
		/// <param name="count">The number of characters to read.</param>
		/// <returns>A character array containing data read from the underlying stream. This might 
		/// be less than the number of characters requested if the end of the stream is reached.</returns>
		public char[] ReadChars(int count)
		{
			if (count <= 0) return null;
			char[] result = new char[count];
			fixed (byte* dataptr_t = &stream[Position])
			{
				fixed (char* resptr_t = &result[0])
				{
					for (int a1 = 0; a1 < count; ++a1)
						*(resptr_t + a1) = *(char*)(dataptr_t + a1 * sizeof(char));
				}
				Position += sizeof(char) * count;
				return result;
			}
		}
		/// <summary>
		/// Reads a signed byte from this stream and advances the current position of the 
		/// stream by one byte.
		/// </summary>
		/// <returns>A signed byte read from the current stream.</returns>
		public sbyte ReadSByte()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				sbyte result = *(sbyte*)dataptr_t;
				Position += sizeof(sbyte);
				return result;
			}
		}
		/// <summary>
		/// Reads a 2-byte signed integer from the current stream and advances the current 
		/// position of the stream by two bytes.
		/// </summary>
		/// <returns>A 2-byte signed integer read from the current stream.</returns>
		public short ReadInt16()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				short result = *(short*)dataptr_t;
				Position += sizeof(short);
				return result;
			}
		}
		/// <summary>
		/// Reads a 2-byte unsigned integer from the current stream and advances the position 
		/// of the stream by two bytes.
		/// </summary>
		/// <returns>A 2-byte unsigned integer read from this stream.</returns>
		public ushort ReadUInt16()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				ushort result = *(ushort*)dataptr_t;
				Position += sizeof(ushort);
				return result;
			}
		}
		/// <summary>
		/// Reads an 4-byte signed integer from the current stream and advances the current 
		/// position of the stream by four bytes.
		/// </summary>
		/// <returns>An 4-byte signed integer read from the current stream.</returns>
		public int ReadInt32()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				int result = *(int*)dataptr_t;
				Position += sizeof(int);
				return result;
			}
		}
		/// <summary>
		/// Reads a 4-byte unsigned integer from the current stream and advances the position 
		/// of the stream by four bytes.
		/// </summary>
		/// <returns>A 4-byte unsigned integer read from this stream.</returns>
		public uint ReadUInt32()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				uint result = *(uint*)dataptr_t;
				Position += sizeof(uint);
				return result;
			}
		}
		/// <summary>
		/// Reads an 8-byte signed integer from the current stream and advances the current 
		/// position of the stream by eight bytes.
		/// </summary>
		/// <returns>An 8-byte signed integer read from the current stream.</returns>
		public long ReadInt64()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				long result = *(long*)dataptr_t;
				Position += sizeof(long);
				return result;
			}
		}
		/// <summary>
		/// Reads an 8-byte unsigned integer from the current stream and advances the current 
		/// position of the stream by eight bytes.
		/// </summary>
		/// <returns>An 8-byte unsigned integer read from the current stream.</returns>
		public ulong ReadUInt64()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				ulong result = *(ulong*)dataptr_t;
				Position += sizeof(ulong);
				return result;
			}
		}
		/// <summary>
		/// Reads a 4-byte floating point value from the current stream and advances the 
		/// current position of the stream by four bytes.
		/// </summary>
		/// <returns>A 4-byte floating point value read from the current stream.</returns>
		public float ReadSingle()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				float result = *(float*)dataptr_t;
				Position += sizeof(float);
				return result;
			}
		}
		/// <summary>
		/// Reads an 8-byte floating point value from the current stream and advances the 
		/// current position of the stream by eight bytes.
		/// </summary>
		/// <returns>An 8-byte floating point value read from the current stream.</returns>
		public double ReadDouble()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				double result = *(double*)dataptr_t;
				Position += sizeof(double);
				return result;
			}
		}
		/// <summary>
		/// Reads a decimal value from the current stream and advances the current position 
		/// of the stream by sixteen bytes.
		/// </summary>
		/// <returns>A decimal value read from the current stream.</returns>
		public decimal ReadDecimal()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				decimal result = *(decimal*)dataptr_t;
				Position += sizeof(decimal);
				return result;
			}
		}
		/// <summary>
		/// Reads a string from the current stream. The string is prefixed with the length,
		/// encoded as an integer seven bits at a time.
		/// </summary>
		/// <returns>The string being read.</returns>
		public string ReadString()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				string result = string.Empty;
				byte count = *dataptr_t;
				for (int a1 = 1; a1 < count + 1; ++a1)
					result += ((char)*(dataptr_t + a1)).ToString();
				Position += 1 + count;
				return result;
			}
		}
		/// <summary>
		/// Reads a null-terminated string from the current stream and advances the current 
		/// position of the stream by the string length plus one bytes.
		/// </summary>
		/// <returns>The string being read.</returns>
		public string ReadNullTerminated()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				string result = string.Empty;
				for (int a1 = 0; *(dataptr_t + a1) != 0; ++a1)
					result += ((char)*(dataptr_t + a1)).ToString();
				Position += 1 + result.Length;
				return result;
			}
		}
		/// <summary>
		/// Reads a null-terminated string from the current stream and advances the current 
		/// position of the stream by the maxlength specified.
		/// </summary>
		/// <param name="maxlength">Max length of bytes to be read, or position advance.</param>
		/// <returns>The string being read.</returns>
		public string ReadNullTerminated(int maxlength)
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				string result = string.Empty;
				for (int a1 = 0; a1 < maxlength && *(dataptr_t + a1) != 0; ++a1)
					result += ((char)*(dataptr_t + a1)).ToString();
				Position += maxlength;
				return result;
			}
		}
		/// <summary>
		/// Returns the next available primitive type and does not advance the position of 
		/// the current stream.
		/// </summary>
		/// <typeparam name="TypeID">Primitive type to be read. If type is not primitive, 
		/// returns default value of the type passed.</typeparam>
		/// <returns>The next available primitive type.</returns>
		public TypeID PeekPrimitive<TypeID>()
		{
			fixed (byte* dataptr_t = &stream[Position])
			{
				var type = typeof(TypeID);
				if (!type.IsPrimitive)
					return default;
				var result = (TypeID)Marshal.PtrToStructure((IntPtr)dataptr_t, type);
				return result;
			}
		}
		/// <summary>
		/// Sets the position within the current stream.
		/// </summary>
		/// <param name="offset">A byte offset relative to the origin parameter.</param>
		/// <param name="origin">A value of type SeekOrigin indicating the 
		/// reference point used to obtain the new position.</param>
		public void Seek(int offset, SeekOrigin origin)
		{
			switch (origin)
			{
				case SeekOrigin.Begin:
					if (offset <= Length)
						Position = offset;
					return;
				case SeekOrigin.End:
					if (offset <= Length)
						Position = Length - offset;
					return;
				case SeekOrigin.Current:
					if (Position + offset <= Length)
						Position += offset;
					else Position = Length;
					return;
			}
		}
		public override string ToString()
		{
			return base.ToString();
		}
	}
}