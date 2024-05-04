# Tutorial Multithreading dalam C#

## Pengenalan

Multithreading adalah teknik yang memungkinkan eksekusi beberapa aliran instruksi secara bersamaan, meningkatkan responsivitas aplikasi dan meningkatkan kinerja. Dalam C#, Anda dapat menggunakan kelas `Thread` untuk membuat dan mengelola thread.

## Mengapa Multithreading Penting?

1. **Responsivitas**: Dengan multithreading, aplikasi dapat tetap responsif saat melakukan tugas berat atau menunggu masukan pengguna.

2. **Peningkatan Kinerja**: Dengan memanfaatkan beberapa inti prosesor secara bersamaan, aplikasi dapat melakukan lebih banyak pekerjaan dalam waktu yang lebih singkat.

3. **Skalabilitas**: Multithreading memungkinkan aplikasi untuk menangani lebih banyak permintaan secara bersamaan, meningkatkan skalabilitas sistem.

## Konsep Dasar Multithreading

1. **Thread**: Thread adalah aliran eksekusi independen dalam sebuah program.

2. **Synchronization**: Synchronization adalah teknik untuk mengontrol akses ke sumber daya bersama dari beberapa thread untuk menghindari situasi seperti race condition.

3. **Deadlock**: Deadlock terjadi ketika dua atau lebih thread terjebak dalam situasi di mana masing-masing menunggu sumber daya yang dipegang oleh yang lain.


## Implementasi Multithreading dalam C#

Berikut adalah contoh sederhana implementasi multithreading dalam C#:

```csharp
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Membuat objek Thread dan menentukan method yang akan dieksekusi
        Thread t1 = new Thread(new ThreadStart(Method1));
        Thread t2 = new Thread(new ThreadStart(Method2));

        // Memulai eksekusi kedua thread
        t1.Start();
        t2.Start();

        // Menunggu kedua thread selesai
        t1.Join();
        t2.Join();

        Console.WriteLine("Eksekusi kedua thread telah selesai.");
    }

    static void Method1()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Method1 dijalankan " + i);
            // Memberi sedikit jeda untuk simulasi
            Thread.Sleep(1000);
        }
    }

    static void Method2()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Method2 dijalankan " + i);
            // Memberi sedikit jeda untuk simulasi
            Thread.Sleep(1000);
        }
    }
}
```
menghasilkan output seperti ini

```csharp
Method1 dijalankan 0
Method2 dijalankan 0
Method1 dijalankan 1
Method2 dijalankan 1
Method1 dijalankan 2
Method2 dijalankan 2
Method1 dijalankan 3
Method2 dijalankan 3
Method1 dijalankan 4
Method2 dijalankan 4
Eksekusi kedua thread telah selesai.
```

