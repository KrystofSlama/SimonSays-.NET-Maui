namespace SimonSays.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        CallingJson();
    }

    // Buttons
    private async void OnBtnPlayClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Play");
    }
    private async void OnBtnScoreClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Score");
    }
    private async void OnBtnOptionsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Options");
    }

    private async Task CallingJson()
    {
        await CreateDataScore();
    }
    // Creating JSON for scores managment
    private async Task CreateDataScore()
    {
        string folderPath = FileSystem.AppDataDirectory;
        string filePath = Path.Combine(folderPath, "dataScore.json");
        // Check if th folder exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        // Check if the file already exists
        if (!File.Exists(filePath))
        {
            string emptyJsonArray = "[]";
            await File.WriteAllTextAsync(filePath, emptyJsonArray);
            Console.WriteLine($"dataScore.json file created successfully. path: {folderPath}");
        }
        else
        {
            Console.WriteLine($"dataScore.json already exists. path: {folderPath}");
        }
    }
}