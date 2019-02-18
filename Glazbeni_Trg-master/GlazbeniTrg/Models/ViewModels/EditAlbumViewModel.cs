using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models.ViewModels
{
    public class EditAlbumViewModel
    {
        public Guid LabelID { get; set; }
        public Album Album { get; set; }
        public IEnumerable<Guid> GenreIDs { get; set; }
        public IEnumerable<Guid> SongIDs { get; set; }
    }
}
