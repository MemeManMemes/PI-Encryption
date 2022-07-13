using System;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace crypt
{
	static class hash
	{
		static string salt = "";
		private static void Main()
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Commands:\n1: Encrypt\n2: Decrypt");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Note: copying and pasting is weird with this program so text decryption might not work first try\n");
			hwh:
			bool error = false;
			salt = "";
			string Hash = "";
			Console.ForegroundColor = ConsoleColor.White;
			char[] chararray = {};
			string hashed = "";
			List<string> list = new List<string>();
			List<Char> printableChars = new List<char>();
			bool w = false;
			int i = 0;
			Console.Write("Enter Command: ");
			string command = Console.ReadLine();
			if (command == "1")
			{
				Console.Clear();
				Console.Write("Would You Like To:\n1: Encrypt Text\n2: Encrypt a File\n\nEnter Command: ");
				string comman = Console.ReadLine();
				if (comman == "1")
				{
				Console.Clear();
				Console.Write("Enter Message You Wish To Send: ");
				string array = Console.ReadLine();
				chararray = array.ToCharArray();
				Console.Write("Make a password for this encryption: ");
				salt = Console.ReadLine();
				w = false;
				i = 0;
				Console.ForegroundColor = ConsoleColor.Green;
				foreach (char item in chararray)
				{
					if (w == false)
					{
				        hashed = hashed + sha256_hash(item.ToString());
						w = true;
					}
					
					else if (w == true)
					{
						hashed = hashed + sha512_hash(item.ToString());
						w = false;
					}
				}
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("\nOutput: \n");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(hashed + "\n\n");
			    }
			    if (comman == "2")
			    {
					Console.Clear();
					Console.Write("Please enter the entire filepath of the file you want to encrypt: ");
					string filepath = Console.ReadLine();
					if (File.Exists(filepath))
					{
						Console.Clear();
					Console.Write("Which directory would you like your file to be stored in: ");
					string path = Console.ReadLine();
					if (Directory.Exists(path))
					{
					Console.Clear();
					Console.Write("What would you like the password to be for this file: ");
					salt = Console.ReadLine();
					Console.Write("What would your encrypted file to be named: ");
					string filename = Console.ReadLine();
					string exitpath = path;
					string filetext = File.ReadAllText(filepath);
					char[] filechars = filetext.ToCharArray();
					string file_encrypted = "";
					i = 0;
					w = false;
					foreach (char item in filechars)
				    {
					if (w == false)
					{
				        file_encrypted += hash.sha256_hash(item.ToString());
						w = true;
					}
					
					else if (w == true)
					{
						file_encrypted += hash.sha512_hash(item.ToString());
						w = false;
					}
				    }
				    if (!exitpath.EndsWith("/"))
				    {
				    byte[] filebytes = Encoding.ASCII.GetBytes(file_encrypted);
				    using (System.IO.FileStream fs = System.IO.File.Create(exitpath + "/" + filename))
                    {
						foreach (byte b in filebytes)
						{
							fs.WriteByte(b);
						}
					}
				}
				if (exitpath.EndsWith("/"))
				{
					byte[] filebytes = Encoding.ASCII.GetBytes(file_encrypted);
				    using (System.IO.FileStream fs = System.IO.File.Create(exitpath + filename))
                    {
						foreach (byte b in filebytes)
						{
							fs.WriteByte(b);
						}
					}
				}
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Encrypted File Created\n");
				    }
				    else 
				    {
						Console.WriteLine("Please enter a real directory path");
						Console.ReadKey();
					}
				    }
				    else 
				    {
						Console.WriteLine("Please enter a real filepath");
						Console.ReadKey();
					}
					
				}
			}
			
			if (command == "2")
			{
				Console.Clear();
				Console.Write("Would You Like To:\n1: Decrypt Text\n2: Decrypt a File\n\nCommand: ");
				string cow_moo = Console.ReadLine();
				if (cow_moo == "1")
				{
				Console.Clear();
				Console.Write("Password: ");
				salt = Console.ReadLine();
				Console.Clear();
				Console.Write("Would you like character support other than ASCII characters?\n1: Use only ASCII characters\n2: Use universal characters\n");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("Note: using the second option is for universal character decryption but will make decryption a lot slower\n");
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("\nCommand: ");
				string cow = Console.ReadLine();
				if (cow == "1")
				{
					for (int j = 0; j < 256; j++)
					{
						printableChars.Add(Convert.ToChar(j));
				    }
				}
				if (cow == "2")
				{
					for (int j = char.MinValue; j <= char.MaxValue; j++)
                    {
                    char c = Convert.ToChar(j);
                    if (!char.IsSurrogate(c))
                    {
                    printableChars.Add(c);
                    }
                    }
				}
				Console.Clear();
				Hash = "";
				Console.Write("Enter Encrypted String: ");
				Hash = Console.ReadLine();
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Working...");
				w = false;
				i = 0;
				Console.ForegroundColor = ConsoleColor.Green;
				while (Hash != "" && error == false)
				{
				      foreach (char c in printableChars)
				      {
						  if (Hash.StartsWith(sha256_hash(c.ToString())))
						  {
							  i = 0;
							  Console.ForegroundColor = ConsoleColor.Cyan;
							  Console.Write("Working...\n");
							  list.Add(c.ToString());
							  Hash = Hash.Remove(0,sha256_hash(c.ToString()).Length);
							  Console.Clear();
							  Console.ForegroundColor = ConsoleColor.White;
							  Console.Write("Decrypted so far: ");
							  Console.ForegroundColor = ConsoleColor.Green;
							  foreach (string s in list)
							  {
								Console.Write(s); 
							  }
							  Console.Write("\n");
							  w = true;
						  }
						  else
						  {
							 i++;
							 if (cow == "2" && i > 126976)
							 {
								 error = true;
							 }
							 if (cow == "1" && i > 512)
							 {
								 error = true;
							 }
						  }
					  }
				      foreach (char c in printableChars)
				      {
						  if (Hash.StartsWith(sha512_hash(c.ToString())))
						  {
							  i = 0;
							  Console.ForegroundColor = ConsoleColor.Cyan;
							  Console.Write("Working...\n");
							  list.Add(c.ToString());
							  Hash = Hash.Remove(0,sha512_hash(c.ToString()).Length);
							  w = false;
							  Console.Clear();
							  Console.ForegroundColor = ConsoleColor.White;
							  Console.Write("Decrypted so far: ");
							  Console.ForegroundColor = ConsoleColor.Green;
							  foreach (string s in list)
							  {
								Console.Write(s); 
							  }
							  Console.Write("\n");
						  }
						  else
						  {
							 i++;
							 if (cow == "2" && i > 126976)
							 {
								 error = true;
							 }
							 if (cow == "1" && i > 512)
							 {
								 error = true;
							 }
						  }
					}
			    }
			    if (error == true)
			    {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("ERROR DETECTED\n");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("Decrypted with error: ");
					Console.ForegroundColor = ConsoleColor.Green;
					foreach (string s in list)
					{
						Console.Write(s);
					}
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.Write(Hash + "\n");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("Check if the hash is correct, then try decrypting the hash again or switch to Universal mode if all else fails");
				}
				if (error == false)
				{
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.Write("DECRYPTED CORRECTLY\n");
					Console.Write("Decrypted text: ");
					Console.ForegroundColor = ConsoleColor.Green;
					foreach (string s in list)
					{
						Console.Write(s);
					}
					Console.Write("\n");
				}
		}
			if (cow_moo == "2")
			{
				Console.Clear();
				Console.Write("Please enter path of this file: ");
				string filepath = Console.ReadLine();
				if (File.Exists(filepath))
				{
				Console.Clear();
				Console.Write("Enter password for this file: ");
				salt = Console.ReadLine();
				Console.Clear();
				Console.Write("Would you like character support other than ASCII characters?\n1: Use only ASCII characters\n2: Use universal characters\n");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("Note: using the second option is for universal character decryption but will make decryption a lot slower\n");
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("\nCommand: ");
				string moo = Console.ReadLine();
				Console.Clear();
				if (moo == "2")
				{
					for (int j = char.MinValue; j <= char.MaxValue; j++)
                    {
						char c = Convert.ToChar(j);
						if (!char.IsSurrogate(c))
						{
							printableChars.Add(c);
						}
                    }
				}
				if (moo == "1")
				{
					for (int j = 0; j < 256; j++)
					{
						printableChars.Add(Convert.ToChar(j));
				    }
				}
				     Console.ForegroundColor = ConsoleColor.Cyan;
					 Console.Write("Working...\n");
                     w = false;
                     char[] filebytes = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(filepath)).ToCharArray();
                     string filepass = "";
                     List<string> filetext = new List<string>();
                     for (int x = 0; x < filebytes.Count(); x++)
                     {
						filepass += filebytes[x];
				     }
                     while (filepass != "" && error == false)
					 {
				      foreach (char c in printableChars)
				      {
						  if (filepass.StartsWith(sha256_hash(c.ToString())))
						  {
							  i = 0;
							  filetext.Add(c.ToString());
							  filepass = filepass.Remove(0,sha256_hash(c.ToString()).Length);
							  Console.Clear();
							  Console.ForegroundColor = ConsoleColor.White;
							  Console.Write("Decrypted so far: ");
							  Console.ForegroundColor = ConsoleColor.Green;
							  foreach (string s in filetext)
							  {
								Console.Write(s); 
							  }
							  Console.Write("\n");
							  w = true;
						  }
						  else
						  {
							 i++;
							 if (moo == "2" && i > 126976)
							 {
								 error = true;
							 }
							 if (moo == "1" && i > 512)
							 {
								 error = true;
							 }
						  }
					  }
				      foreach (char c in printableChars)
				      {
						  if (filepass.StartsWith(sha512_hash(c.ToString())))
						  {
							  i = 0;
							  filetext.Add(c.ToString());
							  filepass = filepass.Remove(0,sha512_hash(c.ToString()).Length);
							  w = false;
							  Console.Clear();
							  Console.ForegroundColor = ConsoleColor.White;
							  Console.Write("Decrypted so far: ");
							  Console.ForegroundColor = ConsoleColor.Green;
							  foreach (string s in filetext)
							  {
								Console.Write(s); 
							  }
							  Console.Write("\n");
						  }
						  else
						  {
							 i++;
							 if (moo == "2" && i > 126976)
							 {
								 error = true;
							 }
							 if (moo == "1" && i > 512)
							 {
								 error = true;
							 }
						  }
					}
			    }
					if (error == true)
					{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("ERROR DETECTED\n");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("Decrypted with error: ");
					Console.ForegroundColor = ConsoleColor.Green;
					foreach (string s in filetext)
					{
						Console.Write(s);
					}
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.Write(filepass + "\n");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("Check if the file's hash is correct, then try decrypting the hash again or switch to Universal mode if all else fails");
					}
				if (error == false)
				{
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.Write("DECRYPTED CORRECTLY\n");
					Console.Write("Decrypted file contents: ");
					Console.ForegroundColor = ConsoleColor.Green;
					foreach (string s in filetext)
					{
						Console.Write(s);
					}
					Console.Write("\n");
				} 
				 }
				 else
			     {
					Console.WriteLine("This file does not exist");
				 }
			}
		}
		if (command != "1" && command != "2")
		    {
			   Console.ForegroundColor = ConsoleColor.Red;
			   Console.WriteLine("'" + command + "' is not a valid command.  Only '1' and '2' are valid.");
		    }
		goto hwh;
	}
		public static String sha256_hash(String value) 
		{
			using (SHA256 hash = SHA256Managed.Create()) 
			{
				char[] s = salt.ToCharArray();
				int[] w = new int[s.Count()];
				int r = 0;
				for(int i = 0; i < s.Count(); i++)
				{
					w[i] = s[i];
				}
				foreach(int i in w)
				{
					r += i;
				}
				r = RoundOff(r);
				return String.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(value)).Select(item => item.ToString(r.ToString())));
			}
        }
        public static String sha512_hash(String value) 
		{
			using (SHA512 hash = SHA512Managed.Create()) 
			{
				char[] s = salt.ToCharArray();
				int[] w = new int[s.Count()];
				int r = 0;
				for(int i = 0; i < s.Count(); i++)
				{
					w[i] = s[i];
				}
				foreach(int i in w)
				{
					r += i;
				}
				r = RoundOff(r);
				return String.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(value)).Select(item => item.ToString(r.ToString())));
			}
        } 
        public static int RoundOff (this int i)
		{
        return ((int)Math.Round(i / 10.0)) * 10;
		}
	}
}
//Po twojej pysznej zupie nie ruszam dupy z klopa
