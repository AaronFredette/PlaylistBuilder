using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaylistBuilder.Models.Classes.DataStructures;

namespace PlaylistBuilder.Library.UnitTests.DataStructureTests
{
	[TestClass]
	public class WheelTests
	{
		private Wheel<int> _wheel;
		[TestInitialize]
		public void SetUp()
		{
			var root1 = new Node<int>() { Value = 1 };
			var root2 = new Node<int>() { Value = 2 };
			var root3 = new Node<int>() { Value = 3 };
			var root4 = new Node<int>() { Value = 4 };

			//configure root1
			root1.Decendents = new List<Node<int>>()
			{
				new Node<int>()
				{
					Value=11,
					Decendents = new List<Node<int>>()
					{
						new Node<int>()
						{
							Value=111
						}
					}

				},
				new Node<int>()
				{
					Value =12,
					Decendents = new List<Node<int>>()
					{
						new Node<int>()
						{
							Value = 121
						},
						new Node<int>()
						{
							Value=122
						}
					}
					
				},
				new Node<int>()
				{
					Value = 13
				}
			};

			root2.Decendents = new List<Node<int>>()
			{
				new Node<int>()
				{
					Value=21,
					Decendents = new List<Node<int>>()
					{
						new Node<int>()
						{
							Value=211
						}
					}

				},
				new Node<int>()
				{
					Value =22,
					Decendents = new List<Node<int>>()
					{
						new Node<int>()
						{
							Value = 221
						},
						new Node<int>()
						{
							Value=222
						}
					}

				},
				new Node<int>()
				{
					Value = 23
				}
			};



			root3.Decendents = new List<Node<int>>()
			{
				new Node<int>()
				{
					Value=31,
					Decendents = new List<Node<int>>()
					{
						new Node<int>()
						{
							Value=311
						}
					}

				},
				new Node<int>()
				{
					Value =32,
					Decendents = new List<Node<int>>()
					{
						new Node<int>()
						{
							Value = 321
						},
						new Node<int>()
						{
							Value=322
						}
					}

				},
				new Node<int>()
				{
					Value = 33
				}
			};


			root4.Decendents = new List<Node<int>>()
			{
				new Node<int>()
				{
					Value=41,
					Decendents = new List<Node<int>>()
					{
						new Node<int>()
						{
							Value=411
						}
					}

				},
				new Node<int>()
				{
					Value =42,
					Decendents = new List<Node<int>>()
					{
						new Node<int>()
						{
							Value = 421
						},
						new Node<int>()
						{
							Value=422
						}
					}

				},
				new Node<int>()
				{
					Value = 43
				}
			};

			root1.Left = root2;
			root1.Right = root4;

			root2.Left = root3;
			root2.Right = root1;

			root3.Left = root4;
			root3.Right = root2;

			root4.Left = root1;
			root4.Right = root3;

			_wheel = new Wheel<int>()
			{
				Nodes = new List<Node<int>>() {
					root1,
					root2,
					root3,
					root4
				}
			};
		}


		[TestMethod]
		public void FindNode_ThatExists_FirstLevel()
		{
			var node = _wheel.FindNode(2);
			Assert.IsNotNull(node);
		}

		[TestMethod]
		public void FindNode_ThatExists_SecondLevel()
		{
			var node = _wheel.FindNode(22);
			Assert.IsNotNull(node);
		}

		[TestMethod]
		public void FindNode_ThatExists_ThirdLevel()
		{
			var node = _wheel.FindNode(322);
			Assert.IsNotNull(node);
		}

		[TestMethod]
		public void FindNode_DoesNotExist()
		{
			var node = _wheel.FindNode(55);
			Assert.IsNull(node);
		}
	}
}
