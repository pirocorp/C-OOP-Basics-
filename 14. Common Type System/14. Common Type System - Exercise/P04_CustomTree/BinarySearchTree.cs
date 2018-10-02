namespace P04_CustomTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    public class BinarySearchTree<T> : ICloneable, IEnumerable<T>
    {
        public BinarySearchTree(T value)
        {
            this.Root = new TreeNode<T>(value);
        }

        public BinarySearchTree(TreeNode<T> root)
        {
            this.Root = root;
        }

        public TreeNode<T> Root { get; private set; }

        public void Add(T value)
        {
            this.Add(new TreeNode<T>(value));
        }

        public void Add(TreeNode<T> treeNode)
        {
            Add(this.Root, treeNode);
        }

        public TreeNode<T> Search(T value)
        {
            return Search(this.Root, value, out var parent);
        }

        public void Delete(T value)
        {
            var subtree = Search(this.Root, value, out var parent);

            if (value == null)
            {
                return;
            }

            if (subtree == null)
            {
                return;
            }

            //deleting root with only one leaf
            if (parent == null)
            {
                if ((subtree.LeftNode == null && subtree.RightNode != null))
                {
                    this.Root = subtree.RightNode;
                    return;
                }

                if (subtree.LeftNode != null && subtree.RightNode == null)
                {
                    this.Root = subtree.LeftNode;
                    return;
                }
            }

            //Deleting leaf without children
            if (subtree.LeftNode == null && subtree.RightNode == null)
            {
                var leafValue = subtree.Value;

                if (parent.LeftNode != null && parent.LeftNode.Value.GetHashCode() == leafValue.GetHashCode())
                {
                    parent.DeleteLeftNode();
                }

                if (parent.RightNode != null && parent.RightNode.Value.GetHashCode() == leafValue.GetHashCode())
                {
                    parent.DeleteRightNode();
                }
            }

            //Deleating leaf with one children
            if ((subtree.LeftNode == null && subtree.RightNode != null))
            {
                var leafValue = subtree.Value;

                if (parent.LeftNode != null && parent.LeftNode.Value.GetHashCode() == leafValue.GetHashCode())
                {
                    parent.SetLeftNode(subtree.RightNode);
                }

                if (parent.RightNode != null && parent.RightNode.Value.GetHashCode() == leafValue.GetHashCode())
                {
                    parent.SetRightNode(subtree.RightNode);
                }
            }

            if (subtree.LeftNode != null && subtree.RightNode == null)
            {
                var leafValue = subtree.Value;

                if (parent.LeftNode != null && parent.LeftNode.Value.GetHashCode() == leafValue.GetHashCode())
                {
                    parent.SetLeftNode(subtree.LeftNode);
                }

                if (parent.RightNode != null && parent.RightNode.Value.GetHashCode() == leafValue.GetHashCode())
                {
                    parent.SetRightNode(subtree.LeftNode);
                }
            }

            //Deleting leaf with two children
            if (subtree.LeftNode != null && subtree.RightNode != null)
            {
                var maxElement = GetMaxNode(subtree.LeftNode).Value;
                var maxElementOfLeftSubtree = Search(subtree, maxElement, out var subtreeMaxParent);

                subtree.ChangeValue(maxElementOfLeftSubtree.Value);

                subtreeMaxParent.SetRightNode(maxElementOfLeftSubtree.LeftNode);
            }
        }

        private static void Add(TreeNode<T> root, TreeNode<T> treeNode)
        {
            var treeNodeKey = treeNode.Key;

            var currentRootKey = root.Key;

            if (currentRootKey < treeNodeKey)
            {
                var rightNode = root.RightNode;

                if (rightNode == null)
                {
                    root.SetRightNode(treeNode);
                    return;
                }

                Add(rightNode, treeNode);
            }

            if (currentRootKey > treeNodeKey)
            {
                var leftNode = root.LeftNode;

                if (leftNode == null)
                {
                    root.SetLeftNode(treeNode);
                    return;
                }

                Add(leftNode, treeNode);
            }
        }

        private static TreeNode<T> Search(TreeNode<T> root, T value, out TreeNode<T> parent) //Search returns subtree with root searched element
        {
            if (root == null)
            {
                parent = null;
                return null;
            }

            if (root.LeftNode != null && root.LeftNode.Value.GetHashCode() == value.GetHashCode())
            {
                parent = root;
                return root.LeftNode;
            }

            if (root.RightNode != null && root.RightNode.Value.GetHashCode() == value.GetHashCode())
            {
                parent = root;
                return root.RightNode;
            }

            var valueKey = value.GetHashCode();

            if (root.Key < valueKey)
            {
                parent = root;
                return Search(root.RightNode, value, out parent);
            }

            if (root.Key > valueKey)
            {
                parent = root;
                return Search(root.LeftNode, value, out parent);
            }

            if (root.Value.GetHashCode() == value.GetHashCode())
            {
                parent = null;
                return root;
            }

            parent = null;
            return null;
        }

        private static TreeNode<T> GetMaxNode(TreeNode<T> root)
        {
            var maxElement = root;

            if (root.RightNode != null)
            {
                maxElement = GetMaxNode(root.RightNode);
            }

            return maxElement;
        }

        public override string ToString()
        {
            return $"Root: {this.Root.Value}";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var iterateThis = IterateThis(this.Root);

            foreach (var item in iterateThis)
            {
                yield return item;
            }
        }

        private List<T> IterateThis(TreeNode<T> root)
        {
            var result = new List<T>();
            result.Add(root.Value);

            if (root != null)
            {
                if (root.LeftNode != null)
                {
                    result.AddRange(this.IterateThis(root.LeftNode));
                }

                if (root.RightNode != null)
                {
                    result.AddRange(this.IterateThis(root.RightNode));
                }
            }
            
            return result;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public BinarySearchTree<T> Clone()
        {
            var clone = new BinarySearchTree<T>(this.Root.Value);
            var isStarted = false;

            foreach (var element in this)
            {
                if (isStarted)
                {
                    clone.Add(element);
                }

                isStarted = true;
            }

            return clone;
        }
    }
}