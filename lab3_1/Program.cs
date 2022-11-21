using System;
using System.Text;
using System.Runtime.InteropServices;
using lab3_1;

class Programm
{
    private static string path = "/Users/artur/ProgrammFiles/STUDY/yavu/lab3_1";
    public static string file1 = path + "/texter (1).txt", file2 = path + "/texter (5).txt";
    
    static void Main()
    {
        Lib? lib1 = new Lib(file1);
        Lib? lib2 = null;
        // Lib? lib1 = new Lib(file1), lib2 = new Lib(file2);
        // if (lib1 !=null && lib2!=null)
        //     Console.WriteLine("Библиотеки открыты успешно");
        // else
        //     Console.WriteLine("ОШИБКАОШИБКАОШИБКА!!!");
        //
        return;
        try 
        {
            
            byte menu;
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1 - Открыть файлы");
                Console.WriteLine("2 - Получить количество слов в файлах");
                Console.WriteLine("3 - Оставить в файлах только десять самых часто встречающихся в них слов");
                Console.WriteLine("4 - Заменить каждое чётное слово из первого файла на соответствующее\n" +
                                  "по порядку слово из второго. Заменить каждое нечётное слово из второго\n" +
                                  "файла на соответствующее по порядку слово из первого");
                Console.WriteLine("5 - Завершить программу");
                menu = Convert.ToByte(Console.ReadLine());
                Console.Clear();
                if (menu != 1 && lib1 == null && lib2 == null)
                {
                    Console.WriteLine("Файлы не открыты");
                    Console.ReadKey();
                    continue;
                }
                switch (menu)
                {
                    case 1:
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Слов в файле {0}: {1}", file1, Lib.length(lib1.desc));
                        Console.WriteLine("Слов в файле {0}: {1}", file2, Lib.length(lib2.desc));
                        Console.ReadKey();
                        break;
                    case 3:
                        string temp = "";
                        int count1 = Lib.length(lib1.desc);
                        var word = new string[count1];
                        var count = new int[count1];
                        int search, ind = 0;
                        StringBuilder str = new StringBuilder(capacity: 255);
                        for (int i = 1, index = 0; i <= count1; i++)
                        {
                            Lib.read(lib1.desc, i, str);
                            search = Array.IndexOf(word, str.ToString());
                            if (search == -1)
                            {
                                word.SetValue(str.ToString(), index);
                                count.SetValue(0, index);
                                index++;
                            }
                            else
                                count[search]++;
                        }
                        for (int i = count1, words = 0; words < 10; i--)
                        {
                            search = Array.IndexOf(count, i, ind);
                            if (search != -1)
                            {
                                temp += (string)word.GetValue(search) + ' ';
                                words++;
                                i++;
                                ind = search + 1;
                            }
                            else
                                ind = 0;
                        }
                        lib1?.Dispose();
                        lib1 = new Lib(file1, false);
                        Lib.write(lib1.desc, temp);
                        lib1?.Dispose();
                        lib1 = new Lib(file1);
                        Console.WriteLine("\nСлова первого файла: {0}", temp);
                        temp = "";
                        int count2 = Lib.length(lib2.desc);
                        word = new string[count2];
                        count = new int[count2];
                        ind = 0;
                        for (int i = 1, index = 0; i <= count2; i++)
                        {
                            Lib.read(lib2.desc, i, str);
                            search = Array.IndexOf(word, str.ToString());
                            if (search == -1)
                            {
                                word.SetValue(str.ToString(), index);
                                count.SetValue(0, index);
                                index++;
                            }
                            else
                                count[search]++;
                        }
                        for (int i = count2, words = 0; words < 10; i--)
                        {
                            search = Array.IndexOf(count, i, ind);
                            if (search != -1)
                            {
                                temp += (string)word.GetValue(search) + ' ';
                                words++;
                                i++;
                                ind = search + 1;
                            }
                            else
                                ind = 0;
                        }
                        lib2?.Dispose();
                        lib2 = new Lib(file2, false);
                        Lib.write(lib2.desc, temp);
                        lib2?.Dispose();
                        lib2 = new Lib(file2);
                        Console.WriteLine("\nСлова второго файла: {0}", temp);
                        Console.ReadKey();
                        break;
                    case 4:
                        count1 = Lib.length(lib1.desc);
                        count2 = Lib.length(lib2.desc);
                        string text1 = "", text2 = "";
                        int minim = count1 > count2 ? count2 : count1;
                        int maxim = count1 > count2 ? count1 : count2;
                        Lib full_txt = count1 > count2 ? lib1 : lib2;
                        StringBuilder slovo = new StringBuilder(capacity: 255);
                        for (int i = 1; i <= minim; i++)
                        {
                            Lib.read(lib1.desc, i++, slovo);
                            text1 += slovo.ToString() + ' ';
                            text2 += slovo.ToString() + ' ';
                            Lib.read(lib2.desc, i, slovo);
                            text1 += slovo.ToString() + ' ';
                            text2 += slovo.ToString() + ' ';
                        }
                        temp = count1 > count2 ? text1 : text2;
                        Console.WriteLine(temp);
                        for (int i = minim + 1; i <= maxim; i++)
                        {
                            Lib.read(full_txt.desc, i, slovo);
                            temp += slovo.ToString() + ' ';
                        }
                        if (count1 > count2)
                            text1 = temp;
                        else
                            text2 = temp;
                        lib1?.Dispose();
                        lib1 = new Lib(file1, false);
                        Lib.write(lib1.desc, text1);
                        lib1?.Dispose();
                        lib1 = new Lib(file1);
                        lib2?.Dispose();
                        lib2 = new Lib(file2, false);
                        Lib.write(lib2.desc, text2);
                        lib2?.Dispose();
                        lib2 = new Lib(file2);
                        Console.WriteLine("\nТекст первого файла: {0}", text1);
                        Console.WriteLine("\nТекст второго файла: {0}", text2);
                        Console.ReadKey();
                        break;
                }
            } while (menu != 5);
        }
        finally
        {
            lib1?.Dispose();
            lib2?.Dispose();
        }
    }

}