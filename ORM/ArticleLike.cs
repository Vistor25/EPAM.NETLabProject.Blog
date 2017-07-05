namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArticleLike")]
    public partial class ArticleLike
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ArticleID { get; set; }

        public long UserID { get; set; }

        public virtual Article Article { get; set; }
    }
}
