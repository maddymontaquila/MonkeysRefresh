using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;
using MonkeyFinder.Model;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Collections.Generic;

namespace MonkeyFinder.ViewModel
{
    public class MonkeysViewModel : BaseViewModel
    {
        public Command GetMonkeysCommand { get; }
        public ObservableCollection<Monkey> Monkeys { get; }

        public MonkeysViewModel()
        {
            Title = "Monkey Finder";
            Monkeys = new ObservableCollection<Monkey>();
            GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
        }

        async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                Monkey[] monkeys = null;

                

                Monkeys.Clear();
                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                if (Application.Current?.MainPage == null)
                    return;

                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
