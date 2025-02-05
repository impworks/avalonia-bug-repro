using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MiniRepro.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AuthorizedUserName))]
    [NotifyCanExecuteChangedFor(nameof(LogInCommand))]
    [NotifyCanExecuteChangedFor(nameof(LogOutCommand))]
    private UserAccount? _authResult;
    
    // !!! The length of the placeholder "Hello world" defines how much of the text will be shown the first time
    public string AuthorizedUserName => AuthResult?.UserName ?? "Hello World";

    [RelayCommand]
    private void LogIn() => AuthResult = new UserAccount("foobar@example.com");

    [RelayCommand]
    private void LogOut() => AuthResult = null;
}

public record UserAccount(string UserName);
