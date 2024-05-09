using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace CarRenting.Models.Entities;

public class ContractStatus
{
    [Key] public int Id { get; set; }

    public Guid ContractStatusId { get; set; }

    [DisplayName("Status name")]
    [MaxLength(20)]
    public string Name { get; set; } = null!; //UNIQUE

    //navigator
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}