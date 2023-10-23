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
    private async void EditTask_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        ContentDialog dialog = new CreateTaskDialog();
        dialog.CloseButtonStyle = (Style)Application.Current.Resources["ButtonStyle1"];
        dialog.XamlRoot = this.XamlRoot;

        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            SuccessBar.IsOpen = true;
            string addNewTask = (string)dialog.Tag;
            CancelBar.IsOpen = false;
            
            TestView.Items[TestView.SelectedIndex] = addNewTask;

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

    // Event handler for "Add" button on Task page
    private async void AddTask_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        // Sets content dialog
        ContentDialog dialog = new CreateTaskDialog();
        dialog.CloseButtonStyle = (Style)Application.Current.Resources["ButtonStyle1"];
        dialog.XamlRoot = this.XamlRoot;

        // Stores result for use in statement
        var result = await dialog.ShowAsync();

        // Statement to manage state detection and string handler
        if (result == ContentDialogResult.Primary)
        {
            SuccessBar.IsOpen = true;
            string addNewTask = (string)dialog.Tag;
            CancelBar.IsOpen = false;
            TestView.Items.Add(addNewTask);
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

    // Handles removal of items in the List.
    private void RemoveTask_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e) // Event handler
    {
        // Looking at if the list is anything more than 0 items, they can be removed
        while (TestView.SelectedIndex > -1)
        {
            // Function to remove items
            TestView.Items.RemoveAt(TestView.SelectedIndex);
        }
    }
}

