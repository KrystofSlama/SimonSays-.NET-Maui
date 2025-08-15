using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSays.Views;

public partial class OptionsPage : ContentPage
{
    public OptionsPage()
    {
        InitializeComponent();
    }

    private void OnBtnResetClicked(object sender, EventArgs e)
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "dataScore.json");

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Overwrite the file with an empty JSON array
            File.WriteAllTextAsync(filePath, "[]");
            Console.WriteLine("JSON file cleared.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }  
    }
}