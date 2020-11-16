using Books.Models;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using System.Linq;

namespace Books
{
    public class BooksManager
    {
        public string GetBooksType(string extension)
        {
            var contentTypes = new FileExtensionContentTypeProvider().Mappings;
            var foundContentType = from contentType in contentTypes
                                   where contentType.Key == extension
                                   select contentType;
            var selectContentType = foundContentType.FirstOrDefault();
            return selectContentType.Value;
        }

        public string GetBooksPath(string directory, BookModel book)
        {
            var allFilesNames = Directory.GetFiles(directory);
            var foundFullBookName = from fullBookName in allFilesNames
                                    where fullBookName.Contains(book.Name)
                                    select fullBookName;

            var bookPath = foundFullBookName.FirstOrDefault();
            var fullBookPath = Path.GetFullPath(bookPath);
            return fullBookPath;
        }
    }
}
