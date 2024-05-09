using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRenting.Models.Entities;

public class CarStatus
{
    [Key] public int Id { get; set; }

    public Guid CarStatusId { get; set; } //UNIQUE

    [DisplayName("Status name")]
    [MaxLength(20)]
    public Guid Name { get; set; } //UNIQUE

    //navigator
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}