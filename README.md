# PI-Encryption
#### Prerequisites: Install Wine (for Linux)
A VERY powerful encryption for the Raspberry Pi!  Use the '1' command to encrypt a message and the '2' command to decrypt a message 
I purposefully put no source code files because I don't want people to see how I made it. 
Currently Linux is only for file decryption (sorry Windows users)
### How to use:
1) Download from repo.
2) run "sudo chmod 744 /path/to/file" and replace /path/to/file with the filepath of the downloaded executable.
3) run the filepath of the executable in the terminal.
4) Have fun with encrypting and decrypting messages!

Once you run the executable by its filename, text should appear like the one below:
```
Commands:
1: Encrypt
2: Decrypt

**Enter Command:**
```

### How to encrypt text:
From the start:
1) Enter "1" into the prompt.
2) Enter "1" into the next prompt to select text encryption.
3) Enter the text you want to encrypt into the next prompt.
4) Green text should return out of the terminal - copy this text.  This is your encrypted text which can be decrypted later.
-----------------------------------------------------------------------------------------------------------
### How to encrypt a file
From the start:
1) Enter "1" into the prompt.
2) Enter "2" into the next prompt.
3) Enter the filepath of your text file.
4) Enter the directory you want your file to go to in the next propmt.
5) Enter the name of the encrypted file.
6) A warning should pop up warning you to remember the first five characters of your text file.  This is important as that will be used as the password for decrypting the encrypted file.
7) Press any key to continue.  Your file should be created in the directory that you specified.
-----------------------------------------------------------------------------------------------------------
### How to decrypt text
From the start:
1) Enter "2" into the prompt.
2) Enter "1" into the next prompt.
3) Select whether you want ASCII decryption with "1" or universal decryption with "2" into the prompt.  ASCII decryption is faster than universal decryption but will only decrypt ASCII characters while universal will decrypt universal characters (even unknown characters!).
4) Enter the encrypted text into the next prompt and hit enter.
5) You should see a progress bar somwhere on your screen stating how far the decrypting has gone as well as the decrypted text.  If any red question marks appear, that means there was an error in decryption.
-----------------------------------------------------------------------------------------------------------
### If you got an error after decrypting text
In this order:
1) Check if the text was copied and pasted correctly.
2) Try running it through the decryptor again.
3)  Try switching to universal decryption.
-----------------------------------------------------------------------------------------------------------
### How to decrypt a file - IN PROGRESS
1) Enter "2" into the prompt.
2) Enter "2" into the next prompt.
3) Enter the encrypted file's path.
4) Select whether you want ASCII decryption with "1" or universal decryption with "2" into the prompt.  ASCII decryption is faster than universal decryption but will only decrypt ASCII characters while universal will decrypt universal characters (even unknown characters!).
5) Once it is done decrypting, enter the first five characters in the file (not the title) into  the prompt.
