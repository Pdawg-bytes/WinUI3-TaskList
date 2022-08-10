using AppUIBasics.ControlPages;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using System;
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
        ContentDialog dialog = new ContentDialog();

        // Defines properties
        dialog.XamlRoot = this.XamlRoot;
        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        dialog.Title = "Create a task";
        dialog.PrimaryButtonText = "Add";
        dialog.CloseButtonText = "Cancel";
        dialog.DefaultButton = ContentDialogButton.Primary;
        dialog.Content = new ContentDialogContent();

        // Stores result for use in statement
        var result = await dialog.ShowAsync();
        
        // Statement to manage state detection
        if (result == ContentDialogResult.Primary)
        {
            SuccessBar.IsOpen = true;
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

