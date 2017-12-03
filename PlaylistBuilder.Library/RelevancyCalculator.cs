using System.Collections.Generic;
using PlaylistBuilder.Models.Classes.Objects;
using PlaylistBuilder.Models.Enum;

namespace PlaylistBuilder.Library
{
    public class RelevancyCalculator
    {
		public double GetSongRelevancy(Song seed, Song test)
		{
			//BPM relevancy
			double bpmRel = BPMRelevancy(seed.BPM, test.BPM);
			//Artist relevancy
			//Sentiment relevancy
			
						 
			return bpmRel;
		}

		//find out how close the two bpms are to compare to relevancy root later
		private double BPMRelevancy(int seedBPM, int testBPM)
		{
			int low = seedBPM > testBPM ? testBPM: seedBPM;
			int high = seedBPM < testBPM ? testBPM : seedBPM;
			double deviance = (double)(high - low) / high;
            return ConvertToRelevancy(deviance);

		}

		private double SentimentRelevancy(Dictionary<PlaylistBuilder.Models.Enum.Emotion, double>seedSentiment, Dictionary<PlaylistBuilder.Models.Enum.Emotion,double> testSentiment)
		{
			double sentiment =0;
			foreach(var key in testSentiment.Keys)
			{
				if (testSentiment.ContainsKey(key))
				{
					var seed = seedSentiment[key];
					var test = testSentiment[key];

					double low = seed > test ? test: seed;
					double high = seed < test ? test : seed;

					double deviance = (high - low) / high;

					double relivance = ConvertToRelevancy(deviance);
					sentiment += relivance;
                }
			}
			return sentiment / testSentiment.Keys.Count;
		}

		private double ConvertToRelevancy(double deviance)
		{
			return 1 - deviance;
		}
    }
}
