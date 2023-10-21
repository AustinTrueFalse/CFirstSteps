using System;
using System.Drawing;
using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


abstract class Company // Компания
{
    public string Address;
    public string Name;
}

class Employee<TId> // Работник
{
    public TId Id;
    public string Name;
    public string Age;

    public Employee(TId id, string name, string age)
    {
        Id = id;
        Name = name;
        Age = age;
    }
}

class Courier<TId> : Employee<TId> // Курьер
{
    public string Vehicle;

    public Courier(TId id, string name, string age, string vehicle) : base (id, name, age)
    {
        Vehicle = vehicle;
    }
}

class Picker<TId> : Employee<TId> // Сборщик
{
    public string Device; // Устройство фиксирования товаров

    public Picker(TId id, string name, string age, string device) : base(id, name, age)
    {
        Device = device;
    }
}

class Product
{
    public string SKU; // Id товара
    public string Name; // Наименование товара
    public string Description; // Описание товара
    public double Cost; // Цена товара
    public double Tax; // Налог товара

    public Product(string sku, string name, string description, double cost, double tax)
    {
        SKU = sku;
        Name = name;
        Description = description;
        Cost = cost;
        Tax = tax;
    }

    public virtual double TaxCounter()
    {
        return Cost * Tax;
    }

}

class Food : Product
{ 
    public string BoxType; // Вид коробки 

    public Food(string sku, string name, string description, double cost, double tax, string boxType) : base (sku, name, description, cost, tax)
    {
        BoxType = boxType;
    }
}

class Drinks : Product
{
    public string TankType; // Вид тары 

    public Drinks(string sku, string name, string description, double cost, double tax, string tankType) : base (sku, name, description, cost, tax)
    {
        TankType = tankType;
    }
}

class NonAlcohol : Drinks
{
    public bool Restriction; // Разрешено ли продавать до 18

    public NonAlcohol(string sku, string name, string description, double cost, double tax, bool restriction, string tankType) : base(sku, name, description, cost, tax, tankType)
    {
        Restriction = restriction;
    }
}

class Alcohol : Drinks
{

    private static double TaxConst = 1.1; // Налог на про`дажу алкоголя

    public override double TaxCounter()
    {
        return Cost * Tax * TaxConst;
    }

    public Alcohol(string sku, string name, string description, double cost, double tax, string tankType) : base(sku, name, description, cost, tax, tankType)
    {

    }
}

class Client
{
    public string Id;
    public string Name;
    private bool Loyalty; // Лояльность клиента

    public Client(string id, string name, bool loyalty) 
    {
        Id = id;
        Name = name;
        Loyalty = loyalty;
    }

    public double CashBack()
    {
        if (Loyalty)
        {
            return 0.15;
        }
        else
        {
            return 0.5;
        }
    }
}


// Справочник

class DataStore<T>
{
    private T[] store; 

    public DataStore(T[] store)
    {
        this.store = store;
    }


    public DataStore(int length)
    {
        store = new T[length];
    }

    public T this[int index]
    {
        get
            {
                if (index >= 0 && index <= store.Length)
                {
                    return store[index];
                }
                else
                {
                    return default(T);
                }
            }
        set
            {
                if (index >= 0 && index <= store.Length)
                {
                    store[index] = value;
                }
            }
    }

    public int Length
    {
        get
        {
            return store.Length;
        }
    }
}


public class Order
{
    Product _product;
    Employee<object> _employee;
    Food _food;
    Alcohol _alcohol;
    NonAlcohol _nonAlcohol;

}


internal class Program
{
    static void Main(string[] args)

    {

        // Тут не совсем понятно как связывать классы с DataStore, нужен ли он единый или нужно создавать отдельный справочник для каждого класса?
        // Ниже проверка его работы

        DataStore<int> Clients = new DataStore<int>(5);
        DataStore<string> Employees = new DataStore<string>(5);
        DataStore<string> Products = new DataStore<string>(5);

        Clients[0] = 123;
        Clients[1] = 124;
        Clients[2] = 125;
        Clients[3] = 126;
        Clients[4] = 127;
  

        Employees[0] = "E-556"; // E - Флаг работника
        Employees[1] = "E-556";
        Employees[2] = "E-556";
        Employees[3] = "E-556";
        Employees[4] = "E-556";
   

        Products[0] = "F-1";  // F - Food
        Products[1] = "F-2";
        Products[2] = "DA-1"; // Drinks - Drinks Alcohol
        Products[3] = "DN-1"; // Drinks - Drinks NonAlcohol
        Products[4] = "F-3";


        // проверка логики заполнения DataStore
        for (int i = 0; i < Clients.Length; i++)
            Console.WriteLine(Clients[i]);
        for (int i = 0; i < Employees.Length; i++)
            Console.WriteLine(Employees[i]);
        for (int i = 0; i < Products.Length; i++)
            Console.WriteLine(Products[i]);
    }



}

