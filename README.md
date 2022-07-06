# PI-Encryption
#### Prerequisites: Install Wine (for Linux)
A editable encryption for the Raspberry Pi!  Use the '1' command to encrypt a message and the '2' command to decrypt a message
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
5) Once it is done decrypting, enter the first five characters in the file (not the title) into the prompt as a password.
---
fcb5f40df9be6bae66c1d77a6c15968866a9e6cbd7314ca432b019d17392f6f412241bc8fc70705b42efead371fd4982c5ba69917e5b4b895810002644f0386da9c3131793458c2bf47608480d64a07278133c99912e0ba2daf23098f3520eb971a1fce4363854ff888cff4b8e7875d600c2682390412a8cf79b37d0b11148b0fa1f90ddd77e400dfe6a3fcf479b00b1ee29e7015c5bb8cd70f5f15b4886cc339275ff553fc8a053f8ddc7324f45168cffaf81f8c3ac93996f6536eef38e5e407681ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb1a882f0ac848b0b6b4ca7b42bfa1d266afd0ddeba9204ae57a984a69376d59816b1ef3f4d442ea8a70396067ff5b70e0ae8eab3935b617b8e366d8e35c3bfe14c13f79bb7b435b05321651daefd374cdc681dc06faa65e374e38337b88ca046dea1f90ddd77e400dfe6a3fcf479b00b1ee29e7015c5bb8cd70f5f15b4886cc339275ff553fc8a053f8ddc7324f45168cffaf81f8c3ac93996f6536eef38e5e407681a1fce4363854ff888cff4b8e7875d600c2682390412a8cf79b37d0b11148b0fa1cded74740d4bbfd4eb126d6de454b59e2d631f36c0ae0d2325b5e2be4da2befe792106b98422ad24c092e8f184b2ff4be0bbbcdcd278db6c2427533b2e9264d110bfe935e70c321c7ca3afc75ce0d0ca2f98b5422e008bb31c00c6d7f1f1c0ad61f90ddd77e400dfe6a3fcf479b00b1ee29e7015c5bb8cd70f5f15b4886cc339275ff553fc8a053f8ddc7324f45168cffaf81f8c3ac93996f6536eef38e5e40768118ac3e7343f016890c510e93f935261169d9e3f565436429830faf0934f4f8e41cded74740d4bbfd4eb126d6de454b59e2d631f36c0ae0d2325b5e2be4da2befe792106b98422ad24c092e8f184b2ff4be0bbbcdcd278db6c2427533b2e9264d1150e721e49c013f00c62cf59f2163542a9d8df02464efeb615d31051b0fddc3261917148ec47923f2e0e3d73142ac4f94ec4c73078865ba6d29f0ea172cd6f4bf34db699af5c33535d3694d4aef91a11f916004d0382f794448a8550623d34c985136a9e7f1c95b82ffb99743e0c5c4ce95d83c9a430aac59f84ef3cbfab614506812241bc8fc70705b42efead371fd4982c5ba69917e5b4b895810002644f0386da9c3131793458c2bf47608480d64a07278133c99912e0ba2daf23098f3520eb9713f79bb7b435b05321651daefd374cdc681dc06faa65e374e38337b88ca046dea1a882f0ac848b0b6b4ca7b42bfa1d266afd0ddeba9204ae57a984a69376d59816b1ef3f4d442ea8a70396067ff5b70e0ae8eab3935b617b8e366d8e35c3bfe14c13f79bb7b435b05321651daefd374cdc681dc06faa65e374e38337b88ca046dea1ca63c07ad35d8c9fb0c92d6146759b122d4ec5d3f67ebe2f30ddb69f9e6c9fd3bf31a5e408b08f1d4d9cd68120cced9e57f010bef3cde97653fed5470da7d1a01
