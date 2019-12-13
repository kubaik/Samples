using Avalonia;
using Avalonia.Markup.Xaml;

namespace MyApp_MVVM
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}