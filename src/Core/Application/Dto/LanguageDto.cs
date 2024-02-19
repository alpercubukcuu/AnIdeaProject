

namespace Application.Dto;

public class LanguageDto : BaseDto
{
   
    public string Title { get; set; }
   
    public string CountryCode { get; set; }
    
    public string Culture { get; set; }
    
    public string Flag { get; set; }
  
    public int Sort { get; set; }
  
    public int? IsRoot { get; set; }
   
    public string? Currency { get; set; }
}
