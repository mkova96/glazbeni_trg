using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models.ViewModels
{
    public class EditSongViewModel
    {
        public Song Song { get; set; }
        public IEnumerable<Guid> GenreIDs { get; set; }
        public IEnumerable<Guid> Producer { get; set; }
        public IEnumerable<Guid> Performer { get; set; }
        public IEnumerable<Guid> Composer { get; set; }
        public IEnumerable<Guid> Songwriter { get; set; }
        public IEnumerable<Guid> Singer { get; set; }
        public IEnumerable<Guid> Drummer { get; set; }
        public IEnumerable<Guid> Bassist { get; set; }
        public IEnumerable<Guid> Guitarist { get; set; }

        public Boolean Band { get; set; }


    }
}