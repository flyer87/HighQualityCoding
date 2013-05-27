using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeContentCatalog;
using System.Linq;

namespace FreeContentCatalog.Tests
{
    [TestClass]
    public class FreeContentCatalogTests
    {
        [TestMethod]
        public void TestMethodAddOneItem()
        {
            Catalog catalog = new Catalog();
            ContentItem item1 = new ContentItem(
                ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"
                });
            catalog.Add(item1);

            Assert.AreEqual(1, catalog.Count);
        }

        [TestMethod]
        public void TestMethodAddDuplicatedBooks()
        {
            Catalog catalog = new Catalog();
            ContentItem item1 = new ContentItem(
                ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(item1);
            catalog.Add(item1);

            ContentItem item2 = new ContentItem(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(item2);

            Assert.AreEqual(3, catalog.Count);
        }

        [TestMethod]
        public void TestMethodAddMultipleItems()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(book);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro Movie C#", "Movie author", "127632223892", "http://www.intromovies.info" });
            catalog.Add(movie);

            ContentItem book2 = new ContentItem(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(book2);

            ContentItem song = new ContentItem(ContentType.Song,
                new string[] {"Intro Song C#", "Song author", "99992223892", 
                    "http://www.introsong.info"});
            catalog.Add(song);

            Assert.AreEqual(4, catalog.Count);
        }

        [TestMethod]
        public void TestMethodGetListContentOneItem()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(book);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro Movie C#", "Movie author", "127632223892", "http://www.intromovies.info" });
            catalog.Add(movie);

            ContentItem song = new ContentItem(ContentType.Song,
                new string[] { "Intro Song C#", "Song author", "99992223892", "http://www.introsong.info" });
            catalog.Add(song);

            var result = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestMethodGetListContentMissingItem()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(book);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] {"Intro Movie C#", "Movie author", "127632223892", 
                    "http://www.intromovies.info"});
            catalog.Add(movie);

            ContentItem song = new ContentItem(ContentType.Song,
                new string[] {"Intro Song C#", "Song author", "99992223892", 
                    "http://www.introsong.info"});
            catalog.Add(song);

            var result = catalog.GetListContent("Missing C#", 10);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void TestMethodGetListContentDupicatedTitles()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(book);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] {"Intro Movie C#", "Movie author", "127632223892", 
                    "http://www.intromovies.info"});
            catalog.Add(movie);

            ContentItem song = new ContentItem(ContentType.Song,
                new string[] {"Intro C#", "Song author", "99992223892", 
                    "http://www.introsong.info"});
            catalog.Add(song);

            var result = catalog.GetListContent("Intro C#", 10);

            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void TestMethodGetListContentEmptyCatalog()
        {
            Catalog catalog = new Catalog();

            var result = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void TestMethodUpdateContentOneItemExisitngUrl()
        {
            Catalog catalog = new Catalog();
            ContentItem book = new ContentItem(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(book);

            catalog.UpdateContent("http://www.introprogramming.info", "http://newurel.com");
            var result = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual("http://newurel.com", result.First().URL);
        }

        [TestMethod]
        public void TestMethodUpdateContentOneItemNonExisitngUrl()
        {
            Catalog catalog = new Catalog();
            ContentItem book = new ContentItem(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(book);

            catalog.UpdateContent("http://nonexistingUrl.com", "http://newurel.com");

            var result = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual("http://www.introprogramming.info", result.First().URL);
        }

        [TestMethod]
        public void TestMethodUpdateContentMultipleItems()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(book);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] {"Intro C#", "Movie author", "127632223892", 
                    "http://www.intromovies.info"});
            catalog.Add(movie);

            ContentItem book2 = new ContentItem(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(book2);

            ContentItem song = new ContentItem(ContentType.Song,
                new string[] {"Intro C#", "Song author", "99992223892", 
                    "http://www.introsong.info"});
            catalog.Add(song);

            catalog.UpdateContent("http://www.introprogramming.info", "http://newUrl.com");

            var result = catalog.GetListContent("Intro C#", 10);

            Assert.AreEqual("http://newUrl.com", result.First().URL);
            Assert.AreEqual("http://newUrl.com", result.Skip(1).First().URL);
        }

        [TestMethod]
        public void TestMethodUpdateContentSetTwiceSameUrl()
        {
            Catalog catalog = new Catalog();

            ContentItem book = new ContentItem(ContentType.Book,
                new string[] {"Intro C#", "S.Nakov", "12763892", 
                    "http://www.introprogramming.info"});
            catalog.Add(book);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] {"Intro C#", "Movie author", "127632223892", 
                    "http://www.intromovies.info"});
            catalog.Add(movie);

            catalog.UpdateContent("http://www.introprogramming.info", "http://www.intromovies.info");
            var result = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual("http://www.intromovies.info", result.First().URL);
            Assert.AreEqual("http://www.intromovies.info", result.Skip(1).First().URL);

            catalog.UpdateContent("http://www.introprogramming.info", "http://www.intromovies.info");
            result = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual("http://www.intromovies.info", result.First().URL);
            Assert.AreEqual("http://www.intromovies.info", result.Skip(1).First().URL);
        }
    }
}
