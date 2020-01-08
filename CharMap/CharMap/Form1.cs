using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CharMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        HashSet<char> chars = new HashSet<char>();
        
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> fileNames = new List<string>(50);
            
            foreach (string file in Directory.EnumerateFiles(tbxFolder.Text, "*.*", SearchOption.AllDirectories))
            {
                // fileNames.Add(file);
                //    Console.WriteLine(file);
                string text = File.ReadAllText(file);
                SeekChar(text);
            }

            List<char> list = chars.ToList();
            list.Sort();
             
            tbxChars.Text = new string(list.ToArray());


        }

        private void SeekChar(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (!chars.Contains(text[i])) {
                    chars.Add(text[i]);
                }
            }
        }
    }
}
