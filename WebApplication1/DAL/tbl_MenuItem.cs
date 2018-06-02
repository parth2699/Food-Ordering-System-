namespace WebApplication1.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuItemId { get; set; }

        public int MenuCatID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(50)]
        public string Order { get; set; }

        [StringLength(10)]
        public string Visible { get; set; }
    }
}
