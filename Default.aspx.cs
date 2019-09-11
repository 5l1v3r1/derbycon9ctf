// DerpyCon_FileServer.Default
using System;

public void button1Clicked(object sender, EventArgs args)
{
	if (button1.Text == "Derp!")
	{
		button1.Text = "Herp!";
	}
	else
	{
		button1.Text = "Derp!";
	}
	string text = "NiceIDORExploitYo349";
	string text2 = "../HerpDerpyConAdmin/";
	string text3 = "connectionString=\"Server=DerpyConDB;Database=DerpyCon;User ID=DerpyDB;Password=DerpyDB;\"";
	button1.Text = text;
	button1.Text = text2;
	button1.Text = text3;
	button1.Text = "HerpDerp!";
}
