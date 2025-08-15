namespace SimonSays;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("Score", typeof(Views.ScorePage));
        Routing.RegisterRoute("Play", typeof(Views.Play));
        Routing.RegisterRoute("Options", typeof(Views.OptionsPage));
    }
}