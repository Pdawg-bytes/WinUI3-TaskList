using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Task_Lisk_App.Views;
public sealed partial class CreateTaskDialog : ContentDialog
{
    public CreateTaskDialog()
    {
        this.InitializeComponent();
    }

    string newTask;

    private void newTaskCreate_TextChanged(object sender, TextChangedEventArgs e)
    {
        newTask = newTaskCreate.Text;
        this.Tag = newTask;
    }
}