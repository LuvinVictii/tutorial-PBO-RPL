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


using System.Windows.Threading;
using Accessibility;
using Microsoft.Windows.Themes;
using Space_Entity;

namespace Space_Battle_Shooter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer gameTimer = new DispatcherTimer();
        bool moveLeft, moveRight, moveUp, moveDown;
        List<Rectangle> itemRemover = new List<Rectangle>();

        Random rand = new Random();
        int enemyCounter = 100;
        int limit = 50;
        string[] enemySprites;
        Player player;
        List<Enemy> enemies;
        List<Bullet> bullets;

        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            MyCanvas.Focus();

            // Menginisialisasi Player dan Enemy

            enemySprites = [
                "pack://application:,,,/images/1.png",
                "pack://application:,,,/images/2.png",
                "pack://application:,,,/images/3.png",
                "pack://application:,,,/images/4.png",
                "pack://application:,,,/images/5.png"
            ];

            player = new Player(MyCanvas, "pack://application:,,,/images/player.png");
            enemies = [];
            bullets = [];

            ImageBrush bg = new ImageBrush();
            bg.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/purple.png"));
            bg.TileMode = TileMode.Tile;
            bg.Viewport = new Rect(0, 0, 0.15, 0.15);
            bg.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
            MyCanvas.Background = bg;


        }



        private void GameLoop(object? sender, EventArgs e)
        {
            enemyCounter -= 1;
            scoreText.Content = "Score: " + player.getScore();
            damageText.Content = "Health: " + player.getHealth();


            if (enemyCounter < 0)
            {
                MakeEnemies();
                enemyCounter = limit;
            }

            player.Update();
            player.Move(moveLeft, moveRight, moveUp, moveDown);

            // PELURU
            Console.WriteLine(bullets);
            foreach (Bullet bullet in bullets.ToList())
            {
                bullet.Update();
                bullet.Move();

                if (bullet.getPositionY() < 0)
                {
                    bullet.removeFromCanvas();
                    bullets.Remove(bullet);
                    continue;
                }

                foreach (Enemy enemy in enemies.ToList())
                {
                    if (bullet.hitBox.IntersectsWith(enemy.hitBox))
                    {
                        enemy.removeFromCanvas();
                        enemies.Remove(enemy);

                        bullet.removeFromCanvas();
                        bullets.Remove(bullet);

                        player.addScore();
                    }
                }

            }

            // MUSUH
            foreach (Enemy enemy in enemies.ToList())
            {
                enemy.Update();
                enemy.Move();
                if (enemy.getPositionY() > 750 || player.hitBox.IntersectsWith(enemy.hitBox))
                {
                    enemy.removeFromCanvas();
                    enemies.Remove(enemy);
                    // kalau kena pesawat cuman kena setengah dari damage
                    player.setHealth(player.getHealth() - (enemy.getDamage() / (enemy.getPositionY() > 750 ? 1 : 2)));
                }
            }

            if (player.getScore() > 5)
            {
                limit = 20;
                // enemySpeed = 15;
            }

            if (player.isDeath())
            {
                gameTimer.Stop();
                damageText.Content = "Health: 0";
                damageText.Foreground = Brushes.Red;
                MessageBox.Show("Captain You have destroyed " + player.getScore() + " Alien Ships" + Environment.NewLine + "Press Ok to Play Again", "Commander Says:");
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            }

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) moveLeft = true;

            if (e.Key == Key.Right) moveRight = true;

            if (e.Key == Key.Up) moveUp = true;

            if (e.Key == Key.Down) moveDown = true;

        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) moveLeft = false;

            if (e.Key == Key.Right) moveRight = false;

            if (e.Key == Key.Up) moveUp = false;

            if (e.Key == Key.Down) moveDown = false;

            if (e.Key == Key.Space)
            {
                // tembak peluru
                bullets.Add(new Bullet(MyCanvas,
                    player.getPositionX() + (player.getWidth() / 2),
                    player.getPositionY() + 20
                ));
            }
        }

        private void MakeEnemies()
        {
            int enemyRandChoice = rand.Next(0, 5);
            string enemySprite = enemySprites[enemyRandChoice];
            enemies.Add(new Enemy(MyCanvas, enemySprite, posX: (double)rand.Next(30, 430)));
        }
    }
}