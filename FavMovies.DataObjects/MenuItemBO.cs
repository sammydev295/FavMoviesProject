using System;
using System.Collections.Generic;
using System.Text;

namespace FavMovies.DataObjects
{
   public class MenuItemBO
    {
        public MenuItemBO()
        {
            //  TargetType = typeof (HomeMasterDetailPageMenuItem);
        }
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public string Uri { get; set; }

    }
}
