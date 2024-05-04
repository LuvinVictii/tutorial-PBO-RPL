# Game Logic
Untuk membuat game, ada beberapa logic yang harus dipahami agar memudahkan penyusunan game

## **Hitbox**
   - Hitbox adalah kotak, bola, atau bentuk apapun yang tidak terlihat dan berfungsi sebagai area 'hit' dari objek tersebut
   - Hitbox biasanya terletak pada objek yang tidak tembus seperti player, musuh, tembok, dsb.
   - Hitbox bisa berbentuk sederhana seperti kotak agar meringankan program, ataupun berbentuk rumit agar gameplay lebih akurat.

![Contoh hitbox](https://github.com/LuvinVictii/tutorial-PBO-RPL/assets/78089862/f7e86103-220e-4aad-9abe-8915457ebb85)


## **Collision Detection**:
   - Collision detection adalah proses mendeteksi apakah 2 (atau lebih) objek bertabrakan.
   - Biasanya dilakukan dengan mengecek apakah 2 hitbox bertabrakan.
   - Collision detection biasanya dilakukan di loop game update, dimana posisi dan hitbox tiap objek dicek setiap game update.

## **Implementasi di C#**:
   - In C#, hitbox dan collision detection dapat diimplementasikan menggunakan PBO.
   - Setiap objek yang akan menggunakan collision detection akan memiliki representasi posisinya, ukurannya, dan bentuk hitboxnya.
   - Akan ada method untuk mengecek collision dengan objek lain.
   - Logika collision handling akan dipanggil ketika ada collision, misalnya mengurangi darah player, proyektil hancur, atau trigger suatu event dalam game.

Berikut adalah contoh sederhana implementasinya:

```
using System;

class Hitbox
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }

    public Hitbox(float x, float y, float width, float height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public bool Intersects(Hitbox other)
    {
        return X < other.X + other.Width &&
               X + Width > other.X &&
               Y < other.Y + other.Height &&
               Y + Height > other.Y;
    }
}

class Program
{
    static void Main()
    {
        Hitbox playerHitbox = new Hitbox(50, 50, 50, 50);
        Hitbox enemyHitbox = new Hitbox(100, 100, 50, 50);

        if (playerHitbox.Intersects(enemyHitbox))
        {
            Console.WriteLine("Collision detected!");
        }
        else
        {
            Console.WriteLine("No collision detected.");
        }
    }
}
```
