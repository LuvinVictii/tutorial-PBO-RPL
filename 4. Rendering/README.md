# Rendering in C#

Rendering dalam C# bisa dilakukan dengan banyak metode. Secara umum ada 3 metode yang dapat digunakan, yaitu WPF, Windows Forms, dan Unity.

## Rendering di WPF

Windows Presentation Foundation (WPF) adalah kerangka kerja UI untuk membangun aplikasi desktop dengan grafis yang rich dan UI modern. WPF dibangun di atas DirectX dan menyediakan model yang kuat dan fleksibel untuk merender grafis 2D dan 3D.

### Konsep Utama dalam Rendering WPF

1. **XAML (Extensible Application Markup Language)**:
   - XAML adalah markup language yang digunakan untuk men-define UI dalam aplikasi WPF. Ini memungkinkan kita untuk membuat dan menginisialisasi objek secara deklaratif.

2. **Menggambar dengan Shapes**:
   - WPF menyediakan bentuk bawaan seperti `Rectangle`, `Ellipse`, `Line`, dan `Path` yang dapat digunakan untuk menggambar grafis 2D.

3. **Brushes dan Pens**:
   - Brushes digunakan untuk mengisi bentuk, sementara pens digunakan untuk memberi garis tepi pada bentuk. WPF menyediakan berbagai jenis brush seperti `SolidColorBrush`, `LinearGradientBrush`, `RadialGradientBrush`, dan `ImageBrush`.

4. **Transforms**:
   - Transforms memungkinkan Anda untuk memanipulasi tampilan bentuk dan elemen UI. Transformasi umum meliputi `RotateTransform`, `ScaleTransform`, `SkewTransform`, dan `TranslateTransform`.

5. **Canvas, Grid, dan Panel lainnya**:
   - Panel adalah wadah yang membantu mengatur dan memposisikan elemen UI. Panel `Canvas` memungkinkan kita untuk memposisikan elemen menggunakan koordinat absolut.

### Contoh: Menggambar Bentuk dalam WPF

Berikut adalah steps by steps untuk membuat aplikasi WPF sederhana yang menggambar bentuk dan menggunakan transformasi.

1. **Membuat Project WPF**:
   - Buka Visual Studio.
   - Buat proyek baru: Pilih "WPF App (.NET Core)".
   - Beri nama project dan klik "Create".

2. **Men-define UI dalam XAML**:
   - Buka file `MainWindow.xaml` dan define UI menggunakan XAML.

Berikut adalah contoh yang menggambar persegi panjang, elips, dan garis, serta menerapkan transformasi rotasi pada persegi panjang:

```xml
<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="450" Width="800">
    <Canvas>
        <!-- Persegi panjang dengan transform rotation -->
        <Rectangle Width="200" Height="100" Fill="LightBlue" Stroke="Black" Canvas.Left="50" Canvas.Top="50">
            <Rectangle.RenderTransform>
                <RotateTransform Angle="45" CenterX="100" CenterY="50" />
            </Rectangle.RenderTransform>
        </Rectangle>

        <!-- Elips -->
        <Ellipse Width="100" Height="100" Fill="LightGreen" Stroke="Black" Canvas.Left="300" Canvas.Top="50" />

        <!-- Garis -->
        <Line X1="50" Y1="200" X2="250" Y2="350" Stroke="Red" StrokeThickness="2" />

        <!-- TextBlock dengan efek bayangan -->
        <TextBlock Text="Hello, WPF!" FontSize="24" Canvas.Left="50" Canvas.Top="400">
            <TextBlock.Effect>
                <DropShadowEffect Color="Black" ShadowDepth="5" />
            </TextBlock.Effect>
        </TextBlock>
    </Canvas>
</Window>
```

### Rendering Lanjutan di WPF

Untuk grafik yang lebih kompleks dan penggambaran khusus, kita dapat menggunakan kelas `DrawingVisual` dan override method `OnRender`.

1. **Membuat Kontrol Custom**:
   - Buat kelas baru yang inherit dari `FrameworkElement`.

2. **Override Method `OnRender`**:
   - Gunakan `DrawingContext` untuk menggambar grafik khusus.

Berikut adalah contoh:

```csharp
using System.Windows;
using System.Windows.Media;

public class CustomDrawing : FrameworkElement
{
    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);

        // Menggambar persegi panjang
        Rect rect = new Rect(50, 50, 200, 100);
        drawingContext.DrawRectangle(Brushes.LightBlue, new Pen(Brushes.Black, 2), rect);

        // Menggambar lingkaran
        drawingContext.DrawEllipse(Brushes.LightGreen, new Pen(Brushes.Black, 2), new Point(400, 100), 50, 50);

        // Menggambar garis
        drawingContext.DrawLine(new Pen(Brushes.Red, 2), new Point(50, 200), new Point(250, 350));

        // Menggambar teks
        FormattedText text = new FormattedText("Hello, WPF!",
            System.Globalization.CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
            new Typeface("Arial"), 24, Brushes.Black);
        drawingContext.DrawText(text, new Point(50, 400));
    }
}
```

3. **Menggunakan Kontrol Kustom dalam XAML**:
   - Tambahkan kontrol kustom ke `MainWindow.xaml`.

```xml
<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:WpfApp"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <local:CustomDrawing />
    </Grid>
</Window>
```

## Rendering di Gambar/Asset di WPF

Di WPF kita juga tidak harus menggambar objek satu persatu. Kita bisa menggunakan asset yang berupa gambar.

### 1. Gambar

Kita dapat menggunakan gambar dalam aplikasi WPF kita dengan menambahkannya ke dalam project dan me-reference-kannya dalam XAML atau code-behind.

#### XAML:

```xml
<Image Source="path/ke/gambar.png" Width="100" Height="100"/>
```

#### Code-behind:

```csharp
BitmapImage bitmap = new BitmapImage(new Uri("path/ke/gambar.png", UriKind.Relative));
myImage.Source = bitmap;
```

### 2. Icon

Icon biasanya digunakan untuk icon aplikasi atau tombol. Kita dapat menggunakan file icon (`.ico`) atau file gambar (`.png`, `.jpg`, dll.) untuk icon.

#### XAML:

```xml
<Button>
    <Image Source="path/ke/icon.ico" Width="16" Height="16"/>
</Button>
```

#### Code-behind:

```csharp
BitmapImage bitmap = new BitmapImage(new Uri("path/ke/ikon.ico", UriKind.Relative));
myButton.Content = new Image { Source = bitmap, Width = 16, Height = 16 };
```

### 3. Font

Untuk menggunakan font custom dalam aplikasi WPF, kita perlu include file font dalam project dan me-reference-kannya dalam XAML.

#### XAML:

```xml
<TextBlock FontFamily="Fonts/#FontCustom" Text="Halo, WPF!" FontSize="24"/>
```

### 4. Sumber Daya Lainnya

Kita juga dapat menggunakan source lainnya, seperti file audio atau file data, dalam project WPF dan mengaksesnya.

#### Mengakses asset lainnya:

```csharp
// Mengakses file teks
string teks = File.ReadAllText("path/ke/file.txt");

// Mengakses file audio
var audioSource = new MediaPlayer();
audioSource.Open(new Uri("path/ke/audio.mp3", UriKind.Relative));
audioSource.Play();
```
