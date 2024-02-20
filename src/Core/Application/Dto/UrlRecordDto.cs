using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto;

public class UrlRecordDto : BaseDto
{
    public string Path { get; set; }
    public string FullPath { get; set; }
    public Guid? ParentId { get; set; }
    public Guid RootUrlId { get; set; }
    public bool? IsRoot { get; set; }

    public string RedirectUrl { get; set; }
    public int? RedirectType { get; set; }
}
