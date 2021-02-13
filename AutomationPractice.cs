using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Learning2020.AutomationPractice.com
{
    class AutomationPractice
    {
        IWebDriver driver;
        string FirstName;
        string LastName;
        string Password;
        string Email;
        By LoginButton = By.ClassName("login");
        public AutomationPractice(IWebDriver driver)
        {
            this.driver = driver;
        }
        #region Generate Functions
        public string GenerateFirstName()
        {
            var FirstLetter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var SmallLetters = "abcdefghijklmnopqrstuvwxyz";
            var Random = new Random();

            var stringFirstName = new char[5];
            stringFirstName[0] = FirstLetter[Random.Next(25)];
            for (int i = 1; i < stringFirstName.Length; i++)
            {
                if (i < 2)
                {
                    stringFirstName[i] = SmallLetters[Random.Next(25)];
                }
                else
                {
                    do
                    {
                        stringFirstName[i] = SmallLetters[Random.Next(25)];
                    }
                    while (stringFirstName[i] == stringFirstName[i - 1]);
                }
            }
            var FirstName = new String(stringFirstName);
            return FirstName;
        }
        public string GenerateLastName()
        {
            var FirstLetter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var SmallLetters = "abcdefghijklmnopqrstuvwxyz";
            var Random = new Random();

            var stringLastName = new char[7];
            stringLastName[0] = FirstLetter[Random.Next(25)];
            for (int i = 1; i < stringLastName.Length; i++)
            {
                if (i < 2)
                {
                    stringLastName[i] = SmallLetters[Random.Next(25)];
                }
                else
                {
                    do
                    {
                        stringLastName[i] = SmallLetters[Random.Next(25)];
                    }
                    while (stringLastName[i] == stringLastName[i - 1]);
                }
            }
            var LastName = new String(stringLastName);
            return LastName;
        }
        public string GenerateNumber()
        {
            var Numbers = "0123456789";
            var Random = new Random();
            var stringPhoneNumber = new char[3];
            for (int i = 0; i < stringPhoneNumber.Length; i++)
            {
                stringPhoneNumber[i] = Numbers[Random.Next(9)];
            }
            var GeneratedNumber = new String(stringPhoneNumber);
            return GeneratedNumber;
        }
        public string GenerateTitle()
        {
            var Numbers = "12";
            var Random = new Random();

            char Title = Numbers[Random.Next(2)];

            if (Title.ToString() == "1")
            {
                return "uniform-id_gender1";
            }
            else
            {
                return "uniform-id_gender2";
            }
        }
        public string GeneratePassword()
        {
            var GeneratePassword = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Random = new Random();

            var stringPassword = new char[20];
            for (int i = 0; i < stringPassword.Length; i++)
            {
                stringPassword[i] = GeneratePassword[Random.Next(GeneratePassword.Length)];
            }

            var password = new String(stringPassword);
            Password = password;
            return password;
        }
        public string GenerateEmailAddress()
        {
            FirstName = GenerateFirstName();
            LastName = GenerateLastName();
            Email = GenerateFirstName() + GenerateLastName() + GenerateNumber() + "@gmail.com";
            return Email;
        }
        public string GeneratePhoneNumber()
        {
            var Numbers = "0123456789";
            var Random = new Random();

            var stringPhoneNumber = new char[6];
            for (int i = 0; i < stringPhoneNumber.Length; i++)
            {
                stringPhoneNumber[i] = Numbers[Random.Next(9)];
            }

            var GeneratedPhoneNumber = new String(stringPhoneNumber);
            var PhoneNumber = "+38762" + GeneratedPhoneNumber;
            return PhoneNumber;
        }
        public int GenerateDayOfBirth()
        {
            var Random = new Random();
            int Day = Random.Next(1, 31);
            return Day;
        }
        public int GenerateMonthOfBirth()
        {
            var Random = new Random();
            int Month = Random.Next(1, 12);
            return Month;
        }
        public int GenerateYearOfBirth()
        {
            var Random = new Random();
            int Year = Random.Next(1950, 2002);
            return Year;
        }
        public int GenerateState()
        {
            Random random = new Random();
            int state = random.Next(1, 50);
            return state;
        }
        #endregion
        #region Dropdown menu selection
        public void SelectDayOfBirth()
        {
            SelectElement Day = new SelectElement(driver.FindElement(By.Name("days")));
            Day.SelectByValue(GenerateDayOfBirth().ToString());
        }
        public void SelectMonthOfBirth()
        {
            SelectElement Month = new SelectElement(driver.FindElement(By.Name("months")));
            Month.SelectByValue(GenerateMonthOfBirth().ToString());
        }
        public void SelectYearOfBirth()
        {
            SelectElement Year = new SelectElement(driver.FindElement(By.Name("years")));
            Year.SelectByValue(GenerateYearOfBirth().ToString());
        }
        #endregion//Need to add functions for selection from State and Country dropdown lists.
        public void OpenWebpage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }
        public void RegisterAnAccount()
        {    
            //Vecina elemenata su pronadjeni po "Name" polju posto postoji sansa da ce se "Id" poslje promijeniti sto bi prouzrokovalo error u pronalazenju elementa.
            driver.FindElement(LoginButton).Click();//Ulazi na stranicu sa mogucnosti registracije ili logina.
            driver.FindElement(By.Name("email_create")).SendKeys(GenerateEmailAddress());//Unosi random generisani email za registraciju
            driver.FindElement(By.Name("SubmitCreate")).Click();//Klikce na dugme za pocetak registracije nakon unosa email-a
            Thread.Sleep(3000);//Ceka tri sekunde kako bi se stranica ucitala
            driver.FindElement(By.Id(GenerateTitle())).Click();////////Provjeriti zasto uvijek generise broj 0////Fixed// Random generise spol koji ce se odabrati
            driver.FindElement(By.Name("customer_firstname")).SendKeys(FirstName);//Unosi random generisano Ime sto je dio email-a
            driver.FindElement(By.Name("customer_lastname")).SendKeys(LastName);//Unosi random generisano Prezime sto je dio email-a
            driver.FindElement(By.Name("passwd")).SendKeys(GeneratePassword());//Random generise prezime od 20 karaktera duzine sto ukljucje Velika slova, mala slova i brojeve
            SelectDayOfBirth();//Generise i odabire dan rodjenja iz dropdown liste 
            SelectMonthOfBirth();//Generise i odabire mjesec rodjenja iz dropdown liste
            SelectYearOfBirth();//Generise i odabire godinu rodjenja iz dropdown liste
            driver.FindElement(By.Name("newsletter")).Click();//Odabire polje za prihvatanje uslova slanja Newsletter-a
            driver.FindElement(By.Name("address1")).SendKeys("Adema Buce 13");//Unosi adresu u polje "Address"
            driver.FindElement(By.Name("city")).SendKeys("Sarajevo");//Unos grada u polje "City"
            SelectElement selectState = new SelectElement(driver.FindElement(By.Name("id_state")));
            selectState.SelectByValue(GenerateState().ToString());//Odabire state iz dropdown liste polje "State"
            driver.FindElement(By.Name("postcode")).SendKeys("71000");//Unosi Zip/Postal code u polje"
            SelectElement selectCountry = new SelectElement(driver.FindElement(By.Name("id_country")));
            selectCountry.SelectByIndex(1);///Index postavalja na 1 posto postoji samo jedna drzava u dropdown menu.
            driver.FindElement(By.Name("phone_mobile")).SendKeys(GeneratePhoneNumber());//Unosi random generisani broj mobitela sto pocinje sa +38762
            driver.FindElement(By.Name("alias")).Clear();
            //Ocistim unosno polje jer defaultno pise "My address", sto prouzrokuje error posto alias ne smije biti duzi od 32 karaktera.
            driver.FindElement(By.Name("alias")).SendKeys("Adema Buce 13, 71000 Sarajevo");//Unos adrese
            driver.FindElement(By.Name("submitAccount")).Click();//Klikce na dugme "Register" kako bi se zavrsila registracija
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.Id("header_logo")).Click();
        }
        public void SignOut()
        {
            driver.FindElement(By.ClassName("logout")).Click();
        }
        public void SignIn()
        {
            driver.FindElement(LoginButton).Click();
            driver.FindElement(By.Name("email")).SendKeys(Email);
            driver.FindElement(By.Name("passwd")).SendKeys(Password);
            driver.FindElement(By.Name("SubmitLogin")).Click();
        }
    }
}
