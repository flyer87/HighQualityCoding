using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace FreeContentCatalog
{
    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContentItem> url;
        private OrderedMultiDictionary<string, IContentItem> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContentItem>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContentItem>(allowDuplicateValues);
        }

        public int Count
        {
            get
            {
                return this.title.KeyValuePairs.Count;
            }
        }

        public void Add(IContentItem content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public IEnumerable<IContentItem> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContentItem> contentToList =
                from c in this.title[title]
                select c;

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            int updatedElementsCount = 0;

            List<IContentItem> contentToList = this.url[oldUrl].ToList();

            foreach (ContentItem content in contentToList)
            {
                this.title.Remove(content.Title, content);
                updatedElementsCount++; 
            }

            this.url.Remove(oldUrl);

            foreach (IContentItem content in contentToList)
            {
                content.URL = newUrl;
            }
            
            foreach (IContentItem content in contentToList)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return updatedElementsCount;
        }
    }
}
