using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaylistBuilder.Models.Enum;
namespace PlaylistBuilder.Models.Classes.Objects
{
    public class Song
    {
		public string Title { get; set; }
		public double Duration { get; set; }
		public int BPM { get; set; }
		public Dictionary<Emotion,int> EmotionalWeights { get; set; }
    }
}
