using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace RebusOps
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
       


        public MainWindow()
        {
            InitializeComponent();

        }

        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                    rebusImage.Source = bitmap;
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                }
                

            }
        }

        private void saveImageButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmap = rebusImage.Source as BitmapImage;
            if (bitmap != null)
            {
                imageListBox.Items.Add(bitmap);

                rebusImage.Source = null;
                imageListBox.Items.Add(imageDescriptionTextBox.Text);
                //// Очистка TextBox
                imageDescriptionTextBox.Clear();
               
            }

        }
        private void imageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (imageListBox.SelectedItem != null)
            {
                BitmapImage bitmap = imageListBox.SelectedItem as BitmapImage;
                if (bitmap != null)
                {
                    rebusImage.Source = bitmap;
                }
            }
            /////////////////////////////////
            string selectedItem = imageListBox.SelectedItem as string;
            // Отображение выбранного элемента в другом TextBox
            imageDescriptionTextBox.Text = selectedItem;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (imageListBox.SelectedItem != null)
            {

                imageListBox.Items.Remove(imageListBox.SelectedItem);
                rebusImage.Source = null;
                // удаление текста imageDescriptionTextBox.Text = "";
           
            }
        }
    }
}


    


