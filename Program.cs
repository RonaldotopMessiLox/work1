using System.Data;
class Programm
{
    public static void Main(String[] args)
    {
        DataTable students = new DataTable();

        students.Columns.Add("Id" , typeof(int));
        students.Columns.Add("Name", typeof(string));
        students.Columns.Add("Age", typeof(int));
        students.Columns.Add("Group Name", typeof(string));

        students.Rows.Add(1, "Петр Красавчикович", 21, "Програмное обеспечение");
        students.Rows.Add(2, "Илья Сигмович", 37, "Инф. бзопасность");
        students.Rows.Add(3, "Виктор Бибкович", 180, "Анегдото-рассказочный факультет");
        students.Rows.Add(4, "Семен Карантинович", 19, "Иркутчане");
        students.Rows.Add(5, "Александр Нормальный", 67, "МО");

        
        int choise = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("Меню: \n0. Выход\r\n1. Найти студента по Id.\r\n2. Изменить его возраст.\r\n3. Добавить нового студента.\r\n4. Удалить одного студента.\r\n5. Повторно вывести таблицу.\r\n6. Посмотреть самого старшего студента");
            choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 0:
                    Console.WriteLine("Досвидание!");
                    break;
                case 6:
                    DataRow maxAgeStudent = students.Rows[0];
                    foreach (DataRow row in students.Rows)
                    {
                        if (Convert.ToInt16(maxAgeStudent["Age"]) < Convert.ToInt16(row["Age"]))
                            maxAgeStudent = row;
                    }
                    Console.WriteLine("Самый старший студент: ");
                    Console.WriteLine($"{maxAgeStudent["Id"]}: {maxAgeStudent["Name"]}, {maxAgeStudent["Age"]} учится в {maxAgeStudent["Group Name"]}");
                    break;
                case 1:
                    Console.WriteLine("Поиск по айди");
                    Console.Write("Введите айди: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    DataRow result = FindById(id, students);
                    if (result != null)
                    {
                        Console.WriteLine($"{result["Id"]}: {result["Name"]}, {result["Age"]} учится в {result["Group Name"]}");
                    }
                    else
                    {
                        Console.WriteLine("Не нашли такого студента!");
                    }
                    break;
                case 5:
                    foreach (DataRow row in students.Rows)
                    {
                        Console.WriteLine($"{row["Id"]}: {row["Name"]}, {row["Age"]} учится в {row["Group Name"]}");
                    }
                    break;
                case 2:
                    Console.Write("Введите айди: ");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    DataRow result1 = FindById(id1, students);
                    if (result1 != null)
                    {
                        Console.Write("Введите новое значение возраста: ");
                        int newAge = Convert.ToInt16(Console.ReadLine());
                        int ageBefore;
                        foreach (DataRow row in students.Rows)
                        {
                            if (row == result1)
                            {
                                ageBefore = Convert.ToInt16(row["Age"]);
                                row["Age"] = newAge;
                                Console.WriteLine($"Возраст успешно изменен! ({ageBefore} -> {newAge})");
                                break;
                            }
                        }
                    }
                    else Console.WriteLine("Не нашли такого студента!");
                    break;
                case 3:
                    DataRow newRow = AddNewStudent(students);
                    Console.WriteLine("Успешно добавленно");
                    break;
                case 4:
                    deleteStudent(students);
                    Console.WriteLine("Студент успешно удален!");
                    break;
                default:
                    break;
            }
            Console.ReadLine();
            } while (choise != 0);

    }
    public static void deleteStudent(DataTable dt)
    {
        Console.WriteLine("Поиск по айди");
        Console.Write("Введите айди: ");
        int id = Convert.ToInt32(Console.ReadLine());
        DataRow result = FindById(id, dt);
        if (result != null)
        {
            dt.Rows.Remove(result);
        }
        else Console.WriteLine("Не найден такой студент!");
    }
    public static DataRow AddNewStudent(DataTable dt)
    {
        Console.WriteLine("Введите имя");
        string name = Console.ReadLine();
        Console.WriteLine("Введите возраст");
        int age = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Введите группу ");
        string Group = Console.ReadLine();

        dt.Rows.Add(Convert.ToInt16(dt.Rows[dt.Rows.Count - 1]["Id"]) + 1, name, age, Group);
        return dt.Rows[dt.Rows.Count - 1];
    }
    public static DataRow FindById(int id, DataTable dt)
    {
        foreach (DataRow row in dt.Rows)
        {
            if (Convert.ToInt16(row["Id"]) == id)
            { 
                return row;
            }
        }
        return null;
    }
}
