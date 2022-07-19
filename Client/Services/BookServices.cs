using System;
using System.Collections.Generic;
using System.Text;
using Books.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Client.Services
{
    class BookServices
    {
        string API_Url = "http://localhost:52835";

        public List<Book> GetAllBook() {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(API_Url);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/JSON");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("api/Books/GetAllBooks").Result;
                List<Book> listBook = JsonConvert.DeserializeObject<List<Book>>(response.Content.ReadAsStringAsync().Result);
                return listBook;

            }
        }

        public List<Book> GetBookByAuthor(string authorName)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(API_Url);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/JSON");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync($"api/Books/GetBooksByAuthor/{authorName}").Result;
                List<Book> listBook = JsonConvert.DeserializeObject<List<Book>>(response.Content.ReadAsStringAsync().Result);
                return listBook;

            }
        }
        public void AddBook(Book book) {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(API_Url);
                var contentData = new StringContent(JsonConvert.SerializeObject(book),System.Text.Encoding.UTF8,"application/JSON");
                HttpResponseMessage response = client.PostAsync("api/Books/AddBook",contentData).Result;
            }
        }

        public void EditBook(int bookId, string BookName, int Price)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(API_Url);
                
                HttpResponseMessage response = client.PutAsync($"api/Books/EditBook?bookId={bookId}&BookName={BookName}&Price={Price}", null).Result;
            }
        }

        public void DeleteBook(int bookId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(API_Url);

                HttpResponseMessage response = client.DeleteAsync($"api/Books/DeleteBook/{bookId}").Result;
            }
        }
    }
}
