using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Win32;

namespace Course_Work
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Message.FillDictionary(Message.keyValues_ru, Message.letters_ru);
            Message.FillDictionary(Message.keyValues_RU, Message.letters_RU);

        }

        // Кнопка для выбора текстового файла:
        private void SelectFile_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFile.ShowDialog() == true)
            {
                using (StreamReader readText = new StreamReader(openFile.FileName, System.Text.Encoding.UTF8))
                {
                    InputBox.Text = readText.ReadToEnd();
                }
            }
        }

        //  Кнопка для расшифровки сообщения:
        private void Decode_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.KeyValidation(KeyBox.Text))
            {
                Message message = new Message(InputBox.Text, KeyBox.Text.ToLower());
                ResultBox.Text = message.Decode();
            }
        }
        // Кнопка для шифровки сообщения:
        private void Encode_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.KeyValidation(KeyBox.Text))
            {
                Message message = new Message(InputBox.Text, KeyBox.Text.ToLower());
                ResultBox.Text = message.Encode();
            }
        }

        // Кнопка для сохранения файла:
        private void SaveFile_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text file (*.txt)|*.txt";
            if (saveFile.ShowDialog() == true)
            {
                File.WriteAllText(saveFile.FileName, ResultBox.Text);
            }
        }

        // Валидация ключа:
        public static bool KeyValidation(string key)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
            {
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBox.Show("Ключ не введён", "Ошибка", button, icon);
                return false;
            }
            foreach (var c in key)
            {
                if (!Message.keyValues_ru.ContainsKey(c) && !Message.keyValues_RU.ContainsKey(c))
                {
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBox.Show("Ключ должен содержать только буквы русского алфавита", "Ошибка", button, icon);
                    return false;
                }
            }
            return true;
        }
    }
}
