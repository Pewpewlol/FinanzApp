using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;


using Android.Graphics;
using Android.Text;
using System.Collections.Generic;

namespace TaschenGeld
{
    [Activity(Label = "@string/callMember", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int FestZahl;
        bool ClickedPM = false;
        bool ClickedTMJ = false;//Minus oder Plus angecklickt
        bool PlusOrMinus;// Plus wahr, Minus Falsch
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            ArrayAdapter<string> adapter;
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            TextView Einkommen = FindViewById<TextView>(Resource.Id.textView2);
            TextView Fehler = FindViewById<TextView>(Resource.Id.textView7);
            Button Speichern = FindViewById<Button>(Resource.Id.button1);


            EditText EditEinkommen = FindViewById<EditText>(Resource.Id.editText1);
            EditText EditBetrag = FindViewById<EditText>(Resource.Id.editText2);
            EditText EditZweck = FindViewById<EditText>(Resource.Id.editText3);


            Button Plus = FindViewById<Button>(Resource.Id.button2);
            Button Minus = FindViewById<Button>(Resource.Id.button3);
            Button Tag = FindViewById<Button>(Resource.Id.button4);
            Button Monat = FindViewById<Button>(Resource.Id.button5);
            Button Jahr = FindViewById<Button>(Resource.Id.button6);
            Button hinzufügen = FindViewById<Button>(Resource.Id.button7);
            
            ListView ViewMe = FindViewById<ListView>(Resource.Id.listView1);
            List<string> items = new List< string>();
            

            Speichern.Click += (object sender, EventArgs e) =>
            {
                if (checkValue(EditEinkommen.Text))
                {            
                    Einkommen.Text = EditEinkommen.Text;
                    FestZahl = int.Parse(EditEinkommen.Text);
                }
                else
                {
                    Einkommen.Text = "Bitte Zahlen";
                }
                    
            };

            Plus.Click += (object sender, EventArgs e) =>
            {
                Plus.SetBackgroundColor(Color.Green);
                Minus.SetBackgroundColor(Color.AntiqueWhite);
                PlusOrMinus = true;
                ClickedPM = true;
            };
            Minus.Click += (object sender, EventArgs e) =>
            {
                Minus.SetBackgroundColor(Color.Red);
                Plus.SetBackgroundColor(Color.AntiqueWhite);
                PlusOrMinus = false;
                ClickedPM = true;
            };
            Tag.Click += (object sender, EventArgs e) =>
            {
                Tag.SetBackgroundColor(Color.LightGreen);
                Monat.SetBackgroundColor(Color.AntiqueWhite);
                Jahr.SetBackgroundColor(Color.AntiqueWhite);
                ClickedTMJ = true;
            };
            Monat.Click += (object sender, EventArgs e) =>
            {
                Tag.SetBackgroundColor(Color.AntiqueWhite);
                Monat.SetBackgroundColor(Color.LightGreen);
                Jahr.SetBackgroundColor(Color.AntiqueWhite);
                ClickedTMJ = true;
            };
            Jahr.Click += (object sender, EventArgs e) =>
            {
                Tag.SetBackgroundColor(Color.AntiqueWhite);
                Monat.SetBackgroundColor(Color.AntiqueWhite);
                Jahr.SetBackgroundColor(Color.LightGreen);
                ClickedTMJ = true;
            };
            EditBetrag.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                if(string.IsNullOrWhiteSpace(EditBetrag.Text))
                {
                    hinzufügen.Clickable = false;
                }
                else
                {
                    hinzufügen.Clickable = true;
                }
            };
            hinzufügen.Click += (object sender, EventArgs e) =>
            {
                if(checkValue(EditBetrag.Text))
                {
                    if (GeClickt())
                    {
                        items.Add(EditBetrag.Text);
                        adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
                        ViewMe.Adapter = adapter;
                        if (PlusOrMinus)
                        {
                            FestZahl += int.Parse(EditBetrag.Text);
                        }
                        else
                            FestZahl -= int.Parse(EditBetrag.Text);
                        Einkommen.Text = FestZahl.ToString();
                    }
                    else
                        Fehler.Text = "Click the Buttons";
                }
                else
                {
                    Fehler.Text = "Bitte Zahlen";
                }
            };

        }
        private bool checkValue(string text)
        {
            
            try
            {
                int.Parse(text);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
        private bool GeClickt()
        {
            if (ClickedPM == true || ClickedTMJ == true)
            {
                return true;
            }
            else
                return false;
        }
        
    }
}

