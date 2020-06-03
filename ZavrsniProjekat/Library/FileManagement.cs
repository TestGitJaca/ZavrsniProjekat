using System;
using System.Collections.Generic;
using System.IO;

namespace ZavrsniProjekat.Library
{
    class FileManagement
    {
        private static string fileName = @"C:\Users\Jasmina\Documents\test.log";

        public static void WriteLine(string logMessage)
        {
            using (StreamWriter fileHandle = new StreamWriter(fileName, true))
            {
                fileHandle.WriteLine("{0}", logMessage);
            }
        }

        public static void Write(string logMessage)
        {
            using (StreamWriter fileHandle = new StreamWriter(fileName, true))
            {
                fileHandle.Write("{0}", logMessage);
            }
        }

    }
}
