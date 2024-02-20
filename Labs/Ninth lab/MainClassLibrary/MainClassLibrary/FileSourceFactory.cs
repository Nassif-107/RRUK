using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РРУК_01
{
    public class FileSourceFactory
    {
        public static IFileSource CreateFileSource(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            switch (extension)
            {
                case ".yaml":
                    return new YamlFileSource();
                case ".html":
                    return new HtmlFileSource();
                default:
                    throw new NotSupportedException($"File extension '{extension}' is not supported.");
            }
        }
    }
}
