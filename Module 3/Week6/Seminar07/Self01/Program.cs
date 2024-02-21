using Self01Lib;

namespace Self01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<BTNode<int>, int> tree = new BinaryTree<BTNode<int>, int>();
            BTNode<int> node1 = new BTNode<int>(1);
            BTNode<int> node2 = new BTNode<int>(2);
            BTNode<int> node3 = new BTNode<int>(3);
            tree.Insert(node1);
            node1.InsertValue(node2);
            node1.InsertValue(node3);
            Console.WriteLine(tree);
        }
    }
}