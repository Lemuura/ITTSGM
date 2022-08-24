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
                saveLinesList.Add("\t\"Minigame.Whack-A-Cody\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Whack-A-Cody_HaveDiscovered\": \"True\",");
            }

            if (flip.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.The Nail Wheel\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.The Nail Wheel_HaveDiscovered\": \"True\",");
            }

            if (tug.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Tug of War\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Tug of War_HaveDiscovered\": \"True\",");
                saveLinesList.Add("\t\"MinigameFlag.Tug of War_HavePlayed\": \"True\",");
            }

            if (plunger.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Plunger\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Plunger_HaveDiscovered\": \"True\",");
            }

            if (tank.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Tank Brothers\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Tank Brothers_HaveDiscovered\": \"True\",");
            }

            if (laser.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Laser Tennis\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Laser Tennis_HaveDiscovered\": \"True\",");
            }

            if (space.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Low Gravity Room\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Low Gravity Room_HaveDiscovered\": \"True\",");
            }

            if (batting.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Baseball\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Baseball_HaveDiscovered\": \"True\",");
            }

            if (feed.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Throwing Hoops\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Throwing Hoops_HaveDiscovered\": \"True\",");
            }

            if (rodeo.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Rodeo\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Rodeo_HaveDiscovered\": \"True\",");
                saveLinesList.Add("\t\"MinigameCounter.Rodeo_CodyWinsData\": \"1\",");
            }

            if (birdstar.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Birdstar\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Birdstar_HaveDiscovered\": \"True\",");
            }

            if (bomb.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Bomb Run\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Bomb Run_HaveDiscovered\": \"True\",");
            }

            if (horse.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Horse Derby\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Horse Derby_HaveDiscovered\": \"True\",");
            }

            if (snow.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Snowball Warfare\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Snowball Warfare_HaveDiscovered\": \"True\",");
                saveLinesList.Add("\t\"MinigameCounter.Snowball Warfare_MayWinsData\": \"1\",");
            }

            if (shuffle.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Shuffle Board\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Shuffle Board_HaveDiscovered\": \"True\",");
            }

            if (icicle.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Icicle Throwing\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Icicle Throwing_HaveDiscovered\": \"True\",");
            }

            if (ice.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Ice Race\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Ice Race_HaveDiscovered\": \"True\",");
            }

            if (larva.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Larva Basket\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Larva Basket_HaveDiscovered\": \"True\",");
            }

            if (garden.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Garden Swing\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Garden Swing_HaveDiscovered\": \"True\",");
            }

            if (snail.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Snail Race\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Snail Race_HaveDiscovered\": \"True\",");
            }

            if (musical.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Musical Chairs\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Musical Chairs_HaveDiscovered\": \"True\",");
            }

            if (track.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Track Runner\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Track Runner_HaveDiscovered\": \"True\",");
                saveLinesList.Add("\t\"MinigameCounter.Track Runner_CodyWinsData\": \"1\",");
            }

            if (slotcars.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Slotcars\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Slotcars_HaveDiscovered\": \"True\",");
            }

            if (chess.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Chess\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Chess_HaveDiscovered\": \"True\",");
            }

            if (volleyball.IsChecked == true)
            {
                saveLinesList.Add("\t\"Minigame.Volleyball\": \"true\",");
                saveLinesList.Add("\t\"MinigameFlag.Volleyball_HaveDiscovered\": \"True\",");
            }
        }

        private void SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            whack.IsChecked = flip.IsChecked = tug.IsChecked = plunger.IsChecked = tank.IsChecked = laser.IsChecked = space.IsChecked = 
            batting.IsChecked = feed.IsChecked = rodeo.IsChecked = birdstar.IsChecked = bomb.IsChecked = horse.IsChecked = snow.IsChecked =
            shuffle.IsChecked = icicle.IsChecked = ice.IsChecked = larva.IsChecked = garden.IsChecked = snail.IsChecked =
            musical.IsChecked = track.IsChecked = slotcars.IsChecked = chess.IsChecked = volleyball.IsChecked = true;
        }

        private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            whack.IsChecked = flip.IsChecked = tug.IsChecked = plunger.IsChecked = tank.IsChecked = laser.IsChecked = space.IsChecked =
            batting.IsChecked = feed.IsChecked = rodeo.IsChecked = birdstar.IsChecked = bomb.IsChecked = horse.IsChecked = snow.IsChecked =
            shuffle.IsChecked = icicle.IsChecked = ice.IsChecked = larva.IsChecked = garden.IsChecked = snail.IsChecked =
            musical.IsChecked = track.IsChecked = slotcars.IsChecked = chess.IsChecked = volleyball.IsChecked = false;
        }

        private void SelectAll_Indeterminate(object sender, RoutedEventArgs e)
        {
            if (whack.IsChecked == true &&
                flip.IsChecked == true &&
                tug.IsChecked == true &&
                plunger.IsChecked == true &&
                tank.IsChecked == true &&
                laser.IsChecked == true &&
                space.IsChecked == true &&
                batting.IsChecked == true &&
                feed.IsChecked == true &&
                rodeo.IsChecked == true &&
                birdstar.IsChecked == true &&
                bomb.IsChecked == true &&
                horse.IsChecked == true &&
                snow.IsChecked == true &&
                shuffle.IsChecked == true &&
                icicle.IsChecked == true &&
                ice.IsChecked == true &&
                larva.IsChecked == true &&
                garden.IsChecked == true &&
                snail.IsChecked == true &&
                musical.IsChecked == true &&
                track.IsChecked == true &&
                slotcars.IsChecked == true &&
                chess.IsChecked == true &&
                volleyball.IsChecked == true)
            {
                OptionsAllCheckBox.IsChecked = false;
            }
        }

        private void SetCheckedState()
        {
            // Controls are null the first time this is called, so we just 
            // need to perform a null check on any one of the controls.
            if (volleyball != null)
            {
                if (whack.IsChecked == true &&
                    flip.IsChecked == true &&
                    tug.IsChecked == true &&
                    plunger.IsChecked == true &&
                    tank.IsChecked == true &&
                    laser.IsChecked == true &&
                    space.IsChecked == true &&
                    batting.IsChecked == true &&
                    feed.IsChecked == true &&
                    rodeo.IsChecked == true &&
                    birdstar.IsChecked == true &&
                    bomb.IsChecked == true &&
                    horse.IsChecked == true &&
                    snow.IsChecked == true &&
                    shuffle.IsChecked == true &&
                    icicle.IsChecked == true &&
                    ice.IsChecked == true &&
                    larva.IsChecked == true &&
                    garden.IsChecked == true &&
                    snail.IsChecked == true &&
                    musical.IsChecked == true &&
                    track.IsChecked == true &&
                    slotcars.IsChecked == true &&
                    chess.IsChecked == true &&
                    volleyball.IsChecked == true)
                {
                    OptionsAllCheckBox.IsChecked = true;
                }
                else if (whack.IsChecked == false &&
                    flip.IsChecked == false &&
                    tug.IsChecked == false &&
                    plunger.IsChecked == false &&
                    tank.IsChecked == false &&
                    laser.IsChecked == false &&
                    space.IsChecked == false &&
                    batting.IsChecked == false &&
                    feed.IsChecked == false &&
                    rodeo.IsChecked == false &&
                    birdstar.IsChecked == false &&
                    bomb.IsChecked == false &&
                    horse.IsChecked == false &&
                    snow.IsChecked == false &&
                    shuffle.IsChecked == false &&
                    icicle.IsChecked == false &&
                    ice.IsChecked == false &&
                    larva.IsChecked == false &&
                    garden.IsChecked == false &&
                    snail.IsChecked == false &&
                    musical.IsChecked == false &&
                    track.IsChecked == false &&
                    slotcars.IsChecked == false &&
                    chess.IsChecked == false &&
                    volleyball.IsChecked == false)
                {
                    OptionsAllCheckBox.IsChecked = false;
                }
                else
                {
                    // Set third state (indeterminate) by setting IsChecked to null.
                    OptionsAllCheckBox.IsChecked = null;
                }
            }
        }

        private void Option_Checked(object sender, RoutedEventArgs e)
        {
            SetCheckedState();
        }

        private void Option_Unchecked(object sender, RoutedEventArgs e)
        {
            SetCheckedState();
        }

        private void AnyBtn_Click(object sender, RoutedEventArgs e)
        {
            OptionsAllCheckBox.IsChecked = false;
            tug.IsChecked = true;
            plunger.IsChecked = true;
            batting.IsChecked = true;
            snail.IsChecked = true;
            track.IsChecked = true;
        }
    }
}
