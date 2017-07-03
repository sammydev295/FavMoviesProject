using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavMovies.Clients.Portable.Interfaces
{
    public interface IResourceContainer
    {
        string GetString(string key);
    }
}
