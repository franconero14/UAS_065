using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_065
{
    class Node
    {
        public int Id_pelanggan;
        public string Nama_pelanggan;
        public string Jenis_kelamin_pelanggan;
        public int Nomor_telepon_pelanggan;
        public Node next;
    }

    class list
    {
        Node START;
        public list()
        {
            START = null;
        }
        public void insert()
        {
            int ip, ntp;
            string np, jkp;

            Console.Write("Masukan Id pelanggan : ");
            ip = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukan Nama pelanggan : ");
            np = Console.ReadLine();
            Console.Write("Masukan Nomor telepon pelanggan : ");
            ntp = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukan Jenis kelamin pelanggan : ");
            jkp = Console.ReadLine();

            Node newnode = new Node();

            newnode.Id_pelanggan = ip;
            newnode.Nama_pelanggan= np;
            newnode.Jenis_kelamin_pelanggan = jkp;
            newnode.Nomor_telepon_pelanggan = ntp;

            if (START == null || ip <= START.Id_pelanggan)
            {
                if ((START != null) && (ip == START.Id_pelanggan))
                {
                    Console.WriteLine("Duplikat Id pelanggan tidak diperbolehkan");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (ip >= current.Id_pelanggan))
            {
                if (ip == current.Id_pelanggan)
                {
                    Console.WriteLine("\nDuplikat Id pelanggan tidak diperbolehkan");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool search(int ntp, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;


            while ((current != null) && (ntp != current.Nomor_telepon_pelanggan))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);

        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nList data pelanggan : ");
                Console.Write("Id pelanggan" + "   " + "Nama pelanggan" + "    " + "Jenis kelamin pelanggan" + "   " + "Nomor telepon pelanggan" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write(currentNode.Id_pelanggan + "    " + currentNode.Nama_pelanggan + "    " + currentNode.Jenis_kelamin_pelanggan + "         " + currentNode.Nomor_telepon_pelanggan + "\n");
                }
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. View all the records in the list");
                    Console.WriteLine("3. Search for a record in the list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insert();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is kosong");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nmasukan Id pelanggan yang ingin dicari : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Node NTP;
                                    for (NTP = current; NTP != null; NTP = NTP.next)
                                    {
                                        Console.WriteLine("\nRecord  found");
                                        Console.WriteLine("\nId pelanggan: " + current.Id_pelanggan);
                                        Console.WriteLine("\nNama pelanggan : " + current.Nama_pelanggan);
                                        Console.WriteLine("\nJenis kelamin pelanggan: " + current.Jenis_kelamin_pelanggan);
                                        Console.WriteLine("\nNomor telepon pelanggan: " + current.Nomor_telepon_pelanggan);
                                    }
                                }
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for for the value entered");
                }
            }
        }
    }
}

//2. Singly Linked List dan Doubly Linked List,
//*Karna penggunaan variasi data tersebut berhubungan dengan soal yang diperintahkan dan penggunaan singly linked list dan doubly linked list dapat membuat aplikasi melakukan pencarian berdasarkan nama pelanggan.

//3. 