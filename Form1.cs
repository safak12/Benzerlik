using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;



namespace Benzerlik
{
    public partial class Form1 : Form
    {

        public static int satirSayisi;
        public static bool flag = false;
        public static bool flag2 = false;
        public static bool flag3 = false;
        public static int sayac = 0;
        public static int sayac1 = 0;
        public static string gelen;
        public static string productİsim;
        public static List<string> companyİsimler = new List<string>();
        public static int payda;
        public static List<CheckModel> result;
        public static List<ThreadSure> sureler;
        public static string Filtre;
        public static double threShold;
        public static string comboDeger;
        public static string compID;
        public static string combo2Deger;
        public static int dakika;
        public static int saniye;
        public static IEnumerable<string> record3Query;

        public Form1()
        {

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            result = new List<CheckModel>();
            sureler = new List<ThreadSure>();
            StreamReader csvreader = new StreamReader(@"C:\Users\safak\Desktop\my_dataa.csv");
            string inputLine = "";
            while ((inputLine = csvreader.ReadLine()) != null)
            {
                var record = new Record();
                string[] csvArray = inputLine.Split(new char[] { ',' });
                record.Product = csvArray[0];
                record.Issue = csvArray[1];
                record.Company = csvArray[2];
                record.State = csvArray[3];
                record.ZıpCode = csvArray[4];
                record.ComplaintId = csvArray[5];


                Record.deliveryRecords.Add(record);
            }

            satirSayisi = Record.deliveryRecords.Count - 2196000;
            this.textBox1.Text = satirSayisi.ToString();



        }

