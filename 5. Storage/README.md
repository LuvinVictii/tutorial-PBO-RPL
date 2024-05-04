# Tutorial Data/Storage (I/O, File) dalam C#

## Pengenalan

Operasi Input/Output (I/O) dan pengelolaan file adalah bagian penting dari pengembangan perangkat lunak. Dalam C#, Anda dapat dengan mudah melakukan operasi I/O dan berinteraksi dengan file menggunakan kelas-kelas bawaan dalam .NET Framework.

## Jenis Operasi I/O

1. **Input**: Membaca data dari sumber eksternal seperti keyboard, file, atau perangkat lainnya.

2. **Output**: Menulis data ke sumber eksternal seperti layar, file, atau perangkat lainnya.

## Operasi Input Sederhana

### Membaca Input dari Pengguna

Untuk membaca input dari pengguna, Anda dapat menggunakan metode `Console.ReadLine()`. Contohnya:

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Masukkan nama Anda: ");
        string name = Console.ReadLine();
        Console.WriteLine("Halo, " + name + "! Selamat datang.");
    }
}
```
Metode ```ReadLine()``` membaca baris teks dari input pengguna dan mengembalikan string yang dimasukkan.

## Operasi Output Sederhana

### Menampilkan Output ke Layar

Untuk menampilkan output ke layar, Anda dapat menggunakan metode ```Console.WriteLine()``` atau ```Console.Write()```. Contohnya:

```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Halo, dunia!");
    }
}
```

Metode ```WriteLine()``` menampilkan teks ke layar diikuti dengan baris baru, sedangkan ```Write()``` hanya menampilkan teks tanpa baris baru.

## Operasi File dalam C#

Dalam C#, Anda dapat melakukan berbagai operasi file seperti membuat, membaca, menulis, menghapus, dan memindahkan file. Berikut adalah contoh penggunaan operasi file dalam C#:

### Membaca File

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = "data.txt";

        // Membaca semua baris dalam file
        string[] lines = File.ReadAllLines(path);

        // Menampilkan isi file
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}
```

### Menulis ke File

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = "output.txt";

        // Data yang akan ditulis ke file
        string[] data = { "Baris 1", "Baris 2", "Baris 3" };

        // Menulis data ke file
        File.WriteAllLines(path, data);

        Console.WriteLine("Data telah ditulis ke file.");
    }
}

```

### Menghapus File 

```csharp
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = "file_to_delete.txt";

        // Menghapus file
        File.Delete(path);

        Console.WriteLine("File telah dihapus.");
    }
}

```