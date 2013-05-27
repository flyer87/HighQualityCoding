using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeContentCatalog
{
    public enum CommandType
    {
        AddBook,
        AddMovie,
        AddSong,
        AddApplication,
        Update,
        Find,
    }

    public enum ContentType
    {
        Book,
        Movie,
        Song,
        Application,
    }

    public enum Acpi
    {
        Title = 0, 
        Author,
        Size,
        Url,
    }
}