        private async void button1_Click(object sender, EventArgs e)
        {

          
            await X();


        }
        static Task Y(object payy)
        {
            return Task.Run(() =>
            {

                int pay = Convert.ToInt32(payy);
                ThreadSure sure = new ThreadSure();
                CheckModel Check = new CheckModel();
                var a = DateTime.Now;
                if (comboDeger == "Product")
                {
                    for (int i = 1; i < satirSayisi - 1; i++)
                    {
                        for (int j = i + 1 + (satirSayisi * (pay) / payda); j < (satirSayisi * (pay + 1) / payda); j++)
                        {

                            if (threShold <= algoritma(Record.deliveryRecords[i].Product, Record.deliveryRecords[j].Product))
                            {
                                Check.record1 = Record.deliveryRecords[i].Product;
                                Check.record2 = Record.deliveryRecords[j].Product;
                                Check.Similarity = algoritma(Record.deliveryRecords[i].Product, Record.deliveryRecords[j].Product);
                                result.Add(Check);


                            }

                        }
                    }
                }
                else if (comboDeger == "Company")
                {
                    for (int i = 1; i < satirSayisi - 1; i++)
                    {
                        for (int j = i + 1 + (satirSayisi * (pay) / payda); j < (satirSayisi * (pay + 1) / payda); j++)
                        {

                            if (threShold <= algoritma(Record.deliveryRecords[i].Company, Record.deliveryRecords[j].Company))
                            {
                                Check.record1 = Record.deliveryRecords[i].Company;
                                Check.record2 = Record.deliveryRecords[j].Company;
                                Check.Similarity = algoritma(Record.deliveryRecords[i].Company, Record.deliveryRecords[j].Company);
                                result.Add(Check);


                            }

                        }
                    }
                }
                else if (comboDeger == "Issue")
                {
                    for (int i = 1; i < satirSayisi - 1; i++)
                    {
                        for (int j = i + 1 + (satirSayisi * (pay) / payda); j < (satirSayisi * (pay + 1) / payda); j++)
                        {

                            if (threShold <= algoritma(Record.deliveryRecords[i].Issue, Record.deliveryRecords[j].Issue))
                            {
                                Check.record1 = Record.deliveryRecords[i].Issue;
                                Check.record2 = Record.deliveryRecords[j].Issue;
                                Check.Similarity = algoritma(Record.deliveryRecords[i].Issue, Record.deliveryRecords[j].Issue);
                                result.Add(Check);


                            }

                        }
                    }
                }

                var b = DateTime.Now;
                sure.threadSure = (b.Minute - a.Minute).ToString() + "dk" + (b.Second - a.Second).ToString() + "sn";
                dakika += b.Minute - a.Minute;
                saniye += b.Second - a.Second;
                sure.threadID = payy.ToString();
                sureler.Add(sure);
                flag = true;
                Thread.CurrentThread.Abort();


            });



        }
        static Task Z(object payy)
        {
            return Task.Run(() =>
            {

                int pay = Convert.ToInt32(payy);
                ThreadSure sure = new ThreadSure();
                CheckModel Check = new CheckModel();
                var a = DateTime.Now;
                if (combo2Deger == "Product")
                {


                    for (int j = 1 + (satirSayisi * (pay) / payda); j < (satirSayisi * (pay + 1) / payda); j++)
                    {

                        if (threShold <= algoritma(Filtre, Record.deliveryRecords[j].Product))
                        {
                            Check.record1 = Filtre;
                            Check.record2 = Record.deliveryRecords[j].Product;
                            Check.Similarity = algoritma(Filtre, Record.deliveryRecords[j].Product);
                            result.Add(Check);


                        }

                    }

                }
                else if (combo2Deger == "Company")
                {

                    for (int j = 1 + (satirSayisi * (pay) / payda); j < (satirSayisi * (pay + 1) / payda); j++)
                    {

                        if (threShold <= algoritma(Filtre, Record.deliveryRecords[j].Company))
                        {
                            Check.record1 = Filtre;
                            Check.record2 = Record.deliveryRecords[j].Company;
                            Check.Similarity = algoritma(Filtre, Record.deliveryRecords[j].Company);
                            result.Add(Check);


                        }

                    }

                }
                else if (combo2Deger == "Issue")
                {

                    for (int j = 1 + (satirSayisi * (pay) / payda); j < (satirSayisi * (pay + 1) / payda); j++)
                    {

                        if (threShold <= algoritma(Filtre, Record.deliveryRecords[j].Issue))
                        {
                            Check.record1 = Filtre;
                            Check.record2 = Record.deliveryRecords[j].Issue;
                            Check.Similarity = algoritma(Filtre, Record.deliveryRecords[j].Issue);
                            result.Add(Check);



                        }

                    }

                }
                var b = DateTime.Now;
                sure.threadSure = (b.Minute - a.Minute).ToString() + "dk" + (b.Second - a.Second).ToString() + "sn";
                dakika += b.Minute - a.Minute;
                saniye += b.Second - a.Second;
                sure.threadID = pay.ToString();
                sureler.Add(sure);
                flag = true;
                Thread.CurrentThread.Abort();
            });
        }
        static Task M(object payy)
        {
            return Task.Run(() =>
            {
                int pay = Convert.ToInt32(payy);
                ThreadSure sure = new ThreadSure();
                CheckModel Check = new CheckModel();
                var a = DateTime.Now;

                for (int i = 1; i < satirSayisi - 1; i++)
                {
                    
                    for (int j = i + 1 + (satirSayisi * (pay) / payda); j < (satirSayisi * (pay + 1) / payda); j++)
                    {

                        if (threShold <= algoritma(Record.deliveryRecords1[i].Issue, Record.deliveryRecords1[j].Issue))
                        {

                           
                                record3Query =
                            from kayit in Record.deliveryRecords1
                            where kayit.ComplaintId == Record.deliveryRecords1[i].ComplaintId
                            select kayit.Company;

                            foreach (var item in record3Query)
                            {
                                    companyİsimler.Add(item);
                            }

                            break;
                          


                        }

                    }

                }


                var b = DateTime.Now;
                sure.threadSure = (b.Minute - a.Minute).ToString() + "dk" + (b.Second - a.Second).ToString() + "sn";
                dakika += b.Minute - a.Minute;
                saniye += b.Second - a.Second;
                sure.threadID = pay.ToString();
                sureler.Add(sure);
                flag = true;
                Thread.CurrentThread.Abort();


            });
        }

        Task X()
        {
            return Task.Run(() =>
            {
                int gelmis = Convert.ToInt32(gelen);
                payda = gelmis;
                Thread[] thread = new Thread[gelmis];
                var sure1 = DateTime.Now;
                if (flag3 == true)
                {
                    for (int i = 0; i < gelmis; i++)
                    {

                        thread[i] = new Thread(hesapla3);
                        thread[i].Start(i);
                    }
                }
                else if (flag2 == true)
                {
                    for (int i = 0; i < gelmis; i++)
                    {

                        thread[i] = new Thread(hesapla2);
                        thread[i].Start(i);
                    }
                }
                else
                {
                    for (int i = 0; i < gelmis; i++)
                    {

                        thread[i] = new Thread(hesapla);
                        thread[i].Start(i);
                    }

                }

            });
        }
     

