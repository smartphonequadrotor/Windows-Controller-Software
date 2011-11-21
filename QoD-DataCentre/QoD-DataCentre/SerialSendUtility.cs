using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QoD_DataCentre
{
    class SerialSendUtility
    {
public static string EncodeCommand(string command)
		{
			if (command.Length == 0)
			{
				throw new Exception("Command to encode must have length greater than 0.");
			}

			if (command.Length > 257)
			{
				throw new Exception("Command to encode must not be longer than 257 bytes (2 bytes for command and maximum 255 bytes of data).");
			}

			// Start framing byte
			string retVal = "!";

			// Command and data
			retVal += command;

			// Checksum
			int crc32Val = 0x0123;
			retVal += crc32Val.ToString("X4").Substring(0, 4);

			// End framing bytes
			retVal += "\r\n";

			return retVal;
		}
    }
}