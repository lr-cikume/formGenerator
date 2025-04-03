using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext
{
    public class BaseDataContextModel
    {
        #region Primary key

        [Column("ID")]
        public Guid Id { get; set; }

        #endregion

        #region Audit fields

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by")]
        public string CreatedBy { get; set; } = "";

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("updated_by")]
        public string UpdatedBy { get; set; } = "";

        #endregion
    }
}
