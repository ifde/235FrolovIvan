namespace Self01Lib
{
    public class BinaryTree<BTNode, T>
        where T : notnull
    {

        BTNode<T> root;
        public BinaryTree() { root = new BTNode<T>(default); }

        public void Insert(BTNode<T> newNode)
        {
            if (newNode.LeftLink != null) throw new ArgumentException("Узел не является частью дерева");
            root.InsertValue(newNode);
        }

        public string Preorder(BTNode<T> node, ref string res)
        {
            if (node.LeftLink == null && node != root) return "";
            foreach (var childNode in node.RightLink)
            {
                if (childNode.RightLink.Count == 0) res += $"|{childNode.Value}|\n";
                else Preorder(childNode, ref res);
            }
            res += $"|{node.Value}|\n";
            return res;
        }

        public override string ToString()
        {
            if (root.RightLink.Count == 0) throw new ArgumentNullException("Дерево пустое.");
            string res = "";
            return Preorder(root, ref res);
        }

        public void Delete(BTNode<T> node)
        {
            node.DeleteThisNode();
        }

        public bool IsEmpty => root == null;
    }

    public class BTNode<T>
        where T : notnull
    {
        T value;
        int cnt;
        BTNode<T>? leftLink;
        List<BTNode<T>> rightLink;

        public BTNode<T>? LeftLink => leftLink;
        public List<BTNode<T>> RightLink => rightLink;

        public T Value => value;
        public int Cnt => cnt;

        public BTNode(T value)
        {
            this.value = value;
            leftLink = null;
            rightLink = new List<BTNode<T>>();
            cnt = 0;
        }

        public void InsertValue(BTNode<T> newNode)
        {
            if (newNode.leftLink != null) throw new ArgumentException("Узел уже является частью дерева.");
            newNode.leftLink = this;
            rightLink.Add(newNode);
            cnt++;
        }

        public void DeleteThisNode()
        {
            if (leftLink == null) return;
            List<BTNode<T>> newRightLinks = new List<BTNode<T>>();
            foreach (var elem in leftLink.RightLink)
            {
                if (elem != leftLink) newRightLinks.Add(elem);
            }
            leftLink.rightLink = newRightLinks;
            leftLink = null;
        }
    }
}