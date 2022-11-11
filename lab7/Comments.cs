using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsLib
{
    public class CommentAttribute : Attribute
    {
        public string Comment { get; set; }
        public string GetComment() => Comment;
        public CommentAttribute() { }
        public CommentAttribute(string _comment) => Comment = _comment;
    }
}