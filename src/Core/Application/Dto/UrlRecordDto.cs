using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto;

public class UrlRecordDto : BaseDto
{
    public string Slug { get; set; }
    public Guid PageId { get; set; }
    public Pages Page { get; set; }


    public string RedirectUrl { get; set; } 
    public int? RedirectType { get; set; }
}
