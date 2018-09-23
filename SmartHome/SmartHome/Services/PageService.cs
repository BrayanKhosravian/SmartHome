using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Interfaces;
using Xamarin.Forms;

namespace SmartHome.Services
{
    class PageService : IPageService
    {
        private readonly Page _page;
        public PageService(Page page)
        {
            _page = page;
        }

        public async Task NavigationPushAsync(Page nextPage)
        {
            await _page.Navigation.PushAsync(nextPage);
        }

        public async Task DisplayAlert(string title, string content, string ok)
        {
            await _page.DisplayAlert(title, content, ok);
        }
    }
}
