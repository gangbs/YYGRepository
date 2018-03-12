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

        public abstract void Add(EasyUITree node);
        public abstract void Remove(EasyUITree node);
    }

    public class EasyUITreeNode : EasyUITree
    {
        public EasyUITreeNode(string id, string text, string state):base(id,text, state)
        {
        }

        public List<EasyUITreeNode> children = new List<EasyUITreeNode>();

        public override void Add(EasyUITree node)
        {
            children.Add(node);
        }

        public override void Remove(EasyUITree node)
        {
            children.Remove(node);
        }
    }

    public class EasyUITreeLeaf : EasyUITree
    {
        public EasyUITreeLeaf(string id, string text) : base(id, text, "close")
        {
        }

        public override void Add(EasyUITree node)
        {
            throw new NotImplementedException();
        }

        public override void Remove(EasyUITree node)
        {
            throw new NotImplementedException();
        }
    }


    public class CompositeClient
    {
        /// <summary>
        /// 生成树
        /// </summary>
        /// <param name="node">节点（有子节点）</param>
        /// <param name="lstChildren">子节点</param>
        /// <param name="lstSearch">搜索范围（已排除子节点）</param>
        public void GenTree(EasyUITreeNode node,List<NodeEntity> lstChildren, List<NodeEntity> lstSearch)
        {
            foreach (var n in lstChildren)
            {
                var lst = lstSearch.FindAll(x=>x.ParentId==n.Id);
                if(lst.Count>0)
                {
                    var composite = new EasyUITreeNode(n.Id, n.Text, "open");
                    node.Add(composite);                    
                    lstSearch.RemoveAll(x => x.ParentId == n.Id);
                    GenTree(composite, lst, lstSearch);
                }
                else
                {
                    var leaf = new EasyUITreeLeaf(n.Id,n.Text);
                    node.Add(leaf);
                }
            }
        }
    }


    public class NodeEntity
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Text { get; set; }
    }

}
