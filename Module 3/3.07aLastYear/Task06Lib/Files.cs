using System.Collections;

namespace Task06Lib
{
    public class FileLines : IEnumerable<string>, IDisposable
    {
        string fileName;
        StreamReader fileStream;

        public FileLines(string fileName)
        {
            this.fileName = fileName;
            fileStream = new StreamReader(fileName);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new FileEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new FileEnumerator(this);
        }

        class FileEnumerator : IEnumerator<string>
        {
            string? line;
            FileLines fl;
            public FileEnumerator(FileLines fl)
            {
                this.fl = fl;
                line = null;
            }
            public string Current => line;
            object IEnumerator.Current => line;
            public bool MoveNext()
            {
                line = fl.fileStream.ReadLine();
                if (line == null)
                {
                    Reset();
                    return false;
                }
                return true;
            }
            public void Reset()
            {
                fl.fileStream.Close();
                fl.fileStream = new StreamReader(fl.fileName);
            }

            public void Dispose()
            {
                
            }
        }

        public void Dispose()
        {
            fileStream.Dispose();
        }
    }
}