using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Nyaralas> nyaralas = new List<Nyaralas>();
            string[] strings = File.ReadAllLines("nyaralas.txt");
            foreach (string s in strings)
            {
                string[] strings1 = s.Split(',');
                Nyaralas nyaralas1 = new Nyaralas(strings1[0], strings1[1], strings1[2], strings1[3], strings1[4], strings1[5], strings1[6]);
                nyaralas.Add(nyaralas1);
            }

            Dictionary<string, double> keyValuePairs = new Dictionary<string, double>();

            foreach (var item in nyaralas)
            {
                if (keyValuePairs.ContainsKey(item.nev))
                {
                    if (item.kedvezmeny == "igen")
                    {
                        keyValuePairs[item.nev] += item.ar * item.napok * item.emberek * 0.85;
                    }
                    else
                    {

                        keyValuePairs[item.nev] += item.ar * item.napok * item.emberek;
                    }
                }
                else
                {
                    if (item.kedvezmeny == "igen")
                    {
                        keyValuePairs.Add(item.nev, item.ar * item.napok * item.emberek * 0.85);
                    }
                    else
                    {

                        keyValuePairs.Add(item.nev, item.ar * item.napok * item.emberek);
                    }
                }

            }

            keyValuePairs = keyValuePairs.OrderByDescending(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value);

            foreach (var kv in keyValuePairs)
            {
                dataGridView1.Rows.Add(kv.Key, kv.Value);
            }

            label2.Text = "A legkevesebbet költő személy: " + keyValuePairs.Keys.Last() + ", összeg: " + keyValuePairs.Values.Last() + " Ft";

            Dictionary<string, int> db = new Dictionary<string, int>();

            foreach (var item in nyaralas)
            {
                if (db.ContainsKey(item.nev))
                {
                    db[item.nev]++;
                }
                else
                {
                    db[item.nev] = 1;
                }
            }
            foreach (var item in db)
            {
                if (item.Value >= 2)
                {
                    string text = "A neve legalább kétszer szerepelt a listában:" + item.Key;
                    listBox1.Items.Add(text);
                }

            }
        }
    }
}
