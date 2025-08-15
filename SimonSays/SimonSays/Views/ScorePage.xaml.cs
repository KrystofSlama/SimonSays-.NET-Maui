using SimonSays.Resources.Models; // Import the Score class
using System.Text.Json; // For JSON deserialization

namespace SimonSays.Views;

public partial class ScorePage : ContentPage
{
    public ScorePage()
    {
        InitializeComponent();
        PopulateScores();
    }

    private async void PopulateScores()
    {
        string folderPath = FileSystem.AppDataDirectory;
        string filePath = Path.Combine(folderPath, "dataScore.json");
        
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found at: " + filePath);
            return;
        }
        string jsonContent = await File.ReadAllTextAsync(filePath);
        List<Score> scores = JsonSerializer.Deserialize<List<Score>>(jsonContent) ?? new List<Score>();
        
        ScoreGrid.RowDefinitions.Clear();
        ScoreGrid.Children.Clear();
       

        // Add rows dynamically
        for (int i = 0; i < scores.Count; i++)
        {
            
            ScoreGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            var nameLabel = new Label
            {
                Text = scores[i].PlayerName,
                FontSize = 20,
                TextColor = Colors.Black,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start
            };
            
            var scoreLabel = new Label
            {
                Text = scores[i].PlayerScore.ToString(),
                FontSize = 20,
                TextColor = Colors.Black,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End
            };
            
            ScoreGrid.Children.Add(nameLabel);
            Grid.SetRow(nameLabel, i);
            Grid.SetColumn(nameLabel, 0); 
            
            ScoreGrid.Children.Add(scoreLabel);
            Grid.SetRow(scoreLabel, i);
            Grid.SetColumn(scoreLabel, 1);
            
        }
    }
}