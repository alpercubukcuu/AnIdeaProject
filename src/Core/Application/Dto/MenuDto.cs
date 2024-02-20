using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto;

public class MenuDto : BaseDto
{
	public string MenuJson { get; set; }
	public string LanguageCode { get; set; }
	public bool IsHeader { get; set; }

	public Guid LanguageId { get; set; }
	public LanguageDto Language { get; set; }
}
