﻿using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace UITest.Contacts
{
	[TestFixture(Platform.iOS)]
	public class DeleteiOS
	{
		IApp app;
		Platform platform;

		public DeleteiOS(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void DeleteWithSwipe()
		{
			string firstName = "John";
			string lastName = "Smith";
			string email = "john@smith.com";

			// Cadastro
			app.Tap(e => e.Text("Adicionar"));

			app.Tap(e => e.Marked("etrFirstName"));
			app.EnterText(firstName);
			app.Tap(e => e.Marked("etrLastName"));
			app.EnterText(lastName);
			app.Tap(e => e.Marked("etrEmail"));
			app.EnterText(email);
			app.Tap(e => e.Text("Salvar"));

			// Exclusão com swipe
			// TODO: analisar swipePercentage; necessário quando inserimos um contato e em seguida tentamos remove-lo.
			app.SwipeRightToLeft(firstName, swipePercentage: 0.9);
			app.Tap(e => e.Text("Apagar"));
		}
	}
}

