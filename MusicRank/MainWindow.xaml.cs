using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;


namespace MusicRank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 




    public partial class MainWindow : Window
    {
        private ObservableCollection<Song> listofSongs { get; set; }
        enum ifWorks { notWorks, Works };
        ifWorks value = ifWorks.Works;


        public MainWindow()
        {
            InitializeComponent();
            listofSongs = new ObservableCollection<Song>();
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {

            Author author = new Author();
            author.name = this.nameTextBox.Text;
            author.surname = this.surnameTextBox.Text;
            author.whatPlays = "music";

            Song song = new Song();
            song.author = author;
            song.title = this.titleTextBox.Text;

            try
            {
                song.mark = Int32.Parse(this.markTextBox.Text);
            }
            catch (FormatException)
            {

                this.infoLabel.Content = "Mark is not integer";
            }


            if (song.title.Length == 0)
            {
                value = ifWorks.notWorks;
                this.infoLabel.Content = "Add title !";
            }
            else
            {
                value = ifWorks.Works;
                this.infoLabel.Content = author.Myname();
            }




            if (value == ifWorks.Works)
                listofSongs.Add(song);


        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {


            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Song>));
            using (StreamWriter wr = new StreamWriter("listofSongs.xml"))
            {
                xs.Serialize(wr, listofSongs);
            }


            this.infoLabel.Content = "Saved !";




        }
    }
}
