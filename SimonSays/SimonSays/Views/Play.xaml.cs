using System.Text.Json;
using SimonSays.Resources.Models;


namespace SimonSays.Views;
public partial class Play
{
    private int _gameScore;    // Score
    private int _gameCycle = 1;     // Round of curent game
    private readonly List<int> _gameArray = new();  // Array of curent round
    private int _pressedBtn;   // Pressed button
    private int _pressedCount; // Count of presses
        
    public Play()
    {
        InitializeComponent();
        BtnRed.IsEnabled = false;
        BtnBlue.IsEnabled = false;
        BtnOrange.IsEnabled = false;
        BtnGreen.IsEnabled = false;
    }
    // Buttons Red, Green, Blue, Orange
    private void GameButtonRed(object sender, EventArgs e)
    {
        _pressedBtn = 1;
        _pressedCount++;
        GameCheck();
    }
    private void GameButtonBlue(object sender, EventArgs e)
    {
        _pressedBtn = 2;
        _pressedCount++;
        GameCheck();
    }
    private void GameButtonOrange(object sender, EventArgs e)
    {
        _pressedBtn = 3;
        _pressedCount++;
        GameCheck();
    }
    private void GameButtonGreen(object sender, EventArgs e)
    {
        _pressedBtn = 4;
        _pressedCount++;
        GameCheck();
    }
    
    private void GameReset()
    {
        _gameScore = 0;
        _gameCycle = 1;
        _gameArray.Clear();
        _pressedCount = 0;
        _pressedBtn = 0;
        
        BtnStart.IsVisible = true;
        BtnStart.IsEnabled = true;
        CurrentScore.Text = "0";
        CurrentPressedCount.Text = "0";
        GameCycleCount.Text = "0";
        LabelPressed.IsVisible = false;
        LabelPressedTwo.IsVisible = false;
        CurrentPressedCount.IsVisible = false;
        GameCycleCount.IsVisible = false;
    }  // Game Reset
    private void OnBtnStartClicked(object sender, EventArgs e)
    {
        BtnStart.IsVisible = false;
        BtnStart.IsEnabled = false;
        BtnRed.IsEnabled = false;
        BtnBlue.IsEnabled = false;
        BtnGreen.IsEnabled = false;
        BtnOrange.IsEnabled = false;
        
        // Creating sequence for game
        _gameArray.Clear();
        int x = _gameCycle;
        while (x >= 1)
        {
            Random rnd = new Random();
            int y = rnd.Next(1, 5);
            _gameArray.Add(y);
            x--;
        }
        
        
        BtnBlink(_gameArray);
        
        GameCycleCount.Text = _gameCycle.ToString();
        CurrentPressedCount.Text = "0";
        LabelPressed.IsVisible = true;
        LabelPressedTwo.IsVisible = true;
        CurrentPressedCount.IsVisible = true;
        GameCycleCount.IsVisible = true;
        
        _gameCycle++;
    }    // After pressing Start
    
    private async void BtnBlink(List<int> gameList)
    {
        for (int i = 0; i < gameList.Count; i++)
        {
            int nowBtnNum = gameList[i];
            // Zesvětlování
            for (float z = 5; z <= 30; z++)
            {
                
                switch (nowBtnNum)
                {
                    case 1:
                        BtnRed.Shadow = new Shadow
                        {
                            Brush = new SolidColorBrush(Colors.Red),
                            Offset = new Point(0, 0),
                            Radius = z,
                            Opacity = 1
                        };
                        await Task.Delay(20);
                        break;
                    
                    case 2:
                        BtnBlue.Shadow = new Shadow
                        {
                            Brush = new SolidColorBrush(Colors.Blue),
                            Offset = new Point(0, 0),
                            Radius = z,
                            Opacity = 1
                        };
                        await Task.Delay(20);
                        break;   
                    
                    case 3:
                        BtnOrange.Shadow = new Shadow
                        {
                            Brush = new SolidColorBrush(Color.FromArgb("#d68100")),
                            Offset = new Point(0, 0),
                            Radius = z,
                            Opacity = 1
                        };
                        await Task.Delay(20);
                        break;
                    
                    case 4:
                        BtnGreen.Shadow = new Shadow
                        {
                            Brush = new SolidColorBrush(Colors.Green),
                            Offset = new Point(0, 0),
                            Radius = z,
                            Opacity = 1
                        };
                        await Task.Delay(20);
                        break;
                }  
                
            }
            // Ztmamování
            for (float z = 30; z >= 5; z--)
            {
                switch (nowBtnNum)
                {
                    case 1:
                        BtnRed.Shadow = new Shadow
                        {
                            Brush = new SolidColorBrush(Colors.Red),
                            Offset = new Point(0, 0),
                            Radius = z,
                            Opacity = 1
                        };
                        await Task.Delay(20);
                        break;
                    
                    case 2:
                        BtnBlue.Shadow = new Shadow
                        {
                            Brush = new SolidColorBrush(Colors.Blue),
                            Offset = new Point(0, 0),
                            Radius = z,
                            Opacity = 1
                        };
                        await Task.Delay(20);
                        break;
                    
                    case 3:
                        BtnOrange.Shadow = new Shadow
                        {
                            Brush = new SolidColorBrush(Color.FromArgb("#d68100")),
                            Offset = new Point(0, 0),
                            Radius = z,
                            Opacity = 1
                        };
                        await Task.Delay(20);
                        break;
                    
                    case 4:
                        BtnGreen.Shadow = new Shadow
                        {
                            Brush = new SolidColorBrush(Colors.Green),
                            Offset = new Point(0, 0),
                            Radius = z,
                            Opacity = 1
                        };
                        await Task.Delay(20);
                        break;
                }
                
            }
        }
        BtnRed.IsEnabled = true;
        BtnBlue.IsEnabled = true;
        BtnGreen.IsEnabled = true;
        BtnOrange.IsEnabled = true;
    }   // Blinking effect
    
