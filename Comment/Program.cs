using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Comment
    {
        public class CommentAttribute : Attribute
        {
            public string Comment { get; set; }
            public string GetComment() => Comment;
            public CommentAttribute() { }
            public CommentAttribute(string _comment) => Comment = _comment;
        }
    }
}