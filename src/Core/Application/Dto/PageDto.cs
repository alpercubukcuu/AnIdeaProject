using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class PageDto: BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }

        public Guid CategoryId { get; set; }
        public PageCategoryDto Category { get; set; }

        public bool IsActive { get; set; }
        public DateTime PublishedDate { get; set; }

        // SEO için ekstra özellikler
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }


        public string LanguageCode { get; set; }
    }
}
