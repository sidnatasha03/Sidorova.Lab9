using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

            var path = "Collection.csv";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding(1251);

            var lines = File.ReadAllLines(path, encoding);
            var persons = new Person[lines.Length - 1];

            for (int i = 1; i < lines.Length; i++)
            {
                var splits = lines[i].Split(';');
                var person = new Person();
                person.Id = Convert.ToInt32(splits[0]);
                person.Name = splits[1];
                person.Email = splits[2];
                person.Phone = splits[3];
                person.Age = Convert.ToInt32(splits[4]);
                person.City = splits[5];
                person.Street = splits[6];
                person.Tag = splits[7];
                person.Price = Convert.ToInt32(splits[8]);
                person.CustomerId = splits[9];
                person.ProductId = splits[10];

                persons[i - 1] = person;
            }

            //Задание 1
            Console.WriteLine("Задание 1");

            int CustomerId = 0;

                if (CustomerId == 1) Console.WriteLine("Записи по свойству CustomerId уникальны");
                for (var i = 0; i < persons.Length; i++)
                { 
                    int k = persons.Count(s => s.CustomerId == persons[i].CustomerId);
                    if (k != CustomerId)
                {
                    Console.WriteLine("Записи по свойству CustomerId не уникальны");
                    break;
                }
                    CustomerId++;
                }
            
            Console.WriteLine();

            //Задание 2
            Console.WriteLine("Задание 2");
            Console.WriteLine("Сумма заказов: " + persons.Sum(x => x.Price));
            Console.WriteLine();

            //Задание 3
            Console.WriteLine("Задание 3");
            var sorted = from x in persons
                         orderby x.ProductId
                         select x;

            var result = "resultsortedemail.csv";

            using (StreamWriter streamWriter = new StreamWriter(result, false, encoding))
            {
                streamWriter.WriteLine($"Id;Name;Email;Phone;Age;City;Street;Tag;Price;CustomerId;ProductId");

                foreach (var a in sorted)
                {
                    streamWriter.WriteLine(a.ToExcel());
                }
                foreach (Person person in sorted)
                    Console.WriteLine(person.Id + " " + person.Name + " " + person.Email + " " + person.City + " " + person.Phone + " " + person.Age + " " + person.Street + " " + person.Tag + " " + person.Price + " " + person.CustomerId + " " + person.ProductId + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Задание 4
            Console.WriteLine("Задание 4");
            var selectedcity = from city in persons
                                where city.City == "Воронеж"
                                select city;

            var result1 = "resultprice.csv";
            using (StreamWriter streamWriter = new StreamWriter(result1, false, encoding))
            {
                streamWriter.WriteLine($"Id;Name;Email;Phone;Age;City;Street;Tag;Price;CustomerId;ProductId");

                foreach (var gorod in selectedcity)
                {
                    streamWriter.WriteLine(gorod.ToExcel());
                }
                foreach (Person person in selectedcity)
                    Console.WriteLine(person.Id + " " + person.Name + " " + person.Email + " " + person.City + " " + person.Phone + " " + person.Age + " " + person.Street + " " + person.Tag + " " + person.Price + " " + person.CustomerId + " " + person.ProductId + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Задание 5
            char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'e', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'm', 'N', 'O', 'P', 'Q', 'r', 'S', 'T', 'U', 'v', 'W', 'X', 'Y', 'z' };
            string[] emails = { "yaguar666@mail.ru", "Sash0kZapash0k@gmail.com", "Bozhenka@mail.ru", "mrsK1tty@gmail.com", "ZayaIzRaya@yandex.ru", "GGbr0@gmail.com", "YaLubluDota2@mail.ru", "NenavizhuDota2@gmail.com", "Gayechka@gmail.com" };
            string[] names = { "Ярослава Всеволодова", "Анастасия Мирная", "Дминтрий Константинопольский", "Мария Выглодова", "Никита Жмыхов", "Диана Зайцева", "Неонила Задорная", "Кирилл Рыготин", "Людмила Польская", "Софья Кудрявцева" };
            string[] cities = { "Москва", "Обнинск", "Омск", "Красноярск", "Краснодар", "Томск", "Новосибирск", "Санкт-Петербург", "Симферополь", "Севастополь" };
            string[] phones = { "(741)465-59-91", "(900)797-56-85", "(983)637-71-24", "(954)093-64-44", "(200)576-89-22", "(593)273-01-91", "(814)393-72-48", "(025)851-00-60", "(221)335-45-39", "(699)132-43-83" };
            string[] streets = { "Проезд Репина", "Манхетен стрит", "Улина Красных фонарей", "Невская", "Красная улица", "Дворцовая площадь", "Тверская улица", "Улица Лузана", "Улица Дзержинского" };
            string[] tags = { "Плакаты", "Фигурки", "Значки", "Дакимакура", "Сладости", "Брелки", "Видео-игры", "Диски", "Геймпады", "Полотенце", "Арты", "Косплей" };
            string[] ages = { "18", "21", "45", "25", "34", "20", "41", "49", "19", "51", "43", "27", "43", "37", "49" };
            var customId = new List<string>();
            var productID = new List<string>();
            Random random = new Random();
            //генерирация случайных записей для customerId 
            for (int j = 0; j < 10; j++)
            {
                string str = "";
                for (int i = 0; i < 10; i++)
                {
                    var newstr = symbols[random.Next(0, symbols.Length)];
                    str += newstr;
                }
                customId.Add(str);
            }
            //генерирация случайных записей для productID 
            for (int g = 0; g < 10; g++)
            {
                string stri = "";
                for (int o = 0; o < 10; o++)
                {
                    var newstri = symbols[random.Next(0, symbols.Length)];
                    stri += newstri;
                }
                productID.Add(stri);
            }
            var result2 = "result.csv";

            using (var writer = new StreamWriter(result2, true, encoding))

            {
    
    for (int l = persons.Length + 1; l < persons.Length + 5; l++)
                {
                    var NewRecord = new List<Person>()
                    {
                      new Person { Id = l, Name = names[random.Next(0, names.Length)], Email = emails[random.Next(0, emails.Length)], Phone = phones[random.Next(0, phones.Length)], Age = random.Next(0, ages.Length), City = cities[random.Next(0, cities.Length)], Street = streets[random.Next(0, streets.Length)], Tag = tags[random.Next(0, tags.Length)], Price = random.Next(200, 40000), CustomerId = customId[random.Next(0, customId.Count)], ProductId = productID[random.Next(0, productID.Count)] }
                    };
                    foreach (var n in NewRecord)
                    {
                        writer.WriteLine(n.ToExcel());
                    }
                }
            }
       



public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Tag { get; set; }
    public int Price { get; set; }
    public string CustomerId { get; set; }
    public string ProductId { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}\n Имя и фамилия: {Name}\n Электронный адрес : {Email}\n Номер телефона: {Phone}\n Возраст: {Age}\n Город: {City}\n Улица: {Street}\n Тэг:{Tag}\n Цена: {Price}\n Id покупателя: {CustomerId}\n Id товара: {ProductId}\n ";
    }
    public string ToExcel()
    {
        return $"{Id};{Name};{Email};{Phone};{Age};{City};{Street};{Tag};{Price};{CustomerId};{ProductId}";
    }
}