    private async void GameCheck()
    {
        CurrentPressedCount.Text = _pressedCount.ToString();
        // Game Over
        if (_gameArray[_pressedCount - 1] != _pressedBtn)
        {
            Vibration.Default.Vibrate(1000);
            Console.WriteLine("-------------------");
            Console.WriteLine("Game Over");
            Console.WriteLine($"Zadaný: {_gameArray[_pressedCount - 1]}, Zmáčklý: {_pressedBtn}");
            Console.WriteLine("-------------------");
            BtnStart.IsEnabled = false;
            BtnRed.IsEnabled = false;
            BtnBlue.IsEnabled = false;
            BtnGreen.IsEnabled = false;
            BtnOrange.IsEnabled = false;
            
            string message = $"Your score: {_gameScore}\nDo you want to save your score? Enter your name (max 8 characters):";
            string playerName = await DisplayPromptAsync("Game Over", message, "Save", "Cancel", "Name", maxLength: 8);

            if (!string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine($"Player {playerName} saved their score of {_gameScore}!");

                // Save the score (optional, depending on your logic)
                await SaveScore(playerName, _gameScore);

                // Navigate back to MainPage
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                Console.WriteLine("Player chose not to save the score.");
                
                GameReset();
            }
        }
        // Checking complete sequence
        else if (_gameArray.Count == _pressedCount)
        {
            // Scoring
            switch (_pressedCount)
            {
                case <= 2:
                    _gameScore += 10;
                    break;
            
                case <= 4:
                    _gameScore += 100;
                    break;
            
                case <= 6:
                    _gameScore += 1000;
                    break;
            
                case <= 8:
                    _gameScore += 10000;
                    break;
            
                default:
                    _gameScore += 100000;
                    break;
            } 
            
            BtnStart.IsEnabled = false;
            BtnRed.IsEnabled = false;
            BtnBlue.IsEnabled = false;
            BtnGreen.IsEnabled = false;
            BtnOrange.IsEnabled = false;
            
            _pressedCount = 0;
            BtnStart.IsVisible = true;
            BtnStart.IsEnabled = true;
        }
        // Increasing score
        else
        {
            switch (_pressedCount)
            {
                case <= 2:
                    _gameScore += 10;
                    break;
            
                case <= 4:
                    _gameScore += 100;
                    break;
            
                case <= 6:
                    _gameScore += 1000;
                    break;
            
                case <= 8:
                    _gameScore += 10000;
                    break;
            
                default:
                    _gameScore += 100000;
                    break;
            } 
        }
        
        
        CurrentScore.Text = _gameScore.ToString();
    }    // Game Checking

    private async Task SaveScore(string playerName, int playerScore)
    {
        string folderPath = FileSystem.AppDataDirectory;
        string filePath = Path.Combine(folderPath, "dataScore.json");

        // Check if the file already exists
        if (!File.Exists(filePath))
        {
            // Create an empty JSON array
            string emptyJsonArray = "[]";
            await File.WriteAllTextAsync(filePath, emptyJsonArray);

            Console.WriteLine($"dataScore.json file created successfully. path: {folderPath}");
        }
        else
        {
            Console.WriteLine($"dataScore.json already exists. path: {folderPath}");
            
        }
        // Saving
        if (File.Exists(filePath))
        {
            string existingJson = await File.ReadAllTextAsync(filePath);
            var scores = JsonSerializer.Deserialize<List<Score>>(existingJson) ?? new List<Score>();

            scores.Add(new Score { PlayerName = playerName, PlayerScore = playerScore });

            string updatedJson = JsonSerializer.Serialize(scores, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, updatedJson);
            Console.WriteLine($"dataScore.json file updated successfully. path: {folderPath}");
        }
        else
        {
            Console.WriteLine("dataScore.json file does not exist. Run CreateJsonFileAsync first.");
        }
    }   // Saving score
}