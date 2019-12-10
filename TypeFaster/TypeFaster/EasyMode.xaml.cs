﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Timers;
using Xamarin.Forms;

namespace TypeFaster
{ 
	public partial class EasyMode : ContentPage
	{
        //==Constants==
        private const String TIMER_STRING = "00:00:000";

        //initialize timer
        Timer timer;

        //==Variables==
        int mins = 0, secs = 0, milliseconds = 1, secValue;

        DateTime date;

        //array of random words to display
        String[] easyRandomWords = new String[] { "theater", "celery", "just random", "candle", "christmas", "xamarin", "experience", "decretal", "strategic", "initial", "pie", "deal","drain", "instal","timber", "equal", "jockey", "lid"};
        public EasyMode ()
        { 
                timer = new Timer
                {
                    Interval = 1 // 1 milliseconds  
                };
                timer.Elapsed += Timer_Elapsed;

                InitializeComponent();

                time.Text = TIMER_STRING;

                //Initialize random function
            Random rnd = new Random();
                rnd.Next(easyRandomWords.Length);

                // displays random words
                lbl.Text = easyRandomWords[rnd.Next(easyRandomWords.Length)];
            }

            // new game button
            private void Btn_Clicked(object sender, EventArgs e)
            {
                timer.Stop();
                // Initialize random function
                Random rnd = new Random();
                rnd.Next(easyRandomWords.Length);

                //displays random words
                lbl.Text = easyRandomWords[rnd.Next(easyRandomWords.Length)];

                //call reset stats function
                Reset_Stats();

            }

            private void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
            //this timer works differently on different platform thats why I've used this switch statement
            //
            switch (Device.RuntimePlatform)
                {
   
                case Device.Android:
                    secValue = 1000;
                    break;
                case Device.UWP:
                    secValue = 100;
                    break;
              
                }//switch

                milliseconds++;
                if (milliseconds >= secValue)
                {
                    secs++;
                    milliseconds = 0;
                }
                if (secs == 59)
                {
                    mins++;
                    secs = 0;
                }


                Device.BeginInvokeOnMainThread(() =>
                {
                    String tiime = String.Format("0:{0}:{1}.{2}", mins, secs, milliseconds);
                    date = DateTime.Parse(tiime);
                    time.Text = date.ToString("mm:ss.fff");

                });
            }

        //entry property changed used to start the timer whenever user enter first character of a string
        private void entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                if (entry.Text == null)
                {
                    //timer.Stop();

                }
                else if (entry.Text.Length > 0)
                {
                    timer.Start();
                    lbl.BackgroundColor = Color.Red;
                    boxy.Color = Color.Red;
                }

                if (entry.Text == lbl.Text)
                {
                    lbl.BackgroundColor = Color.Green;
                    boxy.Color = Color.Green;
                    timer.Stop();
                    score.Text = date.ToString("mm:ss.fff");

                    // Store all  Values  
                    // Application.Current.Properties["SCORE"] = highscore.Text;

                    // highscore.Text = string.Empty;

                    // DisplayAlert("Success", "Score Saved", "OK");

                    entry.Text = null;

                    //Get all Values  
                    if (Application.Current.Properties.ContainsKey("SCORE"))
                    {

                        //highscore.Text = Application.Current.Properties["SCORE"].ToString();

                    }
                    Display();
                    milliseconds = 0;
                    mins = 0;
                    secs = 0;
                }
            }

            private void Display()
            {
                DisplayAlert("Score", string.Format("Your time: {0}", date.ToString("mm:ss.fff")), "Close");

            }

            private void Reset_Stats()
            {
                lbl.BackgroundColor = Color.White;
                boxy.Color = Color.White;
                score.Text = null;
                entry.Text = null;
                time.Text = TIMER_STRING;
                milliseconds = 0;
                mins = 0;
                secs = 0;

            }
        }
    }
