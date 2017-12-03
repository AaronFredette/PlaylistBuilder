using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaylistBuilder.Models.Classes.DataStructures;

namespace PlaylistBuilder.Models.Classes.Objects
{
	public static class EmotionWheel 
	{
		private static Wheel<Enum.Emotion> _wheel;

		private static void BuildWheel()
		{
			if (_wheel != null)
			{
				return;
			}
						
			//Joy Section
			var happyNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Happy };
			var joyNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Joy, Decendents = new List<Node<Enum.Emotion>>() { happyNode } };

			//Anger Section
			var contempt = new Node<Enum.Emotion>() { Value = Enum.Emotion.Contempt };
			var angerNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Angry, Decendents = new List<Node<Enum.Emotion>>() { contempt } };

			//Love Section
			var loveNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Love };
			var romanticNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Romance, Decendents = new List<Node<Enum.Emotion>>() { loveNode } };

			//Fear Section
			var worriedNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Worry };
			var anxiousNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Anxious, Left= worriedNode };
			worriedNode.Right = anxiousNode;
			var fearNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Fear, Decendents = new List<Node<Enum.Emotion>>() { worriedNode, anxiousNode  } };

			//Surprise Section
			var amazedNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Amazement };
			var surpriseNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Surprise, Decendents = new List<Node<Enum.Emotion>>() { amazedNode} };

			//Sad Section
			var disappointedNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Disappointment };
			var sadnessNode = new Node<Enum.Emotion>() { Value = Enum.Emotion.Sad, Decendents = new List<Node<Enum.Emotion>>() { disappointedNode} };

			sadnessNode.Right = surpriseNode;
			sadnessNode.Left = angerNode;

			surpriseNode.Right = joyNode;
			surpriseNode.Left = sadnessNode;

			joyNode.Right = loveNode;
			joyNode.Left = surpriseNode;

			loveNode.Right = fearNode;
			loveNode.Left = joyNode;

			fearNode.Left = loveNode;
			fearNode.Right = angerNode;

			angerNode.Left = fearNode;
			angerNode.Right = sadnessNode;
			
			_wheel = new Wheel<Enum.Emotion>();
			_wheel.Nodes = new List<Node<Enum.Emotion>>() { sadnessNode, surpriseNode, joyNode, loveNode, fearNode, angerNode };
		}

		public static int GetDistanceBetweenNodes(Enum.Emotion seedEmotion, Enum.Emotion testEmotion)
		{
			var seedNode = _wheel.FindNode(seedEmotion);
			var testNode = _wheel.FindNode(testEmotion);
			foreach(var n in _wheel.Nodes)
			{
				if(n.Value == testEmotion) {

				}
			}

			return -1;
		}

		
	}
}
