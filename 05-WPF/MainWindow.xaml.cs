using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using HomeLibrary;
using System;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
		private readonly ObservableCollection<Book> books = new ObservableCollection<Book>(MyBookCollection.GetMyCollection());
		public MainWindow()
        {
            InitializeComponent();
			lbBooks.ItemsSource = books;
		}		

		private void Add(object sender, RoutedEventArgs e)
		{
			books.Add(new Book());			
		}

		private void Delete(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show(
				"This book will be removed",
				"Book removal",
				MessageBoxButton.OKCancel,
				MessageBoxImage.Warning,
				MessageBoxResult.Cancel) == MessageBoxResult.OK)
			{
				books.Remove(lbBooks.SelectedItem as Book);
			}

		}

		private void TitleChanged(object sender, RoutedEventArgs e)
		{
			(lbBooks.SelectedItem as Book).Title = (sender as TextBox).Text;	
		}

		private void AuthorChanged(object sender, RoutedEventArgs e)
		{
			(lbBooks.SelectedItem as Book).Author = (sender as TextBox).Text;
		}
		private void IsReadChanged(object sender, RoutedEventArgs e)
		{
			(lbBooks.SelectedItem as Book).IsRead = (sender as CheckBox).IsChecked ?? false;
		}
		private void YearChanged(object sender, RoutedEventArgs e)
		{
			(lbBooks.SelectedItem as Book).Year = int.Parse((sender as TextBox).Text);
		}
		private void FormatChanged(object sender, RoutedEventArgs e)
		{
				(lbBooks.SelectedItem as Book).Format =
				(BookFormat)Enum.Parse(typeof(BookFormat),
					(sender as ComboBox)
					.SelectedValue
					.ToString()
					.Split(' ')
					[1]
				);
		}

		private void Select(object sender, RoutedEventArgs e)
		{
			lbBook.ItemsSource = new ObservableCollection<Book>() { lbBooks.SelectedItem as Book };
		}

		private void Select(object sender, MouseButtonEventArgs e)
		{
			lbBook.ItemsSource = new ObservableCollection<Book>() { lbBooks.SelectedItem as Book };
		}

		private void SliderChanged(object sender, RoutedEventArgs e)
		{
			topButton.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0, byte.Parse((sender as TextBox).Text), 0));
		}		
	}
}
