using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistBuilder.Models.Classes.DataStructures
{
	public class Wheel<T>
	{
		public List<Node<T>> Nodes { get; set; }

		public Node<T> FindNode(T value)
		{
			if (Nodes == null)
			{
				return null;
			}

			Node<T> foundNode;
			foreach (var root in Nodes)
			{
				foundNode = FindChildNode(root, value);
				if (foundNode != null)
				{
					return foundNode;
				}
			}
			return null;
		}

		private static Node<T> FindChildNode(Node<T> root, T value)
		{
			if (root == null)
			{
				return null;
			}

			if(EqualityComparer<T>.Default.Equals(root.Value, value))
			{
				return root;
			}

			var right = FindChildNode(root.Left, value);
			if(right != null)
			{
				return right;
			}

			var left = FindChildNode(root.Right, value);

			if (left != null)
			{
				return left;
			}

			foreach(var dec in root.Decendents)
			{
				var decendent = FindChildNode(dec, value);
				if(decendent != null)
				{
					return decendent;
				}
			}
			return null;
        }
	}
}
