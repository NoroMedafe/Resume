using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BankAccount
{
    private int number;
    private DateTime openingDate;
    private string fullName;
    private double money;
    private DateTime closeDate;
    private bool closed;

    #region Svoistva
    //Свойства данных
    public int Number { get { return number; } set { number = value; } }
    public DateTime OpeningDate { get { return openingDate; } set { openingDate = value; } }
    public DateTime CloseDate { get { return closeDate; } set { closeDate = value; } }
    public string FullName { get { return fullName; } set { fullName = value; } }
    public double Money { get { return money; } set { money = value; } }
    public bool Closed { get { return closed; } set { closed = value; } }
    #endregion
    
    #region Constructors
    public BankAccount()
    {
        this.number = 0;
        this.openingDate = DateTime.Now;
        this.fullName = "";
        this.money = 0;
        this.closeDate = DateTime.Now;
        closed = false;
    }

    //Конструктор класса
    public BankAccount(int number, DateTime openingDate, string fullName) : this()
    {
        this.number = number;
        this.openingDate = openingDate;
        this.fullName = fullName;
        this.money = 0;
        this.closeDate = closeDate;
        closed = false;
    }
    #endregion

    #region Methods
    public void TopUpAccount(double sum)
    {
        this.money += sum;
    }

    public int FindAccount(BankAccount[] accountMassive, int acnum)
    {
        for (int i = 0; i < accountMassive.Length; i++)//Ищем необходимый счет
        {
            if (accountMassive[i].number == acnum)
            {
                return i;
            }
        }
        return -1;
    }
    public void Withdraw(double sum)
    {
        this.money -= sum;
    }
    #endregion

    #region OperationOverride
    /// <summary>
    /// Слияние двух счетов
    /// </summary>
    /// <param name="a">Первый счет</param>
    /// <param name="b">Второй счет, в последствии будет уничтожен</param>
    /// <returns></returns>
    public static BankAccount operator +(BankAccount a, BankAccount b)
    {
        a.money += b.money;
        return a;
    }

    /// <summary>
    /// Начисление процента b на аккаунт a
    /// </summary>
    /// <param name="a">Аккаунт на который начилсяется процент</param>
    /// <param name="b">Процент</param>
    /// <returns></returns>
    public static BankAccount operator %(BankAccount a, int b)
    {
        a.money += a.money / 100 * b;
        return a;
    }

    /// <summary>
    /// Вычитание из баланса счета суммы b
    /// </summary>
    /// <param name="a">Счет из которого вычитается сумма</param>
    /// <param name="b">Сумма вычитания</param>
    /// <returns></returns>
    public static BankAccount operator -(BankAccount a, double b)
    {
        a.money -= b;
        return a;
    }

    /// <summary>
    /// Начисление на счет a суммы b
    /// </summary>
    /// <param name="a">Счет на который происходит начисление</param>
    /// <param name="b">Сумма начисления</param>
    /// <returns></returns>
    public static BankAccount operator +(BankAccount a, double b)
    {
        a.money += b;
        return a;
    }
    /// <summary>
    /// Перевод всей суммы между двумя счетами
    /// </summary>
    /// <param name="a">Счет с которого будут переведены все деньги</param>
    /// <param name="b">Счет на который будут переведены деньги</param>
    /// <returns></returns>
    public static BankAccount operator -(BankAccount a, BankAccount b)
    {
        a += b.money;
        return a;
    }
    /// <summary>
    /// Сравнение суммы двух счетов
    /// </summary>
    /// <param name="a">Счет A</param>
    /// <param name="b">Счет B</param>
    /// <returns></returns>
    //public static bool operator ==(BankAccount a, BankAccount b)
    //{
    //    { return (a.Money == b.Money) ? true : false; }
    //}

    //public static bool operator !=(BankAccount a, BankAccount b)
    //{
    //    { return (a.Money != b.Money) ? true : false; }
    //}

    #endregion


}