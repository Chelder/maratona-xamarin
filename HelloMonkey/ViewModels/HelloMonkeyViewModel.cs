﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HelloMonkey.Models;
using HelloMonkey.Services;
using Xamarin.Forms;
using HelloMonkey.Helpers;

namespace HelloMonkey.ViewModels
{
    public class HelloMonkeyViewModel : ViewModelBase
    {
        readonly MonkeyApi monkeyApi = new MonkeyApi();

        ObservableCollection<Monkey> monkeys;
        public ObservableCollection<Monkey> Monkeys
        {
            get { return monkeys; }
            set
            {
                monkeys = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadMonkeysCommand { get; set; }

        public HelloMonkeyViewModel() : base("Onde estão os Macacos!?")
        {
            Monkeys = new ObservableCollection<Monkey>();

            LoadMonkeysCommand = new Command(async () =>
            {
                if (Loading) return;
                Loading = true;

                //Altere os dados
                var developer = new Developer
                {
                    Name = "Chelder Lins", // Altere para o seu nome e sobrenome
                    Email = "chelder.lins@gmail.com", // Altere para o seu email
                    City = "Coronel Fabriciano", // Altere para o nome da cidade onde você mora
                    State = "Minas Gerais", // Altere para o estado (UF) onde você mora
                };

                var data = await monkeyApi.GiveMeTheMonkeysAsync(developer);

                Monkeys.Clear();
                Monkeys.AddRange(data);

                Loading = false;
            });
        }
    }
}
