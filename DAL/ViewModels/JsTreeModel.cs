using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModels
{
   public class JsTreeModel
    {
        public string id { get; set; }
   
        public string text { get; set; }
       
        public string icon { get; set; }
        public List<JsTreeModel> children { get; set; } // array of strings or objects
        public JsTreeModelstate state { get; set; }
        public string li_attr { get; set; }            // attributes for the generated LI node
        public string a_attr { get; set; }           // attributes for the generated A node

    }
}


