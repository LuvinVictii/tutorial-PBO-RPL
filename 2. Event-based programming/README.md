# Event-driven Programming
Event-driven programming adalah metode pemrograman yang bergantung pada event yang terjadi. Biasanya event-driven programming digunakan dalam game development.

## Input sebagai Event
Dalam C#, trigger input dapat terdeteksi sebagai event. Berikut adalah penjelasan bagaimana trigger input dilakukan di C#:

1. **Event Handling**: C# menggunakan event-driven programming, di mana action atau input trigger menghasilkan peristiwa yang dapat ditangani oleh event handler.

3. **Event Handlers**: Event handler adalah method atau function yang terpanggil ketika suatu event terjadi. Dalam konteks ini, event handler akan berhubungan dengan input trigger.

4. **Subscribing to Events**: Di C#, kita dapat subscribe to events menggunakan `+=` untuk menyambungkan event handler ke sebuah event. Biasanya hal ini dilakukan di constructor atau inisialisasi kode dari sebuah class.

5. **Responding to Triggers**: Ketika input trigger terjadi (misalnya sebuah tombol ditekan), event tertentu akan tertrigger. Ketika itu terjadi, event handler yang tersambung akan dijalankan.

Berikut contohnya:

```
using System;

class Program
{
    static void Main()
    {
        Button button = new Button();
        button.Click += Button_Click; // Subscribe ke event klik
        
        Console.WriteLine("Press any key to simulate a button click...");
        Console.ReadKey();
        
        button.OnClick(); // Mensimulasikan klik tombol
    }

    static void Button_Click(object sender, EventArgs e)
    {
        Console.WriteLine("Button clicked!");
    }
}

class Button
{
    public event EventHandler Click; // Menentukan event klik

    public void OnClick()
    {
        // Trigger event klik
        Click?.Invoke(this, EventArgs.Empty);
    }
}
```

Dalam contoh ini, ketika kita menekan tombol manapun, `Button click` akan tertrigger, lalu menampilkan "Button clicked!" di console.

## Cara mendapatkan input mouse dan keyboard
Di C#, namespace `System.Windows.Forms` utamanya menyediakan fungsionalitas untuk membuat Graphical User Interface (GUIs) di aplikasi Windows. Namun namespace ini juga menyediakan class untuk handling input untuk mouse dan keyboard.

Penggunaan `System.Windows.Forms` untuk input meliputi:

1. **Mouse Input Handling**:
   - Kita bisa handle input event seperti click, movement, dan scroll menggunakan class `Mouse` dan eventnya.
   - Event mouse yang biasa digunakan adalah `MouseDown`, `MouseUp`, `MouseMove`, dan `MouseWheel`.

2. **Keyboard Input Handling**:
   - Keyboard input bisa di-handle dengan event `Control.KeyDown` dan `Control.KeyUp`
   - `Control.KeyDown` akan mendeteksi ketika suatu tombol keyboard ditekan, dan `Control.KeyUp` akan mendeteksi ketika suatu tombol keyboard dilepas

Berikut contohnya:

```
using System;
using System.Windows.Forms;

class Program
{
    static void Main()
    {
        // Mmebuat form baru
        Form form = new Form();
        form.Text = "Mouse and Keyboard Input Example";
        form.Size = new System.Drawing.Size(300, 200);

        // Subscribe mouse events
        form.MouseDown += Form_MouseDown;
        form.MouseUp += Form_MouseUp;
        form.MouseMove += Form_MouseMove;

        // Subscribe keyboard events
        form.KeyDown += Form_KeyDown;
        form.KeyUp += Form_KeyUp;
        form.KeyPress += Form_KeyPress;

        // Menampilkan form
        Application.Run(form);
    }

    // Mouse event handlers
    static void Form_MouseDown(object sender, MouseEventArgs e)
    {
        Console.WriteLine("Mouse button down: " + e.Button);
    }

    static void Form_MouseUp(object sender, MouseEventArgs e)
    {
        Console.WriteLine("Mouse button up: " + e.Button);
    }

    static void Form_MouseMove(object sender, MouseEventArgs e)
    {
        Console.WriteLine("Mouse moved to: " + e.Location);
    }

    // Keyboard event handlers
    static void Form_KeyDown(object sender, KeyEventArgs e)
    {
        Console.WriteLine("Key down: " + e.KeyCode);
    }

    static void Form_KeyUp(object sender, KeyEventArgs e)
    {
        Console.WriteLine("Key up: " + e.KeyCode);
    }

    static void Form_KeyPress(object sender, KeyPressEventArgs e)
    {
        Console.WriteLine("Key press: " + e.KeyChar);
    }
}
```
