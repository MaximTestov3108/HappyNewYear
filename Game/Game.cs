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

            words = new string[] { "новый год", "шампанское", "дед мороз", "оливье", "подарок", "ёлочка", "бой курантов", "праздник", "мандарин", "декабрь" };
            current_word = "";
            show_text = "";
            count_success = 0;
            count_spaces = 0;
            lives_image = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            count_lives = lives_image.Length;

            start_game(richTextBox1, lives_image);
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
                if(word[e/2] == symbol)
                {
                    y += symbol + " ";
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
            bool is_const = is_contains(current_word, symbol);
            if (is_const)
            {
                show_text = get_new_show_text(current_word, symbol, show_text);
                wordArea.Text = show_text;
                centering_text(wordArea);
            } else
            {
                count_lives--;
                lives_image[count_lives].Image = null;
               
            }
            cur_button.Enabled = false;
            if(count_lives == 0)
            {
                using(Loss L = new Loss())
                {
                    L.ShowDialog();
                }
            } else if((count_spaces + count_success) == current_word.Length)
            {
                using(Success S = new Success())
                {
                    S.ShowDialog();
                }
            }
        }
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'а', button1, button34);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'б', button2, button34);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'в', button8, button34);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'г', button6, button34);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'д', button3, button34);
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'е', button26, button34);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'ё', button10, button34);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'ж', button9, button34);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'з', button11, button34);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'и', button12, button34);
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'й', button13, button34);
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'к', button27, button34);

        }

        private void Button14_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'л', button14, button34);
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'м', button15, button34);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'н', button4, button34);
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'о', button17, button34);
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'п', button16, button34);
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'р', button28, button34);
        }

        private void Button33_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'с', button33, button34);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'т', button7, button34);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'у', button5, button34);
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'ф', button19, button34);
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'х', button18, button34);
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'ц', button20, button34);
        }

        private void Button32_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'ч', button32, button34);
        }

        private void Button30_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'ш', button30, button34);
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'щ', button21, button34);
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'ь', button23, button34);
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'ы', button22, button34);
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'ъ', button24, button34);
        }

        private void Button25_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'э', button25, button34);
        }

        private void Button31_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'ю', button31, button34);
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            button_symbol_click(richTextBox1, 'я', button29, button34);
        }

        private void Button34_Click(object sender, EventArgs e)
        {
            start_game(richTextBox1, lives_image);

            Button[] buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22,button23, button24, button25, button26, button27, button28, button29,button30, button31,button32, button33};

            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Enabled = true;
            }
        }

        private void Button35_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
