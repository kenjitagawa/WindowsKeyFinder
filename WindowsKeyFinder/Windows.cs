using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsKeyFinder
{
    class Windows
    {
        #region Constants

        // first byte offset
        private const int START = 52;

        // last byte offset
        private const int END = START + 15;

        // length of decoded key
        private const int LENGTH = 29;

        private const int DECODED = 15;

        private string m_productKey;

        // List of characters in bytes
        private List<byte> keyHex = new List<byte>();

        // List of possible alpha-numeric characters in key
        List<char> keyChars = new List<char>()
        {
            'B', 'C', 'D', 'F', 'G', 'H',
            'J', 'K', 'M', 'P', 'Q', 'R',
            'T', 'V', 'W', 'X', 'Y', '2',
            '3', '4', '6', '7', '8', '9'
        };

        // Array of characters to hold the product key decoded
        char[] decodedKey = new char[LENGTH];

        #endregion

        #region Properties

        public string Key 
        {
            get 
            {
                return m_productKey;
            }
        }


        #endregion


        public string DecodeKey(byte[] id)
        {
            //add all bytes to our list
            for (var i = START; i <= END; i++)
                keyHex.Add(id[i]);


            //now the decoding starts
            for (var i = LENGTH - 1; i >= 0; i--)

                switch ((i + 1) % 6)
                {
                    //if the calculation is 0 (zero) then add the seperator
                    case 0:
                        decodedKey[i] = '-';
                        break;
                    default:
                        var idx = 0;

                        for (var j = DECODED - 1; j >= 0; j--)
                        {
                            var @value = (idx << 8) | keyHex[j];
                            keyHex[j] = (byte)(@value / 24);
                            idx = @value % 24;
                            decodedKey[i] = keyChars[idx];
                        }
                        break;
                }

            return new string(decodedKey);

        }

        public void FindProductKeyClick()
        {
            byte[] id = null;
            var regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");

            if (regKey != null) id = regKey.GetValue("DigitalProductId") as byte[];

            m_productKey = DecodeKey(id);
        }

    }
}
