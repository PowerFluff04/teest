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

namespace lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        public static int[] sort(int[] mass, int per)
        {
            bool flag = false;
            int i;

            for (i = 0; i < mass.Length - 1; i++)
            {
                if (mass[i] > mass[i + 1])
                {
                    per = mass[i];
                    mass[i] = mass[i + 1];
                    mass[i + 1] = per;
                }
                else continue;
            }
            for (i = 0; i < mass.Length - 1; i++)
            {
                if (mass[i] <= mass[i + 1]) flag = true;
                else
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true) return mass;
            else return sort(mass, per);
        }

        private void btEx_Click(object sender, RoutedEventArgs e)
        {
            lbotv.Items.Clear();
            int sr = 0;
            int k = Convert.ToInt32(tbS.Text);
            int[] mass = new int[k];
            Random rnd = new Random();
            lbotv.Items.Add("Начальный массив: ");
            int sum = 0;
            for (int i = 0; i < k; i++)
            {
                mass[i] = - 100 + rnd.Next(200);
                lbotv.Items.Add(mass[i]);
                sum += mass[i]; 
            }
            sr = sum / k;
            int srotkl = 0;
            double srotkl1 = 0;
            double l = Convert.ToDouble(tbL.Text) / 100;
            int z = Convert.ToInt32(tbZ.Text);
            switch(cbox1.SelectedIndex)
            {
                case 0:
                    int result = 0;
                    for (int i = 1; i < k-1; i++)
                    {
                            if (mass[i] < mass[i + 1] && mass[i] < mass[i - 1])
                            {
                                result++;
                            }                   

                    }
                    lbotv.Items.Add("Кол-во: " + result);
                    break;
                case 1:
                    int tempindex = 0;
                    for (int i = 0; i < k; i++)
                    {
                        int min = 999999;
                        
                        if (mass[i] > sr)
                        {
                            if (mass[i]< min)
                            {
                                min = mass[i];
                                tempindex = i;
                            }
                        }
                    }
                    lbotv.Items.Add("Индекс минимального значения: " + tempindex);
                    break;
                case 2:
                     result = 0;
                    for (int i = 0; i < k-1; i++)
                    {
                        if ((mass[i] > mass[i+1]) || (mass[i] < mass[i+1]))
                        {
                            result++;
                        }
                    }
                    lbotv.Items.Add("Кол-во последовательностей: " + result);
                    break;
                case 3:
                    int per = 0;
                    int j = 1;
                    sort(mass, per);
                    for (int i =0; i <k; i ++)
                    {
                        if (i == (k/2 + 1))
                        {
                            per = mass[i];
                            mass[i] = mass[k - j];
                            mass[k - j] = per;
                            j++;
                            if (i == j) break;
                        }

                    }
                    mass[k - 1] *= -1;
                    lbotv.Items.Add("------------------");
                    for (int i = 0; i< k; i ++)
                    {
                        lbotv.Items.Add(mass[i]);

                    }
                    break;
                case 4:
                    lbotv.Items.Add("------------------");
                    for (int i = 0; i < k; i++)
                    {
                        int v = 0;
                        if (mass[i] > sr)
                        {
                            v = mass[i] - sr;
                        }
                        else
                        {
                            v = sr - mass[i];
                        }
                        lbotv.Items.Add(i + "-й элемент(" + mass[i] + "): отклонение = " + v);   
                    }
                    break;
                case 5:

                    lbotv.Items.Add("Отсортированный массив: ");
                    for (int i = 0; i < k; i++)
                    {
                        srotkl += mass[i] - sr;
                    }
                    srotkl1 = 0.5 * (srotkl / k);
                    for (int i = 0; i < k; i++)
                    {
                        if (mass[i] - sr > srotkl1)
                        {
                            mass[i] = sr;
                        }
                        lbotv.Items.Add(mass[i]);
                    }
                    break;
                case 6:

                    lbotv.Items.Add("Отсортированный массив: ");
                    for (int i = 0; i < k; i++)
                    {
                        srotkl += mass[i] - sr;
                    }
                    srotkl1 = l * (srotkl / k);
                    for (int i = 0; i < k; i++)
                    {
                        if (mass[i] - sr > srotkl1)
                        {
                            mass[i] = sr;
                        }
                        lbotv.Items.Add(mass[i]);
                    }
                    break;
                case 7:
                    lbotv.Items.Add("Отсортированный массив: ");
                    for (int i = 0; i < k; i++)
                    {
                        srotkl += mass[i] - sr;
                    }
                    srotkl1 = l * (srotkl / k);
                    for (int i = 0; i < k; i++)
                    {
                        if (mass[i] - sr > srotkl1)
                        {
                            mass[i] = z;
                        }
                        lbotv.Items.Add(mass[i]);
                    }
                    break;
                case 9:
                    
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
            }
        }
    }
}
