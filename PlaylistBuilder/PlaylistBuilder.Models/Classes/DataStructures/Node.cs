using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaylistBuilder.Models.Enum;

namespace PlaylistBuilder.Models.Classes.DataStructures
{
	public class Node<T>
	{
		public Node<T> Left { get; set; }
		public Node<T> Right { get; set; }
		public List<Node<T>> Decendents {get;set;}

		public T Value { get; set; }
	}
}
