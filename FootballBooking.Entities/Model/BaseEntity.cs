using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBooking.Entities.Model
{
    public abstract class BaseEntity<TId>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public TId Id { get; set; }
    }

    public abstract class AggregateRoot<TId> : BaseEntity<TId>
    {
    }
}