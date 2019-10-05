using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace Sms.Api.Services
{
    public class SmsService
    {
        private SerialPort _serialPort;

        public SmsService(string comPort)
        {
            this._serialPort = new SerialPort();
            this._serialPort.PortName = comPort;
            this._serialPort.BaudRate = 9600;
            this._serialPort.Parity = Parity.None;
            this._serialPort.DataBits = 8;
            this._serialPort.StopBits = StopBits.One;
            this._serialPort.Handshake = Handshake.RequestToSend;
            this._serialPort.DtrEnable = true;
            this._serialPort.RtsEnable = true;
            this._serialPort.NewLine = System.Environment.NewLine;
        }

        public bool SendSMS(string phoneNumber, string smsText)
        {
            if (this._serialPort.IsOpen == false)
            {
                OpenPort();
            }
            if (this._serialPort.IsOpen == true)
            {
                try
                {
                    ConsoleLogger.WriteLine("sending sms to: " + phoneNumber);
                    this._serialPort.WriteLine("AT" + (char)(13));
                    Thread.Sleep(4);
                    this._serialPort.WriteLine("AT+CMGF=1" + (char)(13));
                    Thread.Sleep(5);
                    this._serialPort.WriteLine("AT+CMGS=\"" + phoneNumber + "\"");
                    Thread.Sleep(10);
                    this._serialPort.WriteLine("" + smsText + (char)(26));
                }
                catch (Exception ex)
                {
                    ConsoleLogger.WriteLine("can't send sms to: " + phoneNumber + " " + ex.ToString());
                    
                }
                return true;
            }
            else return false;
        }

        public void OpenPort()
        {
            try
            {
                if (this._serialPort.IsOpen == false)
                {
                    ConsoleLogger.WriteLine("opening port... ");
                    this._serialPort.Open();
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.WriteLine("can't open port. " + ex.ToString());
            }
        }
    }
}