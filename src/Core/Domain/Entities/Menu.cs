using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Menu:BaseEntity
{
	public string MenuJson { get; set; }
	public string LanguageCode { get; set; }
	public bool IsHeader { get; set; }

    public Guid LanguageId { get; set; }
    public Languages Language { get; set; }
}
