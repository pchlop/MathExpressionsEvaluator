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

namespace PTCT_ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
        }

        public static char[] symbols;

        private void eval_formula(object sender, RoutedEventArgs e)
        {
            Result.Text = "Uproszczone równanie ma postać:";

            char niewiadoma;
            string input;
            string wyrazenie;
            //Console.Write("Wprowadź symbol używany w wyrażeniu: ");
            niewiadoma = Variable.Text.ToCharArray()[0];
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            input = Variable.Text;
            string[] symbole = input.Split(delimiterChars);
            string strsymbole = string.Join("", symbole);
            symbols = strsymbole.ToCharArray();

            Variable zmienna = new Variable(niewiadoma);
            //Console.ReadLine();
            //Console.Write("Wprowadź wyrażenie, które chcesz uprościć (obliczyć): ");
            wyrazenie = MathFormula.Text;
            //Console.WriteLine("Wprowadzone wyrażenie to: {0}", wyrazenie.Replace(" ", ""));
            //Console.WriteLine("Wprowadzono znak: {0}, coe: {1}, exp: {2}", zmienna.symbol, zmienna.coefficient, zmienna.exponent);
            //zmienna.exponent = 2.5;
            //Console.WriteLine("Zmienna to {0}", zmienna.rVariable());

            Rnp onp = new Rnp(wyrazenie, symbols);
            //Console.WriteLine(onp.wyrazenie_rnp);
            //USUNĄĆ SPACJE!!!!!!
            char[] char_onp = onp.wyrazenie_rnp.ToCharArray();
            // Console.WriteLine(char_onp);
            ExpressionTree et = new ExpressionTree();
            TreeNode root = et.constructTree(char_onp);
            //no Console.WriteLine(root.wyswietl());
            //Console.ReadLine();
            Eval uproszczone = new Eval(root, symbols);
            Console.WriteLine("\nUproszczone rownanie:   " + uproszczone.wynik.ToString());

            Result.Text = Result.Text + "\n" + uproszczone.wynik.ToString();

            
            string napisuproszczone = uproszczone.wynik.ToString();

            for (int i = 0; i < 3; i++)
            {
                Rnp onp2 = new Rnp(napisuproszczone, symbols);
                char[] uchar_onp = onp2.wyrazenie_rnp.ToCharArray();
                ExpressionTree et2 = new ExpressionTree();
                TreeNode root2 = et2.constructTree(uchar_onp);
                Eval uproszczone2 = new Eval(root2, symbols);
                napisuproszczone = uproszczone2.wynik.ToString();
            }

            string posortowane = "";
            Rnp onp3 = new Rnp(napisuproszczone, symbols);
            char[] uchar_onp3 = onp3.wyrazenie_rnp.ToCharArray();
            ExpressionTree et3 = new ExpressionTree();
            TreeNode root3 = et3.constructTree(uchar_onp3);
            Eval uproszczone3 = new Eval(root3, symbols);
            posortowane = uproszczone3.wynik.DescString();


            Result.Text = Result.Text + "\n" + posortowane;
        }
    }
}
