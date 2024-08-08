using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AKS.Demo.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
    }

    [Required]
    [StringLength(500)]
    [Column("FirstName")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(500)]
    [Column("LastName")]
    public string LastName { get; set; }
}

