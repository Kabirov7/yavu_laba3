using System;
using System.Runtime.InteropServices;
using System.Text;

namespace lab3_1
{
    public class Lib : IDisposable
    {
        public IntPtr desc;
        public const string libPath = "file64.dll";
        public Lib(string path, bool read = true) => desc = open(path, read);
    
        public void Dispose()
        {
            close(desc);
            Console.WriteLine("Файл закрыт");
        }

        [DllImport(libPath)]
        public static extern IntPtr open(string path, bool read);

        [DllImport(libPath)]
        public static extern void close(IntPtr file);

        [DllImport(libPath)]
        public static extern bool read(IntPtr file, int num, StringBuilder word);
    
        [DllImport(libPath)]
        public static extern void write(IntPtr file, string text);
    
        [DllImport(libPath)]
        public static extern int length(IntPtr file);
    }

}