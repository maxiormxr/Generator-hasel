using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie_1
{
    public partial class Form1 : Form
    {
        //int _iloscGenerowanychHasel;
        //string _loginPrefix;
        //string _login;
        //bool _polskieZnaki = false;
        List<string> kolumna1 = new List<string>();
        List<string> kolumna2 = new List<string>();
        List<string> kolumna3 = new List<string>();
        List<string> kolumna4 = new List<string>();
        List<string> kolumna5 = new List<string>();



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> hasla = new List<string>();
            GeneratorHasla _gh;
            try
            {
                _gh = new GeneratorHasla(Convert.ToInt32(textBox4.Text), checkBox1.Checked);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Długość znaków musi być liczbą, ustawiono domyślną długość hasła na 10 znaków.");
                _gh = new GeneratorHasla(10, checkBox1.Checked);
            }
            string login;
            string haslo;
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(textBox3.Text);
            dataGridView1.Rows.Add("Lp.", "Nazwisko", "Imię", "Login", "Hasło");

            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                login = textBox2.Text + "_" + Convert.ToString(i + 1);
                haslo = _gh.GenerujHaslo(checkBox2.Checked);
                if (!hasla.Contains(haslo))
                {
                    hasla.Add(haslo);
                    dataGridView1.Rows.Add(i + 1, "", "", login, haslo);
                }
                else if (i == 0)
                {
                    i = 0;
                }
                else
                {
                    i--;
                }
            }
            MessageBox.Show("Generowanie haseł zakończone");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked == true)
            //    _polskieZnaki = true;
            //else if (checkBox1.Checked == false)
            //    _polskieZnaki = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //Form2 forma2 = new Form2();
            //forma2.Show();
            string[,] wygenerowaneHasla;
            wygenerowaneHasla = new string[dataGridView1.Columns.Count, dataGridView1.Rows.Count];

            for (int indeksKolumny = 0; indeksKolumny < dataGridView1.Columns.Count; indeksKolumny++)
            {
                for (int indeksWiersza = 0; indeksWiersza < dataGridView1.Rows.Count; indeksWiersza++)
                {
                    wygenerowaneHasla[indeksKolumny, indeksWiersza] = Convert.ToString(dataGridView1[indeksKolumny, indeksWiersza].Value);
                }
            }

            //FileStream fs = new FileStream()
            //StreamWriter zapisywanie = new StreamWriter();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Plik CSV - rozdzielany średnikami|*.csv|Plik tekstowy|*.txt";
            sfd.Title = "Zapisz plik jako...";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string nazwaPlikuBezRozszerzenia = sfd.FileName.Substring(0, sfd.FileName.Count() - 4);
                string rozszerzeniePliku = sfd.FileName.Substring(sfd.FileName.Count() - 4, 4);


                StreamWriter writer = new StreamWriter(sfd.OpenFile(), Encoding.UTF8);
                switch (sfd.FilterIndex)
                {
                    case 1:
                        for (int indeksWiersza = 0; indeksWiersza < dataGridView1.Rows.Count; indeksWiersza++)
                        {
                            for (int indeksKolumny = 0; indeksKolumny < dataGridView1.Columns.Count; indeksKolumny++)
                            {
                                writer.Write(wygenerowaneHasla[indeksKolumny, indeksWiersza] + ";");
                            }
                            writer.Write("\n");
                        }
                        break;
                    case 2:
                        for (int indeksWiersza = 0; indeksWiersza < dataGridView1.Rows.Count; indeksWiersza++)
                        {
                            string liniaTekstu = "";
                            //for (int indeksKolumny = 0; indeksKolumny < dataGridView1.Columns.Count; indeksKolumny++)
                            //{
                            //    liniaTekstu += (wygenerowaneHasla[indeksKolumny, indeksWiersza] + "\t");
                            //    writer.Write(liniaTekstu);
                            //}
                            //writer.Write("\n");
                            //if (indeksWiersza >= 2)
                            //{  //copyWriter.Write(wygenerowaneHasla[indeksKolumny, indeksWiersza] + "\t");
                            //    liniaTekstu += "\t\t\t\t";
                            //}
                            for (int indeksKolumny = 0; indeksKolumny < dataGridView1.Columns.Count; indeksKolumny++)
                            {
                                //if (indeksWiersza == 1 || indeksWiersza == 2)
                                //{
                                //    wygenerowaneHasla[indeksKolumny, indeksWiersza] = "\t\t";
                                //}
                                //if (indeksWiersza >= 1 && indeksKolumny >= 3)
                                //{
                                if (indeksWiersza <= 1)
                                { //copyWriter.Write(wygenerowaneHasla[indeksKolumny, indeksWiersza] + "\t\t");

                                    liniaTekstu += (wygenerowaneHasla[indeksKolumny, indeksWiersza] + "\t\t");
                                }
                                else if (indeksWiersza >= 2)
                                {  //copyWriter.Write(wygenerowaneHasla[indeksKolumny, indeksWiersza] + "\t");
                                    if (indeksKolumny == 1 || indeksKolumny == 2)
                                    {
                                        liniaTekstu += "\t\t";
                                    }
                                    liniaTekstu += (wygenerowaneHasla[indeksKolumny, indeksWiersza] + "\t");
                                }
                            }
                            writer.WriteLine(liniaTekstu);


                        }
                        break;
                }

                writer.Dispose();
                writer.Close();

                string sciezkaPlikuLoginHaslo = Path.Combine(Path.GetDirectoryName(sfd.FileName), nazwaPlikuBezRozszerzenia + "_log_pass" + rozszerzeniePliku);

                if (File.Exists(sciezkaPlikuLoginHaslo))
                {
                    File.Delete(sciezkaPlikuLoginHaslo);
                    //File.Copy(sfd.FileName, Path.Combine(Path.GetDirectoryName(sfd.FileName), nazwaPlikuBezRozszerzenia + "_log_pass" + rozszerzeniePliku));
                }
                //else
                //{
                //    var myFile = File.Create(sciezkaPlikuLoginHaslo);
                //    myFile.Close();
                //}

                FileStream fsCopyWriter = new FileStream(sciezkaPlikuLoginHaslo, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter copyWriter = new StreamWriter(fsCopyWriter, Encoding.UTF8);
                //File.Create(sciezkaPlikuLoginHaslo);
                //File.OpenWrite(sciezkaPlikuLoginHaslo);

                //using (StreamWriter copyWriter = File.CreateText(sciezkaPlikuLoginHaslo))
                //{
                switch (sfd.FilterIndex)
                {
                    case 1:
                        for (int indeksWiersza = 0; indeksWiersza < dataGridView1.Rows.Count; indeksWiersza++)
                        {
                            for (int indeksKolumny = 0; indeksKolumny < dataGridView1.Columns.Count; indeksKolumny++)
                            {
                                if (indeksWiersza >= 1 && indeksKolumny >= 3)
                                {
                                    copyWriter.Write(wygenerowaneHasla[indeksKolumny, indeksWiersza] + ";");
                                }
                            }
                            if (indeksWiersza >= 1)
                            {
                                copyWriter.Write("\n");
                            }

                        }
                        break;
                    case 2:
                        for (int indeksWiersza = 0; indeksWiersza < dataGridView1.Rows.Count; indeksWiersza++)
                        {
                            string liniaTekstu = "";
                            for (int indeksKolumny = 0; indeksKolumny < dataGridView1.Columns.Count; indeksKolumny++)
                            {
                                if (indeksWiersza >= 1 && indeksKolumny >= 3)
                                {
                                    if (indeksWiersza == 1)
                                    { //copyWriter.Write(wygenerowaneHasla[indeksKolumny, indeksWiersza] + "\t\t");
                                        liniaTekstu += (wygenerowaneHasla[indeksKolumny, indeksWiersza] + "\t\t");
                                    }
                                    else if (indeksWiersza >=2)
                                    {  //copyWriter.Write(wygenerowaneHasla[indeksKolumny, indeksWiersza] + "\t");
                                        liniaTekstu += (wygenerowaneHasla[indeksKolumny, indeksWiersza] + "\t");
                                    }
                                }
                            }
                            if (liniaTekstu!="")
                                copyWriter.WriteLine(liniaTekstu);
                            //copyWriter.Write("\n");
                            //if (indeksWiersza >= 1)
                            //{
                            //    copyWriter.Write(Environment.NewLine);
                            //}
                        }
                        break;
                }
                //}
                copyWriter.Dispose();
                copyWriter.Close();
                fsCopyWriter.Close();
                MessageBox.Show("Zapisano plik");
            }

            //// If the file name is not an empty string open it for saving.  
            //if (sfd.FileName != "")
            //{
            //    // Saves the Image via a FileStream created by the OpenFile method.  
            //    System.IO.FileStream fs =
            //       (System.IO.FileStream)sfd.OpenFile();
            //    // Saves the Image in the appropriate ImageFormat based upon the  
            //    // File type selected in the dialog box.  
            //    // NOTE that the FilterIndex property is one-based.  
            //    switch (sfd.FilterIndex)
            //    {
            //        case 1:
            //            ZapisywaniePliku(sfd.FileName, wygenerowaneHasla);
            //            break;

            //        case 2:

            //            break;
            //    }

            //    fs.Close();
        }
    }
}

