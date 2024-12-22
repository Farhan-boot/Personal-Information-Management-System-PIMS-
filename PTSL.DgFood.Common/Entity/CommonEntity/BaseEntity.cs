using EntityFrameworkCore.Triggers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text; 
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;  
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model; 
namespace PTSL.DgFood.Common.Entity.CommonEntity
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 0, TypeName = "bigint")]
        public long Id { get; set; }

        [Column("CreatedAt", Order = 1, TypeName = "datetime2 (3)")]
        public DateTime CreatedAt { get; set; }

        [Column("UpdatedAt", Order = 2, TypeName = "datetime2 (3)")]
        public DateTime? UpdatedAt { get; set; }

        [Column("DeletedAt", Order = 3, TypeName = "datetime2 (3)")]
        public DateTime? DeletedAt { get; set; }

        [Column("IsDeleted", Order = 4, TypeName = "bit")]
        public bool IsDeleted { get; set; }

        [Column("IsActive", Order = 5, TypeName = "bit")]
        public bool IsActive { get; set; }

        public long CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public long? DeletedBy { get; set; }
        
        static BaseEntity() // Must be static for the triggers to be registered only once
        {
            Triggers<BaseEntity>.Inserting += entry =>
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.IsDeleted = false;
                entry.Entity.IsActive = true;
            };

            Triggers<BaseEntity>.Updating += entry =>
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
                //entry.Entity.ModifiedBy = 1;
            };


            Triggers<BaseEntity>.Deleting += entry =>
            {
                entry.Entity.DeletedAt = DateTime.UtcNow;
                entry.Entity.IsDeleted = true;
                entry.Cancel = true;
            };
        }
    }
}
