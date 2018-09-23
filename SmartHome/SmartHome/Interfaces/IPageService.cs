using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartHome.Interfaces
{
    public interface IPageService
    {
        Task NavigationPushAsync(Page nextPage);
        Task DisplayAlert(string title, string content, string ok);
    }
}