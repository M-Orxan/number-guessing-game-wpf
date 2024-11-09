using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NumberGuessingGameWPF
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
        int minValue;
        int maxValue;
        int randomNumber;
        int userNumber;

        int chancesCount = 0;

        private void SetTheRange_Click(object sender, RoutedEventArgs e)
        {
            string minimumValue = MinimumValueInput.Text;
            string maximumValue = MaximumValueInput.Text;

            if (!int.TryParse(maximumValue, out maxValue) && !int.TryParse(minimumValue, out minValue))
            {
                MessageBox.Show("You entered invalid values.\nPlease try again");
                MaximumValueInput.Clear();
                MinimumValueInput.Clear();
                return;
            }


            if (string.IsNullOrEmpty(MinimumValueInput.Text))
            {
                MessageBox.Show("You didn't enter minimum value");
                return;

            }
            if (!int.TryParse(minimumValue, out minValue))
            {
                MessageBox.Show("You entered invalid minimum value.\nPlease try again");
                MinimumValueInput.Clear();
                return;
            }


            if (string.IsNullOrEmpty(MaximumValueInput.Text))
            {
                MessageBox.Show("You didn't enter maximum value");
                return;

            }

            if (!int.TryParse(maximumValue, out maxValue))
            {
                MessageBox.Show("You entered invalid maximum value.\nPlease try again");
                MaximumValueInput.Clear();
                return;
            }

            if (string.IsNullOrEmpty(ChancesInput.Text))
            {
                MessageBox.Show("You didn't enter chances count.");

                return;
            }

            if (!int.TryParse(ChancesInput.Text, out chancesCount))
            {
                MessageBox.Show("You entered invalid chances count");
                ChancesInput.Clear();
                return;
            }

            MessageBox.Show($"You have {chancesCount} chances.\nYou should find the number between {minimumValue} and {maximumValue} (both includes)");

            Random random = new Random();

            randomNumber = random.Next(minValue, maxValue + 1);

            label.Content = $"Now please enter number between {minValue} and {maxValue}";
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernumberInput.Text))
            {
                MessageBox.Show("You didn't enter the number");
                return;
            }

            if (!int.TryParse(UsernumberInput.Text, out userNumber))
            {
                MessageBox.Show("You entered invalid number.\nPlease try again");
                UsernumberInput.Clear();

                return;
            }


            if (chancesCount == 1 && userNumber != randomNumber)
            {
                MessageBox.Show($"You lost.\nThe right number is {randomNumber}");
                UsernumberInput.Clear();
                MinimumValueInput.Clear();
                MaximumValueInput.Clear();
                label.Content = "Now please enter number between minValue and maxValue";
                ChancesInput.Clear();
                return;
            }

            if (userNumber < minValue || userNumber > maxValue)
            {
                MessageBox.Show("You didn't enter number between right range.\nPlease enter again");
                UsernumberInput.Clear();
                return;
            }


            if (userNumber < randomNumber)
            {
                if (chancesCount == 1)
                {
                    MessageBox.Show($"Wrong desicion.\nYou have {chancesCount - 1} chance.\nPlease enter higher number");

                }
                else
                {
                    MessageBox.Show($"Wrong desicion.\nYou have {chancesCount - 1} chances.\nPlease enter higher number");

                }
                UsernumberInput.Clear();
                chancesCount--;

            }
            else if (userNumber > randomNumber)
            {
                if (chancesCount == 1)
                {
                    MessageBox.Show($"Wrong desicion.\nYou have {chancesCount - 1} chance.\nPlease enter lower number");

                }
                else
                {
                    MessageBox.Show($"Wrong desicion.\nYou have {chancesCount - 1} chances.\nPlease enter lower number");

                }
                UsernumberInput.Clear();
                chancesCount--;

            }
            else
            {
                MessageBox.Show("Congratulations.\nYou found right number");
                UsernumberInput.Clear();
                MinimumValueInput.Clear();
                MaximumValueInput.Clear();
                label.Content = "Now please enter number between minValue and maxValue";
                ChancesInput.Clear();


            }


        }
    }
}