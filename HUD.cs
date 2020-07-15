using Godot;
using System;

public class HUD : CanvasLayer
{
	[Signal] public delegate void StartGame();

	public void ShowMessage(String text)
	{
		var messageLabel = GetNode<Label>("MessageLabel");
		messageLabel.Text = text;
		messageLabel.Show();
		
		GetNode<Timer>("MessageTimer").Start();
	}

	public async void ShowGameOver()
	{
		ShowMessage("Game Over Man!!");

		var messageTimer = GetNode<Timer>("MessageTimer");
		await ToSignal(messageTimer, "timeout");

		var messageLabel = GetNode<Label>("MessageLabel");
		messageLabel.Text = "Dodge the\nCreeps!";
		messageLabel.Show();
		
		GetNode<Button>("StartButton").Show();
	}

	public void UpdateScore(int score)
	{
		GetNode<Label>("ScoreLabel").Text = score.ToString();
	}

	public void OnStartButtonPressed()
	{
		GetNode<Button>("StartButton").Hide();
		EmitSignal("StartGame");
	}

	public void OnMessageTimerTimeout()
	{
		GetNode<Label>("MessageLabel").Hide();
	}
}
