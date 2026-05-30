using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml.Media;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BetterAbout
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : WindowEx
    {
        public MainWindow()
        {
            InitializeComponent();
            contentFrame.Content = new SummaryPage();
            MicaBackdrop micaAlt = new()
            {
                Kind = MicaKind.BaseAlt
            };
            SystemBackdrop = micaAlt;

        }
    }
}
