using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Game : Form
    {
        static string[] words;
        static string current_word;
        static string show_text;
        static int count_success;
        static int count_spaces;
        static int count_lives;
        static PictureBox[] lives_image;

        public Game()
        {
            InitializeComponent();

            words = new string[] { "новый год", "шампанское", "дед мороз", "оливье", "подарок", "ёлочка", "бой курантов", "праздник" };
            current_word = "";
            show_text = "";
            count_success = 0;
            count_spaces = 0;
            lives_image = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            count_lives = lives_image.Length;   
        }

      public  static void  start_game(RichTextBox wordArea)
        {
            Random random = new Random();
            int word = random.Next(0, words.Length);
            current_word = words[word];
            show_text = get_show_text(current_word);
            wordArea.Text = show_text;
            centering_text(wordArea);
            count_lives = lives_image.Length;
        }
       public static void start_game(RichTextBox wordArea, PictureBox[] lives_image)
        {
            start_game(wordArea);
            var bmp = new Bitmap(Properties.Resources.подарок);
            for(int i = 0; i < lives_image.Length; i++)
            {
                lives_image[i].SizeMode = PictureBoxSizeMode.Zoom;
                lives_image[i].Image = bmp;
            }
            
        }
        public static string get_show_text(string word)
        {
            string y = "";
            for(int j = 0; j < word.Length; j++)
            {
                
                if(word[j] == ' ')
                {
                    y += "  ";
                    count_spaces++;
                } else
                {
                    y += "_ ";
                }
            }
            return (y);
        }
        public static void centering_text(RichTextBox word_area)
        {
            word_area.SelectAll();
            word_area.SelectionAlignment = HorizontalAlignment.Center;
        }
        public static bool is_contains(string word, char symbol)
        {
            
            for(int u = 0; u < word.Length; u++)
            {
                if(word[u] == symbol)
                {
                    return true;
                }
            }
            return false;
        }
        public static string get_new_show_text(string word, char symbol, string old_show_text)
        {
            string y = "";
            for(int e = 0; e < old_show_text.Length; e += 2)
            {
                if(old_show_text[e/2] == symbol)
                {
                    y += symbol + ' ';
                    count_success++;
                } else
                {
                    y += old_show_text[e] + " ";
                }
            }
            return y ;
        }
        public static void button_symbol_click(RichTextBox wordArea, char symbol, Button cur_button, Button startButton)
        {

        }
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
