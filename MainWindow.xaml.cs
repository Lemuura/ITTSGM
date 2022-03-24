using System;
using System.Collections.Generic;
using System.IO;
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

namespace ITTSGM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> saveLinesList = new List<string>();
        private string[] saveLines;

        public MainWindow()
        {
            InitializeComponent();
            ReadSaveFile();
        }

        private void ReadSaveFile()
        {
            if (!File.Exists(@"SaveData.Nuts"))
            {
                MessageBox.Show("Save file can't be located. Has it been moved or deleted?", "File not found");
                return;
            }

            else
            {

                saveLines = File.ReadAllLines(@"SaveData.Nuts");
                saveLinesList = saveLines.ToList();

                checkMinigames();

                Console.WriteLine("Contents of SaveData.Nuts = ");
                foreach (string line in saveLinesList)
                {
                    Console.WriteLine("\t" + line);
                }
            }
        }

        private void WriteToFile()
        {
            saveLinesList.Clear();
            saveLinesList.Add("{");
            saveLinesList.Add("	\"EULA_Accepted\": \"true\",");
            saveLinesList.Add("	\"UID\": \"00000\","); // UID number doesn't seem to matter?
            saveLinesList.Add("	\"FriendsPassInfoShown\": \"True\",");
            saveLinesList.Add("	\"FurthestUnlockedChapter\": \"/Game/Maps/Music/Ending/Music_Ending_BP##EndingIntro\",");
            saveLinesList.Add("	\"LastSaveProgressPoint\": \"/Game/Maps/Shed/Awakening/Awakening_BP##Awakening_Start\",");
            saveLinesList.Add("	\"LastSaveChapter\": \"/Game/Maps/Shed/Awakening/Awakening_BP##Awakening_Start\",");
            WriteMinigames();

            string lastLine = saveLinesList[saveLinesList.Count - 1].TrimEnd(','); // Removes the comma at the end of the file
            saveLinesList.RemoveAt(saveLinesList.Count - 1);
            saveLinesList.Add(lastLine);
            saveLinesList.Add("}");
            saveLines = saveLinesList.ToArray();
            File.WriteAllLines(@"SaveData.Nuts", saveLines);
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            ReadSaveFile();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(@"SaveData.Nuts"))
            {
                MessageBox.Show("Save file can't be located. Has it been moved or deleted?", "File not found");
                return;
            }

            else
            {
                WriteToFile();
            }
        }

        private void checkMinigames()
        {
            if (saveLinesList.Contains("	\"Minigame.Whack-A-Cody\": \"true\",")) { whack.IsChecked = true; } else { whack.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.The Nail Wheel\": \"true\",")) { flip.IsChecked = true; } else { flip.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Tug of War\": \"true\",")) { tug.IsChecked = true; } else { tug.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Plunger\": \"true\",")) { plunger.IsChecked = true; } else { plunger.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Tank Brothers\": \"true\",")) { tank.IsChecked = true; } else { tank.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Laser Tennis\": \"true\",")) { laser.IsChecked = true; } else { laser.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Low Gravity Room\": \"true\",")) { space.IsChecked = true; } else { space.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Baseball\": \"true\",")) { batting.IsChecked = true; } else { batting.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Throwing Hoops\": \"true\",")) { feed.IsChecked = true; } else { feed.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Rodeo\": \"true\",")) { rodeo.IsChecked = true; } else { rodeo.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Birdstar\": \"true\",")) { birdstar.IsChecked = true; } else { birdstar.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Bomb Run\": \"true\",")) { bomb.IsChecked = true; } else { bomb.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Horse Derby\": \"true\",")) { horse.IsChecked = true; } else { horse.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Snowball Warfare\": \"true\",")) { snow.IsChecked = true; } else { snow.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Shuffle Board\": \"true\",")) { shuffle.IsChecked = true; } else { shuffle.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Icicle Throwing\": \"true\",")) { icicle.IsChecked = true; } else { icicle.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Ice Race\": \"true\",")) { ice.IsChecked = true; } else { ice.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Larva Basket\": \"true\",")) { larva.IsChecked = true; } else { larva.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Garden Swing\": \"true\",")) { garden.IsChecked = true; } else { garden.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Snail Race\": \"true\",")) { snail.IsChecked = true; } else { snail.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Musical Chairs\": \"true\",")) { musical.IsChecked = true; } else { musical.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Track Runner\": \"true\",")) { track.IsChecked = true; } else { track.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Slotcars\": \"true\",")) { slotcars.IsChecked = true; } else { slotcars.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Chess\": \"true\",")) { chess.IsChecked = true; } else { chess.IsChecked = false; }
            if (saveLinesList.Contains("	\"Minigame.Volleyball\": \"true\",")) { volleyball.IsChecked = true; } else { volleyball.IsChecked = false; }
        }

        private void WriteMinigames()
        {
            if (whack.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Whack-A-Cody\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Whack-A-Cody_HaveDiscovered\": \"True\",");
            }

            if (flip.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.The Nail Wheel\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.The Nail Wheel_HaveDiscovered\": \"True\",");
            }

            if (tug.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Tug of War\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Tug of War_HaveDiscovered\": \"True\",");
                saveLinesList.Add("	\"MinigameFlag.Tug of War_HavePlayed\": \"True\",");
            }

            if (plunger.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Plunger\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Plunger_HaveDiscovered\": \"True\",");
            }

            if (tank.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Tank Brothers\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Tank Brothers_HaveDiscovered\": \"True\",");
            }

            if (laser.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Laser Tennis\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Laser Tennis_HaveDiscovered\": \"True\",");
            }

            if (space.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Low Gravity Room\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Low Gravity Room_HaveDiscovered\": \"True\",");
            }

            if (batting.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Baseball\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Baseball_HaveDiscovered\": \"True\",");
            }

            if (feed.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Throwing Hoops\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Throwing Hoops_HaveDiscovered\": \"True\",");
            }

            if (rodeo.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Rodeo\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Rodeo_HaveDiscovered\": \"True\",");
            }

            if (birdstar.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Birdstar\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Birdstar_HaveDiscovered\": \"True\",");
            }

            if (bomb.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Bomb Run\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Bomb Run_HaveDiscovered\": \"True\",");
            }

            if (horse.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Horse Derby\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Horse Derby_HaveDiscovered\": \"True\",");
            }

            if (snow.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Snowball Warfare\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Snowball Warfare_HaveDiscovered\": \"True\",");
            }

            if (shuffle.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Shuffle Board\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Shuffle Board_HaveDiscovered\": \"True\",");
            }

            if (icicle.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Icicle Throwing\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Icicle Throwing_HaveDiscovered\": \"True\",");
            }

            if (ice.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Ice Race\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Ice Race_HaveDiscovered\": \"True\",");
            }

            if (larva.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Larva Basket\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Larva Basket_HaveDiscovered\": \"True\",");
            }

            if (garden.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Garden Swing\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Garden Swing_HaveDiscovered\": \"True\",");
            }

            if (snail.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Snail Race\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Snail Race_HaveDiscovered\": \"True\",");
            }

            if (musical.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Musical Chairs\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Musical Chairs_HaveDiscovered\": \"True\",");
            }

            if (track.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Track Runner\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Track Runner_HaveDiscovered\": \"True\",");
            }

            if (slotcars.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Slotcars\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Slotcars_HaveDiscovered\": \"True\",");
            }

            if (chess.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Chess\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Chess_HaveDiscovered\": \"True\",");
            }

            if (volleyball.IsChecked == true)
            {
                saveLinesList.Add("	\"Minigame.Volleyball\": \"true\",");
                saveLinesList.Add("	\"MinigameFlag.Volleyball_HaveDiscovered\": \"True\",");
            }
        }
    }
}
