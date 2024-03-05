using System;
using NfsCore.Reflection;
using NfsCore.Reflection.Attributes;

namespace NfsCore.Support.Underground2.Gameplay
{
	public partial class SmsMessage
	{
		private string _messageLabel = BaseArguments.NULL;
		private byte _b0X02;
		private byte _b0X03;
		private byte _b0X04;
		private byte _b0X05;
		private byte _b0X06;
		private byte _b0X07;
		private byte _b0X08;
		private byte _b0X09;
		private byte _b0X0A;
		private byte _b0X0B;

		[AccessModifiable]
		[StaticModifiable]
		public int CashValue { get; set; }

		[AccessModifiable]
		public string MessageSenderLabel
		{
			get => _messageLabel;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException(nameof(value), "This value cannot be left empty.");
				_messageLabel = value;
			}
		}
	}
}