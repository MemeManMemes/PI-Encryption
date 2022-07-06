using System;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace crypt
{
	class hash
	{
		private static int Main()
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Commands:\n1: Encrypt\n2: Decrypt");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Note: copying and pasting is weird with this program so text decryption might not work first try\n");
			hwh:
			bool isfine = true;
			string[] ARRAY;
			string Hash = "";
			ushort jjjj = 0;
			Console.ForegroundColor = ConsoleColor.White;
			char[] CharArray = {};
			string hashed = "";
			List<string> list = new List<string>();
			List<Char> printableChars = new List<char>();
			bool w = false;
			ushort i = 0;
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
				CharArray = Console.ReadLine().ToCharArray();
				w = false;
				foreach (char item in CharArray)
				{
					if (w == false)
					{
				        hashed += hash.sha256_hash(CharArray[i].ToString()) + "1";
						i++;
						w = true;
					}
					
					else if (w == true)
					{
						hashed += hash.sha512_hash(CharArray[i].ToString()) + "1";
						i++;
						w = false;
					}
					else 
					{
						Console.Clear();
						Console.WriteLine("Something Went Wrong, Please Try Again");
						return 0;
					}
				}
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("\nOutput: \n");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(hashed + "\n");
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
					Console.Write("What would your encrypted file to be named?: ");
					string filename = Console.ReadLine();
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("WARNING!!! Please remember the first five characters of the file you wish to encrypt, as that will be used as the password to decrypt the file - Press ENTER to continue");
					Console.ReadKey();
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
				        file_encrypted += hash.sha256_hash(filechars[i].ToString()) + "1";
						i++;
						w = true;
					}
					
					else if (w == true)
					{
						file_encrypted += hash.sha512_hash(filechars[i].ToString()) + "1";
						i++;
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
				Console.Write("Would you like character support other than ASCII characters?\n1: Use only ASCII characters\n2: Use universal characters\n");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("Note: using the second option is for universal character decryption but will make decryption a lot slower\n");
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("\nCommand: ");
				string cow = Console.ReadLine();
				if (cow == "1")
				{
					for (int j = 0; j < 255; j++)
					{
						printableChars.Add(Convert.ToChar(j));
				    }
				}
				if (cow == "2")
				{
					for (int j = char.MinValue; j <= char.MaxValue; j++)
                    {
                    char c = Convert.ToChar(j);
                    if (!char.IsControl(c) && !char.IsSurrogate(c))
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
				w = false;
				while (Hash != "")
				{
					if (w == false)
					{
				      list.Add(Hash.Substring(0,64));
				      Hash = Hash.Remove(0,65);
				      w = true;
			        }
			        else if (w == true)
			        {
				      list.Add(Hash.Substring(0,128));
				      Hash = Hash.Remove(0,129);
				      w = false;
			        }
			    }
			    ARRAY = list.ToArray();
			    w = false;
				for (int iii = 0; iii < list.Count(); iii++)
				{
					foreach (char c in printableChars)
					{
						if (ARRAY[iii] == sha256_hash(c.ToString()).ToString() && w == false)
						{
							ARRAY[iii] = c.ToString();
							w = true;
							jjjj++;
							Console.Clear();
							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.WriteLine("Working...\n");
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write(" ");
							for (int rrr = 0; rrr < ARRAY.Count(); rrr++)
							{
							if (rrr < iii)
							{
								if (ARRAY[rrr].Length == 1)
								{
								Console.Write(ARRAY[rrr]);
							    }
							    else 
							    {
									Console.ForegroundColor = ConsoleColor.Red;
									Console.Write("?");
									Console.ForegroundColor = ConsoleColor.Green;
								}
							}
						    }
							Console.Write("\n");
							Console.ForegroundColor = ConsoleColor.White;
							Console.Write("[");
							Console.ForegroundColor = ConsoleColor.Green;
							for (int jj = 0; jj < jjjj - 1; jj++)
							{
								Console.Write("■");
							}
							Console.ForegroundColor = ConsoleColor.White;
							for (int jj = 0; jj < ARRAY.Count() - jjjj + 1; jj++)
							{
								Console.Write("*");
							}
							Console.Write("]");
						}
						
						if (ARRAY[iii] == sha512_hash(c.ToString()).ToString() && w == true)
						{
							ARRAY[iii] = c.ToString();
							w = false;
							jjjj++;
							Console.Clear();
							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.WriteLine("Working...\n");
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write(" ");
							for (int rrr = 0; rrr < ARRAY.Count(); rrr++)
							{
							if (rrr < iii)
							{
								if (ARRAY[rrr].Length == 1)
								{
								Console.Write(ARRAY[rrr]);
							    }
							    else 
							    {
									Console.ForegroundColor = ConsoleColor.Red;
									Console.Write("?");
									Console.ForegroundColor = ConsoleColor.Green;
								}
							}
						    }
							Console.Write("\n");
							Console.ForegroundColor = ConsoleColor.White;
							Console.Write("[");
							Console.ForegroundColor = ConsoleColor.Green;
							for (int jj = 0; jj < jjjj - 1; jj++)
							{
								Console.Write("■");
							}
							Console.ForegroundColor = ConsoleColor.White;
							for (int jj = 0; jj < ARRAY.Count() - jjjj + 1; jj++)
							{
								Console.Write("*");
							}
							Console.Write("]");
						}
				    }
				Console.ForegroundColor = ConsoleColor.DarkGreen;
			    if (iii + 1 == ARRAY.Count())
			    {
					foreach (string s in ARRAY)
					{
						Console.Clear();
						if (s.Length != 1 || isfine == false)
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine("(ERRORS DETECTED) Decrypted message:");
							Console.ForegroundColor = ConsoleColor.Red;
							for (int ggg = 0; ggg < ARRAY.Count(); ggg++)
							{
								Console.Write(ARRAY[ggg]);
							}
							isfine = false;
						}
						if (isfine == true)
						{
							Console.WriteLine("(Complete!) Decrypted Message:");
							Console.ForegroundColor = ConsoleColor.Green;
							for (int ggg = 0; ggg < ARRAY.Count(); ggg++)
							{
							Console.Write(ARRAY[ggg]);
							}
						}
					}
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("\nIf there were any errors, try running it through the program again or switch to all character decryption");
				}
				Console.ForegroundColor = ConsoleColor.Green;
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
				Console.Write("Would you like character support other than ASCII characters?\n1: Use only ASCII characters\n2: Use universal characters\n\nCommand:");
				string moo = Console.ReadLine();
				if (moo == "2")
				{
					for (int j = char.MinValue; j <= char.MaxValue; j++)
                    {
						char c = Convert.ToChar(j);
						if (!char.IsControl(c) && !char.IsSurrogate(c))
						{
							printableChars.Add(c);
						}
                    }
				}
                    
				
				if (moo == "1")
				{
					for (int j = 0; j < 255; j++)
					{
						printableChars.Add(Convert.ToChar(j));
				    }
				}
                     w = false;
                     char[] filebytes = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(filepath)).ToCharArray();
                     string filepass = "";
                     List<string> filetext = new List<string>();
                     for (int x = 0; x < filebytes.Count(); x++)
                     {
						filepass += filebytes[x];
				     }
                     while (filepass != "")
				     {
						 if (w == false)
						 {
							 filetext.Add(filepass.Substring(0,64));
				             filepass = filepass.Remove(0,65);
				             w = true;
						 }
						 else if (w == true)
						 {
							 filetext.Add(filepass.Substring(0,128));
							 filepass = filepass.Remove(0,129);
							 w = false;
						 }
					 }
					 i = 0;
					 w = false;
					 ARRAY = filetext.ToArray();
					 foreach (char c in printableChars)
					 {
						 for (int iii = 0; iii < filetext.Count(); iii++)
						 {
							if (ARRAY[iii] == sha256_hash(c.ToString()).ToString())
							{
								ARRAY[iii] = c.ToString();
							jjjj++;
							Console.Clear();
							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.WriteLine("Working...\n");
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write("\n");
							Console.ForegroundColor = ConsoleColor.White;
							Console.Write("[");
							Console.ForegroundColor = ConsoleColor.Green;
							if (iii < ARRAY.Count())
							{
							for (int jj = 0; jj < jjjj - 1; jj++)
							{
								Console.Write("■");
							}
							Console.ForegroundColor = ConsoleColor.White;
							for (int jj = 0; jj < ARRAY.Count() - jjjj + 1; jj++)
							{
								Console.Write("*");
							}
							Console.Write("]");
							}
							}
							if (ARRAY[iii] == sha512_hash(c.ToString()).ToString())
							{
							ARRAY[iii] = c.ToString();
							jjjj++;
							Console.Clear();
							Console.ForegroundColor = ConsoleColor.Cyan;
							Console.WriteLine("Working...\n");
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write("\n");
							Console.ForegroundColor = ConsoleColor.White;
							Console.Write("[");
							Console.ForegroundColor = ConsoleColor.Green;
							if (iii + 1 < ARRAY.Count())
							{
							for (int jj = 0; jj < jjjj - 1; jj++)
							{
								Console.Write("■");
							}
							Console.ForegroundColor = ConsoleColor.White;
							for (int jj = 0; jj < ARRAY.Count() - jjjj + 1; jj++)
							{
								Console.Write("*");
							}
							Console.Write("]");
							}
						    }
						 }
					 }
					 Console.Clear();
					 Console.Write("Password: (Not the title) What are the first five characters in the file you wish to decrypt?: ");
					 string PASS = Console.ReadLine();
					 string pencil = "";
					 for (int s = 0; s < 5; s++)
					 {
						 pencil += ARRAY[s];
					 }
					 if (PASS == pencil)
					 {
						 Console.ForegroundColor = ConsoleColor.Green;
						 Console.WriteLine("Password is correct");
						 Console.WriteLine("Contents of file:");
						 Console.ForegroundColor = ConsoleColor.White;
						 foreach (string gh in ARRAY)
						 {
							 Console.Write(gh);
						 }
					 }
					 else
					 {
						 Console.ForegroundColor = ConsoleColor.Red;
						 Console.WriteLine("Password is incorrect");
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
            return String.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(value)).Select(item => item.ToString("x2")));
          }
        } 
        
        public static String sha512_hash(String value) 
		{
          using (SHA512 hash = SHA512Managed.Create()) 
          {
            return String.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(value)).Select(item => item.ToString("x2")));
          }
        } 
			}
			
		   }
//Po twojej pysznej zupie nie ruszam dupy z klopa

