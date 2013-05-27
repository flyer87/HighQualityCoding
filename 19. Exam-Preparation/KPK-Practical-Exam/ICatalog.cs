using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace FreeContentCatalog
{
    public interface ICatalog
    {
        /// <summary>
        /// Adds an item to the catalog
        /// </summary>
        /// <param name="contentItem">Content item to add</param>
        /// <remarks>If the item already exists, it is added again (duplicates are accepted)</remarks>
        void Add(IContentItem contentItem);

        /// <summary>
        /// Finds a list of items matching the given title
        /// </summary>
        /// <param name="title">Title to search</param>
        /// <param name="numberOfContentElementsToList">The number of the listed items</param>
        /// <exception cref=""></exception>
        /// <remarks>The listed items are ordered in ascending order by their text representation</remarks>
        IEnumerable<IContentItem> GetListContent(string title, int numberOfContentElementsToList);

        /// <summary>
        /// Updates the URL of all items matching the specified old URL
        /// </summary>
        /// <param name="oldUrl">Old URL to update</param>
        /// <param name="newUrl">New URL to change with Old URL</param>
        /// <returns>Number of updated items</returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}