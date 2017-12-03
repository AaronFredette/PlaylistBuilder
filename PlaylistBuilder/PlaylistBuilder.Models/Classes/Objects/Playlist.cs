using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistBuilder.Models.Classes.Objects
{
	public class Playlist
	{
		public IEnumerable<Song> Songs { get; set; }

		public float BPMWeight { get; set; }
		public float ArtistWeight { get; set; }
		public float LyricWeight { get; set; }
	}
}
