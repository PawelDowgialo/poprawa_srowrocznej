using System;
using System.IO;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace aplikacjamuzyczna;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private int pageIndex = 0;
    private void PreviousButton_OnClick(object? sender, RoutedEventArgs e)
    {
        pageIndex--;
        var dataPath = Path.Combine(Environment.CurrentDirectory, "assets/Data.txt");
                    
        var allTextLines = File.ReadAllLines(dataPath);
        if (pageIndex < 0)
        {
            pageIndex = allTextLines.Length/6;
        }
        BandNameTextBlock.Text = allTextLines[0 + (pageIndex * 6)];
        TitleTextBlock.Text = allTextLines[1 + (pageIndex * 6)];
        SongsNumberTextBlock.Text = allTextLines[2 + (pageIndex * 6)];
        YearTextBlock.Text = allTextLines[3 + (pageIndex * 6)];
        
        
    }

    private void NextButton_OnClick(object? sender, RoutedEventArgs e)
    {
        pageIndex++;
        var dataPath = Path.Combine(Environment.CurrentDirectory, "assets/Data.txt");
        
        var allTextLines = File.ReadAllLines(dataPath);
        if (pageIndex >= allTextLines.Length/6)
        {
            pageIndex = 0;
        }
        BandNameTextBlock.Text = allTextLines[0 + (pageIndex * 6)];
        TitleTextBlock.Text = allTextLines[1 + (pageIndex * 6)];
        SongsNumberTextBlock.Text = allTextLines[2 + (pageIndex * 6)];
        YearTextBlock.Text = allTextLines[3 + (pageIndex * 6)];
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        var dataPath = Path.Combine(Environment.CurrentDirectory, "assets/Data.txt");
        
        var allTextLines = File.ReadAllLines(dataPath);
        
        BandNameTextBlock.Text = allTextLines[0 + (pageIndex * 6)];
        TitleTextBlock.Text = allTextLines[1 + (pageIndex * 6)];
        SongsNumberTextBlock.Text = allTextLines[2 + (pageIndex * 6)];
        YearTextBlock.Text = allTextLines[3 + (pageIndex * 6)];
        DownloadsTextBlock.Text = allTextLines[4 + (pageIndex * 6)];
    }

    private void DownloadsButton_OnClick(object? sender, RoutedEventArgs e)
    {
        var dataPath = Path.Combine(Environment.CurrentDirectory, "assets/Data.txt");
        
        var allTextLines = File.ReadAllLines(dataPath);
        var a = long.Parse(allTextLines[4 + (pageIndex * 6)])+1;
        allTextLines[4 + (pageIndex * 6)] = a.ToString();
        File.WriteAllLines(dataPath, allTextLines);
        DownloadsTextBlock.Text = allTextLines[4 + (pageIndex * 6)];
    }
}