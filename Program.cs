using System;
using System.Collections.Generic;

class Program
{
    static List<Task> tasks = new List<Task>();
    static int nextId = 1;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== TASK MANAGER CLI ===");
            Console.WriteLine("1. Lihat Semua Task");
            Console.WriteLine("2. Tambah Task");
            Console.WriteLine("3. Selesaikan Task");
            Console.WriteLine("4. Hapus Task");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih menu: ");

            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    LihatTask();
                    break;
                case "2":
                    TambahTask();
                    break;
                case "3":
                    SelesaikanTask();
                    break;
                case "4":
                    HapusTask();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Menu tidak valid!");
                    TekanEnter();
                    break;
            }
        }
    }

    static void LihatTask()
    {
        Console.Clear();
        Console.WriteLine("=== DAFTAR TASK ===");

        if (tasks.Count == 0)
        {
            Console.WriteLine("Belum ada task.");
        }
        else
        {
            foreach (var task in tasks)
            {
                string status = task.IsCompleted ? "Selesai" : "Belum";
                Console.WriteLine($"{task.Id}. {task.Title} [{status}]");
            }
        }

        TekanEnter();
    }

    static void TambahTask()
    {
        Console.Clear();
        Console.Write("Masukkan nama task: ");
        string title = Console.ReadLine();

        Task newTask = new Task
        {
            Id = nextId,
            Title = title,
            IsCompleted = false
        };

        tasks.Add(newTask);
        nextId++;

        Console.WriteLine("✅ Task berhasil ditambahkan!");
        TekanEnter();
    }

    static void SelesaikanTask()
    {
        Console.Clear();
        Console.Write("Masukkan ID task yang selesai: ");

        try
        {
            int id = int.Parse(Console.ReadLine());
            Task task = tasks.Find(t => t.Id == id);

            if (task != null)
            {
                task.MarkAsCompleted();
                Console.WriteLine("✅ Task ditandai selesai!");
            }
            else
            {
                Console.WriteLine("❌ Task tidak ditemukan!");
            }
        }
        catch
        {
            Console.WriteLine("❌ Input harus angka!");
        }

        TekanEnter();
    }   

    static void HapusTask()
    {
        Console.Clear();
        Console.Write("Masukkan ID task yang ingin dihapus: ");

        try
        {
            int id = int.Parse(Console.ReadLine());
            Task task = tasks.Find(t => t.Id == id);

            if (task != null)
            {
                tasks.Remove(task);
                Console.WriteLine("✅ Task berhasil dihapus!");
            }
            else
            {
                Console.WriteLine("❌ Task tidak ditemukan!");
            }
        }
        catch
        {
            Console.WriteLine("❌ Input harus angka!");
        }

        TekanEnter();
    }

    static void TekanEnter()
    {
        Console.WriteLine("\nTekan ENTER untuk lanjut...");
        Console.ReadLine();
    }
}
