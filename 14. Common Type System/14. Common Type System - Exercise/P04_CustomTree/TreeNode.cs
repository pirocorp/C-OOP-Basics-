namespace P04_CustomTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public TreeNode<T> LeftNode { get; private set; }

        public TreeNode<T> RightNode { get; private set; }

        public int Key => this.Value.GetHashCode();

        public void SetLeftNode(TreeNode<T> node)
        {
            this.LeftNode = node;
        }

        public void SetRightNode(TreeNode<T> node)
        {
            this.RightNode = node;
        }

        public void DeleteLeftNode()
        {
            this.LeftNode = null;
        }

        public void DeleteRightNode()
        {
            this.RightNode = null;
        }

        public void ChangeValue(T value)
        {
            this.Value = value;
        }

        public override int GetHashCode() => this.Value.GetHashCode();

        public override bool Equals(object obj)
        {
            var other = obj as TreeNode<T>;

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (this.GetHashCode() == other.GetHashCode())
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(TreeNode<T> firstNode, TreeNode<T> secondNode)
        {
            if (ReferenceEquals(firstNode, null) || ReferenceEquals(secondNode, null))
            {
                if (ReferenceEquals(firstNode, null) && ReferenceEquals(secondNode, null))
                {
                    return true;
                }

                return false;
            }

            return firstNode.Equals(secondNode);
        }

        public static bool operator !=(TreeNode<T> firstNode, TreeNode<T> secondNode)
        {
            return !(firstNode == secondNode);
        }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}