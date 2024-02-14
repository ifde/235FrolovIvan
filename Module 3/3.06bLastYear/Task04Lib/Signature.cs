namespace Task04Lib
{
    public class Signature
    {
        public static bool HasSignature(byte[] file, byte[] signature)
        {
            if (file == null || signature.Length > file.Length) return false;
            for (int i = 0; i < signature.Length; i++)
            {
                if (signature[i] != file[i]) return false;
            }
            return true;
        }

        public static void AnalyzeDirectoryFiles(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            foreach (string fileName in files)
            {
                byte[] file = File.ReadAllBytes(fileName);

                if (HasSignature(file, new byte[] { 0x47, 0x49, 0x46, 0x38}))
                {
                    Console.WriteLine($"{fileName}: GIF");
                }

                else if (HasSignature(file, new byte[] { 0x25, 0x50, 0x44, 0x46 }))
                {
                    Console.WriteLine($"{fileName}: PDF");
                }

                else if (HasSignature(file, new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }))
                {
                    Console.WriteLine($"{fileName}: PNG");
                }

                else if (HasSignature(file, new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }))
                {
                    Console.WriteLine($"{fileName}: JPEG");
                }

                else if (HasSignature(file, new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 }))
                {
                    Console.WriteLine($"{fileName}: EXIF");
                }

                else
                {
                    Console.WriteLine($"{fileName}: unknown");
                }
            }
        }
    }
}