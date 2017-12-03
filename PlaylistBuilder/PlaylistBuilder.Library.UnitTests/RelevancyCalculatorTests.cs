using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaylistBuilder.Models.Classes.Objects;
namespace PlaylistBuilder.Library.UnitTests
{
	[TestClass]
	public class RelevancyCalculatorTests
	{
		private Song _seedSong, _testSong;

		[TestInitialize]
		public void SetUp()
		{
			_seedSong = new Song() {
				Title = "Seed",
				BPM = 100
			};
			_testSong = new Song()
			{
				Title = "Test"
			};

		}
		[TestMethod]
		public void RelevancyCalculator_BPMIn_CloseMatch()
		{
			RelevancyCalculator calculator = new RelevancyCalculator();
			_testSong.BPM = 98;
			double relevancy = calculator.GetSongRelevancy(_seedSong, _testSong);
			Assert.IsTrue(relevancy > .6);

		}

		[TestMethod]
		public void RelevancyCalculator_BPMIn_NoMatch()
		{
			RelevancyCalculator calculator = new RelevancyCalculator();
			_testSong.BPM = 3;
			double relevancy = calculator.GetSongRelevancy(_seedSong, _testSong);
			Assert.IsTrue(relevancy < .6);

		}

		[TestMethod]
		public void RelevancyCalculator_BPMIn_NoBPM()
		{
			RelevancyCalculator calculator = new RelevancyCalculator();
			double relevancy = calculator.GetSongRelevancy(_seedSong, _testSong);
			Assert.IsTrue(relevancy < .6);

		}

		[TestMethod]
		public void RelevancyCalculator_EmotionalWeight_CloseMatch()
		{

		}
	}
}
