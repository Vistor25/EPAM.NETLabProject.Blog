//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public long ID { get; set; }
        public string Text { get; set; }
        public long ArticleID { get; set; }
        public long UserID { get; set; }
        public System.DateTime CreationDate { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}
