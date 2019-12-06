using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aviasale
{
    public partial class PersonalInfoForm : Form
    {
        public PersonalInfoForm() => InitializeComponent();

        internal static List<Passenger> PassengerList = new List<Passenger>();
        internal static List<Ticket> TicketList = new List<Ticket>();
        int PassangerCounter = 1; 
        double Price;

        private void btnNext_Click(object sender, EventArgs e)
        {
            int Age = DateTime.Now.Year - Convert.ToDateTime(txtBirthDate.Text).Year;
            string Type = null;
            bool IsAdult = false;

            if (Age < 2)
            {
                Price = 0;
                Type = "Бесплатный";
            }
            else if (Age >= 2 && Age <= 12)
            {
                Price = GetInfoForm.Price * 0.5;
                Type = "Уцененный";
            }
            else if (Age > 12)
            {
                Type = "Платный";
                Price = GetInfoForm.Price;
                IsAdult = true;
            }

            PassengerList.Add(new Passenger ( $"{txtSecond.Text} {txtFirst.Text} {txtMiddle.Text}", Age, IsAdult, txtPassport.Text ));
            TicketList.Add(new Ticket(PassengerList[PassengerList.Count-1], "Пермь", GetInfoForm.ToWhere,Price, Type));

            if (PassangerCounter < Passenger.PassengerValue)
            {
                PassangerCounter++;
                Text = "Пассажир №" + (PassangerCounter);
            }
            else
            {
                Hide();
                FinalInfoForm finalInfoForm = new FinalInfoForm();
                finalInfoForm.Show();
            }
        }

        private void PersonalInfoForm_Load(object sender, EventArgs e) =>
            Text = "Пассажир №1";
    }
}