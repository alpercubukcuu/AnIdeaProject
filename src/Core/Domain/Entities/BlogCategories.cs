using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class BlogCategories : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }

	public Guid UrlId { get; set; }
	public UrlRecord Url { get; set; }

	public Guid LanguageId { get; set; }
	public Languages Language { get; set; }

	public ICollection<Blogs> Blogs { get; set; }

}
