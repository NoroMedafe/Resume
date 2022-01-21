using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace КлассыБанк
{

    class Program
    {

        static int IntTryCatch()
        {
            int a;
            try
            {
                a = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный ввод");
                return -1;
            }
            return a;
        }
        static double DoubleTryCatch()
        {
            double a;
            try
            {
                a = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный ввод");
                return -1;
            }
            if (a <= 0) return -1;
            return a;
        }

        public static void Sort(ref BankAccount[] ba)
        {
            for (int i = 0; i < ba.Length; i++)
            {
                if (ba[i]==null)
                {
                    for (int j = i+1; j < ba.Length; j++)
                    {
                        ba[j-1] = ba[j];
                    }
                    Array.Resize(ref ba, ba.Length - 1);
                    if (i == ba.Length-1)
                    {
                        Array.Resize(ref ba, ba.Length - 1);
                    }    
                }
            }
        }
        /// <summary>
        /// Нахождение номера необходимого счета
        /// </summary>
        /// <param name="accountsBank"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        static int FindAccount(ref BankAccount[] accountsBank, int number)
        {
            for (int i = 0; i < accountsBank.Length; i++)
            {
                if (accountsBank[i].Number == number)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// Нахождение пустого элемента массива для последующей записи туда счета
        /// </summary>
        /// <param name="accountsBank"></param>
        /// <returns></returns>
        static int FindNullAccount(ref BankAccount[] accountsBank)
        {
            for (int i = 0; i < accountsBank.Length; i++)
            {
                if (accountsBank[i] == null)
                    return i;
            }
            return -1;
        }
       
        static void Main(string[] args)
        {


            int newnumber = new int();
            int pos = new int();
            double sum = new double();
            int pos2 = new int();
            BankAccount[] accountMassive = new BankAccount[1];
            Console.Title = "Банк";
            string name;
            int acnum;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в Банк 'СПБ-КИТ'");
                Console.WriteLine("Для начала вам необходимо открыть новый счет");
                Console.Write("Введите номер счета:");
                acnum = IntTryCatch();
                if (acnum == -1) continue;
                Console.Write("Введите ваше ФИО:");
                name = Console.ReadLine();
                break;
            }
            accountMassive[0] = new BankAccount(acnum, DateTime.Now, name);
            Console.WriteLine($"Счет на ФИО {name} был успешно открыт");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите дальнейшее действие:\n" +
                "1. Открыть новый счет\n" +
                "2. Пополнить счет\n" +
                "3. Снять деньги со счета\n" +
                "4. Найти счет по номеру\n" +
                "5. Перевод между счетами\n" +
                "6. Объединение двух счетов\n" +
                "7. Начислить проценты\n" +
                "8. Сравнить счета\n" +
                "9. Закрыть счет\n" +
                "99. Просмотр массива ");
                //Выбор пункта
                string selection = Console.ReadLine();

                switch (selection)
                {
                    
                    case "1"://Открытие нового счета
                        Console.Write("Введите номер счета:"); //Создаем новый счет
                        acnum = IntTryCatch();
                        if (acnum <= 0) break; //Запрет на ввод счета с номером <= 0
                        Console.Write("Введите ваше ФИО:");
                        name = Console.ReadLine();//Ввод полного имени
                        Array.Resize(ref accountMassive, accountMassive.Length + 1);
                        accountMassive[accountMassive.Length-1] = new BankAccount(acnum, DateTime.Now, name);//Создаем новую запись                       
                        Console.WriteLine($"Счет на ФИО {name} был успешно открыт");
                        Console.ReadLine();
                        break;
                    

                    
                    case "2"://Пополнение счета
                        Console.Write("Введите номер счета:");
                        acnum = IntTryCatch();//Ввод номера счета
                        if (acnum <= 0) //Запрет на ввод счета с номером <= 0
                            break;
                        pos = FindAccount(ref accountMassive, acnum); //Ищем счет с номером acnum
                        if (pos == -1)
                        {
                            Console.WriteLine("Такого счета не существует!");
                            Console.ReadLine();
                            break;
                        }
                        if (accountMassive[pos].Closed)
                        {
                            Console.WriteLine("Счет закрыт! Любые действия невозможны!");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Введите сумму пополнения:");
                        sum = DoubleTryCatch(); //Проверка ввода double
                        if (sum <= 0) break;
                        accountMassive[pos] += sum;//Метод пополнения суммы счета
                        Console.WriteLine("Транзакция прошла успешно");
                        Console.ReadLine();
                        break;
                  
                    case "3"://Вывод средств
                        Console.Write("Введите номер счета:");
                        acnum = IntTryCatch();//Ввод номера счета
                        if (acnum <= 0) //Запрет на ввод счета с номером <= 0
                            break;
                        pos = FindAccount(ref accountMassive, acnum);//Поиск аккаунта с соответствующим номером счета
                        if (pos == -1)
                        {
                            Console.WriteLine("Такого счета не существует!");
                            Console.ReadLine();
                            break;
                        }
                        if (accountMassive[pos].Closed)
                        {
                            Console.WriteLine("Счет закрыт! Любые действия невозможны!");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Введите сумму снятия:");
                        sum = DoubleTryCatch();
                        if (sum <= 0) break;
                        if (accountMassive[pos].Money < sum) //Если денег недостаточно для снятия
                        {
                            Console.WriteLine("На счету недостаточно средств!");
                            Console.ReadLine();
                            break;
                        }
                        accountMassive[pos] -= sum;//Вывод суммы
                        Console.WriteLine($"Успешное снятие на сумму {sum}");
                        Console.WriteLine("Транзакция прошла успешно");
                        Console.ReadLine();
                        break;
                   
                    case "4"://Информация о счете
                        string a = "Закрыт", b = "Открыт";
                        Console.Write("Введите номер счета:");
                        acnum = IntTryCatch();
                        if (acnum == -1 || acnum <=0) break;
                        pos = FindAccount(ref accountMassive, acnum); //Ищем счет
                        if (pos == -1)
                        {
                            Console.WriteLine("Такого счета не существует!");
                            Console.ReadLine();
                            break;
                        }
                        Console.WriteLine($"Номер счета - {accountMassive[pos].Number}");
                        Console.WriteLine($"ФИО владельца - {accountMassive[pos].FullName}");
                        Console.WriteLine($"Дата открытия - {accountMassive[pos].OpeningDate}");
                        Console.WriteLine($"Сумма на счету - {accountMassive[pos].Money}");
                        if (accountMassive[pos].Closed) Console.WriteLine($"Закрытый счет - Да");
                        else Console.WriteLine($"Закрытый счет - Нет");
                        Console.ReadLine();
                        break;
                   
                    case "5"://Перевод между счетами
                        Console.Write("Введите номер счета !с которого! произойдет перевод:");
                        acnum = IntTryCatch();
                        if (acnum == -1 || acnum <=0) break;
                        pos = FindAccount(ref accountMassive, acnum); //Ищем счет
                        if (pos == -1)
                        {
                            Console.WriteLine("Такого счета не существует!");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Введите номер счета !на который! произойдет перевод:");
                        acnum = IntTryCatch();
                        if (acnum == -1 || acnum <=0) break;
                        pos2 = FindAccount(ref accountMassive, acnum);
                        if (pos2 == -1)
                        {
                            Console.WriteLine("Такого счета не существует!");
                            Console.ReadLine();
                            break;
                        }
                        if (accountMassive[pos].Closed || accountMassive[pos2].Closed)
                        {
                            Console.WriteLine("Один из счетов закрыт!");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Введите сумму:");
                        sum = DoubleTryCatch();
                        if (sum == -1 || sum <=0) break;
                        if (accountMassive[pos].Money < sum)
                        {
                            Console.WriteLine("Недостаточно средств на счету - переводчика средств!");
                            Console.ReadLine();
                            break;
                        }
                        if (sum == accountMassive[pos].Money)
                        {//pos2 - на который перейдут деньги, pos - с которого уйдут все деньги
                            accountMassive[pos2] -= accountMassive[pos];
                            accountMassive[pos] -= sum;
                        }
                        else
                        {
                            accountMassive[pos2].TopUpAccount(sum);
                            accountMassive[pos].Withdraw(sum);
                        }
                        Console.WriteLine("Транзакция прошла успешно");
                        Console.ReadLine();
                        break;
                    
                    //Слияние двух счетов
                    case "6":
                        Console.Write("Введите номер первого счета:");
                        acnum = IntTryCatch();
                        if (acnum == -1 || acnum <=0) break;
                        pos = FindAccount(ref accountMassive, acnum); //Ищем счет
                        if (pos == -1)
                        {
                            Console.WriteLine("Такого счета не существует!");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Введите номер второго счета:");
                        acnum = IntTryCatch();
                        if (acnum == -1 || acnum <=0) break;
                        pos2 = FindAccount(ref accountMassive, acnum);
                        if (pos2 == -1)
                        {
                            Console.WriteLine("Такого счета не существует!");
                            Console.ReadLine();
                            break;
                        }
                        if (accountMassive[pos].Closed || accountMassive[pos2].Closed)
                        {
                            Console.WriteLine("Один из счетов закрыт!");
                            Console.ReadLine();
                            break;
                        }
                        accountMassive[pos] += accountMassive[pos2];
                        accountMassive[pos2] = null;
                        Sort(ref accountMassive);
                        Console.WriteLine("Транзакция прошла успешно");
                        Console.ReadLine();
                        break;
                    
                    //Начисление процентов на счет
                    case "7":
                        Console.Write("Введите номер счета:");
                        acnum = IntTryCatch();
                        if (acnum == -1 || acnum <=0) break;
                        pos = FindAccount(ref accountMassive, acnum); //Ищем счет
                        if (pos == -1)
                        {
                            Console.WriteLine("Такого счета не существует!");
                            Console.ReadLine();
                            break;
                        }
                        if (accountMassive[pos].Closed)
                        {
                            Console.WriteLine("Счет закрыт!");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Введите процент:");
                        int percent = IntTryCatch();
                        if (percent <= 0 || percent >= 100) break;
                        accountMassive[pos] %= percent;
                        Console.WriteLine("Успшное начисление процентов");
                        Console.ReadLine();
                        break;
                   
                    //Сравнение счетов
                    case "8":
                        Console.Write("Введите номер первого счета:");
                        acnum = IntTryCatch();
                        if (acnum == -1 || acnum <=0) break;
                        pos = FindAccount(ref accountMassive, acnum); //Ищем счет
                        if (pos == -1)
                        {
                            Console.WriteLine("Такого счета не существует!");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Введите номер второго счета:");
                        acnum = IntTryCatch();
                        if (acnum == -1 || acnum <=0) break;
                        pos2 = FindAccount(ref accountMassive, acnum);
                        if (pos2 == -1)
                        {
                            Console.WriteLine("Такого счета не существует!");
                            Console.ReadLine();
                            break;
                        }
                        //Отображение информации о счетах
                        Console.Write($" Позиция {pos} Номер:  {accountMassive[pos].Number} ФИО - {accountMassive[pos].FullName} Дата - {accountMassive[pos].OpeningDate} Сумма на счету - {accountMassive[pos].Money} ");
                        if (accountMassive[pos].Money == 0) Console.Write("БАНКРОТ");
                        if (accountMassive[pos].Closed) Console.Write("\t ЗАКРЫТЫЙ СЧЕТ");
                        Console.Write("\n");
                        Console.Write($" Позиция {pos2} Номер:  {accountMassive[pos2].Number} ФИО - {accountMassive[pos2].FullName} Дата - {accountMassive[pos2].OpeningDate} Сумма на счету - {accountMassive[pos2].Money} ");
                        if (accountMassive[pos2].Money == 0) Console.Write("БАНКРОТ");
                        if (accountMassive[pos2].Closed) Console.Write("\t ЗАКРЫТЫЙ СЧЕТ");
                        Console.Write("\n");
                        if (accountMassive[pos].Money == accountMassive[pos2].Money) Console.WriteLine("Сумма на этих счетах оиднакова");
                        Console.ReadLine();
                        break;
                   
                    case "9":
                        Console.Write("Введите номер счета:");
                        acnum = IntTryCatch();
                        if (acnum <=0) break;
                        pos = FindAccount(ref accountMassive, acnum); //Ищем счет
                        if (pos == -1)
                        {
                            Console.WriteLine("Такого счета не существует!");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("Введите ФИО:");
                        string s = Console.ReadLine();
                        if (s != accountMassive[pos].FullName)
                        {
                            Console.WriteLine("Имена владельцев не совпадают");
                            break;
                        }
                        Console.Write("Вы точно хотите закрыть счет? Открыть его будет невозможно!(y/n):");
                        s = Console.ReadLine();
                        if (s == "y")
                        {
                            accountMassive[pos].Closed = true;
                        }
                        else break;
                        Console.WriteLine("Счет был успешно закрыт.Вывод средств и начисление процентов недоступны!");
                        Console.ReadLine();
                        break;
                   

                    case "99":
                        for (int i = 0; i < accountMassive.Length; i++)
                        {
                            if (accountMassive[i] == null)
                            {
                                Console.WriteLine("null account");
                                continue;
                            }
                            Console.Write($" Позиция {i} Номер:  {accountMassive[i].Number} ФИО - {accountMassive[i].FullName} Дата - {accountMassive[i].OpeningDate} Сумма на счету - {accountMassive[i].Money} ");
                            if (accountMassive[i].Number != 0 && accountMassive[i].Money == 0)
                                Console.Write("БАНКРОТ");
                            if (accountMassive[i].Closed) Console.Write("\t ЗАКРЫТЫЙ СЧЕТ");
                            Console.Write("\n");
                        }
                        Console.ReadLine();
                        break;
                }
            }
        }

    }
}
        
   

