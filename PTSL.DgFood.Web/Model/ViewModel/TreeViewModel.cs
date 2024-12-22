using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTSL.DgFood.Web.Model.ViewModel
{ 
    public class TreeViewItemModel
    {
        public int id { get; set; }
        public string text { get; set; }
        public int? parent { get; set; }
    }
    //

    public class TreeNode
    {
        public string id { get; set; }
        public string text { get; set; }
        public string parentid { get; set; }
        public string value { get; set; }
        public string href { get; set; }
        public List<Tree> nodes = new List<Tree>();
    }

    public class Tree
    {
        public int id { get; set; }
        public string text { get; set; }
        public string href { get; set; }
        public List<Tree> nodes = new List<Tree>();
    }

    public class RootObject
    {
        public string text { get; set; }
        public int id { get; set; }
        public int parentid { get; set; }
        public List<RootObject> children = new List<RootObject>();

        public li_attr li_attr { get; set; } = new li_attr();
	}

    public class li_attr
    {
        public string __class { get; set; } = string.Empty;
    }
}