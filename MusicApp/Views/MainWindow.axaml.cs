using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using MusicApp.ViewModels;
using ReactiveUI;

namespace MusicApp.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(action =>
            action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }

    private async Task DoShowDialogAsync(IInteractionContext<MusicStoreViewModel, AlbumViewModel?> interaction)
    {
        MusicStoreWindow dialog = new MusicStoreWindow();
        dialog.DataContext = interaction.Input;

        AlbumViewModel? result = await dialog.ShowDialog<AlbumViewModel?>(this);
        interaction.SetOutput(result);
    }
}