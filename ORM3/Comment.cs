//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public long ID { get; set; }
        public string Text { get; set; }
        public long ArticleID { get; set; }
        public long UserID { get; set; }
        public byte[] CreationDate { get; set; }
    
        public virtual Article Article { get; set; }
    }
}