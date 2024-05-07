using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFACoreDelegates_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Bu delegate geriye değer dönmüyor ve parametresi yok.
        delegate void Mydelegate();
        //MyDelegate tipinde bir değişken
        Mydelegate md1;

        //İkinci Delegate ama bu sefer parametre alıyor.
        delegate void TestDelegate(string item);
        TestDelegate td1;

        //Üçüncü Örnek hem geriye değer döndürüyor hemde parametre alıcak
        delegate int IslemYap(int Sayi1, int Sayi2);
        IslemYap iyd;

        //Action, Predicate, Func
        Action actDelegate;
        Action<string> actDelegate2;

        Predicate<string> preDelegate;

        Func<string, bool> funcDelegate;

        private void Form1_Load(object sender, EventArgs e)
        {
            //md1 = new Mydelegate(Selamla); //Bir methodu bir değişkene atamazsın.      
            //md1 += FormaYazdir;
            //md1 += RenkDegistir;

            //td1 = new TestDelegate(IsmeGoreSelamlama);

            //iyd = new IslemYap(Topla);

            //actDelegate = Selamla;
            //actDelegate2 = IsmeGoreSelamlama;

            //Lambda oluştururak yani kısa,anonim isimsiz method oluşturmayı sağlayan özellik. LINQ soruguları ve delegelerle birlikte kullanılır.
            //actDelegate = () => MessageBox.Show("Selamla");
            //actDelegate = () =>
            //{
            //MessageBox.Show("Selamla");
            //}

            actDelegate = () => MessageBox.Show($"Hoşgeldin");
            actDelegate2 = (x) =>   MessageBox.Show($"Hoşgeldin {x}");

            List<string> sehirler = new List<string>()
            {
                "Paris","Istanbul","Londra"
            };

            //preDelegate = SehirBul;
            //Text = sehirler.Find(preDelegate);

            funcDelegate = SehirBul;
            List<string> bulunanSehirler = sehirler.Where(funcDelegate).ToList();

        }

        public void Selamla()
        {
            MessageBox.Show("Hello World!");
        }

        public void FormaYazdir()
        {
            Text = "Hello World";
        }

        public void RenkDegistir()
        {
            BackColor = Color.Red;
        }

        public void IsmeGoreSelamlama(string item)
        {
            MessageBox.Show($"Hoşgeldin {item}");
        }

        public int Topla(int x, int y)
        {
            return x+y;
        }

        public bool SehirBul(string deger)
        {
            return deger == "Paris";
        }

        private void btnInvoke_Click(object sender, EventArgs e)
        {
            //Delegate içerisindeki bütün methodları çalıştırır.
            /*md1.Invoke();*/ // 

            //td1.Invoke("Ahmet");

            //Text = iyd.Invoke(2,3).ToString();

            //actDelegate.Invoke();
            //actDelegate2.Invoke("Ahmet");
        }
    }
}