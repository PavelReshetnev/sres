using System;
using System.Net.Http;
using System.Net.Http.Json;
using Avalonia.Controls;
using System.Text.RegularExpressions;
using Avalonia.Interactivity;

namespace AvaloniaApplication2;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void ButtonClick_A(object sender, RoutedEventArgs e)
    {
        try
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetFromJsonAsync<ResponseModel>("http://localhost:4444/TransferSimulator");
                FieldA.Text = response.FullName;
            }
        }
        catch (Exception exception)
        {
            FieldA.Text = $"Ошибка: {exception.Message}";
        }
    }

    private class ResponseModel
    {
        public string FullName { get; set; }
    }


    private bool ValidCheak(string text)
    {
        Regex regex = new Regex(@"[\p{L}\d\s\W]");
        return !regex.IsMatch(text);
    }
    private void ButtonClick_B(object sender, RoutedEventArgs e)
    {
        FieldB.Text = ValidCheak(FieldA.Text) ? "Валидно" : "Невалидно";
    }
}