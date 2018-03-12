using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework
{
    /// <summary>
    /// easyui中的树节点
    /// </summary>
    public abstract class EasyUITree
    {
        public EasyUITree(string id,string text,string state)
        {
            this.id = id;
            this.text = text;
            this.state = state;
        }


        private string id { get; set; }
        private string text { get; set; }
        private string state { get; set; }
        //public string checked { get; set; }

        public abstract void Add(EasyUITreeNode node);
        public abstract void Remove(EasyUITreeNode node);
    }

    public class EasyUITreeNode : EasyUITree
    {
        public EasyUITreeNode(string id, string text, string state):base(id,text, state)
        {
        }

        public List<EasyUITreeNode> children = new List<EasyUITreeNode>();

        public override void Add(EasyUITreeNode node)
        {
            children.Add(node);
        }

        public override void Remove(EasyUITreeNode node)
        {
            children.Remove(node);
        }
    }

    public class EasyUITreeLeaf : EasyUITree
    {
        public EasyUITreeLeaf(string id, string text, string state) : base(id, text, state)
        {
        }

        public override void Add(EasyUITreeNode node)
        {
            throw new NotImplementedException();
        }

        public override void Remove(EasyUITreeNode node)
        {
            throw new NotImplementedException();
        }
    }

}
