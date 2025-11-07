using GiphyDotNet.Manager;
using GiphyDotNet.Model.Parameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект_Нежурин_Дакуко__Бибилотека_
{
    public class URLGiphy
    {
            MainPage MainPage = new MainPage();
            public async Task SearchGifsWithWrapperAsync(string query)
            {
                Giphy giphy = new Giphy("sTLKYQidWKfLjT6KVOss8JqjdBBKZQla");
                var searchParameter = new SearchParameter
                {
                    Query = query,
                    Limit = 1 // Optional: limit the number of results
                };

                var gifResult = await giphy.GifSearch(searchParameter);

                foreach (var gif in gifResult.Data)
                {
                    MainPage.syrURl = gif.Images.Original.Url;
                MessageBox.Show(MainPage.syrURl);
            }
            }
        }
}
