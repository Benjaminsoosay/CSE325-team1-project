using Microsoft.AspNetCore.Identity;                                                                                  
                                                                                                                        
namespace CommunityLibrary.Data;                                                                                      
                                                                                                                        
public class ApplicationUser : IdentityUser                                                                           
{                                                                                                   
    public string? SecurityWord { get; set; }
}