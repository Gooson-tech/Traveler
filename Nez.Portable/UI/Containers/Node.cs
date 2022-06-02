using System;
using System.Collections.Generic;

namespace Nez.UI.Containers
{
    public class Node
    {
        internal Element actor;
        internal Node parent;
        internal List<Node> children = new List<Node>(0);
        internal bool selectable = true;
        internal bool expanded;
        internal IDrawable icon;
        internal float height;
        internal object o;

        public Node(Element element)
        {
            actor = element;
        }

        public void SetExpanded(bool expanded)
        {
            if (expanded == this.expanded)
                return;

            this.expanded = expanded;
            if (children.Count == 0)
                return;

            var tree = GetTree();
            if (tree == null)
                return;

            if (expanded)
            {
                for (int i = 0, n = children.Count; i < n; i++)
                    children[i].AddToTree(tree);
            }
            else
            {
                for (var i = children.Count - 1; i >= 0; i--)
                    children[i].RemoveFromTree(tree);
            }

            tree.InvalidateHierarchy();
        }

        protected internal void AddToTree(Tree tree)
        {
            tree.AddElement(actor);
            if (!expanded)
                return;

            var children = this.children;
            for (var i = this.children.Count - 1; i >= 0; i--)
                children[i].AddToTree(tree);
        }

        protected internal void RemoveFromTree(Tree tree)
        {
            tree.RemoveElement(actor);
            if (!expanded)
                return;

            var children = this.children;
            for (var i = this.children.Count - 1; i >= 0; i--)
                children[i].RemoveFromTree(tree);
        }

        public void Add(Node node)
        {
            Insert(children.Count, node);
        }

        public void AddAll(List<Node> nodes)
        {
            for (int i = 0, n = nodes.Count; i < n; i++)
                Insert(children.Count, nodes[i]);
        }

        public void Insert(int index, Node node)
        {
            node.parent = this;
            children.Insert(index, node);
            UpdateChildren();
        }

        public void Remove()
        {
            var tree = GetTree();
            if (tree != null)
                tree.Remove(this);
            else if (parent != null) //
                parent.Remove(this);
        }

        public void Remove(Node node)
        {
            children.Remove(node);
            if (!expanded)
                return;

            var tree = GetTree();
            if (tree == null)
                return;

            node.RemoveFromTree(tree);
            if (children.Count == 0)
                expanded = false;
        }

        public void RemoveAll()
        {
            var tree = GetTree();
            if (tree != null)
            {
                var children = this.children;
                for (var i = this.children.Count - 1; i >= 0; i--)
                    ((Node)children[i]).RemoveFromTree(tree);
            }

            children.Clear();
        }

        public Tree GetTree()
        {
            var parent = actor.GetParent();
            if (!(parent is Tree))
                return null;

            return (Tree)parent;
        }

        public Element GetActor()
        {
            return actor;
        }

        public bool IsExpanded()
        {
            return expanded;
        }

        public List<Node> GetChildren()
        {
            return children;
        }

        public void UpdateChildren()
        {
            if (!expanded)
                return;

            var tree = GetTree();
            if (tree == null)
                return;

            for (var i = children.Count - 1; i >= 0; i--)
                children[i].RemoveFromTree(tree);
            for (int i = 0, n = children.Count; i < n; i++)
                children[i].AddToTree(tree);
        }

        public Node GetParent()
        {
            return parent;
        }

        public void SetIcon(IDrawable icon)
        {
            this.icon = icon;
        }

        public object GetObject()
        {
            return o;
        }

        public void SetObject(object o)
        {
            this.o = o;
        }

        public IDrawable GetIcon()
        {
            return icon;
        }

        public int GetLevel()
        {
            var level = 0;
            var current = this;
            do
            {
                level++;
                current = current.GetParent();
            } while (current != null);

            return level;
        }

        public Node FindNode(object o)
        {
            if (o == null)
                throw new Exception("object cannot be null.");

            if (o.Equals(this.o))
                return this;

            return Tree.FindNode(children, o);
        }

        public void CollapseAll()
        {
            SetExpanded(false);
            Tree.CollapseAll(children);
        }

        public void ExpandAll()
        {
            SetExpanded(true);
            if (children.Count > 0)
                Tree.ExpandAll(children);
        }

        public void ExpandTo()
        {
            var node = parent;
            while (node != null)
            {
                node.SetExpanded(true);
                node = node.parent;
            }
        }

        public bool IsSelectable()
        {
            return selectable;
        }

        public void SetSelectable(bool selectable)
        {
            this.selectable = selectable;
        }

        public void FindExpandedObjects(List<object> objects)
        {
            if (expanded && !Tree.FindExpandedObjects(children, objects))
                objects.Add(o);
        }

        public void RestoreExpandedObjects(List<object> objects)
        {
            for (int i = 0, n = objects.Count; i < n; i++)
            {
                var node = FindNode(objects[i]);
                if (node != null)
                {
                    node.SetExpanded(true);
                    node.ExpandTo();
                }
            }
        }

        public float GetHeight()
        {
            return height;
        }
    }
}