        private void button3_Click(object sender, EventArgs e)
        {

            if (saniye > 60)
            {

                dakika += saniye / 60;
                saniye = saniye - (saniye / 60) * 60;
            }
            this.textBox12.Text = dakika.ToString() + "dk" + saniye.ToString() + "sn";
            if (flag == true)
            {


                Form2 f1 = new Form2();
                TextBox t1 = (TextBox)(f1.Controls["TextBox2"]);
                DataGridView dw4 = (DataGridView)(f1.Controls["dataGridView4"]);
                DataGridView dw1 = (DataGridView)(f1.Controls["dataGridView1"]);
                TextBox t2 = (TextBox)(f1.Controls["TextBox1"]);
                if (flag3 == true)
                {
                    dw4.DataSource = companyİsimler.Select(x => new { Value = x }).ToList();
                    t1.Text = companyİsimler.Count.ToString();
                }
                else
                {
                    dw4.DataSource = result;
                    t1.Text = result.Count.ToString();
                }
                dw1.DataSource = sureler;
                t2.Text = sureler.Count.ToString();
                f1.ShowDialog();



            }
        }



        public async static void hesapla(object payy)
        {
            await Y(payy);


        }

        public async static void hesapla2(object payy)
        {
            await Z(payy);


        }
        public async static void hesapla3(object payy)
        {
            await M(payy);

        }



        public class Record
        {
            public static List<Record> deliveryRecords = new List<Record>();
            public static List<Record> deliveryRecords1 = new List<Record>();
            public string Product { get; set; }
            public string Issue { get; set; }
            public string Company { get; set; }
            public string State { get; set; }
            public string ZıpCode { get; set; }
            public string ComplaintId { get; set; }


        }
        public static int CountWord(string text, string[] b)
        {
            int k = 0;
            char[] a = new char[200];
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    if ((i + 1) == text.Length)
                    {
                        count++;
                    }
                    else
                    {

                        a[k] = text[i];
                        b[count] = new String(a);
                        k++;

                        if (text[i + 1] == ' ')
                        {
                            k = 0;
                            a = null;
                            a = new char[200];
                            count++;
                        }

                    }
                }

            }
            return count;
        }
        public static double algoritma(string kaynak, string hedef)
        {
            string[] cumleler = new string[100];
            string[] cumleler2 = new string[100];
            double ck = 0;
            double sayac = 0;
            double buyuk = 0;


            int İlkCumleSayisi = CountWord(kaynak, cumleler);

            int İkinciCumleSayisi = CountWord(hedef, cumleler2);

            if (İlkCumleSayisi >= İkinciCumleSayisi)
                buyuk = İlkCumleSayisi;
            else
                buyuk = İkinciCumleSayisi;

            for (int i = 0; i < İlkCumleSayisi; i++)
            {
                for (int j = 0; j < İkinciCumleSayisi; j++)
                {
                    if (cumleler[i].Equals(cumleler2[j], StringComparison.OrdinalIgnoreCase))
                    {
                        sayac++;
                        break;
                    }
                }
            }
            ck = ((sayac / buyuk) * 100);


            return ck;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            button4.Enabled = false;
            threShold = Convert.ToDouble(textBox5.Text);
            gelen = textBox4.Text;
            comboDeger = this.comboBox1.SelectedItem.ToString();
            button2.Enabled = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button5.Enabled = false;
            flag2 = true;
            compID = textBox8.Text;
            combo2Deger = comboBox2.SelectedItem.ToString();
            threShold = Convert.ToDouble(textBox7.Text);
            gelen = textBox9.Text;
            if (combo2Deger == "Product")
            {
                var recordQuery =
                   from kayit in Record.deliveryRecords
                   where kayit.ComplaintId == compID
                   select kayit.Product;

                foreach (var a in recordQuery)
                    Filtre = a;

            }
            if (combo2Deger == "Issue")
            {
                var recordQuery =
                   from kayit in Record.deliveryRecords
                   where kayit.ComplaintId == compID
                   select kayit.Issue;

                foreach (var a in recordQuery)
                    Filtre = a;

            }
            if (combo2Deger == "Company")
            {
                var recordQuery =
                   from kayit in Record.deliveryRecords
                   where kayit.ComplaintId == compID
                   select kayit.Company;

                foreach (var a in recordQuery)
                    Filtre = a;

            }

            this.button4.Enabled = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            flag3 = true;
            button4.Enabled = false;
            button2.Enabled = false;
            productİsim = textBox13.Text;
            threShold = Convert.ToDouble(textBox11.Text);
            gelen = textBox10.Text;

            var record2Query =
                     from kayit in Record.deliveryRecords
                     where kayit.Product == productİsim
                     select kayit;

            foreach (var item in record2Query)
            {
                Record.deliveryRecords1.Add(item);
            }

            satirSayisi = Record.deliveryRecords1.Count;
            this.textBox1.Text = satirSayisi.ToString();

            button5.Enabled = false;

        }
    }
}

