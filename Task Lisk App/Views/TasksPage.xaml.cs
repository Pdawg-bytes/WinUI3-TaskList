using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using System;
using System.Diagnostics;
using Microsoft.UI.Xaml.Controls;
using Task_Lisk_App.ViewModels;

namespace Task_Lisk_App.Views;

public sealed partial class TasksPage : Page
{
    public TasksViewModel ViewModel
    {
        get;
    }

    // Initializes ViewModel
    public TasksPage()
    {
        ViewModel = App.GetService<TasksViewModel>();
        InitializeComponent();
    }

    // Event handler for "Edit" button on Task page
    private void EditTask_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        
    }

    // Event handler for "Add" button on Task page
    private async void AddTask_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        // Sets content dialog
        ContentDialog dialog = new CreateTaskDialog();
        dialog.CloseButtonStyle = (Style)Application.Current.Resources["ButtonStyle1"];
        dialog.XamlRoot = this.XamlRoot;

        // Stores result for use in statement
        var result = await dialog.ShowAsync();
        
        // Statement to manage state detection
        if (result == ContentDialogResult.Primary)
        {
            SuccessBar.IsOpen = true;
            string poctext = (string)dialog.Tag;
            pocText.Text = poctext;
            CancelBar.IsOpen = false;
            // Waits 3 seconds then hides bar again
            await Task.Delay(TimeSpan.FromSeconds(3));
            SuccessBar.IsOpen = false;
        }
        else
        {
            CancelBar.IsOpen = true;
            SuccessBar.IsOpen = false;
            // Waits 3 seconds then hides bar again
            await Task.Delay(TimeSpan.FromSeconds(3));
            CancelBar.IsOpen = false;
        }
    }
}

